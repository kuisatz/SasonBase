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
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_aractip", Text = "Araç Tipi" }.CreateAracTipSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_aractur", Text = "Araç Türü" }.CreateAracTurSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_ariza_kod", Text = "Arıza Kod" }.CreateTextBox("İsteğe Bağlı Arıza Kod (7) Girebilirsiniz"));
            Disabled = false;
        }
        public MrkzTop20ArizaRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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

        public string ArizaKod
        {
            get { return GetParameter("param_ariza_kod").ReporterValue.toString(); }
            set { SetParameterReporterValue("param_ariza_kod", value.toString()); }
        }

        public List<decimal> AracTipIds
        {
            get { return GetParameter("param_aractip").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_aractip", value); }
        }

        public List<decimal> AracTurIds
        {
            get { return GetParameter("param_aractur").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_aractur", value); }
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
                case "param_ariza_kod":
                    ArizaKod = value.toString();
                    break; 
                case "param_aractip":
                    AracTipIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
                case "param_aractur":
                    AracTurIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;

            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            string servisIdQuery1 = $" =  {ServisId} ";

            #region tarih
            string dateQuery = "";
        //    string addSQLSelect = "  ARAC_TURU, ";
            string AracTurIdQuery = ""; //  $" = {selectedAracTurId}";
           
         
            decimal selectedServisId = 94; //  ServisIds.first().toString("0").cto<decimal>();
            #endregion

            #region servisidz
        //    decimal selectedServisId = ServisId;
            string servisIdQuery = ""; // $" = {selectedServisId}";

 
            servisIdQuery = $" AND E_SSI31_FORM.SERVISID IN ( {ServisId} )";



            if (ServisIds.isNotEmpty())          
                 servisIdQuery = $" AND E_SSI31_FORM.SERVISID IN ({ServisIds.joinNumeric(",")}) ";
            else
            {              
              //  selectedServisId = ServisId;
             //   servisIdQuery = $" AND E_SSI31_FORM.SERVISID IN ( {selectedServisId} )";
            }
            #endregion

            #region aracturz
            // decimal selectedAracTurId = AracTurIds.first().toString("0").cto<decimal>();
            //  decimal selectedAracTurId = 0; 
          
          

            if (AracTurIds.isNotEmpty())
           //  if (AracTurIds.Count > 0 )
                    AracTurIdQuery = $"  AND ATT.ID  in ({AracTurIds.joinNumeric(",")}) ";
            else
            {            
                AracTurIdQuery = "";                              
            }
            #endregion
            string addSQLGROUP = "  ARAC_TURU, ";
            #region aractipz
            //     decimal selectedAracTipId = AracTipIds.first().toString("0").cto<decimal>();
            string AracTipIdQuery = ""; // $" = {selectedAracTipId}";
            string addSQLAracTur = "";

           //  if (AracTipIds.Count > 0 )
             if (AracTipIds.isNotEmpty())
                {
                    addSQLAracTur = $"    CONCAT(CONCAT(E_SSI31_FORM.VEHICLETYPE,' - '), ATP.KOD) AS ARAC_TURU,  ";         
                    AracTipIdQuery =  $"  AND ATP.ID  in ({AracTipIds.joinNumeric(",")}) ";
                    addSQLGROUP = addSQLGROUP + $"  aractipi,  ";
                }
            else
                {
                    AracTipIdQuery = "";
                    addSQLAracTur = "  E_SSI31_FORM.VEHICLETYPE AS ARAC_TURU,  ";
            }
            #endregion

            #region arizakod
            string arizaKodQuery = "";

            if (ArizaKod.Length == 7)
                arizaKodQuery =  
                       $"  AND ( SUBSTR(e_ssi31_form.islemarizakod, 1, 7) ) =  '{ArizaKod}' ";
            else
                arizaKodQuery = "";

            #endregion

            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";

            MethodReturn mr = new MethodReturn();
            #region eskisql
            /* List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 

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
            */
            #endregion

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
                
                SELECT
                    SERVIS_ADI,                        
                    AYRISTIRMA_TIPI,                        
                    ARAC_TURU,
                    arizakod, 
                    count(arizakod) as adet,
                    (SELECT vtsx.partnercode FROM vt_servisler vtsx where vtsx.servisid = SERVISID and vtsx.dilkod = 'Turkish'  and rownum <2) as partnercode
                FROM (
                    SELECT
                        E_SSI31_FORM.SERVISID, 
                        LIVEFLOWS.RDATE AS TALEP_TARIHI,                      
                        FLOWSTATUSES.DESCRIPTION AS STATU,
                        e_ssi31_form.FIRMAAD AS SERVIS_ADI,   
                        ATP.ID aractipi,                     
                        (SELECT t.ad
                        FROM vw_ayristirmatipler t, ayristirmalar a
                        WHERE a.ayristirmatipid = t.id
                            AND a.id = e_ssi31_form.ayristirmaid
                            AND dilkod = 'Turkish') AS AYRISTIRMA_TIPI,                        
                           /*  E_SSI31_FORM.VEHICLETYPE AS ARAC_TURU, */ 
                            {addSQLAracTur}
                            e_ssi31_form.islemarizakod AS ARIZA_KODU,                            
                            e_ssi31_form.modelnum AS ARAC_MODEL,
                            SUBSTR(e_ssi31_form.islemarizakod, 1, 7) arizakod
                        FROM FLOWDOCUMENTS
                        INNER JOIN LIVEFLOWS ON FLOWDOCUMENTS.PROCESSID = LIVEFLOWS.ID
                        INNER JOIN e_ssi31_form ON FLOWDOCUMENTS.FILEPROFILEID = e_ssi31_form.ID
                        INNER JOIN FLOWSTATUSES ON LIVEFLOWS.STATUS = FLOWSTATUSES.STATUS
                            AND LIVEFLOWS.PROCESS = FLOWSTATUSES.PROCESS
                            AND LIVEFLOWS.FLOWVERSION = FLOWSTATUSES.VERSION
                        INNER JOIN OSUSERS ON LIVEFLOWS.USERID = OSUSERS.ID
                        INNER JOIN SASON.ARACLAR ARC ON ARC.SASENO = E_SSI31_FORM.SASENO AND ARC.DURUMID = 1
                        LEFT JOIN SASON.ARACTURLER att ON ATT.ID = ARC.ARACTURID AND ATT.DURUMID = 1  
                        LEFT JOIN SASON.ARACTIPLER atp ON ATP.ID = ARC.ARACTIPID AND ATP.DURUMID = 1  
                        WHERE LIVEFLOWS.DELETED = 0
                             AND(SELECT COUNT(*)
                                FROM FLOWREQUESTS
                                WHERE PROCESSID = LIVEFLOWS.ID) > 1
                             AND LIVEFLOWS.DELETED = 0
                             AND LIVEFLOWS.STATUS > 1
                             AND LIVEFLOWS.RDATE BETWEEN '{dateQuery}'
                             {AracTurIdQuery}
                             {AracTipIdQuery} 
                             {arizaKodQuery}
                             {servisIdQuery}
                ) asd
                GROUP BY
                    SERVIS_ADI, 
                    AYRISTIRMA_TIPI,
                    {addSQLGROUP} 
                    arizakod
                    ORDER BY adet DESC                     
                       
 

                " )
            .GetDataTable(mr)
            .ToModels();


            CloseCustomAppPool();
            return queryResults;
        }

    }
}