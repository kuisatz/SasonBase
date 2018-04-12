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
    ///  Alış Faturası Rapor
    /// </summary>
    public class SrvsAlisFaturasiRaporu : Base.SasonReporter
    {
        public SrvsAlisFaturasiRaporu()
        {
            Text = "Alış Faturası Raporu";
            SubjectCode = "SrvsAlisFaturasiRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
       //     AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
        //    AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            Disabled = false;
        }
        public SrvsAlisFaturasiRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
         
            string servisIdQuery = $" = {ServisId}";
            string dateQuery = "";

//#if DEBUG
//             selectedServisId = ServisId;
//              servisIdQuery = $" in( {selectedServisId} )";
//#endif
  

            StartDate = StartDate.startOfDay(); 
            FinishDate = FinishDate.endOfDay();
            dateQuery = ""+StartDate.ToString("dd/MM/yyyy") +  "' AND '"+ FinishDate.ToString("dd/MM/yyyy")+"";
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
            select 
                    (select vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = a.servisid  and vtsx.dilkod = 'Turkish') as partnercode,
                    (Select vtsxy.ISORTAKAD FROM vt_servisler vtsxy where  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = a.servisid) as servisad,
                    a.faturaturid, 
                    a.faturano, 
                    a.islemtarihi,
                    a.cariunvan,
                    a.bruttoplam, 
                    a.indirimtoplam,
                    a.netkdvtoplam, 
                    a.nettutar, 
                    a.toplam,
                    a.carikod, 
                    a.vno,
                    a.servisid
                FROM faturalar a
                WHERE a.servisid  {servisIdQuery} 
                and a.islemtarihi between '{dateQuery}'
                and a.faturaturid=4 
            ORDER BY servisad ,a.islemtarihi desc 
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}