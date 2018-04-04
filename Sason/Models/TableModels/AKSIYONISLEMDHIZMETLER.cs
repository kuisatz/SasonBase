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
    public class AKSIYONISLEMDHIZMETLER : SasonBase.Sason.Tables.Table_AKSIYONISLEMDHIZMETLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<AKSIYONISLEMDHIZMETLER>
        {
            Dictionary<Decimal, AKSIYONISLEMDHIZMETLER> dict = new Dictionary<Decimal, AKSIYONISLEMDHIZMETLER>();


            public CONTAINER() { }

            public CONTAINER(IEnumerable<AKSIYONISLEMDHIZMETLER> items) : base(items) { }


            public AKSIYONISLEMDHIZMETLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AKSIYONISLEMDHIZMETLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AKSIYONISLEMDHIZMETLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AKSIYONISLEMDHIZMETLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(AKSIYONISLEMDHIZMETLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AKSIYONISLEMDHIZMETLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AKSIYONISLEMDHIZMETLER> Select
        {
            get { return R.Query<AKSIYONISLEMDHIZMETLER>(); }
        }

        public static AKSIYONISLEMDHIZMETLER SelectItem(Decimal ID)
        {
            return R.Query<AKSIYONISLEMDHIZMETLER>().First(t => t.ID == ID);
        }

        public static List<AKSIYONISLEMDHIZMETLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AKSIYONISLEMDHIZMETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AKSIYONISLEMDHIZMETLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AKSIYONISLEMDHIZMETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

