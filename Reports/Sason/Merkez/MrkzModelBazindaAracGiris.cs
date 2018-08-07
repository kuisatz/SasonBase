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
    /// Merkez Model Bazında Araç Giriş Sayısı Raporu
    /// </summary>
    public class MrkzModelBazindaAracGiris : Base.SasonMerkezReporter
    {
        public MrkzModelBazindaAracGiris()
        {
            Text = "Model Bazında Araç Girişi";
            SubjectCode = "MrkzModelBazindaAracGiris";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            Disabled = false;
        }
        public MrkzModelBazindaAracGiris(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
                        SELECT v.partnercode servis_kodu,
                                v.isortakad servis_adi,
                                si.saseno,
                                si.isemirno,
                                TO_CHAR (si.kayittarih, 'DD.MM.YYYY') ie_kayit_tarihi,
                                at.ad arac_turu,
                                si.modelno model,
                                av.ad arac_varyant,
                                atip.ad arac_tipi,
                                TRUNC((si.kayittarih - svr.ilktesciltarihi)/365,0) yas,
                                svr.ilktesciltarihi
       
                        FROM vt_servisler v,
                            servisisemirler si,
                            vw_aracturler at,
                            vw_aractipler atip,
                            vw_aracvaryantlar av,
                            araclar a,
                            servisvarlikruhsatlar svr

                        WHERE v.dilkod = 'Turkish'
                            AND v.servisid = si.servisid
                            AND si.aractipad = at.kod
                            AND at.dilkod = 'Turkish'
                            AND atip.dilkod = 'Turkish'
                            AND a.saseno = si.saseno
                            AND atip.id = a.aractipid
                            AND av.id = a.aracvaryantid
                            AND av.dilkod = 'Turkish'
                            AND si.saseno=svr.saseno
                            AND si.servisid=svr.servisid
                            AND si.servisid  {servisIdQuery}
                            AND si.kayittarih BETWEEN '{dateQuery}' 
                            AND (si.saseno = NVL ('{SaseNo}', si.saseno)) 

                        ORDER BY si.servisid, si.kayittarih DESC

                ")
            .GetDataTable(mr)
            .ToModels();

            CloseCustomAppPool();
            return queryResults;
        }

    }
}