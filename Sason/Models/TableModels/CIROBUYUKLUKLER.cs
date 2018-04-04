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
    public class CIROBUYUKLUKLER : SasonBase.Sason.Tables.Table_CIROBUYUKLUKLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<CIROBUYUKLUKLER>
        {
            Dictionary<Decimal, CIROBUYUKLUKLER> dict = new Dictionary<Decimal, CIROBUYUKLUKLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<CIROBUYUKLUKLER> items) : base(items) { }


            public CIROBUYUKLUKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public CIROBUYUKLUKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<CIROBUYUKLUKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<CIROBUYUKLUKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(CIROBUYUKLUKLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(CIROBUYUKLUKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<CIROBUYUKLUKLER> Select
        {
            get { return R.Query<CIROBUYUKLUKLER>(); }
        }

        public static CIROBUYUKLUKLER SelectItem(Decimal ID)
        {
            return R.Query<CIROBUYUKLUKLER>().First(t => t.ID == ID);
        }

        public static List<CIROBUYUKLUKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<CIROBUYUKLUKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<CIROBUYUKLUKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<CIROBUYUKLUKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

