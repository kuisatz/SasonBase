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
    public class ESAGARANTIDOSYALISTELER : SasonBase.Sason.Tables.Table_ESAGARANTIDOSYALISTELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ESAGARANTIDOSYALISTELER>
        {
            Dictionary<Decimal, ESAGARANTIDOSYALISTELER> dict = new Dictionary<Decimal, ESAGARANTIDOSYALISTELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ESAGARANTIDOSYALISTELER> items) : base(items) { }


            public ESAGARANTIDOSYALISTELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ESAGARANTIDOSYALISTELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ESAGARANTIDOSYALISTELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ESAGARANTIDOSYALISTELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ESAGARANTIDOSYALISTELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ESAGARANTIDOSYALISTELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ESAGARANTIDOSYALISTELER> Select
        {
            get { return R.Query<ESAGARANTIDOSYALISTELER>(); }
        }

        public static ESAGARANTIDOSYALISTELER SelectItem(Decimal ID)
        {
            return R.Query<ESAGARANTIDOSYALISTELER>().First(t => t.ID == ID);
        }

        public static List<ESAGARANTIDOSYALISTELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ESAGARANTIDOSYALISTELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ESAGARANTIDOSYALISTELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ESAGARANTIDOSYALISTELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

