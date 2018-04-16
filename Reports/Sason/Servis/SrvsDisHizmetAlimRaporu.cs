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
    /// Dış Hizmet Alım Raporu
    /// </summary>
    public class SrvsDisHizmetAlimRaporu : Base.SasonReporter
    {
        public SrvsDisHizmetAlimRaporu()
        {
            Text = "Dış Hizmet Alım Raporu";
            SubjectCode = "SrvsDisHizmetAlimRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
       //     AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
        //    AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            Disabled = false;
        }
        public SrvsDisHizmetAlimRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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

  
            StartDate = StartDate.startOfDay(); 
            FinishDate = FinishDate.endOfDay();
            dateQuery = ""+StartDate.ToString("dd/MM/yyyy") +  "' AND '"+ FinishDate.ToString("dd/MM/yyyy")+"";
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
                SELECT 
                    (SELECT vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = d.servisid  and vtsx.dilkod = 'Turkish') as partnercode,
                    (SELECT vtsxy.ISORTAKAD FROM vt_servisler vtsxy where  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = d.servisid) as servisad,
                    f.netkdvtoplam,
                    f.nettutar,
                    f.netkdvtoplam+f.nettutar toplam, 
                    D.FATURANO,
                    D.SERVISID,
                    D.SERVISISEMIRID,
                    D.SERVISISORTAKID,
                    F.ACIKLAMA,
                    F.ADRES,
                    F.BRUTTOPLAM,
                    F.CARIUNVAN,
                    F.IL,
                    F.ILCE, 
                    F.VERGIDAIRESI,
                    F.VNO,
                    F.ILGILIKISI,
                    F.ILGILIKISITELNO,
                    F.IRSALIYENO,
                    to_char(F.IRSALIYETARIHI,'dd/mm/yyyy') as IRSALIYETARIHI,
                    F.ISLEMTARIHI,
                    (SELECT zx.ISEMIRNO FROM servisisemirler zx where zx.id = d.SERVISISEMIRID) as ISEMIRNO
                FROM sason.servisdishizmetalimlar d, sason.faturalar f
                WHERE     
                    d.faturaid = f.id AND 
                    F.ISLEMTARIHI BETWEEN '{dateQuery}' AND 
                        d.servisid {servisIdQuery}   
                ORDER BY F.islemtarihi desc 
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}