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
            List<object> reportDataSource = new List<object>();
            DataTable dtb = AppPool.EbaTestConnector.CreateQuery(@"
                 SELECT  a.DURUMID,
                       a.ISORTAKAD,
                       a.ID,
                       a.SERVISID,
                       a.HASHSERVISID,
                       a.FATURANO,
                       a.ISEMIRNO,
                       a.SIRANO,
                       a.AYRISTIRMATIPAD,
                       a.MALZEMEKOD,
                       a.MALZEMEAD,
                       a.TURID,
                       a.ARIZAKODU,
                       to_char(a.TAMAMLANMATARIH,'dd/mm/yyyy') as TAMAMLANMATARIH,
                       to_char(a.KAYITTARIH,'dd/mm/yyyy') as KAYITTARIH,
                       a.KM,
                       a.KUR,
                       a.ARACTIPAD,
                       a.MODELNO,
                       a.FIRSTREGDATE,
                       a.ISEMIRTUTAR,
                       a.SASENO,
                       a.ISEMIRTIPID,
                       a.PDFKDV,
                       a.PDFONAYGENELTOPLAM,
                       a.PDFMATRAH,
                       a.AD,
                       a.CLAIMSTATUS,
                       a.FATURAID,
                       a.MIKTAR,
                       a.TUTAR,
                       a.BRUTTUTAR,
                       a.DURUM,
                       a.SERVISSTOKTURAD,
                       a.URETICI,
                       a.ATUTAR,
                       a.PDFISLETIMUCRETI,
                       a.PDFITEMID,
                       a.PDFTOPLAM,
                       a.VERGINO,
                       a.ORJINALKOD,
                       a.ORTALAMAMALIYET,
                       a.INDIRIMORAN,
                       a.TFATTOPLAM,
                        to_char(a.ICMALTARIHI,'dd/mm/yyyy') as ICMALTARIHI,
                       a.ICMALKUR,
                       a.SERVISSTOKTURID,
                        B.KOD, 
                        c.ack , 
                        '{StartDate}' as bastar, 
                        '{FinishDate}'  as bittar,
                        to_char(d.ilktesciltarihi,'dd/mm/yyyy') as ilktesciltarihi
                    FROM SASON.RP_ISEMIRLER a 
                    inner join sason.isemirtipler b ON a.durumid = b.id
                    inner join sason.lovturler c ON a.turid = C.ID
                    inner join servisvarlikruhsatlar d ON a.saseno = d.saseno
                    WHERE A.KAYITTARIH BETWEEN {StartDate} AND {FinishDate}
                       AND (a.saseno = NVL ({SaseNo}, a.saseno))
                       AND a.servisid = {ServisId} 
            ")
            .Parameter("StartDate", StartDate.Date)
            .Parameter("FinishDate", FinishDate.endOfDay())
            .Parameter("ServisId", ServisId)
            .Parameter("SaseNo", SaseNo.isNotNullOrWhiteSpace() ? null : SaseNo)
            .GetDataTable(refMr);
           
           reportDataSource = dtb.ToModels(refMr);

            CloseCustomAppPool();
            return reportDataSource;
        }
    }
}