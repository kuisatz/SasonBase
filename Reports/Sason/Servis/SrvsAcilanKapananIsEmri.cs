using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SasonBase.Reports.Sason.Servis
{
    /// <summary>
    /// Servis Açılan Kapanan İş Emri Raporu
    /// </summary>
    public class SrvsAcilanKapananIsEmri : Base.SasonReporter
    {
        public SrvsAcilanKapananIsEmri()
        {
            Text = "Açılan Kapanan İş Emri";
            SubjectCode = "SrvsAcilanKapananIsEmri";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
     //       AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(false));
            Disabled = false;
        }

        public SrvsAcilanKapananIsEmri(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
            string servisIdQuery = $" = {ServisId}";
            string dateQuery = "";

#if DEBUG           
            servisIdQuery = $" = {ServisId}";
#endif
 
            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";


            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"
                    SELECT SUM(AIES) AS AIES , sum(KIES) AS KIES , servisid, partnercode , servisad , KAYITTARIH  
                    FROM (
                        SELECT max(acikadet) as AIES,
                               max(kapanan_adet) as KIES, 
                               servisid,
                               (SELECT vtsx.partnercode from vt_servisler vtsx WHERE vtsx.servisid = dsf.servisid  and vtsx.dilkod = 'Turkish') as partnercode,
                               (SELECT vtsxy.ISORTAKAD FROM vt_servisler vtsxy WHERE vtsxy.dilkod = 'Turkish' and vtsxy.servisid = dsf.servisid)  as servisad,
                                to_char(KAYITTARIH,'dd/mm/yyyy') as KAYITTARIH
                        FROM 
                            (SELECT count(id) acikadet,null kapanan_adet ,servisid,KAYITTARIH
                                FROM servisisemirler
                                    WHERE 
                                        KAYITTARIH BETWEEN '{dateQuery}' AND
                                        servisid {servisIdQuery}
                                    group by servisid,KAYITTARIH
                                union all
                                SELECT null acikadet ,count(id)kapanan_adet,servisid,TAMAMLANMATARIH
                                FROM servisisemirler
                                    WHERE 
                                        TAMAMLANMATARIH BETWEEN '{dateQuery}' AND
                                        servisid {servisIdQuery}
                            group by servisid,TAMAMLANMATARIH) dsf
                        group by servisid,KAYITTARIH
                    ) 
                    GROUP BY servisid, partnercode , servisad , KAYITTARIH                    
                    order by servisid,KAYITTARIH desc
 
            
            ")
            .GetDataTable()
            .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}