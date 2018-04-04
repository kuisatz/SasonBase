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
    public class EGITIMDUZEYLER : SasonBase.Sason.Tables.Table_EGITIMDUZEYLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<EGITIMDUZEYLER>
        {
            Dictionary<Decimal, EGITIMDUZEYLER> dict = new Dictionary<Decimal, EGITIMDUZEYLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<EGITIMDUZEYLER> items) : base(items) { }


            public EGITIMDUZEYLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public EGITIMDUZEYLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<EGITIMDUZEYLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<EGITIMDUZEYLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(EGITIMDUZEYLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(EGITIMDUZEYLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<EGITIMDUZEYLER> Select
        {
            get { return R.Query<EGITIMDUZEYLER>(); }
        }

        public static EGITIMDUZEYLER SelectItem(Decimal ID)
        {
            return R.Query<EGITIMDUZEYLER>().First(t => t.ID == ID);
        }

        public static List<EGITIMDUZEYLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<EGITIMDUZEYLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<EGITIMDUZEYLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<EGITIMDUZEYLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

