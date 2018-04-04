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
    public class SERVISISORTAKTELEFONTIPLER : SasonBase.Sason.Tables.Table_SERVISISORTAKTELEFONTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISORTAKTELEFONTIPLER>
        {
            Dictionary<Decimal, SERVISISORTAKTELEFONTIPLER> dict = new Dictionary<Decimal, SERVISISORTAKTELEFONTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISORTAKTELEFONTIPLER> items) : base(items) { }


            public SERVISISORTAKTELEFONTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISORTAKTELEFONTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISORTAKTELEFONTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISORTAKTELEFONTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISORTAKTELEFONTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISORTAKTELEFONTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISORTAKTELEFONTIPLER> Select
        {
            get { return R.Query<SERVISISORTAKTELEFONTIPLER>(); }
        }

        public static SERVISISORTAKTELEFONTIPLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISISORTAKTELEFONTIPLER>().First(t => t.ID == ID);
        }

        public static List<SERVISISORTAKTELEFONTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISORTAKTELEFONTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISORTAKTELEFONTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISORTAKTELEFONTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

