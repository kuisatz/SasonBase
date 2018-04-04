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
    public class ISORTAKZIYARETLER : SasonBase.Sason.Tables.Table_ISORTAKZIYARETLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISORTAKZIYARETLER>
        {
            Dictionary<Decimal, ISORTAKZIYARETLER> dict = new Dictionary<Decimal, ISORTAKZIYARETLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISORTAKZIYARETLER> items) : base(items) { }


            public ISORTAKZIYARETLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISORTAKZIYARETLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISORTAKZIYARETLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISORTAKZIYARETLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISORTAKZIYARETLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISORTAKZIYARETLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISORTAKZIYARETLER> Select
        {
            get { return R.Query<ISORTAKZIYARETLER>(); }
        }

        public static ISORTAKZIYARETLER SelectItem(Decimal ID)
        {
            return R.Query<ISORTAKZIYARETLER>().First(t => t.ID == ID);
        }

        public static List<ISORTAKZIYARETLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISORTAKZIYARETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISORTAKZIYARETLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISORTAKZIYARETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

