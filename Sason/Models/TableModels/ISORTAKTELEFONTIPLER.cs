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
    public class ISORTAKTELEFONTIPLER : SasonBase.Sason.Tables.Table_ISORTAKTELEFONTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISORTAKTELEFONTIPLER>
        {
            Dictionary<Decimal, ISORTAKTELEFONTIPLER> dict = new Dictionary<Decimal, ISORTAKTELEFONTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISORTAKTELEFONTIPLER> items) : base(items) { }


            public ISORTAKTELEFONTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISORTAKTELEFONTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISORTAKTELEFONTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISORTAKTELEFONTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISORTAKTELEFONTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISORTAKTELEFONTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISORTAKTELEFONTIPLER> Select
        {
            get { return R.Query<ISORTAKTELEFONTIPLER>(); }
        }

        public static ISORTAKTELEFONTIPLER SelectItem(Decimal ID)
        {
            return R.Query<ISORTAKTELEFONTIPLER>().First(t => t.ID == ID);
        }

        public static List<ISORTAKTELEFONTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISORTAKTELEFONTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISORTAKTELEFONTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISORTAKTELEFONTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

