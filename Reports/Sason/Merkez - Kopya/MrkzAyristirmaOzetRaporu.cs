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
    /// Ayrıştırma Özet Raporu
    /// </summary>
    public class MrkzAyristirmaOzetRaporu : Base.SasonMerkezReporter
    {
        public MrkzAyristirmaOzetRaporu()
        {
            Text = "Ayrıştırma Özet Raporu";
            SubjectCode = "MrkzAyristirmaOzetRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true)); 
            Disabled = false;
        }
        public MrkzAyristirmaOzetRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
                        (SELECT vtsx.partnercode FROM vt_servisler vtsx WHERE vtsx.servisid = a.servisid  AND vtsx.dilkod = 'Turkish') AS partnercode,
                        (SELECT vtsxy.ISORTAKAD FROM vt_servisler vtsxy WHERE  vtsxy.dilkod = 'Turkish' AND vtsxy.servisid = a.servisid) AS servisad,             
                        DECODE (a.turid,
                            1, 'Malzeme',
                            2, 'İşçilik',
                            3, 'Diğer Kalem',
                            4, 'Dış Hizmet') AS Turu,
                        b.dahili,
                        a.harici,
                        c.garanti,
                        d.uzatilmisgaranti,
                        e.aksiyond,
                        f.traksiyon,
                        g.yedekparcagarantisi,
                        h.kanf,
                        i.kvsa,
                        j.reku,
                        k.erwc,
                        l.hediyepaketi,
                        m.bakimpaketi,
                        n.aksiyon,
                        o.comfort,
                        p.comfortplus,
                        r.comfortsuper,
                        a.servisid
                    FROM (SELECT 
                            ROUND (SUM (d.atutar), 0) harici, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.durumid = 1 AND   
                            a.servisid {servisIdQuery} AND 
                            a.ayristirmatipid = 1  AND 
                            a.tarih BETWEEN  '{dateQuery}'
                        GROUP BY turid, a.servisid) a,
     
                        (SELECT 
                            ROUND (SUM(d.atutar), 0) dahili, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.durumid = 1 AND 
                            a.servisid {servisIdQuery} AND 
                            a.ayristirmatipid = 2 AND 
                            a.pdfgarantitarihi BETWEEN  '{dateQuery}' 
                        GROUP BY turid, a.servisid) b,
     
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) garanti, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN  '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 3 AND 
                            icmalid IS NOT NULL 
                            GROUP BY turid, a.servisid) c,
                    
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) uzatilmisgaranti, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN  '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 4  AND 
                            icmalid IS NOT NULL 
                        GROUP BY turid, a.servisid) d,
                    
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) aksiyond, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN  '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 5 AND 
                            icmalid IS NOT NULL 
                        GROUP BY turid, a.servisid) e,
                    
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) traksiyon, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN  '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 6 AND 
                            icmalid IS NOT NULL 
                        GROUP BY turid, a.servisid) f,
                    
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) yedekparcagarantisi, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN  '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 7 AND 
                            icmalid IS NOT NULL 
                        GROUP BY turid, a.servisid) g,
                    
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) kanf, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN  '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 8 AND 
                            icmalid IS NOT NULL 
                        GROUP BY turid, a.servisid) h,
                    
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) kvsa, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN  '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 9 AND 
                            icmalid IS NOT NULL 
                        GROUP BY turid, a.servisid) i,
                    
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) reku, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN  '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 10 AND 
                            icmalid IS NOT NULL 
                        GROUP BY turid, a.servisid) j,
                    
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) erwc, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 11 AND 
                            icmalid IS NOT NULL 
                        GROUP BY turid, a.servisid) k,
                    
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) hediyepaketi, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN  '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 12 AND 
                            icmalid IS NOT NULL 
                        GROUP BY turid, a.servisid) l,
                    
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) bakimpaketi, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN  '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 13 AND 
                            icmalid IS NOT NULL 
                        GROUP BY turid, a.servisid) m,
                    
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) aksiyon, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 14 AND 
                            icmalid IS NOT NULL 
                        GROUP BY turid, a.servisid) n,
                    
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) comfort, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 15 AND 
                            icmalid IS NOT NULL 
                        GROUP BY turid, a.servisid) o,
                    
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) comfortplus, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN  '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 16 AND 
                            icmalid IS NOT NULL 
                        GROUP BY turid, a.servisid) p,
                    
                        (SELECT 
                            ROUND (SUM(d.pdftoplam), 0) comfortsuper, 
                            turid, 
                            a.servisid
                        FROM ayristirmalar a, ayristirmadetaylar d
                        WHERE a.id = d.ayristirmaid AND 
                            a.pdfgarantitarihi BETWEEN '{dateQuery}' and
                            a.servisid {servisIdQuery} AND 
                            a.durumid = 1 AND 
                            a.ayristirmatipid = 17 AND 
                            icmalid IS NOT NULL 
                        GROUP BY turid, a.servisid) r

                    WHERE a.turid = b.turid(+) AND 
                            a.turid = c.turid(+) AND 
                            a.turid = d.turid(+) AND 
                            a.turid = e.turid(+) AND 
                            a.turid = f.turid(+) AND 
                            a.turid = g.turid(+) AND 
                            a.turid = h.turid(+) AND 
                            a.turid = i.turid(+) AND 
                            a.turid = j.turid(+) AND 
                            a.turid = k.turid(+) AND 
                            a.turid = l.turid(+) AND 
                            a.turid = m.turid(+) AND 
                            a.turid = n.turid(+) AND 
                            a.turid = o.turid(+) AND 
                            a.turid = p.turid(+) AND 
                            a.turid = r.turid(+) AND 
                 
                            a.servisid = b.servisid(+) AND 
                            a.servisid = c.servisid(+) AND  
                            a.servisid = d.servisid(+) AND 
                            a.servisid = e.servisid(+) AND 
                            a.servisid = f.servisid(+) AND 
                            a.servisid = g.servisid(+) AND 
                            a.servisid = h.servisid(+) AND 
                            a.servisid = i.servisid(+) AND 
                            a.servisid = j.servisid(+) AND 
                            a.servisid = k.servisid(+) AND 
                            a.servisid = l.servisid(+) AND 
                            a.servisid = m.servisid(+) AND 
                            a.servisid = n.servisid(+) AND 
                            a.servisid = o.servisid(+) AND 
                            a.servisid = p.servisid(+) AND 
                            a.servisid = r.servisid(+)
            
                    ORDER BY servisad  desc 

                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}