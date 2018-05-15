using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SasonBase.Reports.Sason.Merkez
{
    /// <summary>
    /// Merkez Aksiyon Yazışma Geçmişi
    /// </summary>
    public class MrkzAksiyonYazismaGecmisi : Base.SasonMerkezReporter
    {
        public MrkzAksiyonYazismaGecmisi()
        {
            Text = "Aksiyon Yazışma Geçmişi";
            SubjectCode = "MrkzAksiyonYazismaGecmisi";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            Disabled = true;
        }

        public MrkzAksiyonYazismaGecmisi(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
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
            //decimal selectedServisId = ServisIds.first().toString("0").cto<decimal>();
            //string servisIdQuery = $" = {selectedServisId}";
            string dateQuery = "";

//#if DEBUG
//            selectedServisId = ServisId;
//            servisIdQuery = $" = {selectedServisId}";
//#endif

//            if (ServisIds.isNotEmpty())
//                servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
//            else
//            {
//                //    servisIdQuery = $" > 1 ";
//                selectedServisId = ServisId;
//                servisIdQuery = $" in( {selectedServisId} )";
//            }

            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";


            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"     
                        SELECT
                            m.kod AS MEKTUP_ADI,
                            m.tarih AS MEKTUP_TARIH,
                            ma.id AS MEKTUP_ID, 
                            ma.saseno, 
                            var.ad AS MUSTERI_ADI,
                            mektip.kod AS MEKTUP_TIPI, 
                            aks.ad,
                            aks.haricino,
                            aks.arizakodu,
                            aks.bastarih AS AKSIYON_BASLANGICTARIH, 
                            aks.bittarih AS AKS_BITISTARIH,
                            ads.adres
                        FROM
                            mektuplar m, 
                            mektuparaclar ma, 
                            varliklar var, 
                            mektuptipler mektip,
                            aksiyonlar aks, 
                            adresler ads

                        WHERE

                            m.id=ma.mektupid
                            AND var.id=m.varlikid
                            AND mektip.id=m.mektuptipid
                            AND aks.id=m.aksiyonid
                            AND ads.id(+)=m.adresid
                        ORDER BY mektup_tarih DESC
            
            ")
            .GetDataTable()
            .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}