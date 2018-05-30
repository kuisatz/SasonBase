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
    public class MrkzIsEmirleriDurumOzet : Base.SasonMerkezReporter
    {
        public MrkzIsEmirleriDurumOzet()
        {
            Text = "İş Emri Durum Özet Raporu";
            SubjectCode = "MrkzIsEmirleriDurumOzet"; 
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            Disabled = false;
        }

        public MrkzIsEmirleriDurumOzet(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
   
                        select
                            (select vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = data1.servisid  and vtsx.dilkod = 'Turkish') as partnercode,
                            (Select vtsxy.ISORTAKAD FROM vt_servisler vtsxy where  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = data1.servisid) as servisad, 
                            data1.* ,
                        (
                           select count(z.servisid) from  servisisemirler  z where              
                                    to_date(z.kayittarih,'dd/mm/yyyy') = to_date(data1.tar,'dd/mm/yyyy') AND  
                                    z.servisid = data1.servisid -- x.servisid
                             group by to_date(z.kayittarih,'dd/mm/yyyy')) ogun_acilan_emirler,
                             (
                           select count(z.servisid) from  servisisemirler  z where
                                    to_date(z.kayittarih,'dd/mm/yyyy') = to_date(z.tamamlanmatarih,'dd/mm/yyyy') AND  
                                    to_date(z.kayittarih,'dd/mm/yyyy') = to_date(data1.tar,'dd/mm/yyyy') AND  
                                    z.servisid = data1.servisid -- x.servisid
                             group by to_date(z.kayittarih,'dd/mm/yyyy')) ogun_kapatilan_emirler, 
                        (
                           select count(z.servisid) from  servisisemirler  z where
                                    to_date(z.kayittarih,'dd/mm/yyyy') <> to_date(z.tamamlanmatarih,'dd/mm/yyyy') AND  
                                    to_date(z.kayittarih,'dd/mm/yyyy') = to_date(data1.tar,'dd/mm/yyyy') AND  
                                    z.servisid = data1.servisid -- x.servisid
                             group by to_date(z.kayittarih,'dd/mm/yyyy')) ogun_kapatilmayan_emirler,
                        (
                           select count(z.servisid) from  servisisemirler  z where
                                  --  to_date(z.kayittarih,'dd/mm/yyyy') <> to_date(z.tamamlanmatarih,'dd/mm/yyyy') AND  
                                    to_date(z.kayittarih,'dd/mm/yyyy') < to_date(data1.tar,'dd/mm/yyyy') AND  
                                    z.servisid = data1.servisid -- x.servisid
                                    and z.teknikolaraktamamla = 0 and z.tamamlanmatarih is null   
                             ) ogkadar_kapatilmayan_emrler  
                         from ( 
                           select x.servisid , count(x.servisid ) ogunden_kalan_isemirleri , to_date(x.kayittarih,'dd/mm/yyyy') tar   
                           from servisisemirler x 
                           where x.teknikolaraktamamla = 0 and x.tamamlanmatarih is null   
                                and x.servisid  {servisIdQuery}
                                and to_date(x.kayittarih,'dd/mm/yyyy') between '{dateQuery}'
                           group by  x.servisid, to_date(x.kayittarih,'dd/mm/yyyy')   
     
                         ) data1                            
   
                             order by  servisid ,tar desc   
 
            
            ")
            .GetDataTable()
            .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}