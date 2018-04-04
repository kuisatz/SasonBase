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
    public class ISORTAKZIYARETARCL : SasonBase.Sason.Tables.Table_ISORTAKZIYARETARCL.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISORTAKZIYARETARCL>
        {
            Dictionary<Decimal, ISORTAKZIYARETARCL> dict = new Dictionary<Decimal, ISORTAKZIYARETARCL>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISORTAKZIYARETARCL> items) : base(items) { }


            public ISORTAKZIYARETARCL this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISORTAKZIYARETARCL Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISORTAKZIYARETARCL> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISORTAKZIYARETARCL> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISORTAKZIYARETARCL item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISORTAKZIYARETARCL item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISORTAKZIYARETARCL> Select
        {
            get { return R.Query<ISORTAKZIYARETARCL>(); }
        }

        public static ISORTAKZIYARETARCL SelectItem(Decimal ID)
        {
            return R.Query<ISORTAKZIYARETARCL>().First(t => t.ID == ID);
        }

        public static List<ISORTAKZIYARETARCL> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISORTAKZIYARETARCL>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISORTAKZIYARETARCL> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISORTAKZIYARETARCL>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

