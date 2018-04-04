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
    public class SERVISISORTAKZIYARETARCL : SasonBase.Sason.Tables.Table_SERVISISORTAKZIYARETARCL.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISORTAKZIYARETARCL>
        {
            Dictionary<Decimal, SERVISISORTAKZIYARETARCL> dict = new Dictionary<Decimal, SERVISISORTAKZIYARETARCL>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISORTAKZIYARETARCL> items) : base(items) { }


            public SERVISISORTAKZIYARETARCL this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISORTAKZIYARETARCL Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISORTAKZIYARETARCL> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISORTAKZIYARETARCL> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISORTAKZIYARETARCL item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISORTAKZIYARETARCL item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISORTAKZIYARETARCL> Select
        {
            get { return R.Query<SERVISISORTAKZIYARETARCL>(); }
        }

        public static SERVISISORTAKZIYARETARCL SelectItem(Decimal ID)
        {
            return R.Query<SERVISISORTAKZIYARETARCL>().First(t => t.ID == ID);
        }

        public static List<SERVISISORTAKZIYARETARCL> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISORTAKZIYARETARCL>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISORTAKZIYARETARCL> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISORTAKZIYARETARCL>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

