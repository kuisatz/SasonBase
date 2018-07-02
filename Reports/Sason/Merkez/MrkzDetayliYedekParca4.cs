using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SasonBase.Reports.Sason.Merkez
{
    /// <summary>
    /// Merkez Yedek Parça Faaliyet Raporu
    /// </summary>
    public class MrkzDetayliYedekParca4 : Base.SasonMerkezReporter
    {
        public MrkzDetayliYedekParca4()
        {
            Text = "Detaylı Yedek Parça Raporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            Disabled = true ;
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

            #region eskisql
            /*
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
                                SERVISID   {servisIdQuery}  
                                 order by SERVISAD , TARIH, belgeno,malzemekod, musteriad  

                            ")
                            .Parameter("startDate", StartDate.startOfDay())
                            .Parameter("finishDate", FinishDate.endOfDay())
                            .GetDataTable(mr)
                            .ToModels();

                */
            #endregion 

            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 

 
 
                 SELECT  
                    SERVISID  ,
                    SIPARISSERVISID  HASHSERVISID,  
                    (SELECT isortakad
                       FROM vt_servisler
                      WHERE servisid = siparisservisid AND dilkod = 'Turkish')  servisad,
                    TARIH  ,
                    BELGENO   ,
                    BELGETURU  ,
                    ISEMIRTIPI ,
                    ISEMIRTIPID ,
                    VERGINO  ,
                    MUSTERIAD  ,
                    FATURATARIHI   ,
                    CLAIMSTATUS  ,
                    MALZEMEKOD  ,
                    ORJINALKOD ,
                    URETICI   ,
                    SERVISSTOKTURAD  ,
                    ISCILIK_PARCA  ,
                    MALZEMEAD  ,
                    MIKTAR  ,
                    BRUTTUTAR  ,
                    TUTAR  ,
                    SASENO  ,
                    OZELSATISSASENOLAR  , 
                    to_char(TRAFIGECIKISTARIHI,'dd/mm/yyyy') TRAFIGECIKISTARIHI, 
                    KURLAR_PKG.ORTALAMAMALIYET (ORTALAMAMALIYET) ortalamamaliyet,
                    AYRISTIRMATIPAD  ,
                    FIYAT2  ,
                    to_char(KUR) KUR,
                    SERVISSTOKID  ,
                    SERVISSTOKTURID ,
                    EUROINDFIYAT ,  
                     kurlar_pkg.servisstokfiyatgetir (EUROLISTEFIYAT, 2, TRUNC (SYSDATE)) EUROLISTEFIYAT 
                FROM sason.ypdata     
                WHERE  
                    YEDEKPARCARAPORTARIHI  between '{dateQuery}' and 
                    SIPARISSERVISID {servisIdQuery}     
            
                     
                ")
              .GetDataTable(mr)
              .ToModels();

            CloseCustomAppPool();
            return queryResults;
        }

    }
}