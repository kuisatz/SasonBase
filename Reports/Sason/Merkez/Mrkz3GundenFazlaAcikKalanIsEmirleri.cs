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
    /// Merkez 3 Günden Fazla Açık Kalan İş Emirleri Raporu
    /// </summary>
    public class Mrkz3GundenFazlaAcikKalanIsEmirleri : Base.SasonMerkezReporter
    {
        public Mrkz3GundenFazlaAcikKalanIsEmirleri()
        {
            Text = "3 Günden Fazla Açık Kalan İş Emirleri";
            SubjectCode = "Mrkz3GundenFazlaAcikKalanIsEmirleri";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
      //      AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
      //      AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_min_gun", Text = "Min Gün" }.CreateTextBox("İsteğe Bağlı Min Gün Sayısı"));
            AddParameter(new ReporterParameter() { Name = "param_max_gun", Text = "Max Gün" }.CreateTextBox("İsteğe Bağlı Max Gün Sayısı"));
            Disabled = false;
            this.MinGun = "0";
            this.MaxGun = "0";
        }
        public Mrkz3GundenFazlaAcikKalanIsEmirleri(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
            this.MinGun = "0";
            this.MaxGun = "0";
            //      this.FinishDate = finishDate;
        }

    /*    public DateTime StartDate
        {
            get { return GetParameter("param_start_date").ReporterValue.cast<DateTime>(); }
            set { SetParameterReporterValue("param_start_date", value.startOfDay()); }
        }

        public DateTime FinishDate
        {
            get { return GetParameter("param_finish_date").ReporterValue.cast<DateTime>(); }
            set { SetParameterReporterValue("param_finish_date", value.endOfDay()); }
        }
*/
        public List<decimal> ServisIds
        {
            get { return GetParameter("param_servisler").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_servisler", value); }
        }
        public string MinGun
        {
            get { return GetParameter("param_min_gun").ReporterValue.toString(); }
            set { SetParameterReporterValue("param_min_gun", value.toString()); }
        }
        public string MaxGun
        {
            get { return GetParameter("param_max_gun").ReporterValue.toString(); }
            set { SetParameterReporterValue("param_max_gun", value.toString()); }
        }

        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {
                //Dışarıdan Gelen Format 20171231235959 Şeklinde Olmalıdır
            /*    case "param_start_date":
                    StartDate = Convert.ToInt64(value).toDateTime();
                    break;
                case "param_finish_date":
                    FinishDate = Convert.ToInt64(value).toDateTime();
                    break; */
                case "param_servisler":
                    ServisIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
                case "param_min_gun":
                    MinGun = value.toString();
                    break;
                case "param_max_gun":
                    MaxGun = value.toString();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            decimal selectedServisId = ServisIds.first().toString("0").cto<decimal>();
            string servisIdQuery = $" = {selectedServisId}";
            string dateQuery = "";
            string dateGunQuery1 = "";
            string dateGunQuery2 = "";
            int MinGun1 = int.Parse(MinGun);
            int MaxGun1 = int.Parse(MaxGun);


#if DEBUG
             selectedServisId = ServisId;
              servisIdQuery = $" in( {selectedServisId} )";
#endif


            if (ServisIds.isNotEmpty())
                servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            else { 
            //    servisIdQuery = $" > 1 ";
                selectedServisId = ServisId;
                servisIdQuery = $" in( {selectedServisId} )";
            }

            if (MinGun1 > 0)
            {
                dateGunQuery1 = " AND acikkalmagunu >= "+ MinGun;              
            }
            if (MaxGun1 > 0)
            {
                dateGunQuery2 = " AND acikkalmagunu <= " + MaxGun;
            }


            //        StartDate = StartDate.startOfDay(); 
            //       FinishDate = FinishDate.endOfDay();
            //        dateQuery = ""+StartDate.ToString("dd/MM/yyyy") +  "' AND '"+ FinishDate.ToString("dd/MM/yyyy")+"";
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
  
                    SELECT * 
                    FROM (
                         SELECT ie1.servisid AS servisid, 
                         srv.partnercode AS serviskodu, 
                         srv.isortakad AS servisadi, 
                         ie1.isemirno AS isemirno, 
                         ie1.kayittarih AS kayittarihi,
                         SYSDATE raporgunu, 
                         ROUND( SYSDATE - ie1.kayittarih) acikkalmagunu,
                         CASE WHEN ie1.arackazali = 1 
                                THEN 'EVET'
                              ELSE 'HAYIR' 
                         END arac_kazali, 
                         TO_CHAR(ie1.araccikiszamani,'dd.mm.yyyy') AS araccikiszamani,
                         CASE WHEN ie1.aracserviste = 0 
                                THEN 'HAYIR'
                              ELSE 'EVET'
                         END  arac_servis_disinda,
                         CASE WHEN servar.varliktipid=3 
                                THEN 'EVET'
                              ELSE 'HAYIR'
                         END kamu,
                         ie1.aciklama AS aciklama 

                         FROM (SELECT * 
                               FROM servisisemirler 
                               WHERE teknikolaraktamamla = 0 AND tamamlanmatarih IS NULL) ie1
                         LEFT JOIN vt_servisler srv ON srv.dilkod = 'Turkish' AND srv.servisid = ie1.servisid
                         INNER JOIN servisvarliklar servar ON servar.id=ie1.servisvarlikid
                    )

                    WHERE acikkalmagunu > 3 
                         AND servisid {servisIdQuery} 

                    ORDER BY servisid,kayittarihi ASC

                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}