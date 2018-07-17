using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SasonBase.Reports.Sason.Merkez
{
    /// <summary>
    /// Merkez Yedek Parça Faaliyet Raporu
    /// </summary>
    public class MrkzDetayliYedekParca : Base.SasonMerkezReporter
    {
        public MrkzDetayliYedekParca()
        {
            Text = "Detaylı Yedek Parça Raporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            Disabled = false;
        }

        public DateTime StartDate
        {
            get { return GetParameter("param_start_date").ReporterValue.cast<DateTime>(); }
            set { SetParameterReporterValue("param_start_date", value.startOfDay()); }
        }

        public DateTime FinishDate
        {
            get { return GetParameter("param_finish_date").ReporterValue.cast<DateTime>(); }
            set { SetParameterReporterValue("param_finish_date", value.endOfDay()); }
        }

        public List<decimal> ServisIds
        {
            get { return GetParameter("param_servisler").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_servisler", value); }
        }

        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {
                //Dışarıdan Gelen Format 20171231235959 Şeklinde Olmalıdır
                case "param_start_date":
                    StartDate = Convert.ToInt64(value).toDateTime();
                    break;
                case "param_finish_date":
                    FinishDate = Convert.ToInt64(value).toDateTime();
                    break;
                case "param_servisler":
                    ServisIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            decimal selectedServisId = ServisIds.first().toString("0").cto<decimal>();
            string servisIdQuery = $" = {selectedServisId}";
            string dateQuery = "";

  
            if (ServisIds.isNotEmpty())
                servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            else
            {
                //    servisIdQuery = $" > 1 ";
                selectedServisId = ServisId;
                servisIdQuery = $" in( {selectedServisId} )";
            }


            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";

         

            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 

                SELECT  DISTINCT
                    SERVISID  ,
                    SIPARISSERVISID  HASHSERVISID,  
                    (SELECT isortakad
                       FROM vt_servisler
                      WHERE servisid = siparisservisid AND dilkod = 'Turkish')  servisad,
                    TARIH  ,
                    BELGENO   ,
                    BELGETURU  ,
                    ISEMIRTIPI ,
                    ISEMIRTIPID ,
                    VERGINO  ,
                    MUSTERIAD  ,
                    FATURATARIHI   ,
                    CLAIMSTATUS  ,
                    MALZEMEKOD  ,
                    ORJINALKOD ,
                    URETICI   ,
                    SERVISSTOKTURAD  ,
                    ISCILIK_PARCA  ,
                    MALZEMEAD  ,
                    MIKTAR  ,
                    BRUTTUTAR  ,
                    MIKTAR * TUTAR  TUTAR,
                    SASENO  ,
                    OZELSATISSASENOLAR  , 
                    to_char(TRAFIGECIKISTARIHI,'dd/mm/yyyy') TRAFIGECIKISTARIHI, 
                    KURLAR_PKG.ORTALAMAMALIYET (ORTALAMAMALIYET) ortalamamaliyet,
                    AYRISTIRMATIPAD  ,
                    FIYAT2  ,
                    to_char(KUR) KUR,
                    SERVISSTOKID  ,
                    SERVISSTOKTURID ,
                    EUROINDFIYAT ,  
                     kurlar_pkg.servisstokfiyatgetir (EUROLISTEFIYAT, 2, TRUNC (SYSDATE)) EUROLISTEFIYAT 
                FROM sason.ypdata     
                WHERE  
                    YEDEKPARCARAPORTARIHI  between '{dateQuery}' and 
                    SIPARISSERVISID {servisIdQuery}     

                union all


                      SELECT
                        CASE
                             WHEN a.servisid IS NULL THEN a.siparisservisid
                             ELSE a.servisid
                          END
                             servisid,
                            a.siparisservisid HASHSERVISID,
                          CASE
                             WHEN (   a.servisid IS NULL
                                   OR a.servisid = 1
                                   OR (NVL (a.servisid, 1) <> 1
                                       AND NVL (a.siparisservisid, 1) <> 1))
                             THEN
                                (SELECT isortakad
                                   FROM vt_servisler
                                  WHERE servisid = siparisservisid AND dilkod = 'Turkish')
                             ELSE
                                g.isortakad
                          END
                             servisad,
                          A.tarih,
                          a.belgeno,
                          CASE
                             WHEN A.SERVISVARLIKID IS NULL AND siparisservisid IS NULL
                             THEN
                                'İş Emri'
                             ELSE
                                'Direk Satış'
                          END
                             belgeturu,
                          NULL isemirtipi,
                          NULL ISEMIRTIPID,
                          h.vergino,
                          CASE
                             WHEN a.servisvarlikid IS NOT NULL
                             THEN
                                h.ad
                             ELSE
                                (SELECT MAX (isortakad)
                                   FROM vt_servisler
                                  WHERE servisid = a.servisid AND dilkod = 'Turkish')
                          END
                             musteriad,
                          fxxx.ISLEMTARIHI faturatarihi,
                          '' claimstatus,
                          f.KOD malzemekod,
                          CASE
                             WHEN (SELECT orjinalmalzemeid
                                     FROM malzemeler
                                    WHERE id = f.malzemeid)
                                     IS NULL
                             THEN
                                ''          -- f.kod
                             ELSE
                                (SELECT CONCAT ('', gkod)
                                   FROM malzemeler
                                  WHERE id = (SELECT orjinalmalzemeid
                                                FROM malzemeler
                                               WHERE id = f.malzemeid))
                          END
                             orjinalkod,
                          CASE
                             WHEN b.servisekmaliyetid IS NOT NULL THEN '-- '
                             WHEN f.SERVISSTOKTURID = 1 THEN 'MAN'
                             ELSE f.ureticivarlikad
                          END
                             uretici,
                          F.SERVISSTOKTURAD,
                          CASE
                             WHEN b.servisekmaliyetid IS NOT NULL THEN 'Işçilik'
                             ELSE 'Malzeme'
                          END
                             iscilik_parca,
                          F.AD malzemead,
                          b.miktar,
                         CASE
                                  WHEN (a.tarih > sysdate) then  KURLAR_PKG.SERVISSTOKFIYATGETIR (f.servisstokid, a.parabirimid, sysdate)
                                  WHEN (a.tarih is null  ) then  null
                                  ELSE  KURLAR_PKG.SERVISSTOKFIYATGETIR (f.servisstokid, a.parabirimid, a.tarih) END bruttutar,
                          B.BIRIMFIYAT TUTAR,
                          C.SASENO,
                            (
                           select
                                LISTAGG(SASENO,', ') WITHIN GROUP (ORDER BY SERVISSIPARISID , MALZEMEID ASC)  saseno
                            from servissiparissaseler
                            where SERVISSIPARISID = A.ID  AND
                            MALZEMEID = f.malzemeid
                          ) OZELSATISSASENOLAR,

                          '' TRAFIGECIKISTARIHI,
                          KURLAR_PKG.ORTALAMAMALIYET (f.servisstokid) ortalamamaliyet,
                          '' ayristirmatipad,
                         ROUND (
                             ( (

                          CASE
                                      WHEN (a.tarih > sysdate) then  KURLAR_PKG.SERVISSTOKFIYATGETIR (f.servisstokid,  a.parabirimid, sysdate)
                                      WHEN (a.tarih is null  ) then  null
                                      ELSE KURLAR_PKG.SERVISSTOKFIYATGETIR (f.servisstokid,  a.parabirimid, a.tarih) end
                            )),2)  fiyat2,
                           TO_CHAR (kurlar_pkg.CaprazKurTarih (2, a.parabirimid, a.tarih)) kur,
                           f.servisstokid,
                          f.SERVISSTOKTURID ,
                          KURLAR_PKG.STOKFIYATINDGETIR (f.servisstokid,
                                                        2,
                                                        2,
                                                        1,
                                                        0)
                             EUROINDFIYAT,
                          kurlar_pkg.servisstokfiyatgetir (f.servisstokid, 2, TRUNC (SYSDATE)) EUROLISTEFIYAT
                    FROM servissiparisler a,
                          servissiparismlzler b,
                          servisisemirler c,

                    (

                       SELECT s.id SERVISSTOKID,
                              s.KOD,
                              s.AD,
                              s.servisstokturid,
                              t.ad SERVISSTOKTURAD,
                              s.servisstokgrupid,
                              S.BIRIMID,
                              s.URETICIVARLIKID,
                              V1.AD URETICIVARLIKAD,
                              s.malzemeid,
                              M.AD MALZEMEAD,
                              S.SERVISDEPOID,
                              s.servisdeporafid,
                              s.DURUMID,
                              s.SERVISID,
                              t.DILKOD
                         FROM servisstoklar s,
                              vw_servisstokturler t,
                              vw_servisstoksiniflar a,
                              varliklar v1,
                              (
                                  SELECT t.ID,
                              CASE WHEN c.DEGER IS NULL THEN t.KOD ELSE c.DEGER END AD ,
                              dilkod
                         FROM (SELECT t.id, t.KOD,
                                      d.id dilid,
                                      d.kod dilkod,
                                      a.id listealanid
                                 FROM diller d,
                                      malzemeler t,
                                      listeler l,
                                      listealanlar a
                                WHERE
                                        l.kod = 'MALZEMELER'
                                      AND a.listeid = l.id
                                      AND a.kod = 'AD') t,
                              ceviriler c
                        WHERE     c.listealanid(+) = t.listealanid
                              AND c.dilid(+) = t.dilid
                              AND c.alanid(+) = t.id
                              AND t.dilkod = 'Turkish'
                              ) m
                        WHERE     S.SERVISSTOKTURID = t.id(+)
                              AND s.servisstoksinifid = a.id(+)
                              AND S.URETICIVARLIKID = v1.id(+)
                              AND s.malzemeid = m.id(+)
                              AND (t.dilkod = a.dilkod OR a.dilkod IS NULL)
                              AND (t.dilkod = m.dilkod OR m.dilkod IS NULL)
                              AND (t.dilkod = t.dilkod OR t.dilkod IS NULL)
                                AND t.dilkod ='Turkish'

                        ) f,

                    (
                      SELECT S.ID SERVISID,
                              i.ID ISORTAKID,
                              i.AD ISORTAKAD,
                              S.DURUMID
                         FROM SERVISLER S,
                              isortaklar i
                        WHERE   S.DURUMID =1 AND
                                s.isortakid = i.id
                    ) g,

                        (
                           SELECT s.ID SERVISVARLIKID,
                                  s.VERGINO,
                                  s.SERVISID,
                                  CASE WHEN k.ID IS NOT NULL THEN k.AD ELSE s.AD END AD
                             FROM servisvarliklar s,
                                  varliklar k
                            WHERE
                                s.vergino = k.vergino(+)
                           UNION
                           SELECT NULL SERVISVARLIKID,
                                  s.VERGINO,
                                  NULL SERVISID,
                                  s.AD
                             FROM varliklar s
                             WHERE s.vergino IS NULL

                        ) h,

                            --  faturalar fxx,
                            (SELECT
                             fx.id,
                             fx.VNO,
                             fx.faturano,
                             fx.ISLEMTARIHI,
                             fx.isemirno
                            FROM faturalar fx
                            WHERE   TO_DATE(FX.ISLEMTARIHI,'DD/MM/YYYY')   = TO_DATE(sysdate,'DD/MM/YYYY')
                            and fx.faturaturid=3 and fx.servisid  {servisIdQuery}   and fx.durumid=1 
                             ) fxxx

                    WHERE     A.ID = b.servissiparisid
                          AND B.ISEMRINO = C.ISEMIRNO(+)
                          AND siparisservisid <> '1'
                          AND f.servisstokid(+) = b.servisstokid
                          AND a.servisid = g.servisid(+)
                          AND A.SERVISVARLIKID = h.servisvarlikid(+)
                          and a.siparisservisid   {servisIdQuery}    
                          and b.servisekmaliyetid IS NULL
                       --   and a.tarih between '10.06.2018' AND '18.06.2018'

                          AND fxxx.id = b.faturaid
                          and b.faturaid in (SELECT
                             fx.id
                            FROM faturalar fx
                            WHERE  TO_DATE( FX.ISLEMTARIHI ,'DD/MM/YYYY')   = TO_DATE(sysdate,'DD/MM/YYYY')
                            and fx.faturaturid=3 and fx.servisid {servisIdQuery}      and fx.durumid=1
                            )
                            and b.servisstokid in

                      ( SELECT sx.id
                         FROM servisstoklar sx
                            where
                                sx.servisid {servisIdQuery}      and
                                sx.kod in
                                (select distinct stokkod from faturadetaylar
                                where faturaid in (select id from faturalar
                                                where
                                                    faturaturid=3 and
                                                    TO_DATE( islemtarihi,'DD/MM/YYYY')    = TO_DATE(sysdate,'DD/MM/YYYY')  and
                                                    servisid  {servisIdQuery}     and
                                                    durumid=1))
                        )
                       UNION ALL

                     SELECT r.servisid,
                              r.servisid hashservisid,
                              r.isortakad servisad,
                              r.KAYITTARIH tarih,
                              r.isemirno belgeno,
                              'İş Emri' belgeturu,
                              CASE
                                 WHEN r.ISEMIRTIPID = 1 THEN 'BAKIM'
                                 WHEN r.ISEMIRTIPID = 2 THEN 'AKSİYON'
                                 WHEN r.ISEMIRTIPID = 3 THEN 'ONARIM'
                                 WHEN r.ISEMIRTIPID = 4 THEN 'KAZALI ARAÇ'
                                 WHEN r.ISEMIRTIPID = 5 THEN 'BAKIM-EURO 6C'
                                 WHEN r.ISEMIRTIPID = 6 THEN '2. EL ONARIM'
                              END
                                 isemirtipi,
                              r.ISEMIRTIPID,
                              r.vergino,
                              r.ad musteriad,
                              r.faturatarihi,
                              r.claimstatus,
                              r.malzemekod,
                              CASE WHEN o.orjinalgkod IS NULL THEN '' ELSE o.orjinalgkod END orjinalkod,
                              --r.orjinalkod,
                              r.uretici,
                              r.servisstokturad,
                              b.ack iscilik_parca,
                              r.malzemead,
                              r.miktar,
                              r.bruttutar,
                              r.tutar,
                              r.saseno,
                              '' OZELSATISSASENOLAR,
                              to_char(r.FIRSTREGDATE,'dd/mm/yyyy') as TRAFIGECIKISTARIHI,
                              r.ortalamamaliyet,
                              r.ayristirmatipad,
                              r.indirimoran,
                              r.kur,
                              r.servisstokid ,
                              servisstokturid,

                              KURLAR_PKG.STOKFIYATINDGETIR (r.servisstokid,
                                                        2,
                                                        2,
                                                        1,
                                                        0)
                             EUROINDFIYAT,
                          kurlar_pkg.servisstokfiyatgetir (r.servisstokid, 2, TRUNC (SYSDATE)) EUROLISTEFIYAT
                         FROM      -- sason.rp_isemirler r, sason.lovturler b,(SELECT m1.id malzemeid,
                         (
                       SELECT a.durumid,
                              o3.ad ISORTAKAD,
                              d.id,
                              a.servisid,
                              sason.hashservisid (i.servisid) hashservisid,
                              f.faturano,
                              a.isemirno,
                              r.sirano,
                              tr.kod ayristirmatipad,
                              f.ISLEMTARIHI faturatarihi,
                              t.kod malzemekod,
                              t.ad malzemead,
                              D.TURID,
                              a.arizakodu,
                              I.TAMAMLANMATARIH,
                              I.KAYITTARIH,
                              I.KM,
                              I.KUR,
                              i.aractipad,
                              i.modelno,
                              i.firstregdate,
                              T.TUTAR isemirtutar,
                              i.saseno,
                              R.ISEMIRTIPID,
                              A.PDFKDV,
                              A.PDFONAYGENELTOPLAM,
                              A.PDFMATRAH,
                              O2.AD,
                              a.claimstatus,
                              d.faturaid,
                              T.MIKTAR,
                              T.TUTAR,
                              T.BRUTTUTAR, 
                              St.AD SERVISSTOKTURad,
                              CASE
                                WHEN st.id = 1 THEN 'MAN'
                                WHEN ss.ureticivarlikid IS NOT NULL THEN O1.AD
                                ELSE ''  END uretici,
                              d.atutar,
                              D.PDFISLETIMUCRETI,
                              D.PDFITEMID,
                              D.PDFTOPLAM,
                              F.VNO vergino,
                              orjinalkod,
                              KURLAR_PKG.ORTALAMAMALIYET (ss.id) ortalamamaliyet,
                              ROUND (
                                   (  1
                                    -   t.tutar
                                      / CASE WHEN t.bruttutar = 0 THEN NULL ELSE t.bruttutar END)
                                 * 100,
                                 2)
                                 indirimoran,
                              IC.TFATTOPLAM,
                              IC.ICMALTARIHI,
                              CASE
                                  WHEN (ic.icmaltarihi > sysdate) then  KURLAR_PKG.CAPRAZKURTARIH (2, 1, sysdate)
                                  WHEN (ic.icmaltarihi is null  ) then  null
                                  ELSE  KURLAR_PKG.CAPRAZKURTARIH (2, 1, ic.icmaltarihi) END icmalkur,
                              servisstokturid,
                              ss. id as servisstokid
                         FROM servisisemirislemler r,
                            --  servisicmaller ic,
                              (SELECT
                                six.id ,
                                six.icmaltarihi,
                                six.TFATTOPLAM
                              FROM servisicmaller six
                                ) ic ,
                            --  ayristirmadetaylar d,
                              (SELECT
                                dx.id,
                                dx.TURID,
                                dx.faturaid,
                                dx.ayristirmaid,
                                dx.referansid,
                                dx.atutar,
                                dx.PDFISLETIMUCRETI,
                                dx.PDFITEMID,
                                dx.PDFTOPLAM
                              FROM ayristirmadetaylar dx
                              ) d,
                           --   ayristirmalar a,
                           (SELECT
                              ax.id,
                              ax.servisisemirislemid,
                              ax.PDFKDV,
                              ax.PDFONAYGENELTOPLAM,
                              ax.PDFMATRAH,
                              ax.claimstatus,
                              ax.isemirno,
                              ax.ayristirmatipid,
                              ax.durumid,
                              ax.ICMALID,
                              ax.servisid,
                              ax.arizakodu
                           FROM ayristirmalar ax
                           WHERE ax.durumid = 1
                             AND ax.servisid  {servisIdQuery}    
                           ) a,
                              ayristirmatipler tr,
                              -- servisisemirler i,
                              (SELECT
                                ix.servisid,
                                ix.SERVISVARLIKID,
                                ix.isemirno,
                                ix.KAYITTARIH,
                                ix.TAMAMLANMATARIH,
                                ix.KM,
                                ix.KUR,
                                ix.aractipad,
                                ix.modelno,
                                ix.firstregdate,
                                ix.saseno
                              FROM servisisemirler ix
                              WHERE   
                                ix.servisid {servisIdQuery}    
                              ) i,

                            --  faturalar f,
                            (SELECT
                             fx.id,
                             fx.VNO,
                             fx.faturano,
                             fx.ISLEMTARIHI
                            FROM faturalar fx
                            WHERE  
                                fx.faturaturid=1 and fx.servisid {servisIdQuery}      and fx.durumid=1   
                             )f,
                              vw_servisstokturler st,
                          --     sason.rp_isemirdetay t,
                              (
                               SELECT z.id servisisemirid,
                                  I.ID servisisemirislemid,
                                  m.id referansid,
                                  m.miktar,
                                  'MALZEME' TUR,
                                  m.tutar bruttutar,
                                  m.indirimlitutar tutar,

                                  s.kod,
                                  s.ad,
                                  z.servisid,
                                  1 turid,
                                  isemirno,
                                    CASE WHEN o.orjinalgkod IS NULL THEN s.kod ELSE o.orjinalgkod END
                                     orjinalkod
                             FROM servisisemirislemler i,
                                  servisismislemmalzemeler m,
                                   (SELECT m1.id malzemeid,
                                          m1.kod,
                                          m1.gkod,
                                          m2.kod orjinalkod,
                                          m2.gkod orjinalgkod,
                                          m1.orjinalmalzemeid
                                     FROM malzemeler m1, malzemeler m2
                                    WHERE m1.orjinalmalzemeid = M2.ID) o,
                                  servisstoklar s, --
                                  servisisemirler z
                            WHERE     i.id = M.SERVISISEMIRISLEMID
                                  AND s.id = m.servisstokid
                                  AND z.id = i.servisisemirid
                                  AND s.malzemeid = o.malzemeid(+)
                                  AND (m.kendigetirdi <> 1 OR m.kendigetirdi IS NULL)
                                  AND (m.disaridayaptirdi <> 1 OR m.disaridayaptirdi IS NULL)
                                  AND (m.bakimislemynedenid IS NULL)
                                  AND (   I.ISEMIRUYGULAMAMANEDENID IS NULL
                                       OR I.ISEMIRUYGULAMAMANEDENID = 8)
                                  AND m.durumid = 1
                                  AND m.kullanildi = 1
                                  AND z.servisid  {servisIdQuery}    
                                  AND  TO_DATE(z.TAMAMLANMATARIH ,'DD/MM/YYYY')  = TO_DATE(sysdate,'DD/MM/YYYY') 

                              ) t,


                              -- servisstoklar ss,
                              (SELECT
                                ssx.id,
                                ssx.servisid,
                                ssx.servisstokturid,
                                ssx.kod,
                                ssx.ureticivarlikid
                              FROM servisstoklar ssx
                              WHERE
                                ssx.durumid = 1 AND
                                ssx.servisid  {servisIdQuery}    
                              ) ss,
                             -- varliklar o1,
                             (SELECT
                                o1x.id,
                                o1x.ad
                             FROM varliklar o1x
                             ) o1,
                              -- servisvarliklar o2,
                              (SELECT
                                o2x.id,
                                o2x.ad
                              FROM servisvarliklar o2x
                              ) o2,
                          --    isortaklar o3,
                              (SELECT
                                o3x.id,
                                o3x.ad
                              FROM isortaklar o3x
                              ) o3,
                              -- servisler sv
                              (SELECT
                                svx.id,
                                svx.isortakid
                              FROM servisler svx
                              WHERE svx.id {servisIdQuery}    
                              ) sv
                        WHERE     d.ayristirmaid = a.id

                           AND
                             (  ((a.ayristirmatipid IN (1) AND d.faturaid IS NOT NULL AND
                             d.faturaid in (
                                SELECT distinct
                                                        fx.id
                                                        FROM faturalar fx
                                                        WHERE  
                                                         fx.faturaturid=1 and fx.servisid {servisIdQuery}   and fx.durumid=1

                             )




                             ) OR  a.claimstatus IN ( 'Z110'))
                             )

                              AND a.isemirno = i.isemirno
                              AND a.ayristirmatipid = tr.id
                              AND f.id(+) = d.faturaid
                              AND r.id = a.servisisemirislemid
                              AND T.REFERANSID = d.referansid
                              AND st.id(+) = ss.servisstokturid
                              AND t.turid = d.turid
                              AND ss.kod(+) = T.KOD
                              AND (ss.servisid = i.servisid OR ss.servisid IS NULL)
                              AND ss.ureticivarlikid = O1.ID(+)
                              AND I.SERVISVARLIKID = O2.id
                              AND sv.id = i.servisid
                              AND sv.isortakid = o3.id
                              AND st.dilkod = 'Turkish'
                              AND A.ICMALID = ic.id(+)
                                )
                                r,sason.lovturler b,(SELECT m1.id malzemeid,
                                      m1.kod,
                                      m1.gkod,
                                      m2.kod orjinalkod,
                                      m2.gkod orjinalgkod,
                                      m1.orjinalmalzemeid
                                 FROM malzemeler m1, malzemeler m2
                                WHERE m1.orjinalmalzemeid = M2.ID) o
                        WHERE r.turid = b.id and
                        r.malzemekod = o.gkod(+)
 
                     
                ")
              .GetDataTable(mr)
              .ToModels();

            CloseCustomAppPool();
            return queryResults;
        }

    }
}