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
    public class AYRISTIRMATIPLER : SasonBase.Sason.Tables.Table_AYRISTIRMATIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<AYRISTIRMATIPLER>
        {
            Dictionary<Decimal, AYRISTIRMATIPLER> dict = new Dictionary<Decimal, AYRISTIRMATIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<AYRISTIRMATIPLER> items) : base(items) { }


            public AYRISTIRMATIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AYRISTIRMATIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AYRISTIRMATIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AYRISTIRMATIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(AYRISTIRMATIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AYRISTIRMATIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AYRISTIRMATIPLER> Select
        {
            get { return R.Query<AYRISTIRMATIPLER>(); }
        }

        public static AYRISTIRMATIPLER SelectItem(Decimal ID)
        {
            return R.Query<AYRISTIRMATIPLER>().First(t => t.ID == ID);
        }

        public static List<AYRISTIRMATIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AYRISTIRMATIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AYRISTIRMATIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AYRISTIRMATIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

