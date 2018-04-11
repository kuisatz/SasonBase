using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SasonBase.Reports.Sason.Servis
{
    public class AyristirmaRaporu01 : Base.SasonReporter
    {
        public AyristirmaRaporu01()
        {
            Text = "Ayrıştırma Raporu";
            SubjectCode = "AyristirmaRaporu01";
            ReportFileCode = "Ayristirma_Raporu";
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
        }

        public AyristirmaRaporu01(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
          
          
            string dateQuery = "";

            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";

            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"  
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
                        to_char(I.TAMAMLANMATARIH,'dd/mm/yyyy') as TAMAMLANMATARIH,
                        to_char(I.KAYITTARIH,'dd/mm/yyyy') as KAYITTARIH,          
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
                        KURLAR_PKG.CAPRAZKURTARIH (2, 1, ic.icmaltarihi) icmalkur,
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
                        sason.rp_isemirdetay t,
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
                        and i.servisid = {ServisId} 
 
                        and i.id in (select ixx.id from servisisemirler ixx where i.servisid ={ServisId} and ixx.KAYITTARIH between '{dateQuery}'  AND (i.saseno = NVL ('{SaseNo}', i.saseno))   )
          
                        ORDER BY i.id  desc
                      
            ")
         //   .Parameter("StartDate", StartDate.Date)
         //   .Parameter("FinishDate", FinishDate.endOfDay())
         //   .Parameter("ServisId", ServisId)
         //   .Parameter("SaseNo", SaseNo.isNotNullOrWhiteSpace() ? null : SaseNo)
            .GetDataTable(refMr)            
            .ToModels();

            //    reportDataSource = dtb.ToModels(refMr);


            CloseCustomAppPool();
            return queryResults;
        }
    }
}