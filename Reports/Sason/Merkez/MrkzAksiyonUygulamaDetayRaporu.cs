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
    /// Merkez Aksiyon Uygulama Detay Raporu
    /// </summary>
    public class MrkzAksiyonUygulamaDetayRaporu : Base.SasonMerkezReporter
    {
        public MrkzAksiyonUygulamaDetayRaporu()
        {
            Text = "[SI-4] Aksiyon Uygulama Detay Raporu";
            SubjectCode = "MrkzAksiyonUygulamaDetayRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            Disabled = false;
        }
        public MrkzAksiyonUygulamaDetayRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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

#if DEBUG
            selectedServisId = ServisId;
            servisIdQuery = $" = {selectedServisId}";
#endif


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

            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 

                SELECT sorg1.servisid,
                       sorg2.partnercode,
                       sorg2.isortakad,
                       sorg2.sase,
                       sorg2.isemir,
                       sorg1.ayr

                FROM 
                    (SELECT si.servisid  AS servisid,
                            COUNT(DISTINCT si.isemirno) AS ayr
                     FROM
                     servisisemirler si
                     INNER JOIN servisisemirislemler sisl ON sisl.servisisemirid=si.id
                     INNER JOIN vt_servisler srv ON srv.servisid=si.servisid
                     INNER JOIN ayristirmalar ayr ON ayr.isemirno=si.isemirno 

                     WHERE
                     sisl.isemirtipid=2 
                     AND sisl.isemiruygulamamanedenid IS NULL 
                     AND si.tamamlanmatarih IS NOT NULL 
                     AND si.tutar>0 
                     AND ayr.isemirno=si.isemirno 
                     AND ayr.claimstatus='Z110'
                     AND srv.dilkod='Turkish'
                     AND si.kayittarih BETWEEN '{dateQuery}'
                     AND si.servisid {servisIdQuery}
                     GROUP BY si.servisid
                     ORDER BY si.servisid) sorg1

                FULL OUTER JOIN 
                    (SELECT si.servisid AS servisid,
                            srv.partnercode,
                            srv.isortakad,
                            COUNT(DISTINCT si.saseno) AS sase,
                            COUNT(DISTINCT si.isemirno) AS isemir
                     FROM 
                     servisisemirler si,
                     servisisemirislemler sisl,
                     vt_servisler srv

                     WHERE
                     sisl.servisisemirid=si.id
                     AND sisl.isemirtipid=2
                     AND srv.servisid=si.servisid
                     AND srv.dilkod='Turkish'
                     AND si.kayittarih BETWEEN '{dateQuery}'
                     AND si.servisid {servisIdQuery}
                     GROUP BY si.servisid, srv.partnercode,srv.isortakad
                     ORDER BY si.servisid ASC) sorg2
                ON sorg1.servisid = sorg2.servisid

                ")
            .GetDataTable(mr)
            .ToModels();


            CloseCustomAppPool();
            return queryResults;
        }

    }
}