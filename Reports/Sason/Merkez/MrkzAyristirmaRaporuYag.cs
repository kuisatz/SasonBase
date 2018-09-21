using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SasonBase.Reports.Sason.Merkez
{
    /// <summary>
    /// Merkez Yedek Parça Faaliyet Raporu
    /// </summary>
    public class MrkzAyristirmaRaporuYag : Base.SasonMerkezReporter
    {
        public MrkzAyristirmaRaporuYag()
        {
            Text = "[YP-12] Detaylı Ayrıştırma Raporu - Sadece Yağlar";
            SubjectCode = "MrkzAyristirmaRaporuYag";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            Disabled = false;
        }
        public MrkzAyristirmaRaporuYag(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
            this.StartDate = startDate;
            this.FinishDate = finishDate;
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
        public string SaseNo
        {
            get { return GetParameter("param_sase_no").ReporterValue.toString(); }
            set { SetParameterReporterValue("param_sase_no", value.toString()); }
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
                case "param_sase_no":
                    SaseNo = value.toString();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            decimal selectedServisId = ServisIds.first().toString("0").cto<decimal>();
            string servisIdQuery = $" = {selectedServisId}";
            string dateQuery = "";

#if DEBUG
             selectedServisId = ServisId;
              servisIdQuery = $" in( {selectedServisId} )";
#endif


            if (ServisIds.isNotEmpty())
                servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            else { 
            //    servisIdQuery = $" > 1 ";
                selectedServisId = ServisId;
                servisIdQuery = $" in( {selectedServisId} )";
            }


            StartDate = StartDate.startOfDay(); 
            FinishDate = FinishDate.endOfDay();
            dateQuery = ""+StartDate.ToString("dd/MM/yyyy") +  "' AND '"+ FinishDate.ToString("dd/MM/yyyy")+"";
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
               SELECT  distinct
                        (select vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = a.servisid  and vtsx.dilkod = 'Turkish') as partnercode,
                        a.durumid,
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
                        to_char(I.TAMAMLANMATARIH,'dd/mm/yyyy') as TAMAMLANMATARIH,
                        to_char(I.KAYITTARIH,'dd/mm/yyyy') as KAYITTARIH,
                        I.KM,
                        I.KUR,
                        i.aractipad,
                        i.modelno,                        
                        to_char(i.firstregdate,'dd/mm/yyyy') as firstregdate,
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
                        St.kod SERVISSTOKTURad,
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
                        to_char(IC.ICMALTARIHI,'dd/mm/yyyy') as ICMALTARIHI,                        
                        CASE  
                            WHEN (ic.icmaltarihi > sysdate) then  KURLAR_PKG.CAPRAZKURTARIH (2, 1, sysdate)
                            WHEN (ic.icmaltarihi is null  ) then  null
                            ELSE KURLAR_PKG.CAPRAZKURTARIH (2,  1d, ic.icmaltarihi) end
                            icmalkur,
                        servisstokturid,
                        Bx.KOD,
                        cx.ack ,
                        to_char(dx.ilktesciltarihi,'dd/mm/yyyy') as ilktesciltarihi,
                        '{StartDate}' as bastar, 
                        '{FinishDate}'  as bittar,
                        i.id as kyttarhidsi
                    FROM   servisisemirler i, servisisemirislemler r,
                        servisicmaller ic,
                        ayristirmadetaylar d,
                        ayristirmalar a,
                        ayristirmatipler tr,
                   /*  servisisemirler i, */
                        faturalar f,
                        servisstokturler st, 
 --     sason.rp_isemirdetay t,
                        (
                      SELECT z.id servisisemirid,
          I.ID servisisemirislemid,
          m.id referansid,
          m.miktar,--
          'MALZEME' TUR,
          m.tutar bruttutar, --
          m.indirimlitutar tutar,-- 
          s.kod,--
          s.ad,--
          z.servisid,
          Z.TAMAMLANMATARIH, 
          1 turid, --
           CASE WHEN o.orjinalgkod IS NULL THEN s.kod ELSE o.orjinalgkod END
             orjinalkod,
          isemirno --
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
          servisstoklar s, 
          servisisemirler z 
    WHERE     i.id = M.SERVISISEMIRISLEMID
          AND s.id = m.servisstokid 
          AND z.id = i.servisisemirid 
          AND (kendigetirdi <> 1 OR kendigetirdi IS NULL)
          AND (disaridayaptirdi <> 1 OR disaridayaptirdi IS NULL)
          AND s.malzemeid = o.malzemeid(+)
          AND (bakimislemynedenid IS NULL)
          AND (   I.ISEMIRUYGULAMAMANEDENID IS NULL
               OR I.ISEMIRUYGULAMAMANEDENID = 8)
          AND m.durumid = 1 
          AND kullanildi = 1
          and z.servisid   {servisIdQuery} 
          and z.KAYITTARIH between '{dateQuery}' 
      
   UNION ALL
   SELECT z.id servisisemirid,
          i.id servisisemirislemid,
          s.id referansid,
          S.MIKTAR,
          'ISCILIK' TUR,
          s.tutar bruttutar,
          s.indirimlitutar tutar, 
          NVL (NVL (c.kod, t.kod), s.aciklama) kod,
          NVL (NVL (c.ad, t.ad), s.aciklama) ad,
          z.servisid,
          Z.TAMAMLANMATARIH,  
          2 turid,  
          NULL orjinalkod,
          isemirno
     FROM servisisemirislemler i,
          servisismislemiscilikler s,
          vw_servisiscilikler t,
          mt_iscilikler c,
          servisisemirler z
    WHERE     i.id = S.SERVISISEMIRISLEMID
          AND c.iscilikid(+) = S.ISCILIKID
          AND z.id = i.servisisemirid
          AND (c.dilkod = 'Turkish' OR c.dilkod IS NULL)
          AND (disaridayaptirdi <> 1 OR disaridayaptirdi IS NULL)
          AND (bakimislemynedenid IS NULL)
          AND s.durumid = 1
          AND T.DILKOD(+) = 'Turkish'
          AND S.SERVISISCILIKID = T.ID(+)
          AND (   I.ISEMIRUYGULAMAMANEDENID IS NULL
               OR I.ISEMIRUYGULAMAMANEDENID = 8)
          and z.servisid  {servisIdQuery} 
          and z.KAYITTARIH between '{dateQuery}' 
   UNION ALL
   SELECT z.id servisisemirid,
          i.id servisisemirislemid,
          k.id referansid,
          K.MIKTAR,
          'DKALEM' TUR,
          k.tutar bruttutar,
          k.indirimlitutar tutar, 
          REPLACE (LOWER (sason.fn_rmtr (d.ad)), ' ') kod,
          ad,
          z.servisid,
          Z.TAMAMLANMATARIH, 
          3 turid, 
          NULL orjinalkod,
          isemirno
     FROM servisisemirislemler i,
          servisismislemdkalemler k,
          vw_digerkalemler d,
          servisisemirler z
    WHERE     i.id = k.SERVISISEMIRISLEMID
          AND z.id = i.servisisemirid
          AND d.id = K.DIGERKALEMID
          AND dilkod = 'Turkish'
          AND k.durumid = 1
          AND (   I.ISEMIRUYGULAMAMANEDENID IS NULL
               OR I.ISEMIRUYGULAMAMANEDENID = 8)
          and z.servisid   {servisIdQuery} 
          and z.KAYITTARIH between '{dateQuery}' 
   UNION ALL
   SELECT z.id servisisemirid,
          i.id servisisemirislemid,
          k.id referansid,
          1 miktar,
          'DHIZMET' TUR,
          k.tutar bruttutar,
          k.indirimlitutar tutar, 
          REPLACE (LOWER (sason.fn_rmtr (d.aciklama)), ' ') kod,
          d.aciklama ad,
          z.servisid,
          Z.TAMAMLANMATARIH, 
           4 turid, 
           NULL orjinalkod,
          isemirno
     FROM servisisemirislemler i,
          servisismislemdhizmetler k,
          servisdishizmetalimlar d,
          servisisemirler z
    WHERE     i.id = k.SERVISISEMIRISLEMID
          AND z.id = i.servisisemirid
          AND d.id = K.SERVISDISHIZMETALIMID
          AND k.durumid = 1
          AND (   I.ISEMIRUYGULAMAMANEDENID IS NULL
               OR I.ISEMIRUYGULAMAMANEDENID = 8)  
          and z.servisid   {servisIdQuery} 
          and z.KAYITTARIH between '{dateQuery}' 
                        ) t,
                      
                      
                        servisstoklar ss,
                        servisvarliklar o1,
                        servisvarliklar o2,
                        isortaklar o3,
                        servisler sv,
                        sason.isemirtipler bx ,
                        sason.lovturler cx,
                        servisvarlikruhsatlar dx

                WHERE     d.ayristirmaid = a.id
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
                        AND A.ICMALID = ic.id(+)
                        AND a.durumid = bx.id and D.TURID = Cx.ID AND  i.saseno = dx.saseno
                        AND a.durumid = 1
                        and a.servisid = i.servisid
                        and i.servisid {servisIdQuery} 
                        AND ( ss.servisstokturid = '6' OR
                             t.kod IN ('09.11001-0022' , '09.11001-0153' , '09.11001-0160', '09.11001-0823',
                                       '09.11001-0820' , '09.11070-0641' , '09.11070-0434' , '09.11001-1003',
                                       '09.11001-1000' , '09.11001-0013' , 'ZU.GOSAE-0010' , '09.11003-0514',
                                       '09.11003-0507' , '09.11003-0517' , '09.11070-0732' , '09.11070-0692',
                                       '09.11070-0742' , 'ZU.GGRES-0010' , 'ZU.GHD46-0010' , 'ZU.GHD46-0020' ) )
                        and i.id in (select ixx.id from servisisemirler ixx where ixx.servisid {servisIdQuery}  and ixx.KAYITTARIH between '{dateQuery}'  AND (ixx.saseno = NVL ('{SaseNo}', ixx.saseno))   )

                   --     ORDER BY i.servisid,  i.id  desc


                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}