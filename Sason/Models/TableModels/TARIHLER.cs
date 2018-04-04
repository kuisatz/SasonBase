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
    [Serializable]
    public class TARIHLER : SasonBase.Sason.Tables.Table_TARIHLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<TARIHLER>
        {
            Dictionary<Decimal, TARIHLER> dict = new Dictionary<Decimal, TARIHLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<TARIHLER> items) : base(items) { }


            public TARIHLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public TARIHLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<TARIHLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<TARIHLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(TARIHLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(TARIHLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<TARIHLER> Select
        {
            get { return R.Query<TARIHLER>(); }
        }

        public static TARIHLER SelectItem(Decimal ID)
        {
            return R.Query<TARIHLER>().First(t => t.ID == ID);
        }

        public static List<TARIHLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<TARIHLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<TARIHLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<TARIHLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

