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
    /// Merkez Sözleşme Özet Listesi
    /// </summary>
    public class MrkzSozlesmeOzetListesi : Base.SasonMerkezReporter
    {
        public MrkzSozlesmeOzetListesi()
        {
            Text = "Sözleşme Özet Listesi";
            SubjectCode = "MrkzSozlesmeOzetListesi";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            Disabled = false;
        }
        public MrkzSozlesmeOzetListesi(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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

        public string SaseNo
        {
            get { return GetParameter("param_sase_no").ReporterValue.toString(); }
            set { SetParameterReporterValue("param_sase_no", value.toString()); }
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
                case "param_sase_no":
                    SaseNo = value.toString();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            string dateQuery = "";
            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";

            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 

                        SELECT
                            V.Ad, 
                            A.Saseno, 
                            Bgrup.Kod AS Bakim_Grubu,
                            Bst.Kod AS Sozlesme_Tipi, 
                            Bksoz.Bastarih AS Baslangic_Tarihi, 
                            Bksoz.Bittarih AS Bitis_Tarihi,
                            Bksoz.Bakimadedi, 
                            Bksoz.Oncekibakimadedi, 
                            Bksoz.Kullanilan, 
                            Bksoz.Tutar, 
                            Pb.Kod ,
                            (CASE 
                                WHEN Bksoz.Durumid=1 THEN 'AKTIF'
                                ELSE 'PASIF'
                            END) AS Sozlesme_Durum,
                            Bksoz.Km,
                            Bksoz.Saat,
                            Bksoz.Litre
                        FROM
                            Bakimsozlesmeler Bksoz, 
                            Bakimgruplar Bgrup, 
                            Araclar A, 
                            Bakimsozlesmetipler Bst, 
                            Varliklar V, 
                            Parabirimler Pb
                        WHERE
                            Bksoz.Bakimgrupid=Bgrup.Id AND
                            A.Id=Bksoz.Aracid AND
                            Bksoz.Bakimsozlesmetipid=Bst.Id AND
                            Bksoz.Varlikid=V.Id AND
                            Pb.Id=Bksoz.Parabirimid AND
                            (A.Saseno = NVL('{SaseNo}', A.Saseno)) AND
                            Bksoz.Bastarih BETWEEN '{dateQuery}'
                        ORDER BY Bksoz.Id DESC

                ")
            .GetDataTable(mr)
            .ToModels();


            CloseCustomAppPool();
            return queryResults;
        }

    }
}