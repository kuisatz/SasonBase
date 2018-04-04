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
    public class KONTAKTELEFONTIPLER : SasonBase.Sason.Tables.Table_KONTAKTELEFONTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<KONTAKTELEFONTIPLER>
        {
            Dictionary<Decimal, KONTAKTELEFONTIPLER> dict = new Dictionary<Decimal, KONTAKTELEFONTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<KONTAKTELEFONTIPLER> items) : base(items) { }


            public KONTAKTELEFONTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public KONTAKTELEFONTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<KONTAKTELEFONTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<KONTAKTELEFONTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(KONTAKTELEFONTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(KONTAKTELEFONTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<KONTAKTELEFONTIPLER> Select
        {
            get { return R.Query<KONTAKTELEFONTIPLER>(); }
        }

        public static KONTAKTELEFONTIPLER SelectItem(Decimal ID)
        {
            return R.Query<KONTAKTELEFONTIPLER>().First(t => t.ID == ID);
        }

        public static List<KONTAKTELEFONTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<KONTAKTELEFONTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<KONTAKTELEFONTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<KONTAKTELEFONTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

