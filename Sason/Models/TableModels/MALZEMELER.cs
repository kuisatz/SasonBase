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
    public class MALZEMELER : Tables.Table_MALZEMELER.PublicItem
    {
        public bool IsOriginal
        {
            get { return ORJINALMALZEMEID == 0; }
        }

        public class CONTAINER : Antibiotic.Collections.ListContainer<MALZEMELER>
        {
            Dictionary<Decimal, MALZEMELER> dict = new Dictionary<Decimal, MALZEMELER>();
            Dictionary<string, MALZEMELER> kodDict = new Dictionary<string, MALZEMELER>();

            public CONTAINER() { }
            public CONTAINER(IEnumerable<MALZEMELER> items) : base(items) { }

            #region Indexers
            public MALZEMELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }
            #endregion

            #region Get / Gets
            public MALZEMELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MALZEMELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MALZEMELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public MALZEMELER Get(string kod)
            {
                return kodDict.find(kod);
            }

            public List<MALZEMELER> Gets(params string[] kods)
            {
                return kodDict.findToList(kods);
            }

            public List<MALZEMELER> Gets(IEnumerable<string> kods)
            {
                return kodDict.findToList(kods);
            }
            #endregion

            protected override void OnBeforeInsert(MALZEMELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
                if (!cancel)
                    kodDict.set(item.KOD, item);
            }

            protected override void OnAfterRemove(MALZEMELER item)
            {
                dict.remove(item.ID);
            }
        }

        public static IOrderedQueryable<MALZEMELER> Select
        {
            get { return R.Query<MALZEMELER>(); }
        }

        public static MALZEMELER SelectItem(Decimal ID)
        {
            return R.Query<MALZEMELER>().First(t => t.ID == ID);
        }

        public static List<MALZEMELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MALZEMELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static decimal NewSeqId
        {
            get
            {
                return Convert.ToDecimal(SasonBaseApplicationPool.Get.EbaTestConnector.ExecuteScalar("select MALZEMELER_SEQ.NEXTVAL from dual"));
            }
        }

        public static List<MALZEMELER> SelectOverloadFromCodes(IEnumerable<string> kods)
        {
            Exception ex = null;
            if (kods.isEmpty())
                return null;
            return Antibiotic.Database._Helpers.ItemHelpers.SelectItemsFromFieldInValues(typeof(MALZEMELER), "KOD", kods, out ex).toList<MALZEMELER>();
        }

        public static List<MALZEMELER> SelectOverloadFromIDs(IEnumerable<decimal> IDs)
        {
            Exception ex = null;
            if (IDs.isEmpty())
                return null;
            return Antibiotic.Database._Helpers.ItemHelpers.SelectItemsFromFieldInValues(typeof(MALZEMELER), "ID", IDs.toList<object>(), out ex).toList<MALZEMELER>();
        }

    }
}