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
    /// Merkez Bakım Grubundaki Araçlar
    /// </summary>
    public class MrkzBakimGrubundakiAraclar : Base.SasonMerkezReporter
    {
        public MrkzBakimGrubundakiAraclar()
        {
            Text = "Bakım Grubundaki Araçlar Raporu";
            SubjectCode = "MrkzBakimGrubundakiAraclar";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_bakim", Text = "Bakım Grup Türleri" }.CreateBakimTuruSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            Disabled = false;
        }
        public MrkzBakimGrubundakiAraclar(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId; 
        }
        public List<decimal> BakimTuruIds
        {
            get { return GetParameter("param_bakim").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_bakim", value); }
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
                case "param_sase_no":
                    SaseNo = value.toString();
                    break;
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
                selectedBakimTuruId = 40;
                bakimTuruIdQuery = $" in( {selectedBakimTuruId} )";
            }

            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
             SELECT DISTINCT 
                a.saseno, 
                a.bakimgrupkod BAKIM_GRUBU ,
                a.bakimgrupad BAKIM_GRUBU_ADI, 
                a.bakimturkod BAKIM_KONTROL_TURU, 
                a.endeks, 
                a.kilometre, 
                a.endeks LITRE, 
                a.saat, 
                a.gun 
            FROM mt_aracbakimgruplar a
            INNER JOIN bakimgruplar b on b.kod = a.bakimgrupkod    
            WHERE saseno = NVL ('{SaseNo}', a.saseno) AND 
                b.id {bakimTuruIdQuery} 
            ORDER BY a.bakimgrupkod, a.bakimgrupad 
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}