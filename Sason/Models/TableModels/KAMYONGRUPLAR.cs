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
    public class KAMYONGRUPLAR : SasonBase.Sason.Tables.Table_KAMYONGRUPLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<KAMYONGRUPLAR>
        {
            Dictionary<Decimal, KAMYONGRUPLAR> dict = new Dictionary<Decimal, KAMYONGRUPLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<KAMYONGRUPLAR> items) : base(items) { }


            public KAMYONGRUPLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public KAMYONGRUPLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<KAMYONGRUPLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<KAMYONGRUPLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(KAMYONGRUPLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(KAMYONGRUPLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<KAMYONGRUPLAR> Select
        {
            get { return R.Query<KAMYONGRUPLAR>(); }
        }

        public static KAMYONGRUPLAR SelectItem(Decimal ID)
        {
            return R.Query<KAMYONGRUPLAR>().First(t => t.ID == ID);
        }

        public static List<KAMYONGRUPLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<KAMYONGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<KAMYONGRUPLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<KAMYONGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

