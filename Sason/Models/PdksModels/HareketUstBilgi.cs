using Antibiotic.Extensions;
using Antibiotic.Database.Field;
using Antibiotic.Database.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Descriptions;
using Antibiotic.Database;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Database.Query.Statements;
using Antibiotic.Database.Query;
using System.Data;
using SasonBase.Sason.Models.TableModels;

namespace SasonBase.Sason.Models.PdksModels
{
    public class UstBilgiInfo
    {
        public decimal ServisId { get; set; }
        public decimal IsEmirId { get; set; }
        public decimal IsEmirIslemId { get; set; }
        public decimal IsEmirIslemIscilikId { get; set; }
        public decimal NedenId { get; set; }
        public HareketTipi HareketTipi { get; set; }
    }

  //  public enum HareketUstBilgiDurumu
  //  {
		//Bos    = 0, //Herhangi Bir İşçilik Çalışması Yapılmamış //mavi
  //      Devam  = 1, //Üzerinde Cikis Yok (Yalnız Giriş Yapılmış) Veya Giriş Bekleyen Çıkış İşlemi Var (Ara Dinlenme vs Gibi) //sarı
  //      Kapali = 2, //Tamamlanmış. Fakat Yeniden Açılabilir de. // yeşil
  //  }

    public partial class HareketUstBilgi : Tables.Table_THRKUSTBILGI.RawItem
    {
        public virtual Decimal ID { get; set; }
        public virtual Decimal SERVISID { get; set; }
        public virtual Decimal ISEMIRID { get; set; }
        public virtual Decimal ISEMIRISLEMID { get; set; }
        public virtual Decimal ISEMIRISLEMISCILIKID { get; set; }
        public virtual Int32 PLANLANANSURE { get; set; }
        public virtual Int32 CALISILANSURE { get; set; }
        public virtual DateTime BASLANGICTARIHI { get; set; }
        public virtual DateTime BITISTARIHI { get; set; }
        //public virtual HareketUstBilgiDurumu DURUM { get; set; }
    }

    public class ViewHareketUstBilgi : HareketUstBilgi
    {
        [ReadOnlyRelation]
        [RelationCondition("ID","THRKUSTBILGIID")]
        public List<TeknisyenHareket> TeknisyenHareketler { get; set; }
    }

    public partial class HareketUstBilgi
    {
        public static List<HareketUstBilgi> Select_UstBilgiler_FromBig_IsEmirIds(IEnumerable<decimal> isEmirIds, MethodReturn refMr = null)
        {
            Exception ex = null;
            if (isEmirIds.isEmpty())
                return new List<HareketUstBilgi>();
            return Antibiotic.Database._Helpers.ItemHelpers.SelectItemsFromFieldInValues(typeof(HareketUstBilgi), "ISEMIRID", isEmirIds.toList<object>(), out ex).toList<HareketUstBilgi>();
        }

        public static List<HareketUstBilgi> Select_IsEmir_UstHareketBilgileri(decimal isemirid, MethodReturn refMr = null)
        {
            return Select_IsEmirler_UstHareketBilgileri(new List<decimal>().add(isemirid), refMr);
        }

        public static List<HareketUstBilgi> Select_IsEmirler_UstHareketBilgileri(IEnumerable<SERVISISEMIRLER> isEmirler, MethodReturn refMr = null)
        {
            List<decimal> isEmirIdler = isEmirler.select(t => t.ID).toList();
            return Select_IsEmirler_UstHareketBilgileri(isEmirIdler, refMr);
        }

        public static List<HareketUstBilgi> Select_IsEmirler_UstHareketBilgileri(IEnumerable<decimal> isEmirIdler, MethodReturn refMr = null)
        {
            if (isEmirIdler.isEmpty())
                return new List<HareketUstBilgi>();
            MethodReturn subr = SasonBaseApplicationPool.Get.EbaTestConnector.GetDataTable(new dbSelect("thrkustbilgi").where(qt.field("isemirid").inn(isEmirIdler)));
            return subr.Result.cast<DataTable>().ToModels<HareketUstBilgi>(refMr);
        }

        public static List<HareketUstBilgi> Select_IsEmirIslem_UstHareketBilgileri(decimal isEmirIslemId, MethodReturn refMr = null)
        {
            List<HareketUstBilgi> list = SasonBaseApplicationPool.Get.EbaTestConnector.CreateQuery($@"
                select * from thrkustbilgi where ISEMIRISLEMID = {isEmirIslemId}
                ").GetDataTable(refMr).ToModels<HareketUstBilgi>();
            return list;
        }

        public static HareketUstBilgi Select_IsEmirIslemIscilik_UstHareketBilgisi(decimal isEmirIslemIscilikId)
        {
            return R.Query<HareketUstBilgi>().First(t => t.ISEMIRISLEMISCILIKID == isEmirIslemIscilikId);
        }

		/// <summary>
        /// Servisin Kapatılmamış Olan Is Emirlerinin Veritabanında Üst Bilgilerini (Olmayanları) Oluşturuyor.
        /// Oluşturulan Bu Üst Bilgilerin İse Teknisyenler Tarafından Hareketleri Oluşturuluyor
        /// </summary>
        /// <param name="servisId"></param>
		public static void RepairServisIsemirleri(decimal servisId)
        {
            MethodReturn mr = new MethodReturn();

            //THRKUSTBILGI Tablosunda Ust Bilgisi Olmayan IsEmir İşçilik Kaydı Açılıyor
            StringQuery query = SasonBase.SasonBaseApplicationPool.Get.EbaTestConnector.CreateQuery(@"
              INSERT INTO THRKUSTBILGI (SERVISID,ISEMIRID,ISEMIRISLEMID,ISEMIRISLEMISCILIKID,PLANLANANSURE,CALISILANSURE,DURUM) 
                 select {SERVISID} SERVISID, ISEMIRID, ISEMIRISLEMID, ISEMIRISCILIKID, 
                        CASE MANSURE_AW
                            WHEN 0 THEN SERVISSURE_DK
                            ELSE MANSURE_AW
                        END
                        PLANLANAN_DAKIKA, 0, 0
                 from  (
                        select 
                            emir.id as IsEmirId, islem.id IsEmirIslemId, islemiscilik.Id IsEmirIscilikId, 
                                case nvl(DEFISCILIK.MIKTAR,'0')
                                    when '0' then 0
                                    when '****' then 0
                                    else to_number(DEFISCILIK.MIKTAR) * {AW_KARSILIGI}
                                end
                                MANSURE_AW
                                ,nvl(DEFSERISCILIK.SUREDK,0) SERVISSURE_DK
                                ,nvl(ustbilgi.ID,0) as ustbilgiid
                        from 
                            servisisemirler emir
                            ,servisisemirislemler islem
                            ,SERVISISMISLEMISCILIKLER islemiscilik
                            ,ISCILIKLER defiscilik
                            ,SERVISISCILIKLER defseriscilik
                            ,THRKUSTBILGI ustbilgi
                        where
                            emir.servisid = {SERVISID} and EMIR.TEKNIKOLARAKTAMAMLA = 0
                            and ISLEM.SERVISISEMIRID = emir.id
                            and ISLEMISCILIK.SERVISISEMIRISLEMID = islem.id
                            AND DEFISCILIK.ID(+) = ISLEMISCILIK.ISCILIKID
                            and DEFSERISCILIK.ID(+) = ISLEMISCILIK.SERVISISCILIKID
                            and ustbilgi.ISEMIRISLEMISCILIKID(+) = islemiscilik.Id
                        )
                 where ustbilgiid = 0
            ")
            .Parameter("AW_KARSILIGI", 6)
            .Parameter("SERVISID", servisId);
            
            query.Execute(mr);


            string groupKey = System.Guid.NewGuid().ToString("N");

            if (mr.ok())
            {
                //Temp Tablo Temizleniyor
                query.Clear().Query("DELETE FROM TSERVISTMP WHERE GROUPKEY = {GROUPKEY} AND FKEY1 = {SERVISID}")
                    .Parameter("GROUPKEY", groupKey)
                    .Parameter("SERVISID", servisId)
                    .Execute(mr);
            }
            if (mr.ok())
            {
                //Temp Tabloya Zamanları Değişen İşçilik Kayıtlarının Yeni Değerleri Yazılıyor
                query.Clear().Query(@"
                    INSERT INTO TSERVISTMP (GROUPKEY,FKEY1,FKEY2,FKEY3)
                    SELECT {GROUPKEY}, {SERVISID} SERVISID, T0.HAREKETUSTBILGIID, T0.YENI_PLANLANAN_DAKIKA FROM 
                        (
                            select hareketustbilgiid,  
                                CASE MANSURE_AW
                                    WHEN 0 THEN SERVISSURE_DK
                                    ELSE MANSURE_AW
                                END
                                YENI_PLANLANAN_DAKIKA, NVL(hareketustbilgiplanlanan,0) ESKI_PLANLANAN_DAKIKA 
                            from 
                            (
                                select 
                                    emir.id as IsEmirId, islem.id IsEmirIslemId, islemiscilik.Id IsEmirIscilikId, 
                                        case nvl(DEFISCILIK.MIKTAR,'0')
                                            when '0' then 0
                                            when '****' then 0
                                            else to_number(DEFISCILIK.MIKTAR) * {AW_KARSILIGI}
                                        end
                                        MANSURE_AW
                                        ,nvl(DEFSERISCILIK.SUREDK,0) SERVISSURE_DK
                                        ,nvl(ustbilgi.ID,0) hareketustbilgiid
                                        ,ustbilgi.PLANLANANSURE hareketustbilgiplanlanan
                                from 
                                    servisisemirler emir
                                    ,servisisemirislemler islem
                                    ,SERVISISMISLEMISCILIKLER islemiscilik
                                    ,ISCILIKLER defiscilik
                                    ,SERVISISCILIKLER defseriscilik
                                    ,THRKUSTBILGI ustbilgi
                                where
                                    emir.servisid = {SERVISID} and EMIR.TEKNIKOLARAKTAMAMLA = 0
                                    and ISLEM.SERVISISEMIRID = emir.id
                                    and ISLEMISCILIK.SERVISISEMIRISLEMID = islem.id
                                    AND DEFISCILIK.ID(+) = ISLEMISCILIK.ISCILIKID
                                    and DEFSERISCILIK.ID(+) = ISLEMISCILIK.SERVISISCILIKID
                                    and ustbilgi.ISEMIRISLEMISCILIKID(+) = islemiscilik.Id
                            )
                        ) T0
                    where T0.YENI_PLANLANAN_DAKIKA <> ESKI_PLANLANAN_DAKIKA
                ")
                .Parameter("AW_KARSILIGI", 6)
                .Parameter("GROUPKEY", groupKey)
                .Parameter("SERVISID", servisId)
                .Execute(mr);
            }
            if (mr.ok())
            {
                //Temp Tablosundaki Calisma Zamani TPDKSHRK (Üst Bilgi) Tablosundaki Çalışma Zamanına Güncelleniyor.
                query.Clear().Query(@"
                    update 
                        THRKUSTBILGI ustbilgi
                    set ustbilgi.PLANLANANSURE = (select fkey3 from tservistmp tmp where TMP.GROUPKEY = {GROUPKEY} and tmp.fkey1 = ustbilgi.SERVISID and ustbilgi.id = TMP.FKEY2 )
                    where exists (select fkey3 from tservistmp tmp where TMP.GROUPKEY = {GROUPKEY} and tmp.fkey1 = ustbilgi.SERVISID and ustbilgi.id = TMP.FKEY2)                
                ")
                .Parameter("GROUPKEY", groupKey)
                .Execute(mr);
            }
            //if (mr.ok())
            //{
            //    query.Clear().Query("DELETE FROM TSERVISTMP WHERE FTABLE = 'TMP_USTBILGI' AND FKEY1 = {SERVISID}").Parameter("SERVISID", servisId).Execute(mr);
            //}
        }


    }
}