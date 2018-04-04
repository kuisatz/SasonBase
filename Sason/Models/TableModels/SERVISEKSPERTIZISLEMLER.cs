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
    public class SERVISEKSPERTIZISLEMLER : SasonBase.Sason.Tables.Table_SERVISEKSPERTIZISLEMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISEKSPERTIZISLEMLER>
        {
            Dictionary<Decimal, SERVISEKSPERTIZISLEMLER> dict = new Dictionary<Decimal, SERVISEKSPERTIZISLEMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISEKSPERTIZISLEMLER> items) : base(items) { }


            public SERVISEKSPERTIZISLEMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISEKSPERTIZISLEMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISEKSPERTIZISLEMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISEKSPERTIZISLEMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISEKSPERTIZISLEMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISEKSPERTIZISLEMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISEKSPERTIZISLEMLER> Select
        {
            get { return R.Query<SERVISEKSPERTIZISLEMLER>(); }
        }

        public static SERVISEKSPERTIZISLEMLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISEKSPERTIZISLEMLER>().First(t => t.ID == ID);
        }

        public static List<SERVISEKSPERTIZISLEMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISEKSPERTIZISLEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISEKSPERTIZISLEMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISEKSPERTIZISLEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

