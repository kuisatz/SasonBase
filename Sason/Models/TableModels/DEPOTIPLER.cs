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
    public class DEPOTIPLER : SasonBase.Sason.Tables.Table_DEPOTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<DEPOTIPLER>
        {
            Dictionary<Decimal, DEPOTIPLER> dict = new Dictionary<Decimal, DEPOTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<DEPOTIPLER> items) : base(items) { }


            public DEPOTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public DEPOTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<DEPOTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<DEPOTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(DEPOTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(DEPOTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<DEPOTIPLER> Select
        {
            get { return R.Query<DEPOTIPLER>(); }
        }

        public static DEPOTIPLER SelectItem(Decimal ID)
        {
            return R.Query<DEPOTIPLER>().First(t => t.ID == ID);
        }

        public static List<DEPOTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<DEPOTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<DEPOTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<DEPOTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

