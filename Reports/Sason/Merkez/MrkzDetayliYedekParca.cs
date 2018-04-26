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

            #region eskisql
            /*
                          List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
                                SELECT DISTINCT   
                                    AYRISTIRMATIPAD ,
                                    BELGENO,
                                    BELGETURU,
                                    BRUTTUTAR,
                                    HASHSERVISID ,
                                    INDIRIMORAN,
                                    ISCILIK_PARCA,
                                    ISEMIRTIPI,
                                    KUR,
                                    MALZEMEAD,
                                    MALZEMEKOD,
                                    MIKTAR,
                                    MUSTERIAD,
                                    ORJINALKOD,
                                    ORTALAMAMALIYET,
                                    SASENO,
                                    SERVISAD,
                                    SERVISID,
                                    SERVISSTOKTURAD,
                                    TARIH,
                                     to_char(TRAFIGECIKISTARIHI,'dd/mm/yyyy') as TRAFIGECIKISTARIHI,
                                    TUTAR,
                                    URETICI,
                                    VERGINO,
                                    SERVISSTOKTURID, 
                                        {{startDate}} as bastar , 
                                        {{finishDate}} as bittar   
                                FROM sason.rptable_yedekparcadetay 
                                WHERE tarih BETWEEN  {{startDate}} and {{finishDate}} AND
                                SERVISID   {servisIdQuery}  
                                 order by SERVISAD , TARIH, belgeno,malzemekod, musteriad  

                            ")
                            .Parameter("startDate", StartDate.startOfDay())
                            .Parameter("finishDate", FinishDate.endOfDay())
                            .GetDataTable(mr)
                            .ToModels();

                */
            #endregion 

            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 

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
                          KURLAR_PKG.SERVISSTOKFIYATGETIR (f.servisstokid,
                                                           a.parabirimid,
                                                           a.tarih)
                             bruttutar, 
                          B.BIRIMFIYAT TUTAR,
                          C.SASENO,
                          '' TRAFIGECIKISTARIHI,
                          KURLAR_PKG.ORTALAMAMALIYET (f.servisstokid) ortalamamaliyet,
                          '' ayristirmatipad,
                         ROUND (
                             ( (KURLAR_PKG.SERVISSTOKFIYATGETIR (f.servisstokid,
                                                                 a.parabirimid,
                                                                 a.tarih))),
                             2)
                             fiyat2,
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
                          mt_malzemeler d,  
                          vt_servisstoklar f,
                          vt_servisler g,
                          vt_servisvarliklar h
                    WHERE     A.ID = b.servissiparisid
                          AND B.ISEMRINO = C.ISEMIRNO(+)
                          AND B.MALZEMEID = D.MALZEMEID(+)
                          AND siparisservisid <> '1'
                          AND f.servisstokid(+) = b.servisstokid
                          AND a.servisid = g.servisid(+)
                          AND A.SERVISVARLIKID = h.servisvarlikid(+)
                          AND (f.dilkod = d.dilkod OR d.dilkod IS NULL)
                          AND (f.dilkod = g.dilkod OR g.dilkod IS NULL)
                          AND (f.dilkod = h.dilkod OR h.dilkod IS NULL)
                          AND f.dilkod = 'Turkish'    
                          and a.siparisservisid  {servisIdQuery}   
                          and a.tarih between '{dateQuery}'

                       UNION ALL

                       SELECT r.servisid,
                              sason.hashservisid (r.servisid) hashservisid,
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
                              to_char(r.FIRSTREGDATE,'dd/mm/yyyy') as TRAFIGECIKISTARIHI,
                              r.ortalamamaliyet, 
                              r.ayristirmatipad, 
                              r.indirimoran, 
                              r.kur, 
                              servisstokturid,
                              r.SERVISSTOKTURID ,
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
                              CASE
                                 WHEN    (a.ayristirmatipid IN (1) AND d.faturaid IS NOT NULL)
                                      OR a.claimstatus IN ('Z057', 'Z060', 'Z070', 'Z0110')
                                 THEN
                                    'TAMAMLANMIS'
                                 ELSE
                                    'DEVAM EDIYOR'
                              END
                                 DURUM,
                              St.AD SERVISSTOKTURad,
                              CASE WHEN ss.ureticivarlikid IS NULL THEN 'MAN' ELSE O1.AD END
                                 uretici,
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
                              KURLAR_PKG.CAPRAZKURTARIH (2, 1, ic.icmaltarihi) icmalkur,
                              servisstokturid,
          
                              ss. id as servisstokid                                 
                         FROM servisisemirislemler r,
                              servisicmaller ic,
                              ayristirmadetaylar d,
                              ayristirmalar a,
                              ayristirmatipler tr,
                              servisisemirler i,
                              faturalar f,
                              vw_servisstokturler st,
                              sason.rp_isemirdetay t,
                              servisstoklar ss,
                              varliklar o1,
                              servisvarliklar o2,
                              isortaklar o3,
                              servisler sv
                        WHERE     d.ayristirmaid = a.id
                              AND a.isemirno = i.isemirno
                              AND a.ayristirmatipid = tr.id
                              AND a.durumid = 1
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
                        r.malzemekod = o.gkod(+) and
                        r.servisid  {servisIdQuery}  AND 
                        r.KAYITTARIH between '{dateQuery}'
                     
                ")
              .GetDataTable(mr)
              .ToModels();

            CloseCustomAppPool();
            return queryResults;
        }

    }
}