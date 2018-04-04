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
    public class WEBADRESTIPLER : SasonBase.Sason.Tables.Table_WEBADRESTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<WEBADRESTIPLER>
        {
            Dictionary<Decimal, WEBADRESTIPLER> dict = new Dictionary<Decimal, WEBADRESTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<WEBADRESTIPLER> items) : base(items) { }


            public WEBADRESTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public WEBADRESTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<WEBADRESTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<WEBADRESTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(WEBADRESTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(WEBADRESTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<WEBADRESTIPLER> Select
        {
            get { return R.Query<WEBADRESTIPLER>(); }
        }

        public static WEBADRESTIPLER SelectItem(Decimal ID)
        {
            return R.Query<WEBADRESTIPLER>().First(t => t.ID == ID);
        }

        public static List<WEBADRESTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<WEBADRESTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<WEBADRESTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<WEBADRESTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

