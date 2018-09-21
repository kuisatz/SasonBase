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
    /// Merkez Reçete bulunabilirlik raporu
    /// </summary>
    public class MrkzReceteBulunabilirlik : Base.SasonMerkezReporter
    {
        public MrkzReceteBulunabilirlik()
        {
            Text = "[YP-7] Reçete Bulunabilirlik Raporu";
            SubjectCode = "MrkzReceteBulunabilirlik";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            //   AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            //   AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_recete", Text = "Reçete" }.CreateRecetelerSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true)); 
            Disabled = false;
        }
        public MrkzReceteBulunabilirlik(decimal servisId, decimal receteId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
            //    this.StartDate = startDate;
            //    this.FinishDate = finishDate;
           // this.ReceteId = receteId;
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

        public List<decimal> ReceteIds
        {
            get { return GetParameter("param_recete").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_recete", value); }
        }

        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {
         /*       //Dışarıdan Gelen Format 20171231235959 Şeklinde Olmalıdır
                case "param_start_date":
                    StartDate = Convert.ToInt64(value).toDateTime();
                    break;
                case "param_finish_date":
                    FinishDate = Convert.ToInt64(value).toDateTime();
                    break;
         */       case "param_servisler":
                    ServisIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
                  case "param_recete":
                    ReceteIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;

            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            decimal selectedServisId = ServisIds.first().toString("0").cto<decimal>();
            string servisIdQuery = $" = {selectedServisId}";
            //  string dateQuery = "";
            decimal selectedReceteId = ReceteIds.first().toString("0").cto<decimal>();
            string receteIDQuery = $" = {selectedReceteId}";

            if (ServisIds.isNotEmpty())
                servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            else { 
            //    servisIdQuery = $" > 1 ";
                selectedServisId = ServisId;
                servisIdQuery = $" in( {selectedServisId} )";
            }

            if (ReceteIds.isNotEmpty())
                receteIDQuery = $" in ({ReceteIds.joinNumeric(",")}) ";
            else
            {
                selectedReceteId = 756;
                receteIDQuery = $" in( {selectedReceteId} )";
            }
            /*
                        StartDate = StartDate.startOfDay(); 
                        FinishDate = FinishDate.endOfDay();
                        dateQuery = ""+StartDate.ToString("dd/MM/yyyy") +  "' AND '"+ FinishDate.ToString("dd/MM/yyyy")+"";
               */
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
                SELECT 
                  (SELECT vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = b.SERVISID  and vtsx.dilkod = 'Turkish') as partnercode,
                   (SELECT vtsxy.ISORTAKAD FROM vt_servisler vtsxy where  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = b.SERVISID   )  as servisad,  
                    b.*,
                    stok-miktar fark,
                    case when stok-miktar > -1 then 0 
                         when stok-miktar < 0 then  (stok-miktar)*kurlar_pkg.malzemefiyatindgetir(malzemeid,1,2)   end TUTAR  
                from (SELECT a.*,sason.servisstok(sason.getservisstokid(a.malzemeid,servisid)) stok from (
                  SELECT 
                         l.gkod,
                         l.ad,
                         S.SERVISID,
                         l.malzemeid,
                         MAX (miktar) miktar,
                         b.ad birimad,
                         R.KOD
                    FROM (SELECT * from receteler where id {receteIDQuery} ) r,
                         servisreceteler s,
                         recetemalzemeler m,
                         mt_malzemeler l,
                         vw_birimler b
                   WHERE  
                        r.id = m.receteid
                         AND S.RECETEID = r.id
                         AND m.birimid = b.id
                         and b.dilkod='Turkish'
                         and l.malzemeid=m.malzemeid
                GROUP BY l.gkod, l.ad, l.malzemeid, s.servisid, b.ad ,R.KOD) a 
                    where servisid {servisIdQuery} ) b
                    order by kod , ad  
       
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}