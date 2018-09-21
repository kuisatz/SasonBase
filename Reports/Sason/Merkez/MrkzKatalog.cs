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
    /// Merkez KATALOG raporu
    /// </summary>
    public class MrkzKatalog : Base.SasonMerkezReporter
    {
        public MrkzKatalog()
        {
            Text = "[VIS-3] Genel Agrega Katalog Raporu";
            SubjectCode = "MrkzKatalog";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_agreta", Text = "Agrega" }.CreateAgregaSelect(true));        
            Disabled = false;
        }
        public MrkzKatalog(decimal servisId, decimal agretaId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
            //    this.StartDate = startDate;
            //    this.FinishDate = finishDate;
            // this.AgretaId = agretaId;
        }         

        public List<decimal> AgretaIds
        {
            get { return GetParameter("param_agreta").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_agreta", value); }
        }

        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {          
                  case "param_agreta":
                    AgretaIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;

            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {            
            //  string dateQuery = "";
            decimal selectedAgretaId = AgretaIds.first().toString("0").cto<decimal>();
            string agretaIdQuery = $" = {selectedAgretaId}";
         
            if (AgretaIds.isNotEmpty())
                agretaIdQuery = $" in ({AgretaIds.joinNumeric(",")}) ";
            else
            {
                selectedAgretaId = 4;
                agretaIdQuery = $" in( {selectedAgretaId} )";
            }
            
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
                SELECT
                    AGR.ID, 
                    AGR.AD AGREGA_ADI,  
                    t.kod AGREGA_KODU, 
                    T.AD AGREGA_TIPI, 
                    t.durumad DURUM
                FROM vw_agregalar agr,  VW_AGREGATIPLER t 
                WHERE
                    T.AGREGAID = AGR.ID AND
                    AGR.ID  {agretaIdQuery}  AND 
                    agr.dilkod='Turkish' AND
                    t.dilkod = 'Turkish'
                ORDER BY 1 DESC
       
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}