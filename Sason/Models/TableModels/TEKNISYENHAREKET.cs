using Antibiotic.Extensions;
using SasonBase.Sason.Models.PdksModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.TableModels
{
    public enum YeniTeknisyenHareketDurum
    {
        None          = 0,
        Giris         = 1,
        Cikis         = 2,
        DevamBekliyor = 3
    }

    public class TEKNISYENHAREKET : Tables.Table_TEKNISYENHAREKET.RawItem
    {
        public virtual Decimal ID { get; set; }
        public virtual Decimal SERVISID { get; set; }
        public virtual Decimal SERVISTEKNISYENID { get; set; }
        public virtual Decimal ISEMIRID { get; set; }
        public virtual Decimal ISEMIRISLEMID { get; set; }
        public virtual Decimal ISEMIRISLEMISCILIKID { get; set; }
        public virtual DateTime GIRISTARIHI { get; set; }
        public virtual DateTime CIKISTARIHI { get; set; }
        public virtual Int32 GIRISNEDENID { get; set; }
        public virtual Int32 CIKISNEDENID { get; set; }
        public virtual YeniTeknisyenHareketDurum DURUM { get; set; }
        public virtual Decimal EXTGSERVISTEKNISYENID { get; set; }
        public virtual Decimal EXTCSERVISTEKNISYENID { get; set; }

        public DateTime AktifCikisTarih
        {
            get
            {
                if (CIKISTARIHI == DateTime.MinValue)
                    return DateTime.Now;
                return CIKISTARIHI;
            }
        }

        public string ResultImagePath
        {
            get
            {
                string fileName = "";
                switch (DURUM)
                {
                    case YeniTeknisyenHareketDurum.None:
                        fileName = "";
                        break;
                    case YeniTeknisyenHareketDurum.Giris:
                        //fileName = "../images/running.png";
                        fileName = "../images/nedengiris.png";
                        break;
                    case YeniTeknisyenHareketDurum.Cikis:
                        fileName = "../images/completed.png";
                        break;
                    case YeniTeknisyenHareketDurum.DevamBekliyor:
                        fileName = "../images/waiting.png";
                        break;
                }
                return fileName;
            }
        }

        public static void CikisiYapilmamisHareketiKapat(decimal servisId, decimal servisTeknisyenId)
        {
            MethodReturn mr = new MethodReturn();
            using (var ap = SasonBaseApplicationPool.CreateMask)
            {
                TEKNISYENHAREKET oncekiHareket = R.Query<TEKNISYENHAREKET>(mr).First(t => t.SERVISID == servisId && t.SERVISTEKNISYENID == servisTeknisyenId && t.GIRISTARIHI < DateTime.Now.startOfDay() && t.DURUM == YeniTeknisyenHareketDurum.Giris);
                if (oncekiHareket.isNotNull())
                {
                    ServisGunMola servisGunMola = ServisGunMola.SelectServisGunMola(servisId, oncekiHareket.GIRISTARIHI.DayOfWeek, mr).createIsNull();
                    if (servisGunMola.BitisSaati == 0)
                        servisGunMola.BitisSaati = 1080;

                    //giriş tarihine ait çalışma gününün çıkış saati set edilecek
                    oncekiHareket.CIKISTARIHI = oncekiHareket.GIRISTARIHI.startOfDay().AddMinutes(servisGunMola.BitisSaati);
                    oncekiHareket.CIKISNEDENID = 21;
                    oncekiHareket.DURUM = YeniTeknisyenHareketDurum.Cikis;
                    oncekiHareket.EXTCSERVISTEKNISYENID = -1;//System User
                    oncekiHareket.Update();
                }
            }
        }

        public static TEKNISYENHAREKET Get_GirisHareketi(decimal servisTeknisyenId, MethodReturn mr = null)
        {
            using (var ap = SasonBaseApplicationPool.CreateMask)
                return R.Query<TEKNISYENHAREKET>(mr).First(t => t.SERVISTEKNISYENID == servisTeknisyenId && t.DURUM == YeniTeknisyenHareketDurum.Giris);
        }

        public static List<TEKNISYENHAREKET> Get_GirisVeyaGirisBekleyenHareketleri(decimal servisTeknisyenId, MethodReturn mr = null)
        {
            using (var ap = SasonBaseApplicationPool.CreateMask)
                return R.Query<TEKNISYENHAREKET>(mr).Where(t => t.SERVISTEKNISYENID == servisTeknisyenId && (t.DURUM == YeniTeknisyenHareketDurum.Giris || t.DURUM == YeniTeknisyenHareketDurum.DevamBekliyor)).ToList();
        }

        public static List<TEKNISYENHAREKET> Get_GirisVeyaGirisBekleyenHareketleri(decimal servisTeknisyenId, decimal isEmirIslemId, MethodReturn mr = null)
        {
            using (var ap = SasonBaseApplicationPool.CreateMask)
                return R.Query<TEKNISYENHAREKET>(mr).Where(t => t.SERVISTEKNISYENID == servisTeknisyenId && t.ISEMIRISLEMID == isEmirIslemId && (t.DURUM == YeniTeknisyenHareketDurum.Giris || t.DURUM == YeniTeknisyenHareketDurum.DevamBekliyor)).ToList();
        }




        public static List<TEKNISYENHAREKET> GetTeknisyenIsEmirIslemHareketleri(decimal servisTeknisyenId, decimal isEmirIslemId)
        {
            using (var ap = SasonBaseApplicationPool.CreateMask)
                return R.Query<TEKNISYENHAREKET>().Where(t => t.SERVISTEKNISYENID == servisTeknisyenId && t.ISEMIRISLEMID == isEmirIslemId).ToList();
        }

        public static List<TEKNISYENHAREKET> GetGirisVeyaDevamEtmesiGerekenHareketler(decimal servisTeknisyenId, MethodReturn mr = null)
        {
            using (var ap = SasonBaseApplicationPool.CreateMask)
                return R.Query<TEKNISYENHAREKET>(mr).Where(t => t.SERVISTEKNISYENID == servisTeknisyenId && (t.DURUM == YeniTeknisyenHareketDurum.Giris || t.DURUM == YeniTeknisyenHareketDurum.DevamBekliyor)).ToList();
        }


        public static TEKNISYENHAREKET GetAktifHareket(decimal servisTeknisyenId, decimal isEmirIslemId, MethodReturn mr = null)
        {
            TEKNISYENHAREKET ret = null;
            List<TEKNISYENHAREKET> hareketler = Get_GirisVeyaGirisBekleyenHareketleri(servisTeknisyenId, isEmirIslemId, mr);
            ret = hareketler.first(t => t.DURUM == YeniTeknisyenHareketDurum.Giris);
            if (ret == null)
                ret = hareketler.first(t => t.DURUM == YeniTeknisyenHareketDurum.DevamBekliyor);
            return ret;
        }

        /// <summary>
        /// 0 = Hareketi Yok, veya Devam Etmesi Gereken Hareketi Yok, veya Giris Hareketi Yok
        /// </summary>
        /// <param name="servisId"></param>
        /// <param name="servisTeknisyenId"></param>
        /// <param name="isEmirId"></param>
        /// <param name="isEmirIslemId"></param>
        /// <returns></returns>
        public static decimal IslemeGirisYapabilirMi(decimal servisId, decimal servisTeknisyenId, decimal isEmirId, decimal isEmirIslemId, MethodReturn mr = null)
        {
            decimal result = 0;
            using (var ap = SasonBaseApplicationPool.CreateMask)
            {
                /*
                 * Eğer giriş veya devam etmesi Gereken hareketleri varsa
                 */
                List<TEKNISYENHAREKET> hareketler = GetGirisVeyaDevamEtmesiGerekenHareketler(servisTeknisyenId, mr);
                if (hareketler.isNotEmpty())
                {
                    TEKNISYENHAREKET girisHareketi = hareketler.first(t => t.DURUM == YeniTeknisyenHareketDurum.Giris);
                    if (girisHareketi.isNotNull())
                    {
                        if (girisHareketi.ISEMIRISLEMID != isEmirIslemId)
                            result = -1;
                        else
                            result = girisHareketi.ID;
                    }
                    else
                    {
                        TEKNISYENHAREKET devamBekliyor = hareketler.first(t => t.DURUM == YeniTeknisyenHareketDurum.DevamBekliyor);
                        if (devamBekliyor.isNotNull())
                            result = devamBekliyor.ID;
                    }
                }
            }
            return result;
        }

        public static List<TEKNISYENHAREKET> GetIsEmirIslemHareketleri(decimal isEmirIslemId, MethodReturn mr = null)
        {
            using (var ap = SasonBaseApplicationPool.CreateMask)
                return R.Query<TEKNISYENHAREKET>(mr).Where(t => t.ISEMIRISLEMID == isEmirIslemId).toList();
        }

        public static TEKNISYENHAREKET GetTeknisyenHareket(decimal id)
        {
            using (var ap = SasonBaseApplicationPool.CreateMask)
                return R.Query<TEKNISYENHAREKET>().First(t => t.ID == id);
        }




        public class DAGILIM_SONUCLARI : Antibiotic.Collections.ListContainer<DAGILIM_SONUCU>
        {
            Dictionary<decimal, Dictionary<DateTime, List<DAGILIM_SONUCU>>> teknisyen_Tarih_Sonuclar = new Dictionary<decimal, Dictionary<DateTime, List<DAGILIM_SONUCU>>>();
            Dictionary<decimal, List<DAGILIM_SONUCU>> teknisyen_Sonuclar = new Dictionary<decimal, List<DAGILIM_SONUCU>>();
            public override void Add(DAGILIM_SONUCU item)
            {
                teknisyen_Tarih_Sonuclar.check(item.TeknisyenId).check(item.Tarih).add(item);
                teknisyen_Sonuclar.check(item.TeknisyenId).add(item);
                base.Add(item);
            }

            public int GetSonucSure(decimal servisTeknisyenId, NedenFormati format)
            {
                return GetSonucSure(teknisyen_Sonuclar.find(servisTeknisyenId), format);
            }

            public int GetSonucSure(NedenFormati format)
            {
                return GetSonucSure(base.list, format);
            }

            public int GetSonucSure(List<DAGILIM_SONUCU> sonuclar, NedenFormati format)
            {
                int ret = 0;
                sonuclar.forEach(l =>
                {
                    if (l.Neden.FORMATI == format)
                        ret += l.Sure;
                });
                return ret;
            }
        }




        public class DAGILIM_SONUCU
        {
            public decimal TeknisyenId { get; set; }
            public TEKNISYENHAREKET Hareket { get; set; }
            public DateTime Tarih { get; set; }
            public HareketNeden Neden { get; set; }
            public int BaslangicSaati { get; set; }
            public int BitisSaati { get; set; }
            public int Sure { get; set; }

            public string BaslangicSaatiString { get => BaslangicSaati.toTimeString(); }
            public string BitisSaatiString { get => BitisSaati.toTimeString(); }
        }



    }
}