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
    public class FILOBUYUKLUKLER : SasonBase.Sason.Tables.Table_FILOBUYUKLUKLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<FILOBUYUKLUKLER>
        {
            Dictionary<Decimal, FILOBUYUKLUKLER> dict = new Dictionary<Decimal, FILOBUYUKLUKLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<FILOBUYUKLUKLER> items) : base(items) { }


            public FILOBUYUKLUKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public FILOBUYUKLUKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<FILOBUYUKLUKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<FILOBUYUKLUKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(FILOBUYUKLUKLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(FILOBUYUKLUKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<FILOBUYUKLUKLER> Select
        {
            get { return R.Query<FILOBUYUKLUKLER>(); }
        }

        public static FILOBUYUKLUKLER SelectItem(Decimal ID)
        {
            return R.Query<FILOBUYUKLUKLER>().First(t => t.ID == ID);
        }

        public static List<FILOBUYUKLUKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<FILOBUYUKLUKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<FILOBUYUKLUKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<FILOBUYUKLUKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

