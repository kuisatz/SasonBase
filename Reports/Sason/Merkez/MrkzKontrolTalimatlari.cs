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
    /// Merkez Kontrol Talimatları
    /// </summary>
    public class MrkzKontrolTalimatlari : Base.SasonMerkezReporter
    {
        public MrkzKontrolTalimatlari()
        {
            Text = "Kontrol Talimatları";
            SubjectCode = "MrkzKontrolTalimatlari";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_bakim", Text = "Bakım Grup Türleri" }.CreateBakimTuruSelect(true));
            Disabled = false;
        }
        public MrkzKontrolTalimatlari(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId; 
        }
        public List<decimal> BakimTuruIds
        {
            get { return GetParameter("param_bakim").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_bakim", value); }
        }
         
        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {
                
                case "param_bakim":
                    BakimTuruIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;

            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            decimal selectedBakimTuruId = BakimTuruIds.first().toString("0").cto<decimal>();
            string bakimTuruIdQuery = $" = {selectedBakimTuruId}";


            if (BakimTuruIds.isNotEmpty())
                bakimTuruIdQuery = $" in ({BakimTuruIds.joinNumeric(",")}) ";
            else
            {
                selectedBakimTuruId = 21;
                bakimTuruIdQuery = $" in( {selectedBakimTuruId} )";
            }

            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
             SELECT  
                bgrup.ID,  
                bgrup.kod, 
                klm.ad KONTROL_TALIMATI, 
                klm.durumad DURUM, 
                knt.sure, 
                knt.periyot KONTROL_PERIYODU,
                bgrup.endeks, 
                bgrup.kilometre, 
                bgrup.saat, 
                BGRUP.GUN
            FROM bakimgrupkontroller knt, bakimgruplar bgrup, vw_BAKIMKONTROLKALEMLER klm
            WHERE
                KNT.BAKIMGRUPID=bgrup.id and
                KNT.BAKIMKONTROLKALEMID = klm.id and
                KNT.DURUMID = 1 AND 
                klm.dilkod='Turkish' AND 
                bgrup.ID {bakimTuruIdQuery} 
            ORDER BY bgrup.kod, klm.ad 
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}