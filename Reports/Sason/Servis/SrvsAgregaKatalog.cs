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
    ///  Agrega Kataloğu
    /// </summary>
    public class SrvsAgregaKatalog : Base.SasonReporter
    {
        public SrvsAgregaKatalog()
        {
            Text = "Agrega Kataloğu";
            SubjectCode = "SrvsAgregaKatalog";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_agreta", Text = "Agrega" }.CreateAgregaSelect(true));
            Disabled = false;
        }
        public SrvsAgregaKatalog(decimal servisId, decimal agretaId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
          //  this.StartDate = startDate;
         //   this.FinishDate = finishDate;
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
                        AGR.AD AGREGA_ADI, 
                        Q.AD AGREGA_OZELLIK, 
                        T.AD AGREGA_TIPI, 
                        TIP.DEGER KULLANILACAK_DEGER 
                    FROM  VW_AGREGATIPLER T  
                    LEFT JOIN vw_agregalar agr ON T.AGREGAID = AGR.ID 
                    LEFT JOIN AGREGATIPOZELLIKLER tip ON TIP.AGREGATIPID= t.id  
                    LEFT JOIN vw_AGREGAOZELLIKLER q ON Q.ID= TIP.AGREGAOZELLIKID 
                    WHERE   
                        agr.dilkod='Turkish' and 
                        Q.DILKOD = 'Turkish' and 
                        t.dilkod = 'Turkish' AND 
                        AGR.ID  {agretaIdQuery} 
                    ORDER BY AGR.AD ,Q.AD , T.AD 
       
                ")
              .GetDataTable(mr)
               .ToModels();

            CloseCustomAppPool();
            return queryResults;
        }

    }
}