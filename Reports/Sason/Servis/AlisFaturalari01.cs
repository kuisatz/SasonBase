using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Sason.Servis
{
    public class AlisFaturalari01 : Base.SasonReporter
    {
        public AlisFaturalari01()
        {
            Text = "Alış Faturaları";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            Disabled = true;
        }

        public AlisFaturalari01(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            List<object> reportDataSource = new List<object>();
            DataTable dtb = AppPool.EbaTestConnector.CreateQuery(@"
                select a.*,b.kod  
                    from sason.faturalar a,sason.faturaturler b
                where a.servisid = {ServisId}
                    and a.islemtarihi between {StartDate} and {FinishDate}
                    and a.faturaturid=4
                    and a.faturaturid=b.id
            ")
            .Parameter("StartDate", StartDate.Date)
            .Parameter("FinishDate", FinishDate.endOfDay())
            .Parameter("ServisId", ServisId)
            .GetDataTable(refMr);

            reportDataSource = dtb.ToModels(refMr);

            CloseCustomAppPool();
            return reportDataSource;
        }
    }
}