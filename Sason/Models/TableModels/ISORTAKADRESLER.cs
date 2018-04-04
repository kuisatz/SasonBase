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
    public class ISORTAKADRESLER : SasonBase.Sason.Tables.Table_ISORTAKADRESLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISORTAKADRESLER>
        {
            Dictionary<Decimal, ISORTAKADRESLER> dict = new Dictionary<Decimal, ISORTAKADRESLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISORTAKADRESLER> items) : base(items) { }


            public ISORTAKADRESLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISORTAKADRESLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISORTAKADRESLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISORTAKADRESLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISORTAKADRESLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISORTAKADRESLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISORTAKADRESLER> Select
        {
            get { return R.Query<ISORTAKADRESLER>(); }
        }

        public static ISORTAKADRESLER SelectItem(Decimal ID)
        {
            return R.Query<ISORTAKADRESLER>().First(t => t.ID == ID);
        }

        public static List<ISORTAKADRESLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISORTAKADRESLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISORTAKADRESLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISORTAKADRESLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

