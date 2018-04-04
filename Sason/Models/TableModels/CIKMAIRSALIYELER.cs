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
    public class CIKMAIRSALIYELER : SasonBase.Sason.Tables.Table_CIKMAIRSALIYELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<CIKMAIRSALIYELER>
        {
            Dictionary<Decimal, CIKMAIRSALIYELER> dict = new Dictionary<Decimal, CIKMAIRSALIYELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<CIKMAIRSALIYELER> items) : base(items) { }


            public CIKMAIRSALIYELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public CIKMAIRSALIYELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<CIKMAIRSALIYELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<CIKMAIRSALIYELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(CIKMAIRSALIYELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(CIKMAIRSALIYELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<CIKMAIRSALIYELER> Select
        {
            get { return R.Query<CIKMAIRSALIYELER>(); }
        }

        public static CIKMAIRSALIYELER SelectItem(Decimal ID)
        {
            return R.Query<CIKMAIRSALIYELER>().First(t => t.ID == ID);
        }

        public static List<CIKMAIRSALIYELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<CIKMAIRSALIYELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<CIKMAIRSALIYELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<CIKMAIRSALIYELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

