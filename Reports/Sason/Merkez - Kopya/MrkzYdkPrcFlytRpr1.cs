using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Sason.Merkez
{
    /// <summary>
    /// Merkez Yedek Parça Faaliyet Raporu
    /// </summary>
    public class MrkzYdkPrcFlytRpr1 : Base.SasonMerkezReporter
    {
        public MrkzYdkPrcFlytRpr1()
        {
            Text = "Yedek Parça Faaliyet Raporu _ silinecek";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(false));
            Disabled = true;
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
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            decimal selectedServisId = ServisIds.first().toString("0").cto<decimal>();
            string servisIdQuery = $" = {selectedServisId}";

#if DEBUG
            selectedServisId = ServisId;
            servisIdQuery = $" = {selectedServisId}";
#endif  

            MethodReturn mr = new MethodReturn();

            List<ReportData> reportDataSource = new List<ReportData>();
            List<QueryResult> queryResults = AppPool.EbaTestConnector.CreateQuery($@"
                select * from (select * from sason.rptable_yedekparcadetay where servisid {servisIdQuery} and tarih between {{startDate}} AND {{finishDate}}) rpt
            ")
            .Parameter("startDate", StartDate.startOfDay())
            .Parameter("finishDate", FinishDate.endOfDay())
            .GetDataTable(mr)
            .ToModels<QueryResult>();

            ReportData reportData = new ReportData();
            reportDataSource.add(reportData);

            #region Yedek Parça Kısmı
            List<QueryResult> parcalar = queryResults.where(t => t.SERVISSTOKTURID != 6).toList();
            List<QueryResult> servisIciParcalar = parcalar.where(t => t.BelgeTuru == BelgeTuru.IsEmri).toList();
            List<QueryResult> servisDisiParcalar = parcalar.where(t => t.BelgeTuru == BelgeTuru.Digerleri).toList();

            #region Servis Içi
            reportData.YedekParca.ServisIci.Detay.Oem = servisIciParcalar.where(t => t.ServisStokTur == ServisStokTurIds.Oem).select(t => t.TUTAR).Sum();
            reportData.YedekParca.ServisIci.Detay.Oes = servisIciParcalar.where(t => t.ServisStokTur == ServisStokTurIds.Oes).select(t => t.TUTAR).Sum();
            reportData.YedekParca.ServisIci.Detay.Esd = servisIciParcalar.where(t => t.ServisStokTur == ServisStokTurIds.EsDeger).select(t => t.TUTAR).Sum();
            reportData.YedekParca.ServisIci.Detay.Yan_Sanayi = servisIciParcalar.where(t => t.ServisStokTur == ServisStokTurIds.Yansanayi).select(t => t.TUTAR).Sum();
            reportData.YedekParca.ServisIci.Detay.Yan_Sanayi_Muadili_Yok = servisIciParcalar.where(t => t.ServisStokTur == ServisStokTurIds.MuadiliYok).select(t => t.TUTAR).Sum();

            //reportData.YedekParca.ServisIci.UygunParca_Ucretli = reportData.YedekParca.ServisIci.Detay.Oem;
            reportData.YedekParca.ServisIci.UygunParca_Garanti = 0;
            #endregion

            #region Servis Dışı
            reportData.YedekParca.ServisDisi.Detay.Oem = servisDisiParcalar.where(t => t.ServisStokTur == ServisStokTurIds.Oem).select(t => t.TUTAR).Sum();
            reportData.YedekParca.ServisDisi.Detay.Oes = servisDisiParcalar.where(t => t.ServisStokTur == ServisStokTurIds.Oes).select(t => t.TUTAR).Sum();
            reportData.YedekParca.ServisDisi.Detay.Esd = servisDisiParcalar.where(t => t.ServisStokTur == ServisStokTurIds.EsDeger).select(t => t.TUTAR).Sum();
            reportData.YedekParca.ServisDisi.Detay.Yan_Sanayi = servisDisiParcalar.where(t => t.ServisStokTur == ServisStokTurIds.Yansanayi).select(t => t.TUTAR).Sum();
            reportData.YedekParca.ServisDisi.Detay.Yan_Sanayi_Muadili_Yok = servisDisiParcalar.where(t => t.ServisStokTur == ServisStokTurIds.MuadiliYok).select(t => t.TUTAR).Sum();
            #endregion

            #endregion

            #region Yaglar Kısmı
            List<QueryResult> yaglar = queryResults.where(t => t.SERVISSTOKTURID == 6).toList();
            reportData.Yag.Servis_Icinde_Onarima_Kullanilan = yaglar.where(t => t.BelgeTuru == BelgeTuru.IsEmri).select(t => t.TUTAR).Sum();
            reportData.Yag.Servis_Disina_veya_Direk_Satilan = yaglar.where(t => t.BelgeTuru != BelgeTuru.IsEmri).select(t => t.TUTAR).Sum();
            #endregion

            #region Stok Kısmı
            List<Servis.StokRaporu01.QueryResult> servisStokRaporuResults = new Servis.StokRaporu01(selectedServisId, DateTime.Now).ExecuteReport(mr).cast<List<Servis.StokRaporu01.QueryResult>>();
            reportData.Stok.Detay.Oem = servisStokRaporuResults.where(t => t.ServisStokTur == ServisStokTurIds.Oem).select(t => t.STOKTUTAR).Sum();
            reportData.Stok.Detay.Oes = servisStokRaporuResults.where(t => t.ServisStokTur == ServisStokTurIds.Oes).select(t => t.STOKTUTAR).Sum();
            reportData.Stok.Detay.Esd = servisStokRaporuResults.where(t => t.ServisStokTur == ServisStokTurIds.EsDeger).select(t => t.STOKTUTAR).Sum();
            reportData.Stok.Detay.Yan_Sanayi = servisStokRaporuResults.where(t => t.ServisStokTur == ServisStokTurIds.Yansanayi).select(t => t.STOKTUTAR).Sum();
            reportData.Stok.Detay.Yan_Sanayi_Muadili_Yok = servisStokRaporuResults.where(t => t.ServisStokTur == ServisStokTurIds.MuadiliYok).select(t => t.STOKTUTAR).Sum();
            #endregion

            CloseCustomAppPool();
            return reportDataSource;
        }

        public enum BelgeTuru
        {
            None       = 0,
            IsEmri     = 1,
            Digerleri = 2
        }

        public class QueryResult
        {
            public string AYRISTIRMATIPAD { get; set; }
            public string BELGETURU { get; set; }
            public decimal KUR { get; set; }
            public DateTime TARIH { get; set; }
            public decimal TUTAR { get; set; }
            public int SERVISSTOKTURID { get; set; }

            public ServisStokTurIds ServisStokTur { get => (ServisStokTurIds)SERVISSTOKTURID; }

            #region BelgeTuru
            public BelgeTuru BelgeTuru
            {
                get
                {
                    BelgeTuru ret = BelgeTuru.None;
                    switch (BELGETURU)
                    {
                        case "İş Emri":
                            ret = BelgeTuru.IsEmri;
                            break;
                        default:
                            ret = BelgeTuru.Digerleri;
                            break;
                    }
                    return ret;
                }
            } 
            #endregion
        }
        
        #region Data Source
        public class ReportData
        {
            public Detay_YedekParca YedekParca { get; set; } = new Detay_YedekParca();
            public Detay_Yag Yag { get; set; } = new Detay_Yag();
            public Detay_Stok Stok { get; set; } = new Detay_Stok();

            //public decimal StokHaricToplam { get => Yag.Toplam + YedekParca.Toplam; }
            //public decimal StokDahilToplam { get; set; }


            public decimal Oran { get; set; }
        }

        public class Detay_YedekParca
        {
            public Detay_YedekParca_ServisIci ServisIci { get; set; } = new Detay_YedekParca_ServisIci();
            public Detay_YedekParca_ServisDisi ServisDisi { get; set; } = new Detay_YedekParca_ServisDisi();

            public decimal Toplam { get => ServisIci.Toplam + ServisDisi.Toplam; }
        }

        public class Detay_Yag
        {
            public decimal Servis_Icinde_Onarima_Kullanilan { get; set; }
            public decimal Servis_Disina_veya_Direk_Satilan { get; set; }
            public decimal Toplam { get => Servis_Icinde_Onarima_Kullanilan + Servis_Disina_veya_Direk_Satilan; }
        }

        public class Detay_Stok
        {
            public __Detail Detay { get; set; } = new __Detail();
        }

        public class Detay_YedekParca_ServisIci
        {
            public decimal UygunParca_Ucretli { get; set; }
            public decimal UygunParca_Garanti { get; set; }
            public decimal UygunParca_Toplam { get => UygunParca_Ucretli + UygunParca_Garanti; }
            public decimal Yansanayi_Parca { get => Detay.Yan_Sanayi + Detay.Yan_Sanayi_Muadili_Yok; }

            public decimal Toplam { get => Detay.Toplam; }

            public __Detail Detay { get; set; } = new __Detail();
        }

        public class Detay_YedekParca_ServisDisi
        {
            public decimal Uygun_Parca { get => Detay.Oem + Detay.Oes + Detay.Esd; }
            public decimal Yan_Sanayi_Parca { get => Detay.Yan_Sanayi + Detay.Yan_Sanayi_Muadili_Yok; }

            public decimal Toplam { get => Detay.Toplam; }

            public __Detail Detay { get; set; } = new __Detail();
        }

        public class __Detail
        {
            public decimal Oem { get; set; }
            public decimal Oes { get; set; }
            public decimal Esd { get; set; }
            public decimal Yan_Sanayi { get; set; }
            public decimal Yan_Sanayi_Muadili_Yok { get; set; }
            public decimal Toplam { get => Oem + Oes + Esd + Yan_Sanayi + Yan_Sanayi_Muadili_Yok; }
        }
        #endregion
    }
}