using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Sason.Servis
{
    /// <summary>
    /// Merkez Yedek Parça Faaliyet Raporu
    /// </summary>
    public class SrvsDetayliYedekParca : Base.SasonReporter
    {
        public SrvsDetayliYedekParca()
        {
            Text = "Detaylı Yedek Parça Raporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate()); 
            Disabled = false;
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
            
            MethodReturn mr = new MethodReturn();
            /*
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"  
            SELECT DISTINCT
               'a' as AYRISTIRMATIPAD  ,
               'b' as BELGENO  ,
               'c' as BELGETURU ,
               1 as BRUTTUTAR,
               2 as HASHSERVISID,
               3 as INDIRIMORAN ,
                'd' as ISCILIK_PARCA ,
                'e' as ISEMIRTIPI ,
                'f' as KUR ,
                'g' as MALZEMEAD   ,
                'h' as MALZEMEKOD ,
               4 as MIKTAR,
               'j' as MUSTERIAD ,
                'k' as ORJINALKOD ,
               5 as ORTALAMAMALIYET,
                'l' as SASENO ,
                'm' as SERVISAD ,
               6 as SERVISID,
                'n' as SERVISSTOKTURAD ,
              '07/07/2018' as TARIH ,
              '07/07/2018' as TRAFIGECIKISTARIHI ,
              7 as TUTAR  ,
               'o' as URETICI ,
                'p' as VERGINO ,
              9 as SERVISSTOKTURID,
 
                  94 as Servisid,
                 '07/03/2018' as bastar , 
                 '08/03/2018'  as bittar 
                FROM sason.servisler
                WHERE 1 = 1
  ")
            .Parameter("startDate", StartDate.startOfDay())
            .Parameter("finishDate", FinishDate.endOfDay())
            .GetDataTable(mr)
            .ToModels();
            */

              List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
                    SELECT DISTINCT   
                        AYRISTIRMATIPAD ,
                        BELGENO,
                        BELGETURU,
                        BRUTTUTAR,
                        HASHSERVISID ,
                        INDIRIMORAN,
                        ISCILIK_PARCA,
                        ISEMIRTIPI,
                        KUR,
                        MALZEMEAD,
                        MALZEMEKOD,
                        MIKTAR,
                        MUSTERIAD,
                        ORJINALKOD,
                        ORTALAMAMALIYET,
                        SASENO,
                        SERVISAD,
                        SERVISID,
                        SERVISSTOKTURAD,
                        TARIH,
                         to_char(TRAFIGECIKISTARIHI,'dd/mm/yyyy') as TRAFIGECIKISTARIHI,
                        TUTAR,
                        URETICI,
                        VERGINO,
                        SERVISSTOKTURID, 
                            {{startDate}} as bastar , 
                            {{finishDate}} as bittar   
                    FROM sason.rptable_yedekparcadetay 
                    WHERE tarih BETWEEN  {{startDate}} and {{finishDate}} AND
                    SERVISID = {ServisId}  
                     order by SERVISAD , TARIH, belgeno,malzemekod, musteriad  

                ")
                .Parameter("startDate", StartDate.startOfDay())
                .Parameter("finishDate", FinishDate.endOfDay())
                .GetDataTable(mr)
                .ToModels();
              


            CloseCustomAppPool();
            return queryResults;
        }

    }
}