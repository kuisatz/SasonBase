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
    public class DBSLIMITLER : SasonBase.Sason.Tables.Table_DBSLIMITLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<DBSLIMITLER>
        {
            Dictionary<Decimal, DBSLIMITLER> dict = new Dictionary<Decimal, DBSLIMITLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<DBSLIMITLER> items) : base(items) { }


            public DBSLIMITLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public DBSLIMITLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<DBSLIMITLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<DBSLIMITLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(DBSLIMITLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(DBSLIMITLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<DBSLIMITLER> Select
        {
            get { return R.Query<DBSLIMITLER>(); }
        }

        public static DBSLIMITLER SelectItem(Decimal ID)
        {
            return R.Query<DBSLIMITLER>().First(t => t.ID == ID);
        }

        public static List<DBSLIMITLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<DBSLIMITLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<DBSLIMITLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<DBSLIMITLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

