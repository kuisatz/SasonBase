using Antibiotic.Database.Query;
using Antibiotic.Database.Query.Statements;
using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.PdksModels
{
    public enum TeknisyenHareketDurum
    {
        None          = 0,
        Giris         = 1,
        Cikis         = 2,
        DevamBekliyor = 3
    }

    public partial class TeknisyenHareket : Tables.Table_TTEKNISYENHRK.RawItem
    {
        public virtual Decimal ID { get; set; }
        public virtual Decimal THRKUSTBILGIID { get; set; }
        public virtual Decimal SERVISTEKNISYENID { get; set; }
        public virtual DateTime GIRISTARIHI { get; set; }
        public virtual DateTime CIKISTARIHI { get; set; }
        public virtual TeknisyenHareketDurum DURUM { get; set; }
        public virtual Int32 GIRISNEDENID { get; set; }
        public virtual Int32 CIKISNEDENID { get; set; }
        public virtual String FNOTE { get; set; }

        public int CalismaDakika
        {
            get
            {
                int ret = (AktifCikisTarih - GIRISTARIHI).TotalMinutes.toInt();
                return ret;
            }
        }

        public DateTime AktifCikisTarih
        {
            get
            {
                if (CIKISTARIHI == DateTime.MinValue)
                    return DateTime.Now;
                return CIKISTARIHI;
            }
        }
    }

    public class TeknisyenHareketContainer <TTekHrk>: Antibiotic.Collections.ListContainer<TTekHrk> where TTekHrk : TeknisyenHareket
    {
        Dictionary<decimal, List<TTekHrk>> teknisyenIdDict = new Dictionary<decimal, List<TTekHrk>>();
        Dictionary<decimal, List<TTekHrk>> ustBilgiIdDict = new Dictionary<decimal, List<TTekHrk>>();

        public TeknisyenHareketContainer() { }
        public TeknisyenHareketContainer(IEnumerable<TTekHrk> items) : base(items) { }

        public List<TTekHrk> GetTeknisyenHareketler(Decimal servisTeknisyenId)
        {
            return teknisyenIdDict.find(servisTeknisyenId);
        }

        public List<TTekHrk> GetUstBilgiHareketler(decimal ustBilgiId)
        {
            return ustBilgiIdDict.find(ustBilgiId);
        }

        protected override void OnBeforeInsert(TTekHrk item, ref bool cancel)
        {
            teknisyenIdDict.check(item.SERVISTEKNISYENID).add(item);
            ustBilgiIdDict.check(item.THRKUSTBILGIID).add(item);
        }
    }

    public partial class TeknisyenHareket
    {
        //public static List<TeknisyenHareket> Select_Servis_AktifTeknisyenHareketleri(decimal servisId, MethodReturn refMr = null)
        //{
        //    List<TeknisyenHareket> list = SasonBaseApplicationPool.Get.EbaTestConnector.CreateQuery($@"
        //        select * from tteknisyenhrk where thrkustbilgiid in (select id from thrkustbilgi where isemirid in (select id from servisisemirler where servisid = {servisId} and teknikolaraktamamla = 0))
        //        ").GetDataTable(refMr).ToModels<TeknisyenHareket>();
        //    return list;
        //}
        public static List<T> Select_From_UstBilgi_Ids<T>(IEnumerable<Decimal> ustBilgiIds) where T:TeknisyenHareket
        {
            Exception ex = null;
            if (ustBilgiIds.isEmpty())
                return new List<T>();
            return Antibiotic.Database._Helpers.ItemHelpers.SelectItemsFromFieldInValues(typeof(T), "THRKUSTBILGIID", ustBilgiIds.toList<object>(), out ex).toList<T>();
        }


        public static List<TeknisyenHareket> Select_IsEmir_TeknisyenHareketleri(decimal isEmirId, MethodReturn refMr = null)
        {
            List<TeknisyenHareket> list = SasonBaseApplicationPool.Get.EbaTestConnector.CreateQuery($@"
                select * from tteknisyenhrk where thrkustbilgiid in (select id from thrkustbilgi where isemirid = {isEmirId})
                ").GetDataTable(refMr).ToModels<TeknisyenHareket>();
            return list;
        }

        public static List<TeknisyenHareket> Select_IsEmirler_TeknisyenHareketleri(IEnumerable<decimal> isEmirIds, MethodReturn refMr = null)
        {
            if (isEmirIds.isEmpty())
                return new List<TeknisyenHareket>();
            dbSelect sel = new dbSelect("tteknisyenhrk").where(qt.field("thrkustbilgiid").inn(new dbSelect("thrkustbilgi").select("id").where(qt.field("isemirid").inn(isEmirIds))));
            MethodReturn mr = SasonBaseApplicationPool.Get.EbaTestConnector.GetDataTable(sel);
            return mr.Result.cast<DataTable>().ToModels<TeknisyenHareket>(refMr);
        }

        public static List<TeknisyenHareket> Select_IsEmirIslem_TeknisyenHareketleri(decimal isEmirIslemId, MethodReturn refMr = null)
        {
            List<TeknisyenHareket> list = SasonBaseApplicationPool.Get.EbaTestConnector.CreateQuery($@"
                select * from tteknisyenhrk where thrkustbilgiid in (select id from thrkustbilgi where isemirislemid = {isEmirIslemId})
                ").GetDataTable(refMr).ToModels<TeknisyenHareket>();
            return list;
        }

        public static List<TeknisyenHareket> Select_IsEmirIslemIscilik_TeknisyenHareketleri(decimal isEmirIslemIscilikId, MethodReturn refMr = null)
        {
            List<TeknisyenHareket> list = SasonBaseApplicationPool.Get.EbaTestConnector.CreateQuery($@"
                select * from tteknisyenhrk where thrkustbilgiid in (select id from thrkustbilgi where isemirislemiscilikid = {isEmirIslemIscilikId})
                ").GetDataTable(refMr).ToModels<TeknisyenHareket>();
            return list;
        }



        //public static void IsEmirIslem_IscilikSorgula(decimal servisTeknisyenId, decimal isEmirIslemIscilikId)
        //{
        //    HareketUstBilgi hareketUstBilgi = HareketUstBilgi.Select_IsEmirIslemIscilik_UstHareketBilgisi(isEmirIslemIscilikId);
        //    //servisTeknisyen in actif veya bekleyen hareketleri alınacak
        //}


        public static List<TeknisyenHareket> Select_Teknisyen_Hareketler(DateTime startDate, DateTime finishDate, params decimal[] servisTeknisyenId)
        {
            if (servisTeknisyenId.isEmpty())
                return new List<TeknisyenHareket>();

            return R.Query<TeknisyenHareket>()
                .Where(t => t.SERVISTEKNISYENID.In(servisTeknisyenId) && (t.GIRISTARIHI.Between(startDate, finishDate) || t.CIKISTARIHI.Between(startDate, finishDate)))
                //.OrderBy(t=> t.GIRISTARIHI)
                .ToList();
        }

        public static List<TeknisyenHareket> Select_Teknisyenler_Hareketleri(IEnumerable<decimal> servisTeknisyenIdler, DateTime startDate, DateTime finishDate)
        {
            if (servisTeknisyenIdler.isEmpty())
                return new List<TeknisyenHareket>();

            return R.Query<TeknisyenHareket>()
                .Where(t => t.SERVISTEKNISYENID.In(servisTeknisyenIdler) && (t.GIRISTARIHI.Between(startDate, finishDate) || t.CIKISTARIHI.Between(startDate, finishDate)))
                //.OrderBy(t => t.GIRISTARIHI)
                .ToList();
        }



        public static TeknisyenHareket GetTeknisyenHareketFromId(decimal id)
        {
            return R.Query<TeknisyenHareket>().First(t => t.ID == id);
        }


        public static TeknisyenHareket GetTeknisyenCikisiYapilmamisGirisHareketiFromIsEmirIslemIscilikId(decimal isEmirIslemIscilikId, decimal servisTeknisyenId)
        {
            return GetTeknisyenCikisiYapilmamisGirisHareketi(HareketUstBilgi.Select_IsEmirIslemIscilik_UstHareketBilgisi(isEmirIslemIscilikId), servisTeknisyenId);
        }

        public static TeknisyenHareket GetTeknisyenCikisiYapilmamisGirisHareketi(HareketUstBilgi ustBilgi, decimal servisTeknisyenId)
        {
            return GetTeknisyenCikisiYapilmamisGirisHareketi(ustBilgi.ID, servisTeknisyenId);
        }

        public static TeknisyenHareket GetTeknisyenCikisiYapilmamisGirisHareketi(decimal tHrkUstBilgiId, decimal servisTeknisyenId)
        {
            return R.Query<TeknisyenHareket>().First(t => t.SERVISTEKNISYENID == servisTeknisyenId && t.THRKUSTBILGIID == tHrkUstBilgiId && t.DURUM == TeknisyenHareketDurum.Giris);
        }





        public static TeknisyenHareket GetTeknisyenGirisVeyaDevamBekleyenHareket(decimal servisTeknisyenId)
        {
            return R.Query<TeknisyenHareket>()
                .First(t => t.SERVISTEKNISYENID == servisTeknisyenId && (t.DURUM == TeknisyenHareketDurum.Giris || t.DURUM == TeknisyenHareketDurum.DevamBekliyor));
        }

        public static List<TeknisyenHareket> GetTeknisyenGirisVeyaDevamBekleyenHareketler(decimal servisTeknisyenId)
        {
            return R.Query<TeknisyenHareket>()
                .Where(t => t.SERVISTEKNISYENID == servisTeknisyenId && (t.DURUM == TeknisyenHareketDurum.Giris || t.DURUM == TeknisyenHareketDurum.DevamBekliyor)).ToList();
        }

        public static List<TeknisyenHareket> GetTeknisyenGirisVeyaDevamBekleyenHareketler(decimal thrkUstBilgiId, decimal servisTeknisyenId)
        {
            return R.Query<TeknisyenHareket>()
                .Where(t => t.SERVISTEKNISYENID == servisTeknisyenId && t.THRKUSTBILGIID == thrkUstBilgiId && (t.DURUM == TeknisyenHareketDurum.Giris || t.DURUM == TeknisyenHareketDurum.DevamBekliyor)).ToList();
        }

        public static List<TeknisyenHareket> GetTeknisyenHareketler(decimal ustBilgiId, decimal servisTeknisyenId, params TeknisyenHareketDurum[] durumlar)
        {
            if (durumlar.isEmpty())
            {
                return R.Query<TeknisyenHareket>()
                    .Where(t => t.SERVISTEKNISYENID == servisTeknisyenId && t.THRKUSTBILGIID == ustBilgiId).ToList();
            }
            else
            {
                return R.Query<TeknisyenHareket>()
                    .Where(t => t.SERVISTEKNISYENID == servisTeknisyenId && t.THRKUSTBILGIID == ustBilgiId && t.DURUM.In(durumlar)).ToList();

            }
        }

        /// <summary>
        /// Eğer Giriş Olan Bir Hareket Varsa Onu Verir, Yoksa Devam Etmeye Bekleyen Bir Hareket Varsa O'nu Verir, Yoksa Null
        /// Bir Teknisyenin Yalnız Bir Tane Giriş Hareketi Olabilir
        /// Bir Teknisyenin IsEmirİsçilik İçin Yalnız Bir Tane DevamEdebilir Hareketi Bekleyen Bir Hareketi Olabilir.
        /// </summary>
        /// <param name="isEmirIscilikId"></param>
        /// <param name="servisTeknisyenId"></param>
        /// <returns></returns>
        public static TeknisyenHareket GetAktifHareket(decimal isEmirIscilikId, decimal servisTeknisyenId)
        {
            return GetAktifHareketFromUstBilgi(HareketUstBilgi.Select_IsEmirIslemIscilik_UstHareketBilgisi(isEmirIscilikId), servisTeknisyenId);
        }

        public static TeknisyenHareket GetAktifHareketFromUstBilgi(HareketUstBilgi ustbilgi, decimal servisTeknisyenId)
        {
            return GetAktifHareketFromUstBilgi(ustbilgi.ID, servisTeknisyenId);
        }

        public static TeknisyenHareket GetAktifHareketFromUstBilgi(decimal tHrkUstBilgiId, decimal servisTeknisyenId)
        {
            TeknisyenHareket ret = null;
            List<TeknisyenHareket> aktifHareketler = R.Query<TeknisyenHareket>().Where(t => t.SERVISTEKNISYENID == servisTeknisyenId && t.THRKUSTBILGIID == tHrkUstBilgiId && (t.DURUM == TeknisyenHareketDurum.Giris || t.DURUM == TeknisyenHareketDurum.DevamBekliyor)).ToList();
            ret = aktifHareketler.first(t => t.DURUM == TeknisyenHareketDurum.Giris);// Öncelik Giriş Hareketinin
            if (ret == null)
                ret = aktifHareketler.first(t => t.DURUM == TeknisyenHareketDurum.DevamBekliyor); //Yoksa Devam Bekliyor Hareketinin
            return ret;
        }
    }


    public class TeknisyenHareketDagilimSonuclari : Antibiotic.Collections.ListContainer<TeknisyenHareketDagilimSonucu>
    {
        Dictionary<decimal, Dictionary<DateTime, List<TeknisyenHareketDagilimSonucu>>> teknisyen_Tarih_Sonuclar = new Dictionary<decimal, Dictionary<DateTime, List<TeknisyenHareketDagilimSonucu>>>();
        Dictionary<decimal, List<TeknisyenHareketDagilimSonucu>> teknisyen_Sonuclar = new Dictionary<decimal, List<TeknisyenHareketDagilimSonucu>>();
        public override void Add(TeknisyenHareketDagilimSonucu item)
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

        public int GetSonucSure(List<TeknisyenHareketDagilimSonucu> sonuclar, NedenFormati format)
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

    public class TeknisyenHareketDagilimSonucu
    {
        public decimal TeknisyenId { get; set; }
        public TeknisyenHareket Hareket { get; set; }
        public DateTime Tarih { get; set; }
        public HareketNeden Neden { get; set; }
        public int BaslangicSaati { get; set; }
        public int BitisSaati { get; set; }
        public int Sure { get; set; }
    }












}