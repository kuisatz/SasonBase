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
    public class KAMPANYALAR : SasonBase.Sason.Tables.Table_KAMPANYALAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<KAMPANYALAR>
        {
            Dictionary<Decimal, KAMPANYALAR> dict = new Dictionary<Decimal, KAMPANYALAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<KAMPANYALAR> items) : base(items) { }


            public KAMPANYALAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public KAMPANYALAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<KAMPANYALAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<KAMPANYALAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(KAMPANYALAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(KAMPANYALAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<KAMPANYALAR> Select
        {
            get { return R.Query<KAMPANYALAR>(); }
        }

        public static KAMPANYALAR SelectItem(Decimal ID)
        {
            return R.Query<KAMPANYALAR>().First(t => t.ID == ID);
        }

        public static List<KAMPANYALAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<KAMPANYALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<KAMPANYALAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<KAMPANYALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

