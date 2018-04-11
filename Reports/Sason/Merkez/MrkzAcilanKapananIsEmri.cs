using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SasonBase.Reports.Sason.Merkez
{
    /// <summary>
    /// Merkez Açılan Kapanan İş Emri Raporu
    /// </summary>
    public class MrkzAcilanKapananIsEmri : Base.SasonMerkezReporter
    {
        public MrkzAcilanKapananIsEmri()
        {
            Text = "Açılan Kapanan İş Emri";
            SubjectCode = "MrkzAcilanKapananIsEmri";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            Disabled = false;
        }

        public MrkzAcilanKapananIsEmri(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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


            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"     
                    SELECT SUM(AIES) AS AIES , sum(KIES) AS KIES , servisid, partnercode , servisad , KAYITTARIH  
                    FROM (
                        select max(acikadet) as AIES,
                               max(kapanan_adet) as KIES,
                               servisid,
                               (select vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = dsf.servisid  and vtsx.dilkod = 'Turkish') as partnercode,
                               (Select vtsxy.ISORTAKAD FROM vt_servisler vtsxy where vtsxy.dilkod = 'Turkish' and vtsxy.servisid = dsf.servisid) as servisad,
                                to_char(KAYITTARIH,'dd/mm/yyyy') as  KAYITTARIH
                        from
                            (SELECT count(id) acikadet,null kapanan_adet ,servisid, KAYITTARIH
                                FROM servisisemirler
                                    where 
                                        KAYITTARIH BETWEEN '{dateQuery}' AND
                                        servisid {servisIdQuery}
                                    group by servisid, KAYITTARIH
                                union all
                                SELECT null acikadet ,count(id)kapanan_adet,servisid, TAMAMLANMATARIH
                                FROM servisisemirler
                                    where 
                                        TAMAMLANMATARIH BETWEEN '{dateQuery}'
                                    and servisid {servisIdQuery}
                            group by servisid ,TAMAMLANMATARIH) dsf
                        group by servisid ,KAYITTARIH 
                      ) 
                    GROUP BY servisid, partnercode, servisad, KAYITTARIH          
                    order by servisid,KAYITTARIH desc
            
            ")
            .GetDataTable()
            .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}