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
    public class ODEMETIPLER : SasonBase.Sason.Tables.Table_ODEMETIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ODEMETIPLER>
        {
            Dictionary<Decimal, ODEMETIPLER> dict = new Dictionary<Decimal, ODEMETIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ODEMETIPLER> items) : base(items) { }


            public ODEMETIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ODEMETIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ODEMETIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ODEMETIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ODEMETIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ODEMETIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ODEMETIPLER> Select
        {
            get { return R.Query<ODEMETIPLER>(); }
        }

        public static ODEMETIPLER SelectItem(Decimal ID)
        {
            return R.Query<ODEMETIPLER>().First(t => t.ID == ID);
        }

        public static List<ODEMETIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ODEMETIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ODEMETIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ODEMETIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

