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
    public class ISCILIKNESNELER : SasonBase.Sason.Tables.Table_ISCILIKNESNELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISCILIKNESNELER>
        {
            Dictionary<Decimal, ISCILIKNESNELER> dict = new Dictionary<Decimal, ISCILIKNESNELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISCILIKNESNELER> items) : base(items) { }


            public ISCILIKNESNELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISCILIKNESNELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISCILIKNESNELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISCILIKNESNELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISCILIKNESNELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISCILIKNESNELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISCILIKNESNELER> Select
        {
            get { return R.Query<ISCILIKNESNELER>(); }
        }

        public static ISCILIKNESNELER SelectItem(Decimal ID)
        {
            return R.Query<ISCILIKNESNELER>().First(t => t.ID == ID);
        }

        public static List<ISCILIKNESNELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISCILIKNESNELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISCILIKNESNELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISCILIKNESNELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

