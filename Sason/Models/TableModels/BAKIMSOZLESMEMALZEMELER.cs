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
    public class BAKIMSOZLESMEMALZEMELER : SasonBase.Sason.Tables.Table_BAKIMSOZLESMEMALZEMELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMSOZLESMEMALZEMELER>
        {
            Dictionary<Decimal, BAKIMSOZLESMEMALZEMELER> dict = new Dictionary<Decimal, BAKIMSOZLESMEMALZEMELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMSOZLESMEMALZEMELER> items) : base(items) { }


            public BAKIMSOZLESMEMALZEMELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMSOZLESMEMALZEMELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMSOZLESMEMALZEMELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMSOZLESMEMALZEMELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMSOZLESMEMALZEMELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMSOZLESMEMALZEMELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMSOZLESMEMALZEMELER> Select
        {
            get { return R.Query<BAKIMSOZLESMEMALZEMELER>(); }
        }

        public static BAKIMSOZLESMEMALZEMELER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMSOZLESMEMALZEMELER>().First(t => t.ID == ID);
        }

        public static List<BAKIMSOZLESMEMALZEMELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMSOZLESMEMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMSOZLESMEMALZEMELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMSOZLESMEMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

