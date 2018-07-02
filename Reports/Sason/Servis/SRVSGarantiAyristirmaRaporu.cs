using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SasonBase.Reports.Sason.Servis
{
    /// <summary>
    /// Merkez Yedek Parça Faaliyet Raporu
    /// </summary>
    public class SrvsGarantiAyristirmaRaporu : Base.SasonReporter
    {
        public SrvsGarantiAyristirmaRaporu()
        {
            Text = "Garanti Ayrıştırma Detay Raporu";
            SubjectCode = "SrvsGarantiAyristirmaRaporu.";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());            
            AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            Disabled = false;
        }
        public SrvsGarantiAyristirmaRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
                case "param_sase_no":
                    SaseNo = value.toString();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            string servisIdQuery = $" = {ServisId}";
            string dateQuery = "";

 
            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";

 
            MethodReturn mr = new MethodReturn(); 
                List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"  
                                        SELECT * 
                                 FROM( 
                                      SELECT  DISTINCT
                                           (SELECT vtsx.partnercode FROM vt_servisler vtsx WHERE vtsx.servisid = a.servisid  AND vtsx.dilkod = 'Turkish') AS partnercode,
                                           a.durumid,
                                           o3.ad isortakad,
                                           d.id,
                                           a.servisid,
                                           sason.hashservisid (i.servisid) hashservisid,
                                           f.faturano,
                                           a.isemirno,
                                           r.sirano,
                                           tr.kod ayristirmatipad,
                                           t.kod malzemekod,
                                           t.ad malzemead,
                                           d.turid,
                                           a.arizakodu,
                                           TO_CHAR(i.tamamlanmatarih,'dd/mm/yyyy') AS tamamlanmatarih,
                                           TO_CHAR(i.kayittarih,'dd/mm/yyyy') AS kayittarih,
                                           i.km,
                                           i.kur,
                                           i.aractipad,
                                           i.modelno,                        
                                           TO_CHAR(i.firstregdate,'dd/mm/yyyy') AS firstregdate,
                                           t.tutar isemirtutar,
                                           i.saseno,
                                           r.isemirtipid,
                                           a.pdfkdv,
                                           a.pdfonaygeneltoplam,
                                           a.pdfmatrah,
                                           o2.ad,
                                           a.claimstatus,
                                           d.faturaid,
                                           t.miktar,
                                           t.tutar,
                                           t.bruttutar,
                                           CASE
                                                WHEN (a.ayristirmatipid IN (1) AND d.faturaid IS NOT NULL)
                                                     OR a.claimstatus IN ('Z0110') --('Z057', 'Z060', 'Z070', 'Z0110')
                                                THEN
                                                     'TAMAMLANMIS'
                                                WHEN (a.ayristirmatipid IN (1) AND d.faturaid IS NOT NULL)
                                                     OR a.claimstatus IN ('Z107', 'Z109', 'Z999')
                                                THEN
                                                     'REDDEDİLDİ'
                                                ELSE
                                                     'DEVAM EDIYOR'
                                           END durum,
                                           st.kod servisstokturad,
                                           CASE 
                                                WHEN ss.ureticivarlikid IS NULL THEN 'MAN' ELSE o1.ad 
                                           END uretici,
                                           d.atutar,
                                           d.pdfisletimucreti,
                                           d.pdfitemid,
                                           d.pdftoplam,
                                           f.vno vergino,
                                           orjinalkod,
                                           kurlar_pkg.ortalamamaliyet (ss.id) ortalamamaliyet,
                                           ROUND(
                                                (  1
                                                -  t.tutar
                                                    / CASE 
                                                          WHEN t.bruttutar = 0 THEN NULL 
                                                          ELSE t.bruttutar 
                                                      END)
                                                * 100,
                                                2) indirimoran,
                                           ic.tfattoplam,
                                           TO_CHAR(ic.icmaltarihi,'dd/mm/yyyy') AS icmaltarihi,
                                           CASE  
                                                WHEN (ic.icmaltarihi > SYSDATE) 
                                                     THEN  kurlar_pkg.caprazkurtarih (2, 1, SYSDATE)     
                                                WHEN (ic.icmaltarihi IS NULL  ) 
                                                     THEN  NULL
                                                ELSE  kurlar_pkg.caprazkurtarih (2, 1, ic.icmaltarihi) 
                                           END icmalkur,
                                           servisstokturid,
                                           bx.kod,
                                           cx.ack ,
                                           TO_CHAR(dx.ilktesciltarihi,'dd/mm/yyyy') AS ilktesciltarihi,
                                           '{StartDate}' AS bastar, 
                                           '{FinishDate}'  AS bittar,
                                           i.id AS kyttarhidsi
                                      FROM servisisemirler i, 
                                           servisisemirislemler r,
                                           servisicmaller ic,
                                           ayristirmadetaylar d,
                                           ayristirmalar a,
                                           ayristirmatipler tr,
                                       /*  servisisemirler i, */
                                           faturalar f,
                                           servisstokturler st,
                                           sason.rp_isemirdetay t,
                                           servisstoklar ss,
                                           servisvarliklar o1,
                                           servisvarliklar o2,
                                           isortaklar o3,
                                           servisler sv,
                                           sason.isemirtipler bx ,
                                           sason.lovturler cx,
                                           servisvarlikruhsatlar dx

                                      WHERE d.ayristirmaid = a.id
                                           AND a.isemirno = i.isemirno
                                           AND a.ayristirmatipid = tr.id
                                           AND f.id(+) = d.faturaid
                                           AND r.id = a.servisisemirislemid
                                           AND t.referansid = d.referansid
                                           AND st.id(+) = ss.servisstokturid
                                           AND t.turid = d.turid
                                           AND ss.kod(+) = t.kod
                                           AND (ss.servisid = i.servisid OR ss.servisid IS NULL)
                                           AND ss.ureticivarlikid = o1.id(+)
                                           AND i.servisvarlikid = o2.id
                                           AND sv.id = i.servisid
                                           AND sv.isortakid = o3.id
                                           AND a.icmalid = ic.id(+)
                                           AND a.durumid = bx.id and d.turid = cx.id and  i.saseno = dx.saseno
                                           AND a.durumid = 1               AND i.id IN (SELECT ixx.id FROM servisisemirler ixx WHERE   ixx.durumid = 1 AND ixx.servisid {servisIdQuery} 

                                           AND a.servisid = i.servisid
                                           AND i.servisid {servisIdQuery} 
                                                          AND ixx.kayittarih BETWEEN '{dateQuery}'   
                                                          AND (i.saseno = NVL ('{SaseNo}', ixx.saseno))   )
                                          AND a.ayristirmatipid NOT IN (1,2)           
                                 ) asd 
                            ORDER BY servisid, isemirno, servisstokturad ASC, kayittarih DESC   
                ")                          
                .GetDataTable(mr)
                .ToModels();

                
            CloseCustomAppPool();
            return queryResults;
        }

    }
}