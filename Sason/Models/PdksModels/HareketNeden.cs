using Antibiotic.Extensions;
using Antibiotic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.PdksModels
{
    public enum NedenFormati
    {
        None                     = 0,
        Giris_IsBaslangici       = 1, //Yeni Giriyorsa
        Giris_IsDevami           = 2,
        Giris_IsYardimi          = 3,
        Cikis_IsBitisi           = 4, //Devam Edemez, Başlar  Teknisyen İşçiliği Tamamlamış
        AraDinlenme              = 5, //Devam Edebilir,  yemek, çay, sigara
        Izin                     = 6, //Devam Edebilir, saatlik izin almış ise
        Gorevli                  = 7, //Devam Edebilir , Yardıma da gidebilir
        IsKazasi                 = 8, //Devam Edebilir
        EksikSaat                = 9,
        NormalCalisma            = 10,
    }

    public enum HareketTipi
    {
        None  = 0,
        Giris = 1,
        Cikis = 2,
    }

    public partial class HareketNeden : Tables.Table_THRKNEDEN.RawItem
    {
        public string NedenResim { get; set; }
        public Decimal ID { get; set; }
        public String KOD { get; set; }
        public String TANIM { get; set; }
        public NedenFormati FORMATI { get; set; }
        public HareketTipi HAREKETTIPI { get; set; }
        public decimal PDKS { get; set; }
        //public virtual Int32 SIRANO { get; set; }
        //public virtual String ACIKLAMA { get; set; }

        public override string ToString()
        {
            return $"ID : {ID}, KOD : {KOD}, TANIM : {TANIM}, FORMATI : {FORMATI}, HAREKETTIPI : {HAREKETTIPI}, PDKS : {PDKS}";
        }
    }

    public partial class HareketNeden
    {
        public static List<HareketNeden> Select_Nedenler()
        {
            return R.Query<HareketNeden>().ToList();
        }
    }

    public class HareketNedenContainer : Antibiotic.Collections.ListContainer<HareketNeden>
    {
        Dictionary<Decimal, HareketNeden> dict = new Dictionary<Decimal, HareketNeden>();

        public HareketNedenContainer() { }

        public HareketNedenContainer(IEnumerable<HareketNeden> items) : base(items) { }


        public HareketNeden this[Decimal nedenId]
        {
            get { return dict.find(nedenId); }
        }

        public HareketNeden Get(Decimal nedenId)
        {
            return dict.find(nedenId);
        }

        public List<HareketNeden> Gets(params Decimal[] nedenIds)
        {
            return dict.findToList(nedenIds);
        }

        public List<HareketNeden> Gets(IEnumerable<Decimal> nedenIds)
        {
            return dict.findToList(nedenIds);
        }

        protected override void OnBeforeInsert(HareketNeden item, ref bool cancel)
        {
            dict.set(item.ID, item, out cancel);
        }

        protected override void OnAfterRemove(HareketNeden item)
        {
            dict.remove(item.ID);
        }
    }



}