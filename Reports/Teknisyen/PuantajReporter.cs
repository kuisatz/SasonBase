using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;
using SasonBase.Reports.Models;
using SasonBase.Reports.Teknisyen.Base;
using SasonBase.Sason.Models.PdksModels;
using SasonBase.Sason.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Teknisyen
{
    public class PuantajReporter : TeknisyenReporter
    {
        public PuantajReporter()
        {
            Text = "Puantaj Raporu";
            SubjectCode = "TEKNISYEN_PUANTAJ_01";
            ReportFileCode = "Puantaj";
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_teknisyen", Text = "Teknisyen" }.CreateTeknisyenSelect(true));
        }

        public PuantajReporter(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
            this.StartDate = startDate;
            this.FinishDate = finishDate;
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

        public List<decimal> ServisTeknisyenIds
        {
            get { return GetParameter("param_teknisyen").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_teknisyen", value); }
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
                case "param_teknisyen":
                    ServisTeknisyenIds = value.toString().split(',').select(t=> Convert.ToDecimal(t)).toList();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            List<ReportData> reportDataSource = new List<ReportData>();

            HareketNedenContainer       nedenContainer            = new HareketNedenContainer(R.Query<HareketNeden>(refMr).ToList());
            List<HareketNeden>          nedenler = nedenContainer.ToList();
            ServisTeknisyenContainer    servisTeknisyenContainer  = null;
            if (ServisTeknisyenIds.isEmpty())
                servisTeknisyenContainer = new ServisTeknisyenContainer(R.Query<ServisTeknisyen>(refMr).Where(t => t.SERVISID == ServisId).ToList());
            else
                servisTeknisyenContainer = new ServisTeknisyenContainer(R.Query<ServisTeknisyen>(refMr).Where(t => t.ID.In(ServisTeknisyenIds)).ToList());

            TeknisyenHareketContainer<RptTeknisyenHareket> teknisyenHareketContainer = new TeknisyenHareketContainer<RptTeknisyenHareket>(R.Query<RptTeknisyenHareket>(refMr).Where(h => h.SERVISTEKNISYENID.In(servisTeknisyenContainer.select(t=> t.ID))).ToList());

            IEnumerable<decimal> ustBilgiIds = teknisyenHareketContainer.select(t => t.THRKUSTBILGIID);
            List<HareketUstBilgi> hareketUstBilgiler = null;
            if (ustBilgiIds.isNotEmpty())
                hareketUstBilgiler = R.Query<HareketUstBilgi>(refMr).Where(t => t.ID.In(ustBilgiIds)).ToList();

            List<ServisGunMola> gunMolalar = ServisGunMola.SelectServisGunMolalar(ServisId, refMr);

            List<RptIsEmir> isEmirler = R.Query<RptIsEmir>(refMr).Where(t => t.SERVISID == ServisId && t.KAYITTARIH.Between(StartDate, FinishDate)).ToList();

            PuantajGunlugu pg = new PuantajGunlugu();
            servisTeknisyenContainer.forEach(st =>
            {
                teknisyenHareketContainer.GetTeknisyenHareketler(st.ID).forEach(hr =>
                {
                    HareketUstBilgi ustBilgi = hareketUstBilgiler.first(t => t.ID == hr.THRKUSTBILGIID);

                    ReportData reportData = new ReportData()
                    {
                        Teknisyen = st,
                        Hareket = hr,
                        IsEmir = isEmirler.first(t => t.ID == ustBilgi?.ISEMIRID),
                    };

                    reportData.IsEmirIslem = reportData.IsEmir?.Islemler.first(t => t.ID == ustBilgi?.ISEMIRISLEMID);
                    reportData.IsEmirIslemIscilik = reportData.IsEmirIslem?.Iscilikler.first(t => t.ID == ustBilgi?.ISEMIRISLEMISCILIKID);

                    hr.GirisNeden = nedenContainer[hr.GIRISNEDENID];
                    hr.CikisNeden = nedenContainer[hr.CIKISNEDENID];

                    hr.PSonuc = Puantaj.GetPuantajSonuclari(hr.MakeList(), pg, gunMolalar, nedenler);
                    hr.Calisma =hr.PSonuc.GetSonucSure(NedenFormati.NormalCalisma);

                    reportDataSource.add(reportData);
                });
            });

            CloseCustomAppPool();
            return reportDataSource;
        }

        public class ReportData
        {
            public ServisTeknisyen Teknisyen { get; set; }
            public RptTeknisyenHareket Hareket { get; set; }
            public RptIsEmir IsEmir { get; set; }
            public RptIsEmirIslem IsEmirIslem { get; set; }
            public RptIsEmirIslemIscilik IsEmirIslemIscilik { get; set; }
        }


    }
}