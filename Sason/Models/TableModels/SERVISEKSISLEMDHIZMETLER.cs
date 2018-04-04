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
    public class SERVISEKSISLEMDHIZMETLER : SasonBase.Sason.Tables.Table_SERVISEKSISLEMDHIZMETLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISEKSISLEMDHIZMETLER>
        {
            Dictionary<Decimal, SERVISEKSISLEMDHIZMETLER> dict = new Dictionary<Decimal, SERVISEKSISLEMDHIZMETLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISEKSISLEMDHIZMETLER> items) : base(items) { }


            public SERVISEKSISLEMDHIZMETLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISEKSISLEMDHIZMETLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISEKSISLEMDHIZMETLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISEKSISLEMDHIZMETLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISEKSISLEMDHIZMETLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISEKSISLEMDHIZMETLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISEKSISLEMDHIZMETLER> Select
        {
            get { return R.Query<SERVISEKSISLEMDHIZMETLER>(); }
        }

        public static SERVISEKSISLEMDHIZMETLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISEKSISLEMDHIZMETLER>().First(t => t.ID == ID);
        }

        public static List<SERVISEKSISLEMDHIZMETLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISEKSISLEMDHIZMETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISEKSISLEMDHIZMETLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISEKSISLEMDHIZMETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

