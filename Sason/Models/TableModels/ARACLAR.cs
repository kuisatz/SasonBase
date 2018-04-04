using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;

namespace SasonBase.Sason.Models.TableModels
{
    [Serializable()]
    public class ARACLAR : SasonBase.Sason.Tables.Table_ARACLAR.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<ARACLAR>
        {
            Dictionary<Decimal, ARACLAR> dict = new Dictionary<Decimal, ARACLAR>();
            Dictionary<string, ARACLAR> saseDict = new Dictionary<string, ARACLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ARACLAR> items) : base(items) { }


            public ARACLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ARACLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ARACLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ARACLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public ARACLAR GetFromSase(string saseNo)
            {
                return saseDict.find(saseNo);
            }

            protected override void OnBeforeInsert(ARACLAR item, ref bool cancel)
            {
                saseDict.set(item.SASENO.trim().ToUpper(), item, out cancel);
                if (!cancel)
                    dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ARACLAR item)
            {
                dict.remove(item.ID);
            }
        }


        public static IOrderedQueryable<ARACLAR> Select
        {
            get { return R.Query<ARACLAR>(); }
        }

        public static ARACLAR SelectItem(Decimal ID)
        {
            return R.Query<ARACLAR>().First(t => t.ID == ID);
        }

        public static ARACLAR SelectAracFromSaseNo(string saseno)
        {
            return R.Query<ARACLAR>().First(t => t.SASENO == saseno);
        }


        public static List<ARACLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ARACLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ARACLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ARACLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ARACLAR> SelectOverloadFromSaseNo(IEnumerable<string> saseNos)
        {
            Exception ex = null;
            if (saseNos.isEmpty())
                return null;
            return Antibiotic.Database._Helpers.ItemHelpers.SelectItemsFromFieldInValues(typeof(ARACLAR), "SASENO", saseNos, out ex).toList<ARACLAR>();
        }

        public static List<ARACLAR> SelectOverloadFromIDs(IEnumerable<decimal> IDs)
        {
            Exception ex = null;
            if (IDs.isEmpty())
                return null;
            return Antibiotic.Database._Helpers.ItemHelpers.SelectItemsFromFieldInValues(typeof(ARACLAR), "ID", IDs.toList<object>(), out ex).toList<ARACLAR>();
        }


    }
}

