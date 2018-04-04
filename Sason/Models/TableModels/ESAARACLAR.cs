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
    public class ESAARACLAR : SasonBase.Sason.Tables.Table_ESAARACLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ESAARACLAR>
        {
            Dictionary<Decimal, ESAARACLAR> dict = new Dictionary<Decimal, ESAARACLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ESAARACLAR> items) : base(items) { }


            public ESAARACLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ESAARACLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ESAARACLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ESAARACLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ESAARACLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ESAARACLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ESAARACLAR> Select
        {
            get { return R.Query<ESAARACLAR>(); }
        }

        public static ESAARACLAR SelectItem(Decimal ID)
        {
            return R.Query<ESAARACLAR>().First(t => t.ID == ID);
        }

        public static List<ESAARACLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ESAARACLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ESAARACLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ESAARACLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

