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
    public class ISEMIRAGREGALAR : SasonBase.Sason.Tables.Table_ISEMIRAGREGALAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISEMIRAGREGALAR>
        {
            Dictionary<Decimal, ISEMIRAGREGALAR> dict = new Dictionary<Decimal, ISEMIRAGREGALAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISEMIRAGREGALAR> items) : base(items) { }


            public ISEMIRAGREGALAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISEMIRAGREGALAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISEMIRAGREGALAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISEMIRAGREGALAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISEMIRAGREGALAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISEMIRAGREGALAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISEMIRAGREGALAR> Select
        {
            get { return R.Query<ISEMIRAGREGALAR>(); }
        }

        public static ISEMIRAGREGALAR SelectItem(Decimal ID)
        {
            return R.Query<ISEMIRAGREGALAR>().First(t => t.ID == ID);
        }

        public static List<ISEMIRAGREGALAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISEMIRAGREGALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISEMIRAGREGALAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISEMIRAGREGALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

