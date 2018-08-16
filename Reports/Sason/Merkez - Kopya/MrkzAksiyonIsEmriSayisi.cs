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
    /// Merkez Aksiyon İş Emri Sayısı Raporu
    /// </summary>
    public class MrkzAksiyonIsEmriSayisi : Base.SasonMerkezReporter
    {
        public MrkzAksiyonIsEmriSayisi()
        {
            Text = "Aksiyon İş Emri Sayısı Raporu";
            SubjectCode = "MrkzAksiyonIsEmriSayisi";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;            
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true)); 
            Disabled = false;
        }
        public MrkzAksiyonIsEmriSayisi(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;            
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
 
            if (ServisIds.isNotEmpty())
                servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            else { 
            //    servisIdQuery = $" > 1 ";
                selectedServisId = ServisId;
                servisIdQuery = $" in( {selectedServisId} )";
            }
           
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
                SELECT distinct
                   a.SERVISID, 
                   (SELECT vtsx.partnercode FROM vt_servisler vtsx where vtsx.servisid = a.SERVISID  and vtsx.dilkod = 'Turkish') as partnercode,
                   (SELECT vtsxy.ISORTAKAD FROM vt_servisler vtsxy where  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = a.SERVISID) as servisad, 
                   count(b.servisisemirid) as servisisemiridadedi, 
                   to_number ( to_char(KAYITTARIH,'mm')) as ay,
                   to_char(KAYITTARIH, 'Month')  as ayadi,
                   to_char(sysdate,'yyyy') as yil
                 FROM servisisemirler a 
                 INNER JOIN servisisemirislemler b on a.id=b.servisisemirid
                 WHERE 
                    b.isemirtipid=2 AND
                    a.servisid {servisIdQuery} AND
                    to_char(sysdate,'yyyy') =  to_char(KAYITTARIH,'yyyy')
                 GROUP BY a.servisid, to_number ( to_char(KAYITTARIH,'mm')), to_char(KAYITTARIH, 'Month') 
                 order by 1,5 desc
                
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}