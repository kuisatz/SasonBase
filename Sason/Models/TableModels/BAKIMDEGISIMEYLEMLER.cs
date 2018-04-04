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
    public class BAKIMDEGISIMEYLEMLER : SasonBase.Sason.Tables.Table_BAKIMDEGISIMEYLEMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMDEGISIMEYLEMLER>
        {
            Dictionary<Decimal, BAKIMDEGISIMEYLEMLER> dict = new Dictionary<Decimal, BAKIMDEGISIMEYLEMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMDEGISIMEYLEMLER> items) : base(items) { }


            public BAKIMDEGISIMEYLEMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMDEGISIMEYLEMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMDEGISIMEYLEMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMDEGISIMEYLEMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMDEGISIMEYLEMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMDEGISIMEYLEMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMDEGISIMEYLEMLER> Select
        {
            get { return R.Query<BAKIMDEGISIMEYLEMLER>(); }
        }

        public static BAKIMDEGISIMEYLEMLER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMDEGISIMEYLEMLER>().First(t => t.ID == ID);
        }

        public static List<BAKIMDEGISIMEYLEMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMDEGISIMEYLEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMDEGISIMEYLEMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMDEGISIMEYLEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

