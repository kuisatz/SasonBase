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
    public class ISCILIKARACVARYANTLAR : SasonBase.Sason.Tables.Table_ISCILIKARACVARYANTLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISCILIKARACVARYANTLAR>
        {
            Dictionary<Decimal, ISCILIKARACVARYANTLAR> dict = new Dictionary<Decimal, ISCILIKARACVARYANTLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISCILIKARACVARYANTLAR> items) : base(items) { }


            public ISCILIKARACVARYANTLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISCILIKARACVARYANTLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISCILIKARACVARYANTLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISCILIKARACVARYANTLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISCILIKARACVARYANTLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISCILIKARACVARYANTLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISCILIKARACVARYANTLAR> Select
        {
            get { return R.Query<ISCILIKARACVARYANTLAR>(); }
        }

        public static ISCILIKARACVARYANTLAR SelectItem(Decimal ID)
        {
            return R.Query<ISCILIKARACVARYANTLAR>().First(t => t.ID == ID);
        }

        public static List<ISCILIKARACVARYANTLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISCILIKARACVARYANTLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISCILIKARACVARYANTLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISCILIKARACVARYANTLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

