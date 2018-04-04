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
    public class ARACSINIFLAR : SasonBase.Sason.Tables.Table_ARACSINIFLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ARACSINIFLAR>
        {
            Dictionary<Decimal, ARACSINIFLAR> dict = new Dictionary<Decimal, ARACSINIFLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ARACSINIFLAR> items) : base(items) { }


            public ARACSINIFLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ARACSINIFLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ARACSINIFLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ARACSINIFLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ARACSINIFLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ARACSINIFLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ARACSINIFLAR> Select
        {
            get { return R.Query<ARACSINIFLAR>(); }
        }

        public static ARACSINIFLAR SelectItem(Decimal ID)
        {
            return R.Query<ARACSINIFLAR>().First(t => t.ID == ID);
        }

        public static List<ARACSINIFLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ARACSINIFLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ARACSINIFLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ARACSINIFLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

