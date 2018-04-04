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
    public class BAKIMGRUPDEGISIMLER : SasonBase.Sason.Tables.Table_BAKIMGRUPDEGISIMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMGRUPDEGISIMLER>
        {
            Dictionary<Decimal, BAKIMGRUPDEGISIMLER> dict = new Dictionary<Decimal, BAKIMGRUPDEGISIMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMGRUPDEGISIMLER> items) : base(items) { }


            public BAKIMGRUPDEGISIMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMGRUPDEGISIMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMGRUPDEGISIMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMGRUPDEGISIMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMGRUPDEGISIMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMGRUPDEGISIMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMGRUPDEGISIMLER> Select
        {
            get { return R.Query<BAKIMGRUPDEGISIMLER>(); }
        }

        public static BAKIMGRUPDEGISIMLER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMGRUPDEGISIMLER>().First(t => t.ID == ID);
        }

        public static List<BAKIMGRUPDEGISIMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMGRUPDEGISIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMGRUPDEGISIMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMGRUPDEGISIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

