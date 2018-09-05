using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SasonBase.Reports.Sason.Servis
{
    /// <summary>
    ///  Yan sanayi kullanım nedenleri raporu
    /// </summary>
    public class SrvsTeknikOlTamamAyristirmasiOlmayanIE : Base.SasonReporter
    {
        public SrvsTeknikOlTamamAyristirmasiOlmayanIE()
        {
            Text = "Teknik Olarak Tamamlanmış Ayrıştırması Yapılmamış İş Emri Raporu";
            SubjectCode = "SrvsTeknikOlTamamAyristirmasiOlmayanIE";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;              
            Disabled = false;
        }
        public SrvsTeknikOlTamamAyristirmasiOlmayanIE(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
        }
          
        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {
                //Dışarıdan Gelen Format 20171231235959 Şeklinde Olmalıdır
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
         
            string servisIdQuery = $" = {ServisId}";

//#if DEBUG
//             selectedServisId = ServisId;
//              servisIdQuery = $" in( {selectedServisId} )";
//#endif
  
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
                            SELECT vt.isortakad servis_adi, 
                                vt.partnercode servis_kodu, 
                                a.isemirno,
                                a.tamamlanmatarih,
                                sv.ad musteri_adi, 
                                a.tutar
    
                            FROM servisisemirler a, 
                                servisvarliklar sv,
                                vt_servisler vt

                            WHERE   a.servisid {servisIdQuery} AND
                                a.teknikolaraktamamla=1
                                AND vt.servisid=a.servisid
                                AND vt.dilkod='Turkish'
                                AND a.tutar>0
                                AND a.servisvarlikid=sv.id
                                AND a.isemirno not in
                                (SELECT DISTINCT isemirno
                                FROM ayristirmalar)
                            ORDER BY   vt.servisid ASC,  a.tamamlanmatarih DESC
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}