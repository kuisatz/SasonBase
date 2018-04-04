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
    public class ISORTAKZIYARETKNL : SasonBase.Sason.Tables.Table_ISORTAKZIYARETKNL.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISORTAKZIYARETKNL>
        {
            Dictionary<Decimal, ISORTAKZIYARETKNL> dict = new Dictionary<Decimal, ISORTAKZIYARETKNL>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISORTAKZIYARETKNL> items) : base(items) { }


            public ISORTAKZIYARETKNL this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISORTAKZIYARETKNL Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISORTAKZIYARETKNL> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISORTAKZIYARETKNL> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISORTAKZIYARETKNL item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISORTAKZIYARETKNL item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISORTAKZIYARETKNL> Select
        {
            get { return R.Query<ISORTAKZIYARETKNL>(); }
        }

        public static ISORTAKZIYARETKNL SelectItem(Decimal ID)
        {
            return R.Query<ISORTAKZIYARETKNL>().First(t => t.ID == ID);
        }

        public static List<ISORTAKZIYARETKNL> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISORTAKZIYARETKNL>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISORTAKZIYARETKNL> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISORTAKZIYARETKNL>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

