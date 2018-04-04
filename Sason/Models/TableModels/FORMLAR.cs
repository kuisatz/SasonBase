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
    public class FORMLAR : SasonBase.Sason.Tables.Table_FORMLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<FORMLAR>
        {
            Dictionary<Decimal, FORMLAR> dict = new Dictionary<Decimal, FORMLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<FORMLAR> items) : base(items) { }


            public FORMLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public FORMLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<FORMLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<FORMLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(FORMLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(FORMLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<FORMLAR> Select
        {
            get { return R.Query<FORMLAR>(); }
        }

        public static FORMLAR SelectItem(Decimal ID)
        {
            return R.Query<FORMLAR>().First(t => t.ID == ID);
        }

        public static List<FORMLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<FORMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<FORMLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<FORMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

