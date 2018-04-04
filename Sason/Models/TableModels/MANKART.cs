using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Database.Row;

namespace SasonBase.Sason.Models.TableModels
{
    [Serializable()]
    public class MANKART : Tables.Table_MANKART.PublicItem
    {
        #region GetBakiye
        public Decimal GetBakiye()
        {
            return MANKARTHAREKETLER.SelectBakiye(ID);
        }
        #endregion

        #region Puan Hesapla
        public MANKARTHAREKETLER PuanHesapla(List<FATURADETAYLAR> faturaDetaylar, decimal param_ServisId, bool param_PuanKullan, decimal param_KullanilacakPuan)
        {
            MethodReturn ret = new MethodReturn();

            if (param_PuanKullan && param_KullanilacakPuan == 0)
                param_PuanKullan = false;

            decimal p_MinManKartPuan = 50; // Mankart Puanýný Kullanmasý Ýçin Kartýnda en az 50 Tl Olmasý Gerekiyor
            //Orginal Parcalarin Kdv'siz Toplam Tutarlarýnýn Yuzde Kaç'ýný Mankart Puaný Ýle Ödeyebilir
            decimal p_KullanilabilirYuzde = 50;

            List<string> malzemeKodlari = null;
            SERVISSTOKLAR.CONTAINER servisStoklar = null;
            MALZEMELER.CONTAINER malzemeler = null;
            MALZEMEOZELKODLAR.CONTAINER malzemeOzelKodlar = null;

            if (ret.ok())
                malzemeKodlari = faturaDetaylar.select(t => t.KOD).toList();

            if (ret.ok())
            {
                servisStoklar = new SERVISSTOKLAR.CONTAINER(SERVISSTOKLAR.SelectItemsFromCodes(param_ServisId, malzemeKodlari));
                malzemeler = new MALZEMELER.CONTAINER(MALZEMELER.SelectItems(servisStoklar.select(t => t.MALZEMEID)));
                malzemeOzelKodlar = new MALZEMEOZELKODLAR.CONTAINER(MALZEMEOZELKODLAR.SelectAll());
            }

            MANKARTHAREKETLER manKartHareket = new MANKARTHAREKETLER() { MANKARTID = this.ID, FATURAID = 0, TARIH = DateTime.Now };
            ret.Result = manKartHareket;

            if (ret.ok())
            {
                decimal toplamOriginalParcaTutarlari = GetToplamOriginalParcaTutarlari(faturaDetaylar, servisStoklar, malzemeler, malzemeOzelKodlar);

                decimal manKartBakiye = this.GetBakiye();
                decimal kullanmakIstedigiBakiye = param_KullanilacakPuan.CastToRange(0, manKartBakiye);
                decimal maxKullanilacakPuan = toplamOriginalParcaTutarlari.Percent(p_KullanilabilirYuzde).RoundToDecimals(2);

                if (manKartBakiye >= p_MinManKartPuan && param_PuanKullan) //Bakiye Uygun ve Puan Kullanacak Ýþaretlenmiþ Ýse
                {
                    decimal kullanilanPuan = kullanmakIstedigiBakiye.CastToRange(0, maxKullanilacakPuan);
                    decimal kalanParcaTutari = toplamOriginalParcaTutarlari - kullanilanPuan;
                    manKartHareket.HARCANANPUAN = kullanilanPuan;
                    manKartHareket.KAZANILANPUAN = GetKazanilanPuan(
                        kalanParcaTutari.Divide(toplamOriginalParcaTutarlari), 
                        kullanilanPuan.Divide(toplamOriginalParcaTutarlari),
                        faturaDetaylar, servisStoklar, malzemeler, malzemeOzelKodlar);
                }
                else
                {
                    manKartHareket.KAZANILANPUAN = GetKazanilanPuan(1, 0, faturaDetaylar, servisStoklar, malzemeler, malzemeOzelKodlar);
                }
            }

            return manKartHareket;
        }
        #endregion

        #region Container
        public class CONTAINER : Antibiotic.Collections.ListContainer<MANKART>
        {
            Dictionary<Decimal, MANKART> dict = new Dictionary<Decimal, MANKART>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<MANKART> items) : base(items) { }


            public MANKART this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public MANKART Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MANKART> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MANKART> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(MANKART item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(MANKART item)
            {
                dict.remove(item.ID);
            }
        }
        #endregion

        #region Static METHODS
        public static IOrderedQueryable<MANKART> Select
        {
            get { return R.Query<MANKART>(); }
        }

        public static MANKART SelectItem(Decimal ID)
        {
            return R.Query<MANKART>().First(t => t.ID == ID);
        }

        public static List<MANKART> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MANKART>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MANKART> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MANKART>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static MANKART SelectFromSaseNo(string saseNo)
        {
            return Select.First(t => t.SASENO == saseNo);
        }

        public static MANKART SelectFromKartNo(string kartNo)
        {
            return Select.First(t => t.KARTNO == kartNo);
        }

        #region Puan Kullan / Hesapla
        public static MethodReturn PuanKullanHesapla(decimal param_FaturaId, bool param_PuanKullan, decimal param_KullanilacakPuan)
        {
            MethodReturn ret = new MethodReturn();

            if (param_PuanKullan && param_KullanilacakPuan == 0)
                param_PuanKullan = false;

            decimal param_ServisId = 0;

            //Mankart Ayarlar Tablosundan Okunacaklar
            //decimal p_KalanTutarPuanOrani = 0;
            decimal p_MinManKartPuan = 50; // Mankart Puanýný Kullanmasý Ýçin Kartýnda en az 50 Tl Olmasý Gerekiyor
            //Orginal Parcalarin Kdv'siz Toplam Tutarlarýnýn Yuzde Kaç'ýný Mankart Puaný Ýle Ödeyebilir
            decimal p_KullanilabilirYuzde = 50;

            FATURALAR fatura                              = null;
            List<FATURADETAYLAR> faturaDetaylar           = null;
            List<string> malzemeKodlari                   = null;
            SERVISSTOKLAR.CONTAINER servisStoklar         = null;
            MALZEMELER.CONTAINER malzemeler               = null;
            MALZEMEOZELKODLAR.CONTAINER malzemeOzelKodlar = null;
            SERVISISEMIRLER isEmri                        = null;
            MANKART mankart                               = null;

            fatura = FATURALAR.SelectItem(param_FaturaId);
            if (fatura.isNotNull())
                param_ServisId = fatura.SERVISID;
            else
                ret.SetException("Fatura Bilgisine Ulaþýlamadý");

            if (ret.ok())
                isEmri = SERVISISEMIRLER.SelectFromIsEmirNo(fatura.ISEMIRNO);

            if (ret.ok() && isEmri.isNotNull())
                mankart = MANKART.SelectFromSaseNo(isEmri.SASENO);

            if (mankart.isNull())
                ret.SetException("Mankart Yok");

            if (ret.ok())
            {
                faturaDetaylar = FATURADETAYLAR.SelectItemsFromFaturaId(param_FaturaId);
                malzemeKodlari = faturaDetaylar.select(t => t.KOD).toList();
            }

            if (ret.ok())
            {
                servisStoklar = new SERVISSTOKLAR.CONTAINER(SERVISSTOKLAR.SelectItemsFromCodes(param_ServisId, malzemeKodlari));
                malzemeler = new MALZEMELER.CONTAINER(MALZEMELER.SelectItems(servisStoklar.select(t => t.MALZEMEID)));
                malzemeOzelKodlar = new MALZEMEOZELKODLAR.CONTAINER(MALZEMEOZELKODLAR.SelectAll());
            }

            if (ret.ok())
            {
                decimal toplamOriginalParcaTutarlari = GetToplamOriginalParcaTutarlari(faturaDetaylar, servisStoklar, malzemeler, malzemeOzelKodlar);

                MANKARTHAREKETLER manKartHareket = MANKARTHAREKETLER.SelectFromFatura(param_FaturaId).createIsNull();
                manKartHareket.MANKARTID = mankart.ID;
                manKartHareket.FATURAID = param_FaturaId;
                manKartHareket.TARIH = DateTime.Now;

                decimal manKartBakiye = mankart.GetBakiye();
                decimal kullanmakIstedigiBakiye = param_KullanilacakPuan.CastToRange(0, manKartBakiye);
                decimal maxKullanilacakPuan = toplamOriginalParcaTutarlari.Percent(p_KullanilabilirYuzde).RoundToDecimals(2);

                if (manKartBakiye >= p_MinManKartPuan && param_PuanKullan) //Bakiye Uygun ve Puan Kullanacak Ýþaretlenmiþ Ýse
                {
                    decimal kullanilanPuan = kullanmakIstedigiBakiye.CastToRange(0, maxKullanilacakPuan);
                    decimal kalanParcaTutari = toplamOriginalParcaTutarlari - kullanilanPuan;
                    manKartHareket.HARCANANPUAN = kullanilanPuan;
                    manKartHareket.KAZANILANPUAN = GetKazanilanPuan(kalanParcaTutari / toplamOriginalParcaTutarlari, kullanilanPuan / toplamOriginalParcaTutarlari,
                        faturaDetaylar, servisStoklar, malzemeler, malzemeOzelKodlar);
                }
                else
                {
                    manKartHareket.KAZANILANPUAN = GetKazanilanPuan(1, 0, faturaDetaylar, servisStoklar, malzemeler, malzemeOzelKodlar);
                }

                fatura.MANKARTKAZANILAN = manKartHareket.KAZANILANPUAN;
                fatura.MANKARTHARCANAN = manKartHareket.HARCANANPUAN;

                ret = new List<ItemRawModel>().add(fatura).addRange(faturaDetaylar).add(manKartHareket).Update();
            }

            return ret;
        }
        #endregion

        #region GetToplamOriginalParcaTutarlari
        public static Decimal GetToplamOriginalParcaTutarlari(List<FATURADETAYLAR> faturaDetaylar, 
            SERVISSTOKLAR.CONTAINER servisStoklar, 
            MALZEMELER.CONTAINER malzemeler, 
            MALZEMEOZELKODLAR.CONTAINER malzemeOzelKodlar)
        {
            decimal _orjinalParcalarToplamTutari = 0;
            faturaDetaylar.forEach(faturaDetay =>
            {
                faturaDetay.ClearManKartPuanFields();
                SERVISSTOKLAR servisStok = servisStoklar[faturaDetay.KOD];
                MALZEMELER malzeme = null;
                if (servisStok.isNotNull())
                    malzeme = malzemeler[servisStok.MALZEMEID];
                if (malzeme.isNotNull() && malzeme.IsOriginal)
                {
                    MALZEMEOZELKODLAR malzemeOzelKod = malzemeOzelKodlar[malzeme.MALZEMEOZELKODID1];
                    if (malzemeOzelKod.isNotNull() && malzemeOzelKod.KOD.cto<decimal>() > 0)
                        _orjinalParcalarToplamTutari += faturaDetay.TUTAR;
                }
            });
            return _orjinalParcalarToplamTutari;
        }
        #endregion

        #region GetKazanilanPuan
        public static Decimal GetKazanilanPuan(decimal parcaOrani, decimal harcamaOrani,
            List<FATURADETAYLAR> faturaDetaylar, 
            SERVISSTOKLAR.CONTAINER servisStoklar, 
            MALZEMELER.CONTAINER malzemeler, 
            MALZEMEOZELKODLAR.CONTAINER malzemeOzelKodlar)
        {
            if (parcaOrani == 0)
                parcaOrani = 1;

            decimal _kazanilanPuan = 0;
            faturaDetaylar.forEach(faturaDetay =>
            {
                faturaDetay.ClearManKartPuanFields();
                SERVISSTOKLAR servisStok = servisStoklar[faturaDetay.KOD];
                MALZEMELER malzeme = null;
                if (servisStok.isNotNull())
                    malzeme = malzemeler[servisStok.MALZEMEID];
                if (malzeme.isNotNull() && malzeme.IsOriginal)
                {
                    MALZEMEOZELKODLAR malzemeOzelKod = malzemeOzelKodlar[malzeme.MALZEMEOZELKODID1];
                    if (malzemeOzelKod.isNotNull() && malzemeOzelKod.KOD.cto<decimal>() > 0)
                    {
                        faturaDetay.MANKARTORAN = malzemeOzelKod.KOD.cto<decimal>();
                        faturaDetay.MANKARTPUAN = (faturaDetay.TUTAR * parcaOrani).Percent(faturaDetay.MANKARTORAN).RoundToDecimals(2);
                        faturaDetay.MANKARTHARCANAN = (faturaDetay.TUTAR * harcamaOrani).RoundToDecimals(2);
                        _kazanilanPuan += faturaDetay.MANKARTPUAN;
                    }
                    //faturaDetay.p_KdvTutari = (faturaDetay.TUTAR - faturaDetay.MANKARTHARCANAN).Percent(faturaDetay.KDVORAN);
                }
            });
            return _kazanilanPuan;
        }
        #endregion

        #endregion
    }
}