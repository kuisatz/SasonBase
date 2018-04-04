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
    public class AYAKKABINUMARALAR : SasonBase.Sason.Tables.Table_AYAKKABINUMARALAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<AYAKKABINUMARALAR>
        {
            Dictionary<Decimal, AYAKKABINUMARALAR> dict = new Dictionary<Decimal, AYAKKABINUMARALAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<AYAKKABINUMARALAR> items) : base(items) { }


            public AYAKKABINUMARALAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AYAKKABINUMARALAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AYAKKABINUMARALAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AYAKKABINUMARALAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(AYAKKABINUMARALAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AYAKKABINUMARALAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AYAKKABINUMARALAR> Select
        {
            get { return R.Query<AYAKKABINUMARALAR>(); }
        }

        public static AYAKKABINUMARALAR SelectItem(Decimal ID)
        {
            return R.Query<AYAKKABINUMARALAR>().First(t => t.ID == ID);
        }

        public static List<AYAKKABINUMARALAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AYAKKABINUMARALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AYAKKABINUMARALAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AYAKKABINUMARALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

