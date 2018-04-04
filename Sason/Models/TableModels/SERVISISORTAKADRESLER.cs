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
    public class SERVISISORTAKADRESLER : SasonBase.Sason.Tables.Table_SERVISISORTAKADRESLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISORTAKADRESLER>
        {
            Dictionary<Decimal, SERVISISORTAKADRESLER> dict = new Dictionary<Decimal, SERVISISORTAKADRESLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISORTAKADRESLER> items) : base(items) { }


            public SERVISISORTAKADRESLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISORTAKADRESLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISORTAKADRESLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISORTAKADRESLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISORTAKADRESLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISORTAKADRESLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISORTAKADRESLER> Select
        {
            get { return R.Query<SERVISISORTAKADRESLER>(); }
        }

        public static SERVISISORTAKADRESLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISISORTAKADRESLER>().First(t => t.ID == ID);
        }

        public static List<SERVISISORTAKADRESLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISORTAKADRESLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISORTAKADRESLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISORTAKADRESLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

