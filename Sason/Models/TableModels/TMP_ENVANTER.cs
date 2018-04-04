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
    public class TMP_ENVANTER : SasonBase.Sason.Tables.Table_TMP_ENVANTER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<TMP_ENVANTER>
        {
            Dictionary<Decimal, TMP_ENVANTER> dict = new Dictionary<Decimal, TMP_ENVANTER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<TMP_ENVANTER> items) : base(items) { }


            public TMP_ENVANTER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public TMP_ENVANTER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<TMP_ENVANTER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<TMP_ENVANTER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(TMP_ENVANTER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(TMP_ENVANTER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<TMP_ENVANTER> Select
        {
            get { return R.Query<TMP_ENVANTER>(); }
        }

        public static TMP_ENVANTER SelectItem(Decimal ID)
        {
            return R.Query<TMP_ENVANTER>().First(t => t.ID == ID);
        }

        public static List<TMP_ENVANTER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<TMP_ENVANTER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<TMP_ENVANTER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<TMP_ENVANTER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

