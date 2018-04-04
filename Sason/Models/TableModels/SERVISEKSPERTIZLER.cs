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
    public class SERVISEKSPERTIZLER : SasonBase.Sason.Tables.Table_SERVISEKSPERTIZLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISEKSPERTIZLER>
        {
            Dictionary<Decimal, SERVISEKSPERTIZLER> dict = new Dictionary<Decimal, SERVISEKSPERTIZLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISEKSPERTIZLER> items) : base(items) { }


            public SERVISEKSPERTIZLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISEKSPERTIZLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISEKSPERTIZLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISEKSPERTIZLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISEKSPERTIZLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISEKSPERTIZLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISEKSPERTIZLER> Select
        {
            get { return R.Query<SERVISEKSPERTIZLER>(); }
        }

        public static SERVISEKSPERTIZLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISEKSPERTIZLER>().First(t => t.ID == ID);
        }

        public static List<SERVISEKSPERTIZLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISEKSPERTIZLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISEKSPERTIZLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISEKSPERTIZLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

