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
    public class SERVISPROJELER : SasonBase.Sason.Tables.Table_SERVISPROJELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISPROJELER>
        {
            Dictionary<Decimal, SERVISPROJELER> dict = new Dictionary<Decimal, SERVISPROJELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISPROJELER> items) : base(items) { }


            public SERVISPROJELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISPROJELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISPROJELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISPROJELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISPROJELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISPROJELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISPROJELER> Select
        {
            get { return R.Query<SERVISPROJELER>(); }
        }

        public static SERVISPROJELER SelectItem(Decimal ID)
        {
            return R.Query<SERVISPROJELER>().First(t => t.ID == ID);
        }

        public static List<SERVISPROJELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISPROJELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISPROJELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISPROJELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

