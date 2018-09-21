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
            Text = "[İE-7] İş Emri Durum Özet Raporu";
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

                    SELECT
                        (SELECT vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = vv.servisid  and vtsx.dilkod = 'Turkish') as partnercode,
                        (SELECT vtsxy.ISORTAKAD FROM vt_servisler vtsxy where  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = vv.servisid) as servisad, 
                        vv.servisid ,  
                        tarihicin.tar ttarihh, 
                        nvl( (
                            SELECT count(z.servisid) from  servisisemirler  z where                                
                                to_date(z.kayittarih,'dd/mm/yyyy') < to_date(tarihicin.tar,'dd/mm/yyyy') AND  
                                z.servisid = vv.servisid 
                                and z.teknikolaraktamamla = 0 and z.tamamlanmatarih is null   
                            ),0) ogkadar_kapatilmayan_emrler, 
                        nvl((
                            SELECT count(z.servisid) from  servisisemirler  z where              
                                    to_date(z.kayittarih,'dd/mm/yyyy') = to_date(tarihicin.tar,'dd/mm/yyyy') AND  
                                    z.servisid = vv.servisid  
                                group by to_date(z.kayittarih,'dd/mm/yyyy')),0) ogun_acilan_emirler,
                        nvl((
                            SELECT count(z.servisid) from  servisisemirler  z where                              
                                    to_date(z.tamamlanmatarih,'dd/mm/yyyy') <> to_date(tarihicin.tar,'dd/mm/yyyy')  AND  
                                    to_date(z.kayittarih,'dd/mm/yyyy') = to_date(tarihicin.tar,'dd/mm/yyyy') AND
                                    z.servisid = vv.servisid                                 
                             group by to_date(z.kayittarih,'dd/mm/yyyy')),0) ogun_kapatilmayan_emirler ,                               
                       
                        nvl((
                            SELECT count(z.servisid) from  servisisemirler  z where
                                    to_date(z.tamamlanmatarih,'dd/mm/yyyy') = to_date(tarihicin.tar,'dd/mm/yyyy')  AND  
                                    to_date(z.kayittarih,'dd/mm/yyyy') = to_date(tarihicin.tar,'dd/mm/yyyy') AND  
                                    z.servisid = vv.servisid
                         ),0) ogun_acilankapanan_emirler,
                        nvl((
                            SELECT count(z.servisid) from  servisisemirler  z where
                                    to_date(z.tamamlanmatarih,'dd/mm/yyyy') = to_date(tarihicin.tar,'dd/mm/yyyy')  AND                                    
                                    z.servisid = vv.servisid
                         ),0) ogun_kapatilan_emir ,
                        nvl((
                            SELECT count(z.servisid) from  servisisemirler  z where
                                    to_date(z.tamamlanmatarih,'dd/mm/yyyy') <= to_date(tarihicin.tar,'dd/mm/yyyy')  AND                                    
                                    z.servisid = vv.servisid
                         ),0) ogune_kadarkapatilan_emir 
                              
                    from vt_servisler vv  
                    left join (
                        SELECT distinct  to_date(x.kayittarih,'dd/mm/yyyy') tar   
                        from servisisemirler x WHERE
                            x.kayittarih between '{dateQuery}'
                        ) tarihicin on 1 = 1
                   
                  where 
                        vv.dilkod = 'Turkish' AND  
                        vv.servisid not in (1,134,136) AND 
                        vv.durumid = 1 
                        and vv.servisid  {servisIdQuery} 
                      order by  vv.servisid  , tarihicin.tar desc

  
            
            ")
            .GetDataTable()
            .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}