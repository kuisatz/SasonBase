using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SasonBase.Reports.Sason.Servis
{
    /// <summary>
    /// Servis Bakım Geçmişi Raporu
    /// </summary>
    public class SrvsBakimGecmisi : Base.SasonReporter
    {
        public SrvsBakimGecmisi()
        {
            Text = "Bakım Geçmişi";
            SubjectCode = "SrvsBakimGecmisi";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
     //       AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(false));
            AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            //Disabled = false;
        }

        public SrvsBakimGecmisi(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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

#if DEBUG           
            servisIdQuery = $" = {ServisId}";
#endif

            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";


            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"
              
                        SELECT e.saseno,
                               e.kayittarih,
                               e.tamamlanmatarih,
                               e.km,
                               e.endeks AS litre,
                               e.saat,
                               --E.TBITISTARIHI,
                               e.isemirno,
                               t.isortakad,
                               bakimtoplu AS bakim_no,
                               t.partnercode AS yskod,
                               CASE 
                                  WHEN bakimstatu =1 THEN  'TAM' 
                                  WHEN bakimstatu =0 THEN 'EKSIK' 
                                  ELSE 'HATALI'
                               END AS bakimstatu,
                                a.esagarantino, 
                                a.servisgarantino, 
                                a.claimstatus
                        FROM servisisemirler e,
                             servisisemirislemler i,
                             vt_servisler t,
                             ayristirmalar a 

                        WHERE  e.kayittarih BETWEEN '{dateQuery}'  
                             AND e.id = i.servisisemirid 
                             AND isemirtipid =1 
                             AND (e.saseno = NVL ('{SaseNo}', e.saseno)) 
                             AND t.servisid = e.servisid
                             AND e.isemirno=a.isemirno
                             AND e.servisid  {servisIdQuery}
                             AND t.dilkod='Turkish'
                             AND e.tamamlanmatarih IS NOT NULL
                             AND bakimtoplu IS NOT NULL
                             AND e.teknikolaraktamamla = 1
                             AND a.servisisemirislemid = i.id
                        ORDER BY e.servisid, e.kayittarih DESC
            
            ")


            .GetDataTable()
            .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}