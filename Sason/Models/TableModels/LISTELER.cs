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
    public class LISTELER : SasonBase.Sason.Tables.Table_LISTELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<LISTELER>
        {
            Dictionary<Decimal, LISTELER> dict = new Dictionary<Decimal, LISTELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<LISTELER> items) : base(items) { }


            public LISTELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public LISTELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<LISTELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<LISTELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(LISTELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(LISTELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<LISTELER> Select
        {
            get { return R.Query<LISTELER>(); }
        }

        public static LISTELER SelectItem(Decimal ID)
        {
            return R.Query<LISTELER>().First(t => t.ID == ID);
        }

        public static List<LISTELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<LISTELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<LISTELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<LISTELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

