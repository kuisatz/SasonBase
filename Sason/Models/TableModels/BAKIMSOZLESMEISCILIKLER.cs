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
    public class BAKIMSOZLESMEISCILIKLER : SasonBase.Sason.Tables.Table_BAKIMSOZLESMEISCILIKLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMSOZLESMEISCILIKLER>
        {
            Dictionary<Decimal, BAKIMSOZLESMEISCILIKLER> dict = new Dictionary<Decimal, BAKIMSOZLESMEISCILIKLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMSOZLESMEISCILIKLER> items) : base(items) { }


            public BAKIMSOZLESMEISCILIKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMSOZLESMEISCILIKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMSOZLESMEISCILIKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMSOZLESMEISCILIKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMSOZLESMEISCILIKLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMSOZLESMEISCILIKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMSOZLESMEISCILIKLER> Select
        {
            get { return R.Query<BAKIMSOZLESMEISCILIKLER>(); }
        }

        public static BAKIMSOZLESMEISCILIKLER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMSOZLESMEISCILIKLER>().First(t => t.ID == ID);
        }

        public static List<BAKIMSOZLESMEISCILIKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMSOZLESMEISCILIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMSOZLESMEISCILIKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMSOZLESMEISCILIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

