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
    public class SERVISISORTAKZIYARETKNL : SasonBase.Sason.Tables.Table_SERVISISORTAKZIYARETKNL.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISORTAKZIYARETKNL>
        {
            Dictionary<Decimal, SERVISISORTAKZIYARETKNL> dict = new Dictionary<Decimal, SERVISISORTAKZIYARETKNL>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISORTAKZIYARETKNL> items) : base(items) { }


            public SERVISISORTAKZIYARETKNL this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISORTAKZIYARETKNL Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISORTAKZIYARETKNL> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISORTAKZIYARETKNL> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISORTAKZIYARETKNL item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISORTAKZIYARETKNL item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISORTAKZIYARETKNL> Select
        {
            get { return R.Query<SERVISISORTAKZIYARETKNL>(); }
        }

        public static SERVISISORTAKZIYARETKNL SelectItem(Decimal ID)
        {
            return R.Query<SERVISISORTAKZIYARETKNL>().First(t => t.ID == ID);
        }

        public static List<SERVISISORTAKZIYARETKNL> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISORTAKZIYARETKNL>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISORTAKZIYARETKNL> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISORTAKZIYARETKNL>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

