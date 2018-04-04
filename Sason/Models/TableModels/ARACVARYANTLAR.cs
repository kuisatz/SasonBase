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
    public class ARACVARYANTLAR : SasonBase.Sason.Tables.Table_ARACVARYANTLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ARACVARYANTLAR>
        {
            Dictionary<Decimal, ARACVARYANTLAR> dict = new Dictionary<Decimal, ARACVARYANTLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ARACVARYANTLAR> items) : base(items) { }


            public ARACVARYANTLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ARACVARYANTLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ARACVARYANTLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ARACVARYANTLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ARACVARYANTLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ARACVARYANTLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ARACVARYANTLAR> Select
        {
            get { return R.Query<ARACVARYANTLAR>(); }
        }

        public static ARACVARYANTLAR SelectItem(Decimal ID)
        {
            return R.Query<ARACVARYANTLAR>().First(t => t.ID == ID);
        }

        public static List<ARACVARYANTLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ARACVARYANTLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ARACVARYANTLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ARACVARYANTLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

