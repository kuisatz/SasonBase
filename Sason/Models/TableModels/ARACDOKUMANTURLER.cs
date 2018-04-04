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
    public class ARACDOKUMANTURLER : SasonBase.Sason.Tables.Table_ARACDOKUMANTURLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ARACDOKUMANTURLER>
        {
            Dictionary<Decimal, ARACDOKUMANTURLER> dict = new Dictionary<Decimal, ARACDOKUMANTURLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ARACDOKUMANTURLER> items) : base(items) { }


            public ARACDOKUMANTURLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ARACDOKUMANTURLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ARACDOKUMANTURLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ARACDOKUMANTURLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ARACDOKUMANTURLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ARACDOKUMANTURLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ARACDOKUMANTURLER> Select
        {
            get { return R.Query<ARACDOKUMANTURLER>(); }
        }

        public static ARACDOKUMANTURLER SelectItem(Decimal ID)
        {
            return R.Query<ARACDOKUMANTURLER>().First(t => t.ID == ID);
        }

        public static List<ARACDOKUMANTURLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ARACDOKUMANTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ARACDOKUMANTURLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ARACDOKUMANTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

