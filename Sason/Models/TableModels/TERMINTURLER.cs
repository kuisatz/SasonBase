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
    public class TERMINTURLER : SasonBase.Sason.Tables.Table_TERMINTURLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<TERMINTURLER>
        {
            Dictionary<Decimal, TERMINTURLER> dict = new Dictionary<Decimal, TERMINTURLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<TERMINTURLER> items) : base(items) { }


            public TERMINTURLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public TERMINTURLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<TERMINTURLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<TERMINTURLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(TERMINTURLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(TERMINTURLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<TERMINTURLER> Select
        {
            get { return R.Query<TERMINTURLER>(); }
        }

        public static TERMINTURLER SelectItem(Decimal ID)
        {
            return R.Query<TERMINTURLER>().First(t => t.ID == ID);
        }

        public static List<TERMINTURLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<TERMINTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<TERMINTURLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<TERMINTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

