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
    public class TEKNISYENUZMANLIKALANLAR : SasonBase.Sason.Tables.Table_TEKNISYENUZMANLIKALANLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<TEKNISYENUZMANLIKALANLAR>
        {
            Dictionary<Decimal, TEKNISYENUZMANLIKALANLAR> dict = new Dictionary<Decimal, TEKNISYENUZMANLIKALANLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<TEKNISYENUZMANLIKALANLAR> items) : base(items) { }


            public TEKNISYENUZMANLIKALANLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public TEKNISYENUZMANLIKALANLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<TEKNISYENUZMANLIKALANLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<TEKNISYENUZMANLIKALANLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(TEKNISYENUZMANLIKALANLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(TEKNISYENUZMANLIKALANLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<TEKNISYENUZMANLIKALANLAR> Select
        {
            get { return R.Query<TEKNISYENUZMANLIKALANLAR>(); }
        }

        public static TEKNISYENUZMANLIKALANLAR SelectItem(Decimal ID)
        {
            return R.Query<TEKNISYENUZMANLIKALANLAR>().First(t => t.ID == ID);
        }

        public static List<TEKNISYENUZMANLIKALANLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<TEKNISYENUZMANLIKALANLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<TEKNISYENUZMANLIKALANLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<TEKNISYENUZMANLIKALANLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

