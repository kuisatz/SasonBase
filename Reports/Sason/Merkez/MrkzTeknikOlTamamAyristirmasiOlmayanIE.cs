using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SasonBase.Reports.Sason.Merkez
{
    /// <summary>
    /// Merkez Teknik Ol Tamam Ayristirmasi Olmayan IE
    /// </summary>
    public class MrkzTeknikOlTamamAyristirmasiOlmayanIE : Base.SasonMerkezReporter
    {
        public MrkzTeknikOlTamamAyristirmasiOlmayanIE()
        {
            Text = "Teknik Olarak Tamamlanmış Ayrıştırması Yapılmamış İş Emri Raporu";
            SubjectCode = "MrkzTeknikOlTamamAyristirmasiOlmayanIE";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            Disabled = false;
        }

        public MrkzTeknikOlTamamAyristirmasiOlmayanIE(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
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
                   
            ")
            .GetDataTable()
            .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}