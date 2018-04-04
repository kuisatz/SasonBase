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
    public class BAKIMSOZLESMELER : SasonBase.Sason.Tables.Table_BAKIMSOZLESMELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMSOZLESMELER>
        {
            Dictionary<Decimal, BAKIMSOZLESMELER> dict = new Dictionary<Decimal, BAKIMSOZLESMELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMSOZLESMELER> items) : base(items) { }


            public BAKIMSOZLESMELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMSOZLESMELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMSOZLESMELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMSOZLESMELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMSOZLESMELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMSOZLESMELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMSOZLESMELER> Select
        {
            get { return R.Query<BAKIMSOZLESMELER>(); }
        }

        public static BAKIMSOZLESMELER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMSOZLESMELER>().First(t => t.ID == ID);
        }

        public static List<BAKIMSOZLESMELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMSOZLESMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMSOZLESMELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMSOZLESMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

