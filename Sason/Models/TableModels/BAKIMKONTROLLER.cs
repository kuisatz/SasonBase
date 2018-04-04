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
    public class BAKIMKONTROLLER : SasonBase.Sason.Tables.Table_BAKIMKONTROLLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMKONTROLLER>
        {
            Dictionary<Decimal, BAKIMKONTROLLER> dict = new Dictionary<Decimal, BAKIMKONTROLLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMKONTROLLER> items) : base(items) { }


            public BAKIMKONTROLLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMKONTROLLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMKONTROLLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMKONTROLLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMKONTROLLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMKONTROLLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMKONTROLLER> Select
        {
            get { return R.Query<BAKIMKONTROLLER>(); }
        }

        public static BAKIMKONTROLLER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMKONTROLLER>().First(t => t.ID == ID);
        }

        public static List<BAKIMKONTROLLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMKONTROLLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMKONTROLLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMKONTROLLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

