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
    /// Merkez Garanti Red Raporu
    /// </summary>
    public class MrkzGarantiRedRaporu : Base.SasonMerkezReporter
    {
        public MrkzGarantiRedRaporu()
        {
            Text = "Garanti Red Raporu";
            SubjectCode = "MrkzGarantiRedRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            Disabled = false;
        }
        public MrkzGarantiRedRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
             

            if (ServisIds.isNotEmpty())
                servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            else
            {
                //    servisIdQuery = $" > 1 ";
                selectedServisId = ServisId;
                servisIdQuery = $" in ( {selectedServisId} )";
            }


            StartDate = StartDate.startOfDay(); 
            FinishDate = FinishDate.endOfDay();
            dateQuery = ""+StartDate.ToString("dd/MM/yyyy") +  "' AND '"+ FinishDate.ToString("dd/MM/yyyy")+"";

            MethodReturn mr = new MethodReturn(); 
                List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"   
                      SELECT -- FLOWDOCUMENTS.FILEPROFILEID,
                            --   FLOWDOCUMENTS.PROCESSID,        
                             (select vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = e_ssi31_form.SERVISID and vtsx.dilkod = 'Turkish') as partnercode,
                             (Select vtsxy.ISORTAKAD FROM vt_servisler vtsxy where  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = e_ssi31_form.SERVISID )  as servisad,          
                             OSUSERS.FIRSTNAME || ' ' || OSUSERS.LASTNAME AS AkisiBaslatan,
                             LIVEFLOWS.RDATE,
                             LIVEFLOWS.FDATE,
                             FLOWSTATUSES.DESCRIPTION,
                             FLOWSTATUSES.STATUS,         
                             e_ssi31_form.FIRMAAD,
                             e_ssi31_form.garantituru,
                             e_ssi31_form.garantistatu,
                             e_ssi31_form.garantirednedenid_text,
                             (SELECT esagarantino
                                FROM ayristirmalar g
                               WHERE g.id = e_ssi31_form.ayristirmaid)  'ESAGARANTINO',
                            (select C.KOD from bakimsozlesmeler a, araclar b, bakimsozlesmetipler c where a.aracid = b.id and c.id = A.BAKIMSOZLESMETIPID and saseno = e_ssi31_form.saseno and a.durumid = 1) bakimsozlesmetipi,
                                 e_ssi31_form.REGNUMBER PLAKA, (SELECT esastatu  FROM ayristirmalar g WHERE g.id = e_ssi31_form.ayristirmaid)  'ESASTATU',
                             (SELECT t.ad
                                FROM vw_ayristirmatipler t, ayristirmalar a
                               WHERE     a.ayristirmatipid = t.id
                                     AND a.id = e_ssi31_form.ayristirmaid
                                     AND dilkod = '<?=DILKOD>')
                                'AYRISTIRMATIPAD',
                             e_ssi31_form.servisgarantino,
                             e_ssi31_form.saseno,
                             e_ssi31_form.SERVISID,
                             e_ssi31_form.isemirno,
                          --e_ssi31_form.ISLACIKLAMA,
                             e_ssi31_form.islemarizakod,
                             e_ssi31_form.islemtipad,
                             e_ssi31_form.regnumber,
                        --e_ssi31_form.islemtipad,
                             e_ssi31_form.firstregdate,
                             e_ssi31_form.exworksdate,
                             e_ssi31_form.vehiclekm,
                             e_ssi31_form.modelnum,
                             e_ssi31_form.engineserialnum,
                             e_ssi31_form.engineunittype,
                             e_ssi31_form.pkm,
                             e_ssi31_form.uom,
                             NVL(e_ssi31_form.belgeno, '-') belgeno
                       FROM FLOWDOCUMENTS
                            INNER JOIN LIVEFLOWS ON FLOWDOCUMENTS.PROCESSID = LIVEFLOWS.ID
                             INNER JOIN e_ssi31_form
                                ON FLOWDOCUMENTS.FILEPROFILEID = e_ssi31_form.ID
                             INNER JOIN
                             FLOWSTATUSES
                                ON     LIVEFLOWS.STATUS = FLOWSTATUSES.STATUS
                                   AND LIVEFLOWS.PROCESS = FLOWSTATUSES.PROCESS
                                   AND LIVEFLOWS.FLOWVERSION = FLOWSTATUSES.VERSION
                             INNER JOIN OSUSERS ON LIVEFLOWS.USERID = OSUSERS.ID
                       WHERE LIVEFLOWS.DELETED = 0 AND
                             (SELECT COUNT(*)
                                    FROM FLOWREQUESTS
                                   WHERE PROCESSID = LIVEFLOWS.ID) > 1 AND
                             LIVEFLOWS.DELETED = 0 AND
                             LIVEFLOWS.STATUS > 1 AND
                             LIVEFLOWS.STATUS  in (22) AND 
                            e_ssi31_form.SERVISID {servisIdQuery}  AND 
                            LIVEFLOWS.RDATE BETWEEN'{dateQuery}'
                     ORDER BY LIVEFLOWS.RDATE DESC 
 
                ")                          
                .GetDataTable(mr)
                .ToModels();

                
            CloseCustomAppPool();
            return queryResults;
        }

    }
}