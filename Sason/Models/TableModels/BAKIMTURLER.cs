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
    public class BAKIMTURLER : SasonBase.Sason.Tables.Table_BAKIMTURLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMTURLER>
        {
            Dictionary<Decimal, BAKIMTURLER> dict = new Dictionary<Decimal, BAKIMTURLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMTURLER> items) : base(items) { }


            public BAKIMTURLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMTURLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMTURLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMTURLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMTURLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMTURLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMTURLER> Select
        {
            get { return R.Query<BAKIMTURLER>(); }
        }

        public static BAKIMTURLER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMTURLER>().First(t => t.ID == ID);
        }

        public static List<BAKIMTURLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMTURLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

