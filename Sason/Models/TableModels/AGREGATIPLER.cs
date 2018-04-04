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
    public class AGREGATIPLER : SasonBase.Sason.Tables.Table_AGREGATIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<AGREGATIPLER>
        {
            Dictionary<Decimal, AGREGATIPLER> dict = new Dictionary<Decimal, AGREGATIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<AGREGATIPLER> items) : base(items) { }


            public AGREGATIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AGREGATIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AGREGATIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AGREGATIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(AGREGATIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AGREGATIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AGREGATIPLER> Select
        {
            get { return R.Query<AGREGATIPLER>(); }
        }

        public static AGREGATIPLER SelectItem(Decimal ID)
        {
            return R.Query<AGREGATIPLER>().First(t => t.ID == ID);
        }

        public static List<AGREGATIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AGREGATIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AGREGATIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AGREGATIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

