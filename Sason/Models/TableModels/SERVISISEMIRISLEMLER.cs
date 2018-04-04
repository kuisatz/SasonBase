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
    public class SERVISISEMIRISLEMLER : SasonBase.Sason.Tables.Table_SERVISISEMIRISLEMLER.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISEMIRISLEMLER>
        {
            Dictionary<Decimal, SERVISISEMIRISLEMLER> dict = new Dictionary<Decimal, SERVISISEMIRISLEMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISEMIRISLEMLER> items) : base(items) { }


            public SERVISISEMIRISLEMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISEMIRISLEMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISEMIRISLEMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISEMIRISLEMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISEMIRISLEMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISEMIRISLEMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISEMIRISLEMLER> Select
        {
            get { return R.Query<SERVISISEMIRISLEMLER>(); }
        }

        public static SERVISISEMIRISLEMLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISISEMIRISLEMLER>().First(t => t.ID == ID);
        }

        public static List<SERVISISEMIRISLEMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISEMIRISLEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISEMIRISLEMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISEMIRISLEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

