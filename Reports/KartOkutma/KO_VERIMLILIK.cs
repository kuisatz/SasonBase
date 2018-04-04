using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;
using SasonBase.Sason.Models.PdksModels;
using SasonBase.Sason.Models.TableModels;
using SasonBase.Sason.Models.TeknisyenModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.KartOkutma
{
    public class KO_VERIMLILIK_01 : Base.KartOkutmaReporter
    {
        public KO_VERIMLILIK_01()
        {
            Text                                        = "Genel Verimlilik Raporu";
            SubjectCode                                 = "KO_VERIMLILIK_01";
            ReportFileCode                              = "Verimlilik";
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
        }

        public KO_VERIMLILIK_01(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            this.ServisId = servisId;
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

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            List<SERVISTEKNISYEN_REPORT_DATA> servisTeknisyenler = R.Query<SERVISTEKNISYEN_REPORT_DATA>(refMr).Where(t=> t.SERVISID == ServisId).ToList();
            //Tarih Aralığında Personelin Hareketlerini Bul
            List<TEKNISYENHAREKET> hareketler = R.Query<TEKNISYENHAREKET>(refMr).Where(t => t.GIRISTARIHI.Between(StartDate.startOfDay(), FinishDate.endOfDay()) && t.SERVISTEKNISYENID.In(servisTeknisyenler.select(tks=> tks.ID)) && t.DURUM == YeniTeknisyenHareketDurum.Cikis).ToList();
            //Bu Hareketlerde Kullanılan İşEmirİşlemleri Çek
            List<Teknisyen_ViewServisIsEmirIslemIscilikler> iscilikler = Teknisyen_ViewServisIsEmirIslemIscilikler.SelectOverloadFromISLEMID(hareketler.select(t=> t.ISEMIRISLEMID).Distinct().toList());

            PuantajGunlugu pg = new PuantajGunlugu();
            List<ServisGunMola> servisGunMolalari = ServisGunMola.SelectServisGunMolalar(ServisId, refMr);
            List<HareketNeden> hareketNedenler = HareketNeden.Select_Nedenler();

            foreach (SERVISTEKNISYEN_REPORT_DATA servisTeknisyen in servisTeknisyenler)
            {
                var teknisyenHareketler = hareketler.where(t => t.SERVISTEKNISYENID == servisTeknisyen.ID).orderBy(t=> t.GIRISTARIHI).toList();
                List<decimal> teknisyenIslemIds = teknisyenHareketler.select(t => t.ISEMIRISLEMID).Distinct().toList();
                var teknisyenIscilikler = iscilikler.where(t => teknisyenIslemIds.contains(t.SERVISISEMIRISLEMID)).toList();

                servisTeknisyen.Faturalanan_Dakika = (int)teknisyenIscilikler.Sum(t => t.Iscilik_Dakika_Suresi);

                List<DateTime> tarihler = teknisyenHareketler.select(t => t.GIRISTARIHI.Date).Distinct().toList();
                foreach (var tarih in tarihler)
                {
                    var firstIn = teknisyenHareketler.where(t => t.GIRISTARIHI.Date == tarih).first().GIRISTARIHI;
                    var lastOut = teknisyenHareketler.where(t => t.GIRISTARIHI.Date == tarih).last().CIKISTARIHI;
                    servisTeknisyen.NetMevcudiyet_Dakika += (int)(lastOut - firstIn).TotalMinutes;
                }

                TEKNISYENHAREKET.DAGILIM_SONUCLARI hamPntjData = Puantaj.GetPuantajSonuclari(teknisyenHareketler, pg, servisGunMolalari, hareketNedenler);
                servisTeknisyen.FiiliCalisma_Dakika = hamPntjData.GetSonucSure(NedenFormati.NormalCalisma);
            }

            return servisTeknisyenler;
        }

        public class SERVISTEKNISYEN_REPORT_DATA : SERVISTEKNISYENLER
        {
            [ReadOnlyMappedRelation()]
            [RelationCondition("TEKNISYENID", "ID")]
            public TEKNISYENLER Teknisyen { get; set; }

            public int Faturalanan_Dakika { get; set; }
            public int NetMevcudiyet_Dakika { get; set; }
            public int FiiliCalisma_Dakika { get; set; }
        }

    }
}