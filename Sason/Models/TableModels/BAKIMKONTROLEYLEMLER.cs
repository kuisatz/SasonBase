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
    public class BAKIMKONTROLEYLEMLER : SasonBase.Sason.Tables.Table_BAKIMKONTROLEYLEMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMKONTROLEYLEMLER>
        {
            Dictionary<Decimal, BAKIMKONTROLEYLEMLER> dict = new Dictionary<Decimal, BAKIMKONTROLEYLEMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMKONTROLEYLEMLER> items) : base(items) { }


            public BAKIMKONTROLEYLEMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMKONTROLEYLEMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMKONTROLEYLEMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMKONTROLEYLEMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMKONTROLEYLEMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMKONTROLEYLEMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMKONTROLEYLEMLER> Select
        {
            get { return R.Query<BAKIMKONTROLEYLEMLER>(); }
        }

        public static BAKIMKONTROLEYLEMLER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMKONTROLEYLEMLER>().First(t => t.ID == ID);
        }

        public static List<BAKIMKONTROLEYLEMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMKONTROLEYLEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMKONTROLEYLEMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMKONTROLEYLEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

