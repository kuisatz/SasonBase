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
    ///Tüm Talimatlar Raporu
    /// </summary>
    public class MrkzTumTalimatlar : Base.SasonMerkezReporter
    {
        public MrkzTumTalimatlar()
        {
            Text = "Tüm Talimatlar Raporu";
            SubjectCode = "MrkzTumTalimatlar";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_bakim", Text = "Bakım Grup Türleri" }.CreateBakimTuruSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            Disabled = false;
        }
        public MrkzTumTalimatlar(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
             

                SELECT 
                    bgrup.kod, 
                    klm.ad KONTROL_TALIMATI, 
                    klm.durumad DURUM, 
                    knt.sure, 
                    knt.periyot KONTROL_PERIYODU,
                    bgrup.endeks, 
                    bgrup.kilometre, 
                    bgrup.saat, 
                    BGRUP.GUN
                FROM bakimgrupkontroller knt, bakimgruplar bgrup,   
                    ( SELECT t.ID,
                            t.KOD,
                            CASE WHEN c.DEGER IS NULL THEN t.KOD ELSE c.DEGER END AD,
                            t.BASTARIH,
                            t.BITTARIH,
                            t.BAKIMKONTROLID,
                            t.DURUMID,
                            d.AD DURUMAD,
                            t.DILID,
                            t.DILKOD,
                            t.LISTEALANID ADLISTEALANID,
                            c.ID ADCEVIRIID
                        FROM(SELECT t.*,
                                    dx.id dilid,
                                    dx.kod dilkod,
                                    a.id listealanid
                                FROM diller dx,
                                    bakimkontrolkalemler t,
                                    listeler l,
                                    listealanlar a
                            WHERE     l.kod = 'BAKIMKONTROLKALEMLER'
                                    AND a.listeid = l.id
                                    AND a.kod = 'AD') t,
                            ceviriler c,
                            vw_durumlar d
                    WHERE c.listealanid(+) = t.listealanid
                            AND c.dilid(+) = t.dilid
                            AND c.alanid(+) = t.id
                            AND d.id = t.durumid
                            AND t.dilid = d.dilid
                    ) klm
                where
                KNT.BAKIMGRUPID = bgrup.id and
                KNT.BAKIMKONTROLKALEMID = klm.id and
                klm.dilkod = 'Turkish' AND 
                bgrup.id {bakimTuruIdQuery}  
            ORDER BY bgrup.kod 
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}