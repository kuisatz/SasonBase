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
    public class ISEMIRTIPLER : SasonBase.Sason.Tables.Table_ISEMIRTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISEMIRTIPLER>
        {
            Dictionary<Decimal, ISEMIRTIPLER> dict = new Dictionary<Decimal, ISEMIRTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISEMIRTIPLER> items) : base(items) { }


            public ISEMIRTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISEMIRTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISEMIRTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISEMIRTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISEMIRTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISEMIRTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISEMIRTIPLER> Select
        {
            get { return R.Query<ISEMIRTIPLER>(); }
        }

        public static ISEMIRTIPLER SelectItem(Decimal ID)
        {
            return R.Query<ISEMIRTIPLER>().First(t => t.ID == ID);
        }

        public static List<ISEMIRTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISEMIRTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISEMIRTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISEMIRTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

