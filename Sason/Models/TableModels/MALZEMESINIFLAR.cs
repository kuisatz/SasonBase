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
    public class MALZEMESINIFLAR : SasonBase.Sason.Tables.Table_MALZEMESINIFLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<MALZEMESINIFLAR>
        {
            Dictionary<Decimal, MALZEMESINIFLAR> dict = new Dictionary<Decimal, MALZEMESINIFLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<MALZEMESINIFLAR> items) : base(items) { }


            public MALZEMESINIFLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public MALZEMESINIFLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MALZEMESINIFLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MALZEMESINIFLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(MALZEMESINIFLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(MALZEMESINIFLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<MALZEMESINIFLAR> Select
        {
            get { return R.Query<MALZEMESINIFLAR>(); }
        }

        public static MALZEMESINIFLAR SelectItem(Decimal ID)
        {
            return R.Query<MALZEMESINIFLAR>().First(t => t.ID == ID);
        }

        public static List<MALZEMESINIFLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MALZEMESINIFLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MALZEMESINIFLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MALZEMESINIFLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

