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
    /// Top 20 Arıza Listesi Raporu
    /// </summary>
    public class MrkzTop20ArizaRaporu : Base.SasonMerkezReporter
    {
        public MrkzTop20ArizaRaporu()
        {
            Text = "Top 20 Arıza Listesi Raporu";
            SubjectCode = "MrkzTop20ArizaRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            Disabled = false;
        }
        public MrkzTop20ArizaRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";

            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 

                    SELECT   OSUSERS.FIRSTNAME || ' ' || OSUSERS.LASTNAME AS AkisiBaslatan,
                             LIVEFLOWS.RDATE AS TALEP_TARIHI,
                             LIVEFLOWS.FDATE AS ONAY_TARIHI,
                             FLOWSTATUSES.DESCRIPTION AS STATU,
                             e_ssi31_form.FIRMAAD AS SERVIS_ADI,
                             e_ssi31_form.garantituru,
                             e_ssi31_form.garantistatu,
                             e_ssi31_form.garantirednedenid_text AS GARANTI_RED_NEDENI,
                             (SELECT esagarantino
                                FROM ayristirmalar g
                               WHERE g.id = e_ssi31_form.ayristirmaid) AS ESAGARANTINO,
                             (SELECT t.ad
                                FROM vw_ayristirmatipler t, ayristirmalar a
                               WHERE     a.ayristirmatipid = t.id
                                     AND a.id = e_ssi31_form.ayristirmaid
                                     AND dilkod = 'Turkish') AS AYRISTIRMA_TIPI,
                             e_ssi31_form.servisgarantino,
                             E_SSI31_FORM.VEHICLETYPE AS ARAC_TIPI,
                             e_ssi31_form.saseno,
                             e_ssi31_form.isemirno,
                             e_ssi31_form.islemarizakod AS ARIZA_KODU,
                             e_ssi31_form.islemtipad AS ISLEM_TIPI,
                             e_ssi31_form.firstregdate AS TRAFIGE_CIKIS_TARIHI,
                             e_ssi31_form.exworksdate AS FABRIKA_CIKIS_TARIHI,
                             e_ssi31_form.modelnum AS ARAC_MODEL,
                             e_ssi31_form.engineserialnum AS MOTOR_NO,
                             e_ssi31_form.engineunittype AS MOTOR_TIPI,
                             e_ssi31_form.pkm AS ARAC_KM
                        FROM FLOWDOCUMENTS
                             INNER JOIN LIVEFLOWS ON FLOWDOCUMENTS.PROCESSID = LIVEFLOWS.ID
                             INNER JOIN e_ssi31_form ON FLOWDOCUMENTS.FILEPROFILEID = e_ssi31_form.ID
                             INNER JOIN FLOWSTATUSES ON LIVEFLOWS.STATUS = FLOWSTATUSES.STATUS
                                   AND LIVEFLOWS.PROCESS = FLOWSTATUSES.PROCESS
                                   AND LIVEFLOWS.FLOWVERSION = FLOWSTATUSES.VERSION
                             INNER JOIN OSUSERS ON LIVEFLOWS.USERID = OSUSERS.ID
                       WHERE     LIVEFLOWS.DELETED = 0
                             AND(SELECT COUNT(*)
                                    FROM FLOWREQUESTS
                                   WHERE PROCESSID = LIVEFLOWS.ID) > 1
                             AND LIVEFLOWS.DELETED = 0
                             AND LIVEFLOWS.STATUS > 1 
                             AND LIVEFLOWS.RDATE BETWEEN '{dateQuery}'
                       ORDER BY LIVEFLOWS.RDATE DESC

            ")
            .GetDataTable(mr)
            .ToModels();


            CloseCustomAppPool();
            return queryResults;
        }

    }
}