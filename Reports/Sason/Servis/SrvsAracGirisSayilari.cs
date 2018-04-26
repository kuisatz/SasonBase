using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Sason.Servis
{
    public class SrvsAracGirisSayilari : Base.SasonReporter
    {
        public SrvsAracGirisSayilari()
        {
            Text = "Araç Giriş Sayıları (Liste)";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            Disabled = true;
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
            List<object> reportDataSource = AppPool.EbaTestConnector.CreateQuery($@"
                    SELECT
                        tarihler.tarih, tarihler.yil, tarihler.ay, servis.servisid, servis.isortakad SERVISISORTAKAD, servis.VARLIKAD SERVISVARLIKAD, ags.arac_giris, ags.isemir_acilan, ags.isemir_kapanan
                    FROM 
                        (SELECT TARIH, YIL, AY FROM TARIHLER WHERE TARIH BETWEEN {{startDate}} AND {{finishDate}}) tarihler
                    left join vt_servisler servis on servis.servisid = {ServisId} and servis.dilkod = 'Turkish'
                    left join mobilags ags on AGS.SERVIS = servis.servisid and AGS.TARIH = tarihler.tarih
                    order by tarihler.tarih, servis.servisid                
            ")
            .Parameter("startDate", StartDate.startOfDay())
            .Parameter("finishDate", FinishDate.endOfDay())
            .GetDataTable()
            .ToModels();

            CloseCustomAppPool();
            return reportDataSource;
        }
    }
}