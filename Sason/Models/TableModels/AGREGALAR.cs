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
    public class AGREGALAR : SasonBase.Sason.Tables.Table_AGREGALAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<AGREGALAR>
        {
            Dictionary<Decimal, AGREGALAR> dict = new Dictionary<Decimal, AGREGALAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<AGREGALAR> items) : base(items) { }


            public AGREGALAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AGREGALAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AGREGALAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AGREGALAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(AGREGALAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AGREGALAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AGREGALAR> Select
        {
            get { return R.Query<AGREGALAR>(); }
        }

        public static AGREGALAR SelectItem(Decimal ID)
        {
            return R.Query<AGREGALAR>().First(t => t.ID == ID);
        }

        public static List<AGREGALAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AGREGALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AGREGALAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AGREGALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

