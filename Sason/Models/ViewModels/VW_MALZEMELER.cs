using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;

namespace SasonBase.Sason.Models.ViewModels
{
    [Serializable()]
    public class VW_MALZEMELER : SasonBase.Sason.Views.View_VW_MALZEMELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<VW_MALZEMELER>
        {
            Dictionary<Decimal, VW_MALZEMELER> dict = new Dictionary<Decimal, VW_MALZEMELER>();
            Dictionary<string, VW_MALZEMELER> kodDict = new Dictionary<string, VW_MALZEMELER>();


            public CONTAINER() { }

            public CONTAINER(IEnumerable<VW_MALZEMELER> items) : base(items) { }


            public VW_MALZEMELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public VW_MALZEMELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<VW_MALZEMELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<VW_MALZEMELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public VW_MALZEMELER GetFromKod(string kod)
            {
                return kodDict.find(kod);
            }


            protected override void OnBeforeInsert(VW_MALZEMELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
                kodDict.set(item.KOD, item);
            }

            protected override void OnAfterRemove(VW_MALZEMELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<VW_MALZEMELER> Select
        {
            get { return R.Query<VW_MALZEMELER>(); }
        }

        public static VW_MALZEMELER SelectItem(Decimal ID)
        {
            return R.Query<VW_MALZEMELER>().First(t => t.ID == ID);
        }

        public static List<VW_MALZEMELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<VW_MALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<VW_MALZEMELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<VW_MALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<VW_MALZEMELER> SelectOverloadFromCodes(IEnumerable<string> kods)
        {
            Exception ex = null;
            if (kods.isEmpty())
                return null;
            return Antibiotic.Database._Helpers.ItemHelpers.SelectItemsFromFieldInValues(typeof(VW_MALZEMELER), "KOD", kods, out ex).toList<VW_MALZEMELER>();
        }

        public static List<VW_MALZEMELER> SelectOverloadFromIDs(IEnumerable<decimal> IDs)
        {
            Exception ex = null;
            if (IDs.isEmpty())
                return null;
            return Antibiotic.Database._Helpers.ItemHelpers.SelectItemsFromFieldInValues(typeof(VW_MALZEMELER), "ID", IDs.toList<object>(), out ex).toList<VW_MALZEMELER>();
        }


    }
}

