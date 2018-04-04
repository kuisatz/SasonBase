using Antibiotic.Database.Field;
using Antibiotic.Database.Query;
using Antibiotic.Database.Query.Statements;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;
using SasonBase.Sason.Models.PdksModels;
using SasonBase.Sason.Models.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.TeknisyenModels
{
    static class LocalHelpers
    {
        public static TeknisyenHareketDurum GetTeknisyenDurum(decimal servisTeknisyenId, List<TeknisyenHareket> hareketler, List<HareketUstBilgi> ustBilgiler)
        {
            List<TeknisyenHareket> ustBilgiHareketleri;
            List<TeknisyenHareket> servisTeknisyenHareketleri;
            return GetTeknisyenDurum(servisTeknisyenId, hareketler, ustBilgiler, out ustBilgiHareketleri, out servisTeknisyenHareketleri);
        }

        public static TeknisyenHareketDurum GetTeknisyenDurum(decimal servisTeknisyenId, List<TeknisyenHareket> hareketler,  List<HareketUstBilgi> ustBilgiler, out List<TeknisyenHareket> ustBilgiHareketleri, out List<TeknisyenHareket> servisTeknisyenHareketleri)
        {
            TeknisyenHareketDurum teknisyenDurum = TeknisyenHareketDurum.None;

            var ustBilgiIDler = ustBilgiler.select(t => t.ID).toList();

            ustBilgiHareketleri             = hareketler.where(t => ustBilgiIDler.Contains(t.THRKUSTBILGIID)).toList();
            servisTeknisyenHareketleri      = ustBilgiHareketleri.where(t => t.SERVISTEKNISYENID == servisTeknisyenId).toList();

            if (servisTeknisyenHareketleri.isEmpty())
                teknisyenDurum = TeknisyenHareketDurum.None;//servisTeknisyen'in harketi yok
            else
            {
                if (servisTeknisyenHareketleri.first(t => t.DURUM == TeknisyenHareketDurum.Giris).isNotNull())
                    teknisyenDurum = TeknisyenHareketDurum.Giris;
                else if (servisTeknisyenHareketleri.first(t => t.DURUM == TeknisyenHareketDurum.DevamBekliyor).isNotNull())
                    teknisyenDurum = TeknisyenHareketDurum.DevamBekliyor;
                else if (servisTeknisyenHareketleri.first(t => t.DURUM == TeknisyenHareketDurum.Cikis).isNotNull())
                    teknisyenDurum = TeknisyenHareketDurum.Cikis;
            }

            return teknisyenDurum;
        }
    }






    public class Teknisyen_ViewServisIsEmirler : Tables.Table_SERVISISEMIRLER.RawItem
    {
        public decimal ID { get; set; }
        protected decimal SERVISARACID { get; set; }
        public Decimal SERVISID { get; set; }
        public Decimal TEKNIKOLARAKTAMAMLA { get; set; }

        [DbTargetField("MUSTERIAD")] public string AraciGetiren { get; set; }
        [DbTargetField("ACIKLAMA")] public string Aciklama { get; set; }
        [DbTargetField("ISEMIRNO")] public string IsEmirNo { get; set; }

        [DbTargetField("SASENO")] public String AracSaseNo { get; set; }
        [DbTargetField("PLAKA")] public String AracPlaka { get; set; }
        [DbTargetField("KM")] public decimal AracKm { get; set; }
        [DbTargetField("MODELNO")] public string AracModelNo { get; set; }

        internal DateTime KAYITTARIH { get; set; }

        public string KayitTarihiStr
        {
            get
            {
                return KAYITTARIH.ToString("dd.MM.yyyy HH:mm");
            }
        }

        //public ViewServisIsEmirDurumu Durumu { get; set; }

        //public TeknisyenHareketDurum GenelIsDurumu { get; set; }

        internal DateTime? IlkHareketTarihi { get; set; }
        internal DateTime? SonHareketTarihi { get; set; }

        public string IlkHareketTarihiStr
        {
            get
            {
                if (IlkHareketTarihi.isNotNull())
                    return IlkHareketTarihi.Value.ToString("dd.MM.yyyy HH:mm");
                return "-";
            }
        }

        public string SonHareketTarihiStr
        {
            get
            {
                if (SonHareketTarihi.isNotNull())
                    return SonHareketTarihi.Value.ToString("dd.MM.yyyy HH:mm");
                return "-";
            }
        }


        internal TeknisyenHareketDurum TeknisyenIsDurumu { get; set; }
        public string TeknisyenDurumResim
        {
            get
            {
                string fileName = "";
                switch (TeknisyenIsDurumu)
                {
                    case TeknisyenHareketDurum.None:
                        fileName = "";
                        break;
                    case TeknisyenHareketDurum.Giris:
                        fileName = "../images/running.png";
                        break;
                    case TeknisyenHareketDurum.Cikis:
                        fileName = "../images/completed.png";
                        break;
                    case TeknisyenHareketDurum.DevamBekliyor:
                        fileName = "../images/waiting.png";
                        break;
                }
                return fileName;
            }
        }

        internal int PlanlananSure { get; set; }
        internal int CalisilanSure { get; set; }
        internal int TeknisyenSure { get; set; }

        public string PlanlananSureStr { get { return PlanlananSure.toTimeStringZeroThenEmpty(); } }
        public string CalisilanSureStr { get { return CalisilanSure.toTimeStringZeroThenEmpty(); } }
        public string TeknisyenSureStr { get { return TeknisyenSure.toTimeStringZeroThenEmpty(); } }

        public static List<Teknisyen_ViewServisIsEmirler> Select_Servis_IsEmirler_View(decimal servisId, decimal servisTeknisyenId)
        {
            MethodReturn mr = new MethodReturn();

            List<Teknisyen_ViewServisIsEmirler>                 servis_IsEmirleri    = R.Query<Teknisyen_ViewServisIsEmirler>().Where(t => t.SERVISID == servisId && t.TEKNIKOLARAKTAMAMLA == 0).ToList();

            List<decimal> isEmirIds = servis_IsEmirleri.select(t => t.ID).ToList();

            List<HareketUstBilgi>                               servis_UstHareketBilgileri          = HareketUstBilgi.Select_IsEmirler_UstHareketBilgileri(isEmirIds);
            List<TeknisyenHareket>                              servis_TeknisyenHareketleri         = TeknisyenHareket.Select_IsEmirler_TeknisyenHareketleri(isEmirIds);
            List<Teknisyen_ViewServisIsEmirIslemler>            servis_IsEmirIslemleri              = Teknisyen_ViewServisIsEmirIslemler.Select_IsEmirler_Islemler(isEmirIds);
            List<Teknisyen_ViewServisIsEmirIslemIscilikler>     servis_IsEmirIslem_Iscilikleri      = Teknisyen_ViewServisIsEmirIslemIscilikler.Select_IsEmirler_Iscilikleri(isEmirIds);
            List<ServisGunMola>                                 servis_Gun_Molalar                  = ServisGunMola.SelectServisGunMolalar(servisId);

            List<HareketNeden> nedenler = HareketNeden.Select_Nedenler();
            PuantajGunlugu pg = new PuantajGunlugu();
            pg.InitNedenler(nedenler);

            servis_IsEmirleri.forEach(isemir =>
            {
                List<HareketUstBilgi> isEmir_ustBilgileri = servis_UstHareketBilgileri.Where(t => t.ISEMIRID == isemir.ID).toList();
                List<TeknisyenHareket> isEmir_TeknisyenHareketleri = null;
                List<TeknisyenHareket> servisTeknisyenHareketleri = null;
                isemir.TeknisyenIsDurumu = LocalHelpers.GetTeknisyenDurum(servisTeknisyenId, servis_TeknisyenHareketleri, isEmir_ustBilgileri, out isEmir_TeknisyenHareketleri, out servisTeknisyenHareketleri);

                if (isEmir_TeknisyenHareketleri.isNotEmpty())
                {
                    isemir.IlkHareketTarihi = isEmir_TeknisyenHareketleri.Min(t => t.GIRISTARIHI);
                    isemir.SonHareketTarihi = isEmir_TeknisyenHareketleri.OrderByDescending(t => t.GIRISTARIHI).first().AktifCikisTarih;
                }

                if (isEmir_ustBilgileri.isNotEmpty())
                    isemir.PlanlananSure = isEmir_ustBilgileri.Sum(t => t.PLANLANANSURE);

                TeknisyenHareketDagilimSonuclari puantajSonuclari = Puantaj.GetPuantajSonuclari(isEmir_TeknisyenHareketleri, pg, servis_Gun_Molalar, nedenler);
                isemir.CalisilanSure = puantajSonuclari.GetSonucSure(NedenFormati.NormalCalisma);// isEmir_TeknisyenHareketleri.Sum(t => t.CalismaDakika);
                isemir.TeknisyenSure = puantajSonuclari.GetSonucSure(servisTeknisyenId, NedenFormati.NormalCalisma);
            });
            return servis_IsEmirleri.orderByDesc(t=> t.TeknisyenDurumResim).toList();
        }
    }

    public class Teknisyen_ViewServisIsEmirIslemler : SasonBase.Sason.Tables.Table_SERVISISEMIRISLEMLER.RawItem
    {
        public decimal  ID { get; set; }
        public int      SERVISISEMIRID { get; set; }
        public string   ACIKLAMA { get; set; }

        public int      ToplamIscilikSayisi { get; set; }

        internal int    PlanlananSure { get; set; }
        internal int    CalisilanSure { get; set; }
        internal int    TeknisyenSure { get; set; }

        public string PlanlananSureStr { get { return PlanlananSure.toTimeStringZeroThenEmpty(); } }
        public string CalisilanSureStr { get { return CalisilanSure.toTimeStringZeroThenEmpty(); } }
        public string TeknisyenSureStr { get { return TeknisyenSure.toTimeStringZeroThenEmpty(); } }

        internal TeknisyenHareketDurum TeknisyenIsDurumu { get; set; }
        public string TeknisyenDurumResim
        {
            get
            {
                string fileName = "";
                switch (TeknisyenIsDurumu)
                {
                    case TeknisyenHareketDurum.None:
                        fileName = "";
                        break;
                    case TeknisyenHareketDurum.Giris:
                        fileName = "../images/running.png";
                        break;
                    case TeknisyenHareketDurum.Cikis:
                        fileName = "../images/completed.png";
                        break;
                    case TeknisyenHareketDurum.DevamBekliyor:
                        fileName = "../images/waiting.png";
                        break;
                }
                return fileName;
            }
        }

        //internal static List<Teknisyen_ViewServisIsEmirIslemler> Select_Servis_IsEmir_Islemler(decimal servisId)
        //{
        //    List<Teknisyen_ViewServisIsEmirIslemler> list = SasonBaseApplicationPool.Get.EbaTestConnector.CreateQuery($@"
        //        select ID, SERVISISEMIRID, ACIKLAMA from servisisemirislemler where servisisemirid in (select id from servisisemirler where servisid = {servisId} and teknikolaraktamamla = 0)
        //        ").GetDataTable().ToModels<Teknisyen_ViewServisIsEmirIslemler>();
        //    return list;
        //}

        internal static List<Teknisyen_ViewServisIsEmirIslemler> Select_IsEmirler_Islemler(IEnumerable<decimal> isEmirIdler)
        {
            if (isEmirIdler.isEmpty())
                return new List<Teknisyen_ViewServisIsEmirIslemler>();
            return SasonBaseApplicationPool.Get.EbaTestConnector.GetDataTable(
                    new dbSelect("servisisemirislemler").select("ID", "SERVISISEMIRID", "ACIKLAMA").where(qt.field("servisisemirid").inn(isEmirIdler))
                ).Result.ToModels<Teknisyen_ViewServisIsEmirIslemler>();
        }


        public static List<Teknisyen_ViewServisIsEmirIslemler> Select_IsEmir_Islemler_View(decimal ownerIsEmirId, decimal servisTeknisyenId)
        {
            MethodReturn mr = new MethodReturn();

            List<Teknisyen_ViewServisIsEmirIslemler> servisIsEmirIslemler = R.Query<Teknisyen_ViewServisIsEmirIslemler>(mr).Where(t => t.SERVISISEMIRID == ownerIsEmirId).ToList();

            List<HareketUstBilgi>                               isEmir_UstHareketBilgileri  = HareketUstBilgi.Select_IsEmir_UstHareketBilgileri(ownerIsEmirId, mr);
            List<TeknisyenHareket>                              isEmir_TeknisyenHareketleri = TeknisyenHareket.Select_IsEmir_TeknisyenHareketleri(ownerIsEmirId, mr);
            List<Teknisyen_ViewServisIsEmirIslemIscilikler>     isEmir_Iscilikleri          = Teknisyen_ViewServisIsEmirIslemIscilikler.Select_IsEmir_Iscilikleri(ownerIsEmirId);

            decimal servisId = isEmir_UstHareketBilgileri.first().SERVISID;

            List<ServisGunMola> servis_gun_molalar = ServisGunMola.SelectServisGunMolalar(servisId);

            List<HareketNeden> nedenler = HareketNeden.Select_Nedenler();
            PuantajGunlugu pg = new PuantajGunlugu();
            pg.InitNedenler(nedenler);

            servisIsEmirIslemler.forEach(islem =>
            {
                List<HareketUstBilgi> islem_UstBilgileri = isEmir_UstHareketBilgileri.where(t => t.ISEMIRISLEMID == islem.ID).toList();
                List<TeknisyenHareket> islem_TeknisyenHareketleri = null;
                List<TeknisyenHareket> servisTeknisyenHareketleri = null;
                islem.TeknisyenIsDurumu = LocalHelpers.GetTeknisyenDurum(servisTeknisyenId, isEmir_TeknisyenHareketleri, islem_UstBilgileri, out islem_TeknisyenHareketleri, out servisTeknisyenHareketleri); ;

                var iscilikler = isEmir_Iscilikleri.where(t => t.SERVISISEMIRISLEMID == islem.ID).toList();
                islem.ToplamIscilikSayisi = iscilikler.count();

                if (islem_TeknisyenHareketleri.isNotEmpty())
                    islem.CalisilanSure = servisTeknisyenHareketleri.Sum(t => t.CalismaDakika);

                if (islem_UstBilgileri.isNotEmpty())
                    islem.PlanlananSure = islem_UstBilgileri.Sum(t => t.PLANLANANSURE);

                TeknisyenHareketDagilimSonuclari puantajSonuclari = Puantaj.GetPuantajSonuclari(islem_TeknisyenHareketleri, pg, servis_gun_molalar, nedenler);
                islem.CalisilanSure = puantajSonuclari.GetSonucSure(NedenFormati.NormalCalisma);
                islem.TeknisyenSure = puantajSonuclari.GetSonucSure(servisTeknisyenId, NedenFormati.NormalCalisma);
            });

            return servisIsEmirIslemler;
        }
    }

    public class Teknisyen_ViewServisIsEmirIslemIscilikler : SasonBase.Sason.Tables.Table_SERVISISMISLEMISCILIKLER.RawItem
    {
        public virtual Decimal ID { get; set; }
        public virtual Decimal SERVISISEMIRISLEMID { get; set; }
        public virtual Decimal ISCILIKID { get; set; }
        public virtual Decimal SERVISISCILIKID { get; set; }
        public virtual Decimal SERVISPAKETID { get; set; }
        protected virtual String ACIKLAMA { get; set; }
        public virtual Decimal DISARIDAYAPTIRDI { get; set; }
        public virtual Decimal BAKIMISLEMYNEDENID { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("ISCILIKID", "ID")]
        public RptIscilik01 Iscilik { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("SERVISISCILIKID", "ID")]
        public RptServisIscilik01 ServisIscilik { get; set; }

        public string Iscilik_AW_Aciklama
        {
            get { return Iscilik?.AWAciklama; }
        }

        public string Aciklama
        {
            get
            {
                string retAciklama = this.ACIKLAMA;
                if (retAciklama.isNullOrWhiteSpace() && ServisIscilik.isNotNull())
                    retAciklama = ServisIscilik.KOD;
                return retAciklama;
            }
        }

        public decimal Iscilik_Dakika_Suresi
        {
            get
            {
                decimal ret = 0;
                if (Iscilik.isNotNull())
                    ret = Iscilik.DakikaDegeri;
                else if (ServisIscilik.isNotNull())
                    ret = ServisIscilik.SUREDK;
                return ret;
            }
        }


        internal TeknisyenHareketDurum TeknisyenIsDurumu { get; set; }
        public string TeknisyenDurumResim
        {
            get
            {
                string fileName = "";
                switch (TeknisyenIsDurumu)
                {
                    case TeknisyenHareketDurum.None:
                        fileName = "";
                        break;
                    case TeknisyenHareketDurum.Giris:
                        fileName = "../images/running.png";
                        break;
                    case TeknisyenHareketDurum.Cikis:
                        fileName = "../images/completed.png";
                        break;
                    case TeknisyenHareketDurum.DevamBekliyor:
                        fileName = "../images/waiting.png";
                        break;
                }
                return fileName;
            }
        }

        internal int PlanlananSure { get; set; }
        internal int CalisilanSure { get; set; }
        internal int TeknisyenSure { get; set; }

        public string PlanlananSureStr { get { return PlanlananSure.toTimeStringZeroThenEmpty(); } }
        public string CalisilanSureStr { get { return CalisilanSure.toTimeStringZeroThenEmpty(); } }
        public string TeknisyenSureStr { get { return TeknisyenSure.toTimeStringZeroThenEmpty(); } }

        //internal static List<Teknisyen_ViewServisIsEmirIslemIscilikler> Select_Servis_Iscilikleri(decimal servisId)
        //{
        //    List<Teknisyen_ViewServisIsEmirIslemIscilikler> list = SasonBaseApplicationPool.Get.EbaTestConnector.CreateQuery($@"
        //        select id, SERVISISEMIRISLEMID from servisismislemiscilikler where servisisemirislemid in (select id from servisisemirislemler where servisisemirid in (select id from servisisemirler where servisid = {servisId} and teknikolaraktamamla = 0))
        //        ").GetDataTable().ToModels<Teknisyen_ViewServisIsEmirIslemIscilikler>();
        //    return list;
        //}

        internal static List<Teknisyen_ViewServisIsEmirIslemIscilikler> Select_IsEmir_Iscilikleri(decimal isEmirId, MethodReturn refMr = null)
        {
            List<Teknisyen_ViewServisIsEmirIslemIscilikler> list = SasonBaseApplicationPool.Get.EbaTestConnector.CreateQuery($@"
                select id, SERVISISEMIRISLEMID from servisismislemiscilikler where servisisemirislemid in (select id from servisisemirislemler where servisisemirid in (select id from servisisemirler where id = {isEmirId}))
                ").GetDataTable(refMr).ToModels<Teknisyen_ViewServisIsEmirIslemIscilikler>();
            return list;
        }

        internal static List<Teknisyen_ViewServisIsEmirIslemIscilikler> Select_IsEmirler_Iscilikleri(IEnumerable<decimal> isEmirIdler, MethodReturn refMr = null)
        {
            if (isEmirIdler.isEmpty())
                return new List<Teknisyen_ViewServisIsEmirIslemIscilikler>();
            return SasonBaseApplicationPool.Get.EbaTestConnector.GetDataTable(
                new dbSelect("servisismislemiscilikler").select("ID", "SERVISISEMIRISLEMID").where(
                        qt.field("servisisemirislemid").inn(
                            new dbSelect("servisisemirislemler").select("id").where(qt.field("servisisemirid").inn(isEmirIdler))))
                ).Result.ToModels<Teknisyen_ViewServisIsEmirIslemIscilikler>();
        }



        public static List<Teknisyen_ViewServisIsEmirIslemIscilikler> SelectOverloadFromIDs(IEnumerable<decimal> IDs)
        {
            Exception ex = null;
            if (IDs.isEmpty())
                return new List<Teknisyen_ViewServisIsEmirIslemIscilikler>();
            return Antibiotic.Database._Helpers.ItemHelpers.SelectItemsFromFieldInValues(typeof(Teknisyen_ViewServisIsEmirIslemIscilikler), "ID", IDs.toList<object>(), out ex).toList<Teknisyen_ViewServisIsEmirIslemIscilikler>();
        }

        public static List<Teknisyen_ViewServisIsEmirIslemIscilikler> SelectOverloadFromISLEMID(IEnumerable<decimal> ISLEMIDs)
        {
            Exception ex = null;
            if (ISLEMIDs.isEmpty())
                return new List<Teknisyen_ViewServisIsEmirIslemIscilikler>();
            return Antibiotic.Database._Helpers.ItemHelpers.SelectItemsFromFieldInValues(typeof(Teknisyen_ViewServisIsEmirIslemIscilikler), "SERVISISEMIRISLEMID", ISLEMIDs.toList<object>(), out ex).toList<Teknisyen_ViewServisIsEmirIslemIscilikler>();
        }



        public static List<Teknisyen_ViewServisIsEmirIslemIscilikler> Select_IsEmirIslem_Iscilikleri_View(decimal isEmirIslemId, decimal servisTeknisyenId)
        {
            List<Teknisyen_ViewServisIsEmirIslemIscilikler> list = R.Query<Teknisyen_ViewServisIsEmirIslemIscilikler>().Where(t => t.SERVISISEMIRISLEMID == isEmirIslemId).ToList();

            List<HareketUstBilgi>   isEmirIslem_UstHareketBilgileri = HareketUstBilgi.Select_IsEmirIslem_UstHareketBilgileri(isEmirIslemId);
            List<TeknisyenHareket>  isEmirIslem_TeknisyenHareketleri = TeknisyenHareket.Select_IsEmirIslem_TeknisyenHareketleri(isEmirIslemId);

            decimal servisId = isEmirIslem_UstHareketBilgileri.first().SERVISID;
            List<ServisGunMola> servis_gun_molalar = ServisGunMola.SelectServisGunMolalar(servisId);

            List<HareketNeden> nedenler = HareketNeden.Select_Nedenler();
            PuantajGunlugu pg = new PuantajGunlugu();
            pg.InitNedenler(nedenler);


            list.forEach(iscilik =>
            {
                List<HareketUstBilgi> iscilik_UstBilgileri = isEmirIslem_UstHareketBilgileri.where(t => t.ISEMIRISLEMISCILIKID == iscilik.ID).toList();
                List<TeknisyenHareket> iscilik_TeknisyenHareketleri = null;
                List<TeknisyenHareket> servisTeknisyenHareketleri = null;
                iscilik.TeknisyenIsDurumu = LocalHelpers.GetTeknisyenDurum(servisTeknisyenId, isEmirIslem_TeknisyenHareketleri, iscilik_UstBilgileri, out iscilik_TeknisyenHareketleri, out servisTeknisyenHareketleri);

                if (iscilik_UstBilgileri.isNotEmpty())
                    iscilik.PlanlananSure = iscilik_UstBilgileri.Sum(t => t.PLANLANANSURE);

                TeknisyenHareketDagilimSonuclari puantajSonuclari = Puantaj.GetPuantajSonuclari(iscilik_TeknisyenHareketleri, pg, servis_gun_molalar,nedenler);
                iscilik.CalisilanSure = puantajSonuclari.GetSonucSure(NedenFormati.NormalCalisma);
                iscilik.TeknisyenSure = puantajSonuclari.GetSonucSure(servisTeknisyenId, NedenFormati.NormalCalisma);
            });

            return list;
        }

    }


}