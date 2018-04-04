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
    public class BAKIMSOZLESMETIPLER : SasonBase.Sason.Tables.Table_BAKIMSOZLESMETIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMSOZLESMETIPLER>
        {
            Dictionary<Decimal, BAKIMSOZLESMETIPLER> dict = new Dictionary<Decimal, BAKIMSOZLESMETIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMSOZLESMETIPLER> items) : base(items) { }


            public BAKIMSOZLESMETIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMSOZLESMETIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMSOZLESMETIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMSOZLESMETIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMSOZLESMETIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMSOZLESMETIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMSOZLESMETIPLER> Select
        {
            get { return R.Query<BAKIMSOZLESMETIPLER>(); }
        }

        public static BAKIMSOZLESMETIPLER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMSOZLESMETIPLER>().First(t => t.ID == ID);
        }

        public static List<BAKIMSOZLESMETIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMSOZLESMETIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMSOZLESMETIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMSOZLESMETIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

