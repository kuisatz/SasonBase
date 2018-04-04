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
    public class ISORTAKLAR : SasonBase.Sason.Tables.Table_ISORTAKLAR.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<ISORTAKLAR>
        {
            Dictionary<Decimal, ISORTAKLAR> dict = new Dictionary<Decimal, ISORTAKLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISORTAKLAR> items) : base(items) { }


            public ISORTAKLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISORTAKLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISORTAKLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISORTAKLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISORTAKLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISORTAKLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISORTAKLAR> Select
        {
            get { return R.Query<ISORTAKLAR>(); }
        }

        public static ISORTAKLAR SelectItem(Decimal ID)
        {
            return R.Query<ISORTAKLAR>().First(t => t.ID == ID);
        }

        public static List<ISORTAKLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISORTAKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISORTAKLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISORTAKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

