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
    public class SERVISISORTAKZIYARETLER : SasonBase.Sason.Tables.Table_SERVISISORTAKZIYARETLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISORTAKZIYARETLER>
        {
            Dictionary<Decimal, SERVISISORTAKZIYARETLER> dict = new Dictionary<Decimal, SERVISISORTAKZIYARETLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISORTAKZIYARETLER> items) : base(items) { }


            public SERVISISORTAKZIYARETLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISORTAKZIYARETLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISORTAKZIYARETLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISORTAKZIYARETLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISORTAKZIYARETLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISORTAKZIYARETLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISORTAKZIYARETLER> Select
        {
            get { return R.Query<SERVISISORTAKZIYARETLER>(); }
        }

        public static SERVISISORTAKZIYARETLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISISORTAKZIYARETLER>().First(t => t.ID == ID);
        }

        public static List<SERVISISORTAKZIYARETLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISORTAKZIYARETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISORTAKZIYARETLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISORTAKZIYARETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

