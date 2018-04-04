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
    public class BAKIMAGREGATIPLER : SasonBase.Sason.Tables.Table_BAKIMAGREGATIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMAGREGATIPLER>
        {
            Dictionary<Decimal, BAKIMAGREGATIPLER> dict = new Dictionary<Decimal, BAKIMAGREGATIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMAGREGATIPLER> items) : base(items) { }


            public BAKIMAGREGATIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMAGREGATIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMAGREGATIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMAGREGATIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMAGREGATIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMAGREGATIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMAGREGATIPLER> Select
        {
            get { return R.Query<BAKIMAGREGATIPLER>(); }
        }

        public static BAKIMAGREGATIPLER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMAGREGATIPLER>().First(t => t.ID == ID);
        }

        public static List<BAKIMAGREGATIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMAGREGATIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMAGREGATIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMAGREGATIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

