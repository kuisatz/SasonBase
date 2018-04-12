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
    ///  Servis Hareket Raporu
    /// </summary>
    public class SrvsServisHareketRaporu : Base.SasonReporter
    {
        public SrvsServisHareketRaporu()
        {
            Text = "Servis Hareket Raporu";
            SubjectCode = "SrvsServisHareketRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
       //     AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
        //    AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            Disabled = false;
        }
        public SrvsServisHareketRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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

        //public List<decimal> ServisIds
        //{
        //    get { return GetParameter("param_servisler").ReporterValue.cast<List<decimal>>(); }
        //    set { SetParameterReporterValue("param_servisler", value); }
        //}
   /*     public string SaseNo
        {
            get { return GetParameter("param_sase_no").ReporterValue.toString(); }
            set { SetParameterReporterValue("param_sase_no", value.toString()); }
        }

            */
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
        /*        case "param_sase_no":
                    SaseNo = value.toString();
                    break;
                    */
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {

            string servisIdQuery = $" = {ServisId}";
            string dateQuery = "";

            StartDate = StartDate.startOfDay(); 
            FinishDate = FinishDate.endOfDay();
            dateQuery = ""+StartDate.ToString("dd/MM/yyyy") +  "' AND '"+ FinishDate.ToString("dd/MM/yyyy")+"";
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
            SELECT
                DISTINCT b.servisid,
                (select vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = b.servisid  and vtsx.dilkod = 'Turkish') as partnercode,
                (Select vtsxy.ISORTAKAD FROM vt_servisler vtsxy where  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = b.servisid) as servisad,
                d.kod,
                d.ad,
                a.miktar,
                br.ad BIRIM,
                A.BIRIMFIYAT ALIS_FIYATI,
                b.TARIH,
                f.faturano,
                KURLAR_PKG.CAPRAZKURTARIH (2, 1, b.TARIH) kur,
                kurlar_pkg.servisstokfiyatgetir (d.id, 2, TRUNC (SYSDATE)) as EUROLISTEFIYAT,
                KURLAR_PKG.STOKFIYATINDGETIR (d.id, 2, 2, 1,0) as EUROINDFIYAT
            FROM servisstokhareketdetaylar  a
            INNER JOIN servisstokhareketler b on B.ID = A.SERVISSTOKHAREKETID and b.parabirimid=1
            INNER JOIN servissiparisler c on c.id=b.servissiparisid and c.siparisservisid=1
            INNER JOIN servisstoklar d on d.id = A.SERVISSTOKID
            INNER JOIN faturalar f on f.id=b.faturaid
            INNER JOIN vw_birimler br on br.id=a.birimid and br.dilkod='Turkish'
            INNER JOIN servisdeporaflar dr ON d.servisdeporafid = dr.id  
            INNER JOIN servisstokturler sst ON sst.id = d.servisstokturid  
            WHERE
                a.stokislemtipdeger=1 and
                b.servisid {servisIdQuery} AND
                b.TARIH between '{dateQuery}'
            ORDER BY b.servisid , b.TARIH desc  
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}