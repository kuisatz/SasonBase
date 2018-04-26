using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Sason.Servis
{
    public class SrvsAracGirisSayilari02 : SrvsAracGirisSayilari
    {
        public SrvsAracGirisSayilari02()
        {
            Text = "Araç Giriş Sayıları (R02)";
            Disabled = true;
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            List<ReportData> reportDataSource = new List<ReportData>();
            List<RowData> rowDataSource = AppPool.EbaTestConnector.CreateQuery($@"
                    SELECT
                        tarihler.tarih, servis.PARTNERCODE, servis.servisid, servis.isortakad SERVISISORTAKAD, servis.VARLIKAD SERVISVARLIKAD, ags.arac_giris, ags.isemir_acilan, ags.isemir_kapanan
                    FROM 
                        (SELECT TARIH, YIL, AY FROM TARIHLER WHERE TARIH BETWEEN {{startDate}} AND {{finishDate}}) tarihler
                    left join vt_servisler servis on servis.servisid = {ServisId} and servis.dilkod = 'Turkish'
                    left join mobilags ags on AGS.SERVIS = servis.servisid and AGS.TARIH = tarihler.tarih
                    order by tarihler.tarih, servis.servisid
            ")
            .Parameter("startDate", StartDate.startOfDay())
            .Parameter("finishDate", FinishDate.endOfDay())
            .GetDataTable()
            .ToModels<RowData>();
            foreach (RowData data in rowDataSource)
            {
                int ay = data.TARIH.Month;
                int yil = data.TARIH.Year;
                ReportData reportData = reportDataSource.first(t => t.ServisId == data.SERVISID && t.Yil == yil);
                if (reportData.isNull())
                {
                    reportData = new ReportData()
                    {
                        PartnerCode = data.PARTNERCODE,
                        ServisId = data.SERVISID,
                        ServisAdi = data.SERVISISORTAKAD,
                        ServisVarlikAdi = data.SERVISVARLIKAD,
                        Yil = data.TARIH.Year,
                    };
                    reportDataSource.add(reportData);
                }
                reportData.SetPropertyValue($"AIS{ay}", reportData.GetPropertyValue<decimal>($"AIS{ay}") + data.ISEMIR_ACILAN);
                reportData.SetPropertyValue($"KIS{ay}", reportData.GetPropertyValue<decimal>($"KIS{ay}") + data.ISEMIR_KAPANAN);
                reportData.SetPropertyValue($"AGS{ay}", reportData.GetPropertyValue<decimal>($"AGS{ay}") + data.ARAC_GIRIS);
            }

            CloseCustomAppPool();
            return reportDataSource;
        }

        class RowData
        {
            public DateTime TARIH { get; set; }
            public string PARTNERCODE { get; set; }
            public decimal SERVISID { get; set; }
            public string SERVISISORTAKAD { get; set; }
            public string SERVISVARLIKAD { get; set; }
            public decimal ARAC_GIRIS { get; set; }
            public decimal ISEMIR_ACILAN { get; set; }
            public decimal ISEMIR_KAPANAN { get; set; }
        }

        public class ReportData
        {
            //Header
            public string PartnerCode { get; set; }
            public decimal ServisId { get; set; }
            public string ServisAdi { get; set; }
            public string ServisVarlikAdi { get; set; }
            public int Yil { get; set; }

            //Açılan İş Emirleri (Ay No)
            public decimal AIS1 { get; set; }
            public decimal AIS2 { get; set; }
            public decimal AIS3 { get; set; }
            public decimal AIS4 { get; set; }
            public decimal AIS5 { get; set; }
            public decimal AIS6 { get; set; }
            public decimal AIS7 { get; set; }
            public decimal AIS8 { get; set; }
            public decimal AIS9 { get; set; }
            public decimal AIS10 { get; set; }
            public decimal AIS11 { get; set; }
            public decimal AIS12 { get; set; }

            public decimal AIS { get => AIS1 + AIS2 + AIS3 + AIS4 + AIS5 + AIS6 + AIS7 + AIS8 + AIS9 + AIS10 + AIS11 + AIS12; }

            //Kapanan İş Emirleri (Ay No)
            public decimal KIS1 { get; set; }
            public decimal KIS2 { get; set; }
            public decimal KIS3 { get; set; }
            public decimal KIS4 { get; set; }
            public decimal KIS5 { get; set; }
            public decimal KIS6 { get; set; }
            public decimal KIS7 { get; set; }
            public decimal KIS8 { get; set; }
            public decimal KIS9 { get; set; }
            public decimal KIS10 { get; set; }
            public decimal KIS11 { get; set; }
            public decimal KIS12 { get; set; }

            public decimal KIS { get => KIS1 + KIS2 + KIS3 + KIS4 + KIS5 + KIS6 + KIS7 + KIS8 + KIS9 + KIS10 + KIS11 + KIS12; }

            //Araç Giriş Sayıları (Ay No)
            public decimal AGS1 { get; set; }
            public decimal AGS2 { get; set; }
            public decimal AGS3 { get; set; }
            public decimal AGS4 { get; set; }
            public decimal AGS5 { get; set; }
            public decimal AGS6 { get; set; }
            public decimal AGS7 { get; set; }
            public decimal AGS8 { get; set; }
            public decimal AGS9 { get; set; }
            public decimal AGS10 { get; set; }
            public decimal AGS11 { get; set; }
            public decimal AGS12 { get; set; }

            public decimal AGS { get => AGS1 + AGS2 + AGS3 + AGS4 + AGS5 + AGS6 + AGS7 + AGS8 + AGS9 + AGS10 + AGS11 + AGS12; }
        }
    }
}