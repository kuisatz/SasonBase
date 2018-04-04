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
    public class BAKIMDEGISIMLER : SasonBase.Sason.Tables.Table_BAKIMDEGISIMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMDEGISIMLER>
        {
            Dictionary<Decimal, BAKIMDEGISIMLER> dict = new Dictionary<Decimal, BAKIMDEGISIMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMDEGISIMLER> items) : base(items) { }


            public BAKIMDEGISIMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMDEGISIMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMDEGISIMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMDEGISIMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMDEGISIMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMDEGISIMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMDEGISIMLER> Select
        {
            get { return R.Query<BAKIMDEGISIMLER>(); }
        }

        public static BAKIMDEGISIMLER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMDEGISIMLER>().First(t => t.ID == ID);
        }

        public static List<BAKIMDEGISIMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMDEGISIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMDEGISIMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMDEGISIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

