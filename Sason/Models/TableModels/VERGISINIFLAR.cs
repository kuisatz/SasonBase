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
    public class VERGISINIFLAR : SasonBase.Sason.Tables.Table_VERGISINIFLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<VERGISINIFLAR>
        {
            Dictionary<Decimal, VERGISINIFLAR> dict = new Dictionary<Decimal, VERGISINIFLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<VERGISINIFLAR> items) : base(items) { }


            public VERGISINIFLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public VERGISINIFLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<VERGISINIFLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<VERGISINIFLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(VERGISINIFLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(VERGISINIFLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<VERGISINIFLAR> Select
        {
            get { return R.Query<VERGISINIFLAR>(); }
        }

        public static VERGISINIFLAR SelectItem(Decimal ID)
        {
            return R.Query<VERGISINIFLAR>().First(t => t.ID == ID);
        }

        public static List<VERGISINIFLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<VERGISINIFLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<VERGISINIFLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<VERGISINIFLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

