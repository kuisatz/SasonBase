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
            Text = "[Grn-4] Garanti Red Raporu";
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
                      SELECT
                        A.SERVISGARANTINO,
                        j.partnercode  serviskodu,
                        A.PDFgarantiTARIHi garantitarihi,
                        A.PDFDMSNO dmsno,
                        pdftoplam gidentutar,
                        A.PDFONAYNETGENELTOPLAM gelentutar,
                        A.claimstatus statu,
                        j.isortakad yetkiliservis,
                        a.arizakodu,
                        a.CASENO,
                        a.CLAIMNO,
                        C.AD ayristirmatipi,
                        E.AD isemirislemtipi,
                        F.MUSTERIAD,
                        F.KAYITTARIH isemirbastarihi,
                        F.TAMAMLANMATARIH isemirbittarih, 
                        f.SASENO,
                        F.ISEMIRNO,
                        G.AD musteri,
                        h.regnumber plaka,
                        h.ad Turu
                    FROM ayristirmalar a,vw_ayristirmatipler c, servisisemirislemler d,vw_isemirtipler e,servisisemirler f,servisvarliklar g,
                      (SELECT a.saseno,
                        m.regnumber,
                        m.vehicletype,
                        b.ad,
                        dilkod
                    FROM araclar a,
                        esaaraclar ea,
                        vx_vis_vehiclemaster m,vw_aracturler b
                    WHERE     ea.vin = a.saseno
                        AND ea.id = m.esaaracid
                        and M.VEHICLETYPE=b.kod) h, vt_servisler j
                    where
                    a.AYRISTIRMATIPID=c.id
                    and c.dilkod='Turkish'
                    and a.SERVISISEMIRISLEMID=D.ID
                    and D.ISEMIRTIPID=E.ID
                    and e.dilkod=c.dilkod
                    and D.servisisemirid=f.id
                    and F.SERVISVARLIKID=G.ID
                    and h.saseno=f.saseno
                    and h.dilkod=c.dilkod
                    and a.servisid=j.servisid
                    and j.dilkod=e.dilkod
                    and a.tarih between '{dateQuery}'
                    and a.servisid  {servisIdQuery} 
                    and a.claimstatus in ('Z107','Z109','Z999') 
             ORDER BY a.tarih DESC 
 
                ")                          
                .GetDataTable(mr)
                .ToModels();

                
            CloseCustomAppPool();
            return queryResults;
        }

    }
}