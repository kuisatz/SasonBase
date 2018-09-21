using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace SasonBase.Reports.Sason.Merkez
{
    /// <summary>
    /// Merkez Genel Araç Raporu
    /// </summary>
    public class MrkzGenelAracRaporu : Base.SasonMerkezReporter
    {
        public MrkzGenelAracRaporu()
        {
            Text = "[VIS-4] Genel Araç Raporu";
            SubjectCode = "MrkzGenelAracRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            Disabled = false;
        }
        public MrkzGenelAracRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            //base.ServisId = servisId;
            //this.StartDate = startDate;
            //this.FinishDate = finishDate;
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
                case "param_sase_no":
                    SaseNo = value.toString();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 

                  SELECT DISTINCT vm.vin as SASE_NO, 
                        vm.vehiclenum as KISA_SASE, 
                        SVR.PLAKA as PLAKA,
                        vm.modelnum ARAC_MODEL, 
                        vm.variant VARYANT, 
                        vm.exworksdate FABRIKA_CIKIS_TARIHI, 
                        vm.firstregdate TRAFIGE_CIKIS_TARIHI,
                        vm.vehicleregdate RUHSAT_TARIHI, 
                        vm.lastvisitdate SON_SERVIS_ZIYARET_TARIHI,
                        vm.wheelstrack, 
                        vm.overhang, 
                        vm.doorkeynum KAPI_KILIT_NUMARASI, 
                        vm.vehicledes ARAC_TIP_VARYANT,
                        vm.vehicledescavis ARAC_TIPI, 
                        vm.vehicletype ARAC_TIPI, 
                        vm.motbr MOTOR_TIPI, 
                        vm.schadstkl MOTOR_NORMU, 
                        vm.vehiclekm ARAC_KM, 
                        vm.assetmanuf URETICI
                    FROM
                        VX_VIS_VEHICLEMASTER vm,
                        servisvarlikruhsatlar svr,
                        esaaraclar ea
                    WHERE
                        vm.vin is not null and
                        vm.vin=svr.saseno and
                        EA.ID=VM.ESAARACID and
                       (ea.vin = NVL ('{SaseNo}', ea.vin))

                ")
            .GetDataTable(mr)
            .ToModels();

            CloseCustomAppPool();
            return queryResults;
        }

    }
}