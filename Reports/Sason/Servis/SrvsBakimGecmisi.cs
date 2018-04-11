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
              
                    SELECT E.SASENO,
                           E.KAYITTARIH,
                           E.TAMAMLANMATARIH,
                           E.KM,
                           E.ENDEKS as LITRE,
                           E.SAAT,
                           --E.TBITISTARIHI,
                           E.ISEMIRNO,
                           T.ISORTAKAD,
                           BAKIMTOPLU as BAKIM_NO,
                           T.PARTNERCODE as YSKOD,
                           case 
                            when BAKIMSTATU =1 then  'TAM' 
                            when BAKIMSTATU =0 then 'EKSIK' 
                            else 'HATALI' end as BAKIMSTATU

                        FROM SERVISISEMIRLER E,
                             SERVISISEMIRISLEMLER I,
                             VT_SERVISLER T 

                        WHERE  E.KAYITTARIH BETWEEN '{dateQuery}' 
                            and E.ID = I.SERVISISEMIRID 
                            and ISEMIRTIPID =1 
                            and (E.SASENO = NVL ('{SaseNo}', E.SASENO)) 
                            and T.SERVISID = E.SERVISID
                            and E.SERVISID {servisIdQuery}
                            and T.DILKOD='Turkish'
                            and E.TAMAMLANMATARIH is not null
                            and BAKIMTOPLU is not null
                            and E.TEKNIKOLARAKTAMAMLA = 1
                        ORDER BY E.SERVISID, E.KAYITTARIH desc
            
            ")


            .GetDataTable()
            .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}