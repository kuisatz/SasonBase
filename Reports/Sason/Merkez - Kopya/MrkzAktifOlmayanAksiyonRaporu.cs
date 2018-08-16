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
    ///EOI ile bilgisi gelen ancak henüz aktif olmayan aksiyonlar kaydı (log) 
    ///Aktif Olmayan Aksiyon Raporu
    /// </summary>
    public class MrkzAktifOlmayanAksiyonRaporu : Base.SasonMerkezReporter
    {
        public MrkzAktifOlmayanAksiyonRaporu()
        {
            Text = "Açılmamış Aksiyon Raporu";
            SubjectCode = "MrkzAktifOlmayanAksiyonRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            Disabled = false;
        }
        public MrkzAktifOlmayanAksiyonRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
            string dateQuery = "";

            StartDate = StartDate.startOfDay(); 
            FinishDate = FinishDate.endOfDay();
            dateQuery = ""+StartDate.ToString("dd/MM/yyyy") +  "' AND '"+ FinishDate.ToString("dd/MM/yyyy")+"";
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
                      SELECT EXTRECALLNUM AS HARICI_NO,
                             INTRECALLNUM AS DAHLI_NO,
                             WARRANTYCLAIMTYPE AS GARANTI_TIPI,
                             REFDATE AS BASLANGIC_TARIHI,
                             RECALLVALIDTO AS BITIS_TARIHI,
                             WARRANTYCLAIMNUM AS GARANTI_NUMARASI,
                             --TXTTABLECOUNTER,
                             DocAppendix AS DOKUMAN_LINKI,
                             DamageCode AS ARIZA_KODU,
                             SIShortText AS KISA_ACIKLAMA,
                             --WarrantyClaimType,
                             Priority AS ONCELIK
         
                       FROM MX_VIS_SERVICEINFODETAILS a

                       WHERE refdate IS NOT NULL and 
                             
                             extrecallnum not in (SELECT refaksiyonid FROM aksiyonlar WHERE refaksiyonid is not null)
       
                       GROUP BY EXTRECALLNUM,
                             INTRECALLNUM,
                             WARRANTYCLAIMTYPE,
                             REFDATE,
                             RECALLVALIDTO,
                             WARRANTYCLAIMNUM,
                             TXTTABLECOUNTER,
                             DocAppendix,
                             DamageCode,
                             SIShortText,
                             WarrantyClaimType,
                             Priority
         
                        ORDER BY 1 DESC

                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}