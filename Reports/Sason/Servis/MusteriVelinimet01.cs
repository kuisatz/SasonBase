using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Sason.Servis
{
    public class MusteriVelinimet01 : Base.SasonReporter
    {
        public MusteriVelinimet01()
        {
            Text = "Müşteri Velinimetimizdir";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            Disabled = true;
        }

        public MusteriVelinimet01(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
                 SELECT distinct
                   s.id,o.ad,s.isemirno,
                      to_char(s.kayittarih,'dd.mm.yyyy') tarih,
                      S.MUSTERIAD,
                      S.MUSTERITELEFON,
                      T.ISORTAKAD,
                      case when S.KULLANICIID is null then s.okullaniciid else s.kullaniciid end kullanici,
                      t.partnercode,
                      S.ARACTIPAD,
                      s.saseno,R.PLAKA,
                      CASE when O.FILOBUYUKLUKID is null then 1 else 0 end filo,h.servisisortakkontaktipad,no,h.ad kontakad
                from sason.vt_servisler t,sason.servisisemirler s,sason.vt_servisisortaklar o ,sason.servisvarlikruhsatlar r ,sason.vw_isortakkontakbilgiler h
                    where O.SERVISISORTAKID =S.SERVISISORTAKID and s.servisid=t.servisid
                      and t.dilkod='Turkish' and S.SASENO=R.SASENO
                      and s.kayittarih between {StartDate} and {FinishDate}
                      and t.dilkod=o.dilkod 
                      and  (s.servisid = {ServisId} or {ServisId} = 1)
                      and O.SERVISISORTAKID=h.servisisortakid(+)
                      and (h.servisisortakkontaktipid=6 or h.servisisortakkontaktipid is null)
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