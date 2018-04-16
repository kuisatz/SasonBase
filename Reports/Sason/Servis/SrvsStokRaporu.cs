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
    ///  Stok Raporu
    /// </summary>
    public class SrvsStokRaporu : Base.SasonReporter
    {
        public SrvsStokRaporu()
        {
            Text = "Stok Raporu";
            SubjectCode = "SrvsStokRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Tarih" }.CreateDate());
               
            Disabled = false;
        }
        public SrvsStokRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
            this.StartDate = startDate; 
        }

        public DateTime StartDate
        {
            get { return GetParameter("param_start_date").ReporterValue.cast<DateTime>(); }
            set { SetParameterReporterValue("param_start_date", value.startOfDay()); }
        }

       
          
        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {
                //Dışarıdan Gelen Format 20171231235959 Şeklinde Olmalıdır
                case "param_start_date":
                    StartDate = Convert.ToInt64(value).toDateTime(); 
                    break; 
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
         
            string servisIdQuery = $" = {ServisId}";
            string dateQuery = ""; 

            StartDate = StartDate.startOfDay();

            dateQuery = "to_date('" + StartDate.ToString("dd/MM/yyyy") + "')";
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
                SELECT 
                       a.kod tur,
                       p.ID,
                       P.AD,
                       p.HSERVISID,
                       p.KOD,
                       p.servisstokturid,
                       P.STOKMIKTAR STOKMIKTAR,
                       p.BIRIMAD,
                       P.INDFIYAT EUROINDFIYAT,
                       P.FIYAT EUROLISTEFIYAT,
                       P.ORTALAMAMALIYET ORTALAMAMALIYET,
                       p.SERVISDEPOAD,
                       p.SERVISDEPORAFAD,
                       p.stokmiktar * p.ortalamamaliyet stoktutar,
                       p.ORJINALKOD
                  FROM(SELECT servisstokturid,
                               a.id,
                               a.servisid hservisid,
                               a.kod,
                               C.STOKMIKTAR,
                               r.ad BIRIMAD,
                               kurlar_pkg.servisstokfiyatgetir(a.id, 2, TRUNC({dateQuery}))
                                  fiyat,
                               KURLAR_PKG.STOKFIYATINDGETIR(a.id,
                                                             2,
                                                             2,
                                                             1,
                                                             0)
                               indfiyat,
                               kurlar_pkg.ORTALAMAMALIYET(a.id) ortalamamaliyet,
                               d.ad SERVISDEPOAD,
                               p.ad SERVISDEPOrafAD,
                               a.ad,
                               CASE WHEN orj.orjinalgkod IS NULL THEN a.kod ELSE orj.orjinalgkod END ORJINALKOD
                          FROM(SELECT DISTINCT servisstokid
                                  FROM sason.servisstokhareketdetaylar) h,
                               sason.servisstoklar a,
                               sason.vt_genelstok c,
                               sason.vw_birimler r,
                               sason.servisdepolar d,
                               sason.servisdeporaflar p,
                               (SELECT m1.id malzemeid,
                                  m1.kod,
                                  m1.gkod,
                                  m2.kod orjinalkod,
                                  m2.gkod orjinalgkod,
                                  m1.orjinalmalzemeid
                                FROM malzemeler m1, malzemeler m2
                                WHERE m1.orjinalmalzemeid = M2.ID) orj 
                         WHERE     h.servisstokid = a.id
                               AND A.ID = C.SERVISSTOKID
                               AND C.STOKMIKTAR <> 0
                               AND a.servisid = c.servisid
                               AND r.dilkod = 'Turkish'
                               AND A.SERVISDEPOID = d.id(+)
                               AND A.kod = orj.kod(+)
                               AND a.servisdeporafid = p.id(+)
                               AND r.id = a.birimid) p,
                       servisstokturler a
                 WHERE p.servisstokturid = a.id AND hservisid {servisIdQuery} 
 
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}