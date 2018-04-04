using Antibiotic.Extensions;
using SasonBase.Reports.Models;
using SasonBase.Reports.Teknisyen.Base;
using SasonBase.Sason.Models.PdksModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Teknisyen
{
    public class IsEmriPuantajRaporu : TeknisyenReporter
    {
        public IsEmriPuantajRaporu()
        {
            Text = "İş Emri Puantaj Raporu";
            SubjectCode = "TEKNISYEN_PUANTAJ_03";
            ReportFileCode = "IsEmriPuantaj";
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_teknisyen", Text = "Teknisyen" }.CreateTeknisyenSelect(true));
        }

        public IsEmriPuantajRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            ServisId        = servisId;
            this.StartDate  = startDate;
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
                    ServisTeknisyenIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            List<ReportData> reportDataSource = new List<ReportData>();

            PuantajGunlugu              pg                       = new PuantajGunlugu();
            List<ServisGunMola>         gunMolalar               = ServisGunMola.SelectServisGunMolalar(ServisId, refMr);
            HareketNedenContainer       nedenContainer           = new HareketNedenContainer(R.Query<HareketNeden>(refMr).ToList());
            List<HareketNeden>          nedenler                 = nedenContainer.ToList();
            ServisTeknisyenContainer    servisTeknisyenContainer = null;
            if (ServisTeknisyenIds.isEmpty())
                servisTeknisyenContainer = new ServisTeknisyenContainer(R.Query<ServisTeknisyen>(refMr).Where(t => t.SERVISID == ServisId).ToList());
            else
                servisTeknisyenContainer = new ServisTeknisyenContainer(R.Query<ServisTeknisyen>(refMr).Where(t => t.ID.In(ServisTeknisyenIds)).ToList());

            List<RptIsEmir>                                     isEmirler                 = R.Query<RptIsEmir>(refMr).Where(t => t.SERVISID == ServisId && t.KAYITTARIH.Between(StartDate, FinishDate)).ToList();
            List<HareketUstBilgi>                               hareketUstBilgiler        = HareketUstBilgi.Select_UstBilgiler_FromBig_IsEmirIds(isEmirler.select(i => i.ID));
            TeknisyenHareketContainer<RptTeknisyenHareket>      teknisyenHareketContainer = new TeknisyenHareketContainer<RptTeknisyenHareket>(RptTeknisyenHareket.Select_From_UstBilgi_Ids<RptTeknisyenHareket>(hareketUstBilgiler.select(u=> u.ID)).ToList());

            isEmirler.forEach(isEmir =>
            {
                isEmir.Islemler.forEach(islem =>
                {
                    islem.Iscilikler.forEach(iscilik =>
                    {
                        HareketUstBilgi ustBilgi = hareketUstBilgiler.first(t => t.ISEMIRISLEMISCILIKID == iscilik.ID);
                        if (ustBilgi.isNotNull())
                        {
                            teknisyenHareketContainer.GetUstBilgiHareketler(ustBilgi.ID).forEach(hr =>
                            {
                                ServisTeknisyen servisTeknisyen = servisTeknisyenContainer[hr.SERVISTEKNISYENID];
                                if (servisTeknisyen.isNotNull())
                                {
                                    ReportData reportData = new ReportData()
                                    {
                                        Teknisyen = servisTeknisyen,
                                        Hareket = hr,
                                        IsEmir = isEmir,
                                        IsEmirIslem = islem,
                                        IsEmirIslemIscilik = iscilik
                                    };

                                    hr.GirisNeden = nedenContainer[hr.GIRISNEDENID];
                                    hr.CikisNeden = nedenContainer[hr.CIKISNEDENID];

                                    hr.PSonuc = Puantaj.GetPuantajSonuclari(hr.MakeList(), pg, gunMolalar, nedenler);
                                    hr.Calisma = hr.PSonuc.GetSonucSure(NedenFormati.NormalCalisma);

                                    reportDataSource.add(reportData);
                                }
                            });
                        }

                    });
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