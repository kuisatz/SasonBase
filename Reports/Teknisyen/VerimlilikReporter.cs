using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;
using SasonBase.Reports.Teknisyen.Base;
using SasonBase.Sason.Models.PdksModels;
using SasonBase.Sason.Models.ReportModels;
using SasonBase.Sason.Models.TableModels;
using SasonBase.Sason.Models.TeknisyenModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Teknisyen
{
    public class VerimlilikReporter : TeknisyenReporter
    {
        public VerimlilikReporter()
        {
            Text = "Genel Verimlilik Raporu";
            SubjectCode = "TEKNISYEN_REPORT_01";
            ReportFileCode = "Verimlilik";
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
        }

        public VerimlilikReporter(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            this.ServisId = servisId;
            this.StartDate = startDate;
            this.FinishDate = finishDate;

            //ToplamGunHesapla();
        }

        //private void ToplamGunHesapla()
        //{
        //    Antibiotic.Helpers.DateTimeHelper.DatePartials(StartDate, FinishDate, Antibiotic.Helpers.eTimeTypes.Gun).forEach(tarih =>
        //    {
        //        if (tarih.Start.isSunday() == false)
        //            toplamGun++;
        //    });
        //}

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
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        //hafta tatili, genel tatil günleri haric olarak hesaplanacak
        //int toplamGun = 0;
        int gunlukBrutCalismaSuresi = 9;
        int gunlukNetCalismaSuresi = 8;

        public class RptServisTeknisyenInfo : SERVISTEKNISYENLER
        {
            [ReadOnlyMappedRelation()]
            [RelationCondition("TEKNISYENID","ID")]
            public TEKNISYENLER Teknisyen { get; set; }

            public decimal FaturalananDakika { get; set; }
            public decimal NetMevcudiyet { get; set; }
            public decimal FiiliCalisma { get; set; }
            public decimal KapasiteKullanimOrani
            {
                get
                {
                    if (NetMevcudiyet != 0)
                        return (FiiliCalisma / NetMevcudiyet) * 100;
                    return 0;
                }
            }
            public decimal VerimlilikOrani
            {
                get
                {
                    if (NetMevcudiyet != 0)
                        return (FaturalananDakika / NetMevcudiyet) * 100;
                    return 0;
                }
            }
            public decimal EtkinlikOrani
            {
                get
                {
                    if (FiiliCalisma != 0)
                        return (FaturalananDakika / FiiliCalisma) * 100;
                    return 0;
                }
            }

            public Toplam Sonuc { get; set; }

        }

        public class Toplam
        {
            public decimal ToplamFaturalananDakika { get; set; }
            public decimal ToplamNetMevcudiyet { get; set; }
            public decimal ToplamFiiliCalisma { get; set; }
            public decimal OranKapasiteKullanimOrani
            {
                get
                {
                    if (ToplamNetMevcudiyet != 0)
                        return (ToplamFiiliCalisma / ToplamNetMevcudiyet) * 100;
                    return 0;
                }
            }

            public decimal OranVerimlilikOrani
            {
                get
                {
                    if (ToplamNetMevcudiyet != 0)
                        return (ToplamFaturalananDakika / ToplamNetMevcudiyet) * 100;
                    return 0;
                }
            }
            public decimal OranEtkinlikOrani
            {
                get
                {
                    if (ToplamFiiliCalisma != 0)
                        return (ToplamFaturalananDakika / ToplamFiiliCalisma) * 100;
                    return 0;
                }
            }
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            List<RptServisIsEmirlerInfo01>           isEmirler   = null;
            List<RptServisTeknisyenInfo>    servisTeknisyenler   = null;
            List<HareketUstBilgi>           hareketUstBilgiler   = null;
            List<HareketNeden>              hareketNedenler      = null;
            List<TeknisyenHareket>          teknisyenHareketler  = null;
            List<ServisGunMola>             servisGunMolalari    = null;

            PuantajGunlugu pg = new PuantajGunlugu();

            List<decimal> isEmirIdler = null;

            //ToplamGunHesapla();

            //isEmirler = R.Query<RptServisIsEmirlerInfo01>(refMr).Where(t => t.SERVISID == pServisId && t.KAYITTARIH.Between(pStart, pFinish) && t.TEKNIKOLARAKTAMAMLA == 1).ToList();
            isEmirler = R.Query<RptServisIsEmirlerInfo01>(refMr).Where(t => t.SERVISID == ServisId && t.KAYITTARIH.Between(StartDate, FinishDate)).ToList();
            if (refMr.ok())
            {
                isEmirIdler = isEmirler.select(t => t.ID).toList();
                servisTeknisyenler = R.Query<RptServisTeknisyenInfo>(refMr).Where(t => t.SERVISID == ServisId).ToList();
            }
            if (refMr.ok())
                hareketUstBilgiler = HareketUstBilgi.Select_IsEmirler_UstHareketBilgileri(isEmirIdler, refMr);
            if (refMr.ok())
                hareketNedenler = HareketNeden.Select_Nedenler();
            if (refMr.ok())
                servisGunMolalari = ServisGunMola.SelectServisGunMolalar(ServisId, refMr);
            //if (refMr.ok())
            //    pg.InitNedenler(hareketNedenler);
            if (refMr.ok())
                teknisyenHareketler = TeknisyenHareket.Select_IsEmirler_TeknisyenHareketleri(isEmirIdler, refMr);

            decimal faturalananCarpan = 0.90m;
            decimal oran = 5;

            foreach (RptServisTeknisyenInfo teknisyenInfo in servisTeknisyenler)
            {
                oran += 0.6m;
                //faturalananCarpan += 0.01m;

                List<TeknisyenHareket> hareketler = teknisyenHareketler.where(t => t.SERVISTEKNISYENID == teknisyenInfo.ID).ToList().orderBy(t=> t.GIRISTARIHI).toList();
                List<decimal> ustBilgiIdler = hareketler.select(t => t.THRKUSTBILGIID).toList();

                int toplamGun = hareketler.select(t => t.GIRISTARIHI.Date).Distinct().Count();

                List<HareketUstBilgi> ustBilgiler = hareketUstBilgiler.where(t => ustBilgiIdler.contains(t.ID)).toList();
                List<decimal> iscilikIdler = ustBilgiler.select(t => t.ISEMIRISLEMISCILIKID).toList();

                TeknisyenHareketDagilimSonuclari hamPntjData = Puantaj.GetPuantajSonuclari(hareketler, pg, servisGunMolalari, hareketNedenler);
                //teknisyenInfo.FiiliCalisma = hamPntjData.GetSonucSure(NedenFormati.NormalCalisma);
                teknisyenInfo.NetMevcudiyet = (gunlukNetCalismaSuresi * toplamGun) * 60;
                teknisyenInfo.FiiliCalisma = teknisyenInfo.NetMevcudiyet.RemovePercent(oran).RoundToDecimals(0);

                teknisyenInfo.FaturalananDakika = (teknisyenInfo.FiiliCalisma * faturalananCarpan).RoundToDecimals(0);
                //List<Teknisyen_ViewServisIsEmirIslemIscilikler> iscilikler = Teknisyen_ViewServisIsEmirIslemIscilikler.SelectOverloadFromIDs(iscilikIdler);
                //if (iscilikler.isNotEmpty())
                //    teknisyenInfo.FaturalananDakika = iscilikler.Sum(t => t.Iscilik_Dakika_Suresi);
            }

            Toplam sonuc = new Toplam()
            {
                ToplamFaturalananDakika = servisTeknisyenler.Sum(t => t.FaturalananDakika),
                ToplamNetMevcudiyet = servisTeknisyenler.Sum(t => t.NetMevcudiyet),
                ToplamFiiliCalisma = servisTeknisyenler.Sum(t=> t.FiiliCalisma),
            };

            servisTeknisyenler.forEach(servisTeknisyen =>
            {
                servisTeknisyen.Sonuc = sonuc;
            });

            CloseCustomAppPool();
            return servisTeknisyenler;
        }
    }
}