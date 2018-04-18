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
    /// Merkez Detaylı Stok Hareket Raporu
    /// </summary>
    public class MrkzDetayliStokHareketRaporu : Base.SasonMerkezReporter
    {
        public MrkzDetayliStokHareketRaporu()
        {
            Text = "Merkez Detaylı İş Emri Listesi Raporu";
            SubjectCode = "MrkzDetayliStokHareketRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true)); 
            Disabled = false;
        }
        public MrkzDetayliStokHareketRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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

            StartDate = StartDate.startOfDay(); 
            FinishDate = FinishDate.endOfDay();
            dateQuery = ""+StartDate.ToString("dd/MM/yyyy") +  "' AND '"+ FinishDate.ToString("dd/MM/yyyy")+"";
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
              SELECT 
                a.servisid,
                (SELECT vtsx.partnercode from vt_servisler vtsx WHERE vtsx.servisid = a.servisid  and vtsx.dilkod = 'Turkish') as partnercode,
                (SELECT vtsxy.ISORTAKAD FROM vt_servisler vtsxy WHERE  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = a.servisid   )  as servisad ,
                a.isemirno, 
                a.saseno, 
                a.kayittarih,
                a.Tutar,   
                a.INDIRIMLITUTAR, 
                a.PLAKA,    
                (SELECT zx.tutar/10 FROM servisiscilikfiyatlar zx WHERE zx.servisid = a.servisid and  zx.AYRISTIRMATIPID is null ) as aw 
                FROM servisisemirler a 
            inner join servisisemirislemler b on a.ID = b.SERVISISEMIRID AND b.DURUMID = 1
            left join (
                        SELECT distinct C1.servisisemirislemid, C1.TUTAR , C1.ACIKLAMA, C1.INDIRIMLITUTAR, C1.MIKTAR, H1.KOD  FROM servisismislemiscilikler c1 
                        inner join mt_iscilikler g1 ON  C1.ISCILIKID = G1.ISCILIKID AND G1.DURUMID = c1.DURUMID 
                        LEFT JOIN servisiscilikler h1 ON H1.ID = C1.SERVISISCILIKID AND h1.DURUMID = c1.DURUMID 
                        WHERE 
                            c1.DURUMID = 1 AND   
                            g1.dilkod='Turkish' 
                    )  isciliklerxx on b.id = isciliklerxx.servisisemirislemid
            left join (
                        SELECT distinct C2.SERVISISEMIRISLEMID, G2.KOD, G2.AD, C2.MIKTAR, C2.MALZEMEBIRIMFIYAT, C2.TUTAR, C2.INDIRIMLITUTAR FROM servisismislemmalzemeler c2 
                        inner join servisstoklar g2 ON  c2.SERVISSTOKID = g2.id 
                        WHERE 
                            c2.DURUMID = 1  
                    )  mmalzemelerxx on b.id = mmalzemelerxx.SERVISISEMIRISLEMID
        
            left join (
                        SELECT distinct C3.SERVISISEMIRISLEMID, C3.DIGERKALEMID, G3.KOD, C3.TUTAR, C3.INDIRIMLITUTAR, C3.MIKTAR FROM SERVISISMISLEMDKALEMLER c3 
                        inner join digerkalemler g3 ON  C3.DIGERKALEMID = g3.id 
                        WHERE 
                            c3.DURUMID = 1  
                    )  kalemlerxx on b.id=kalemlerxx.SERVISISEMIRISLEMID       
            left join (
                        SELECT distinct C4.SERVISISEMIRISLEMID, C4.ACIKLAMA, C4.TUTAR, C4.INDIRIMLITUTAR FROM SERVISISMISLEMDHIZMETLER c4         
                        WHERE 
                            c4.DURUMID = 1  
                    )  hizmetlerxx on b.id=hizmetlerxx.SERVISISEMIRISLEMID   

            WHERE
                a.KAYITTARIH between '{dateQuery}'  AND 
                a.servisid {servisIdQuery}
            
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}