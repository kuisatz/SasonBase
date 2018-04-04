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
    public class SERVISEKMALIYETLER : SasonBase.Sason.Tables.Table_SERVISEKMALIYETLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISEKMALIYETLER>
        {
            Dictionary<Decimal, SERVISEKMALIYETLER> dict = new Dictionary<Decimal, SERVISEKMALIYETLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISEKMALIYETLER> items) : base(items) { }


            public SERVISEKMALIYETLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISEKMALIYETLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISEKMALIYETLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISEKMALIYETLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISEKMALIYETLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISEKMALIYETLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISEKMALIYETLER> Select
        {
            get { return R.Query<SERVISEKMALIYETLER>(); }
        }

        public static SERVISEKMALIYETLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISEKMALIYETLER>().First(t => t.ID == ID);
        }

        public static List<SERVISEKMALIYETLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISEKMALIYETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISEKMALIYETLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISEKMALIYETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

