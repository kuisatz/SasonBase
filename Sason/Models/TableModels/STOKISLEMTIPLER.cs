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
    public class STOKISLEMTIPLER : SasonBase.Sason.Tables.Table_STOKISLEMTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<STOKISLEMTIPLER>
        {
            Dictionary<Decimal, STOKISLEMTIPLER> dict = new Dictionary<Decimal, STOKISLEMTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<STOKISLEMTIPLER> items) : base(items) { }


            public STOKISLEMTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public STOKISLEMTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<STOKISLEMTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<STOKISLEMTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(STOKISLEMTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(STOKISLEMTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<STOKISLEMTIPLER> Select
        {
            get { return R.Query<STOKISLEMTIPLER>(); }
        }

        public static STOKISLEMTIPLER SelectItem(Decimal ID)
        {
            return R.Query<STOKISLEMTIPLER>().First(t => t.ID == ID);
        }

        public static List<STOKISLEMTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<STOKISLEMTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<STOKISLEMTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<STOKISLEMTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

