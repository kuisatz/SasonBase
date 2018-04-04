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
    public class ISCILIKARACSINIFLAR : SasonBase.Sason.Tables.Table_ISCILIKARACSINIFLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISCILIKARACSINIFLAR>
        {
            Dictionary<Decimal, ISCILIKARACSINIFLAR> dict = new Dictionary<Decimal, ISCILIKARACSINIFLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISCILIKARACSINIFLAR> items) : base(items) { }


            public ISCILIKARACSINIFLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISCILIKARACSINIFLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISCILIKARACSINIFLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISCILIKARACSINIFLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISCILIKARACSINIFLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISCILIKARACSINIFLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISCILIKARACSINIFLAR> Select
        {
            get { return R.Query<ISCILIKARACSINIFLAR>(); }
        }

        public static ISCILIKARACSINIFLAR SelectItem(Decimal ID)
        {
            return R.Query<ISCILIKARACSINIFLAR>().First(t => t.ID == ID);
        }

        public static List<ISCILIKARACSINIFLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISCILIKARACSINIFLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISCILIKARACSINIFLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISCILIKARACSINIFLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

