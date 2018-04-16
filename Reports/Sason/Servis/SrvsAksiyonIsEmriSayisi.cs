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
    ///  Aksiyon İş Emri Sayısı Raporu
    /// </summary>
    public class SrvsAksiyonIsEmriSayisi : Base.SasonReporter
    {
        public SrvsAksiyonIsEmriSayisi()
        {
            Text = "Aksiyon İş Emri Sayısı Raporu";
            SubjectCode = "SrvsAksiyonIsEmriSayisi";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;            
            Disabled = false;
        }
        public SrvsAksiyonIsEmriSayisi(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;            
        }
         
        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {
              
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
         
            string servisIdQuery = $" = {ServisId}"; 
             
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
                 order by 3 desc
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}