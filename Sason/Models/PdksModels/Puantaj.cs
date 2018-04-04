using Antibiotic.Extensions;
using SasonBase.Sason.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.PdksModels
{
    public static class Puantaj
    {
        public static TeknisyenHareketDagilimSonuclari GetPuantajSonuclari<THRT>(List<THRT> teknisyenHareketleri, PuantajGunlugu pg, List<ServisGunMola> servisGunMolalari, List<HareketNeden> nedenler) where THRT:TeknisyenHareket
        {
            TeknisyenHareketDagilimSonuclari sonuclar = new TeknisyenHareketDagilimSonuclari();
            foreach (TeknisyenHareket hareket in teknisyenHareketleri)
            {
                List<DateTimeBetween> tarihler = Antibiotic.Helpers.DateTimeHelper.DatePartials(hareket.GIRISTARIHI, hareket.AktifCikisTarih, Antibiotic.Helpers.eTimeTypes.Gun);

                foreach (DateTimeBetween tarihArasi in tarihler)
                {
                    pg.MolalardanDagilimOlustur(servisGunMolalari.first(t => t.HaftaninGunu == tarihArasi.Start.DayOfWeek));
                    pg.InitNedenler(nedenler);

                    int girisSaati = tarihArasi.Start.toDbIntTimeRoundSecond();
                    int cikisSaati = tarihArasi.Finish.toDbIntTimeRoundSecond();
                    
                    pg.Dagilim.forEach(dag =>
                    {
                        int intersectValue = 0;
                        int intersectStart = 0;
                        int intersectEnd   = 0;
                        if (Antibiotic.Helpers.IntegerHelpers.IsIntersect(dag.BaslangicSaati, dag.BitisSaati, girisSaati, cikisSaati, out intersectValue, out intersectStart, out intersectEnd))
                        {
                            //Console.WriteLine($"Hrk:[{tarihArasi.Start.ToString("dd.MM.yyyy HH:mm")}, {tarihArasi.Finish.ToString("dd.MM.yyyy HH:mm")}] => Sonuç:{tarihArasi.Start.Date.ToString("dd.MM.yyyy")} [{dag.NedenKodu}] ({intersectStart.toTimeString()}-{intersectEnd.toTimeString()})={intersectValue.toTimeString()}");
                            TeknisyenHareketDagilimSonucu sonuc = new TeknisyenHareketDagilimSonucu()
                            {
                                TeknisyenId    = hareket.SERVISTEKNISYENID,
                                Hareket        = hareket,
                                Tarih          = tarihArasi.Start.Date,
                                Neden          = dag.Neden,
                                BaslangicSaati = intersectStart,
                                BitisSaati     = intersectEnd,
                                Sure           = intersectValue,
                            };
                            sonuclar.Add(sonuc);
                        }
                    });
                }
            }
            return sonuclar;
        }




        public static TEKNISYENHAREKET.DAGILIM_SONUCLARI GetPuantajSonuclari(List<TEKNISYENHAREKET> teknisyenHareketleri, PuantajGunlugu pg, List<ServisGunMola> servisGunMolalari, List<HareketNeden> nedenler)
        {
            TEKNISYENHAREKET.DAGILIM_SONUCLARI sonuclar = new TEKNISYENHAREKET.DAGILIM_SONUCLARI();
            foreach (TEKNISYENHAREKET hareket in teknisyenHareketleri)
            {
                List<DateTimeBetween> tarihler = Antibiotic.Helpers.DateTimeHelper.DatePartials(hareket.GIRISTARIHI, hareket.AktifCikisTarih, Antibiotic.Helpers.eTimeTypes.Gun);

                foreach (DateTimeBetween tarihArasi in tarihler)
                {
                    pg.MolalardanDagilimOlustur(servisGunMolalari.first(t => t.HaftaninGunu == tarihArasi.Start.DayOfWeek));
                    pg.InitNedenler(nedenler);

                    int girisSaati = tarihArasi.Start.toDbIntTimeRoundSecond();
                    int cikisSaati = tarihArasi.Finish.toDbIntTimeRoundSecond();

                    pg.Dagilim.forEach(dag =>
                    {
                        int intersectValue = 0;
                        int intersectStart = 0;
                        int intersectEnd = 0;
                        if (Antibiotic.Helpers.IntegerHelpers.IsIntersect(dag.BaslangicSaati, dag.BitisSaati, girisSaati, cikisSaati, out intersectValue, out intersectStart, out intersectEnd))
                        {
                            //Console.WriteLine($"Hrk:[{tarihArasi.Start.ToString("dd.MM.yyyy HH:mm")}, {tarihArasi.Finish.ToString("dd.MM.yyyy HH:mm")}] => Sonuç:{tarihArasi.Start.Date.ToString("dd.MM.yyyy")} [{dag.NedenKodu}] ({intersectStart.toTimeString()}-{intersectEnd.toTimeString()})={intersectValue.toTimeString()}");
                            TEKNISYENHAREKET.DAGILIM_SONUCU sonuc = new TEKNISYENHAREKET.DAGILIM_SONUCU()
                            {
                                TeknisyenId = hareket.SERVISTEKNISYENID,
                                Hareket = hareket,
                                Tarih = tarihArasi.Start.Date,
                                Neden = dag.Neden,
                                BaslangicSaati = intersectStart,
                                BitisSaati = intersectEnd,
                                Sure = intersectValue,
                            };
                            sonuclar.Add(sonuc);
                        }
                    });
                }
            }
            return sonuclar;
        }
    }


}