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
    /// Merkez Bakım Geçmişi Raporu
    /// </summary>
    public class MrkzBakimGecmisi : Base.SasonMerkezReporter
    {
        public MrkzBakimGecmisi()
        {
            Text = "Bakım Geçmişi";
            SubjectCode = "MrkzBakimGecmisi";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            //Disabled = false;
        }
        public MrkzBakimGecmisi(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
        public string SaseNo
        {
            get { return GetParameter("param_sase_no").ReporterValue.toString(); }
            set { SetParameterReporterValue("param_sase_no", value.toString()); }
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
                case "param_sase_no":
                    SaseNo = value.toString();
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
            servisIdQuery = $" = {selectedServisId}";
#endif


            if (ServisIds.isNotEmpty())
                servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            else
            {
                //    servisIdQuery = $" > 1 ";
                selectedServisId = ServisId;
                servisIdQuery = $" in( {selectedServisId} )";
            }

            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";

            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 

                        SELECT e.saseno,
                               e.kayittarih,
                               e.tamamlanmatarih,
                               e.km,
                               e.endeks AS litre,
                               e.saat,
                               --E.TBITISTARIHI,
                               e.isemirno,
                               t.isortakad,
                               bakimtoplu AS bakim_no,
                               t.partnercode AS yskod,
                               CASE 
                                  WHEN bakimstatu =1 THEN  'TAM' 
                                  WHEN bakimstatu =0 THEN 'EKSIK' 
                                  ELSE 'HATALI'
                               END AS bakimstatu,
                                a.esagarantino, 
                                a.servisgarantino, 
                                a.claimstatus
                        FROM servisisemirler e,
                             servisisemirislemler i,
                             vt_servisler t,
                             ayristirmalar a 

                        WHERE  e.kayittarih BETWEEN '{dateQuery}'  
                             AND e.id = i.servisisemirid 
                             AND isemirtipid =1 
                             AND (e.saseno = NVL ('{SaseNo}', e.saseno)) 
                             AND t.servisid = e.servisid
                             AND e.isemirno=a.isemirno
                             AND e.servisid  {servisIdQuery}
                             AND t.dilkod='Turkish'
                             AND e.tamamlanmatarih IS NOT NULL
                             AND bakimtoplu IS NOT NULL
                             AND e.teknikolaraktamamla = 1
                             AND a.servisisemirislemid = i.id
                        ORDER BY e.servisid, e.kayittarih DESC
 

                ")
            .GetDataTable(mr)
            .ToModels();
//Eski sorgu
    //SELECT E.SASENO,
    //     E.KAYITTARIH,
    //     E.TAMAMLANMATARIH,
    //     E.KM,
    //     E.ENDEKS as LITRE,
    //     E.SAAT,
    //     --E.TBITISTARIHI,
    //     E.ISEMIRNO,
    //     T.ISORTAKAD,
    //     BAKIMTOPLU as BAKIM_NO,
    //     T.PARTNERCODE as YSKOD,
    //     case 
    //      when BAKIMSTATU =1 then  'TAM' 
    //      when BAKIMSTATU =0 then 'EKSIK' 
    //      else 'HATALI' end as BAKIMSTATU

    //FROM SERVISISEMIRLER E,
    //       SERVISISEMIRISLEMLER I,
    //       VT_SERVISLER T 

    //WHERE  E.KAYITTARIH BETWEEN '{dateQuery}' 
    //      and E.ID = I.SERVISISEMIRID 
    //      and ISEMIRTIPID =1 
    //      and (E.SASENO = NVL ('{SaseNo}', E.SASENO)) 
    //      and T.SERVISID = E.SERVISID
    //      and E.SERVISID {servisIdQuery}
    //      and T.DILKOD='Turkish'
    //      and E.TAMAMLANMATARIH is not null
    //   /*   and BAKIMTOPLU is not null */
    //        and E.TEKNIKOLARAKTAMAMLA = 1
    // ORDER BY E.SERVISID, E.KAYITTARIH desc


            CloseCustomAppPool();
            return queryResults;
        }

    }
}