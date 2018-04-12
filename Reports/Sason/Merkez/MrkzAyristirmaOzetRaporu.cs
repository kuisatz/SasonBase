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
                (select vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = a.servisid  and vtsx.dilkod = 'Turkish') as partnercode,
                (Select vtsxy.ISORTAKAD FROM vt_servisler vtsxy where  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = a.servisid) as servisad,             
                DECODE (a.turid,
                    1, 'Malzeme',
                    2, 'İşçilik',
                    3, 'Diğer Kalem',
                    4, 'Dış Hizmet') as Turu,
                b.dahili,
                a.harici,
                c.garanti,
                a.servisid
            FROM (  SELECT 
                        ROUND (SUM (d.atutar), 0) harici, 
                        turid, 
                        a.servisid
                    FROM ayristirmalar a, ayristirmadetaylar d
                    WHERE 
                        a.id = d.ayristirmaid AND 
                        a.durumid = 1 AND   
                        a.servisid {servisIdQuery} AND 
                        a.ayristirmatipid = 1  AND 
                        a.tarih between  '{dateQuery}' 
                    GROUP BY turid, a.servisid) a,
                (SELECT 
                    ROUND (SUM(d.atutar), 0) dahili, 
                    turid, 
                    a.servisid
                FROM ayristirmalar a, ayristirmadetaylar d
                WHERE 
                    a.id = d.ayristirmaid AND 
                    a.durumid = 1 AND 
                    a.servisid {servisIdQuery} AND 
                    a.ayristirmatipid = 2 AND 
                    a.tarih between  '{dateQuery}' 
                GROUP BY turid, a.servisid) b,
                ( SELECT 
                    ROUND (SUM(d.pdftoplam), 0) garanti, 
                    turid, 
                    a.servisid
                FROM ayristirmalar a, ayristirmadetaylar d
                WHERE 
                    a.id = d.ayristirmaid AND 
                    a.tarih between  '{dateQuery}'  AND
                    a.servisid {servisIdQuery} AND 
                    a.durumid = 1 AND 
                    a.ayristirmatipid NOT IN (1, 2) AND 
                    icmalid IS NOT NULL 
                    GROUP BY turid, a.servisid) c
            WHERE     
            a.turid = b.turid(+) AND 
            a.turid = c.turid(+) AND 
            A.SERVISID = b.servisid(+) AND 
            a.servisid = c.servisid(+)   
            ORDER BY servisad  desc 
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}