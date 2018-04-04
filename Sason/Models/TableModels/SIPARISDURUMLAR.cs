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
    public class SIPARISDURUMLAR : SasonBase.Sason.Tables.Table_SIPARISDURUMLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SIPARISDURUMLAR>
        {
            Dictionary<Decimal, SIPARISDURUMLAR> dict = new Dictionary<Decimal, SIPARISDURUMLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SIPARISDURUMLAR> items) : base(items) { }


            public SIPARISDURUMLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SIPARISDURUMLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SIPARISDURUMLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SIPARISDURUMLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SIPARISDURUMLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SIPARISDURUMLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SIPARISDURUMLAR> Select
        {
            get { return R.Query<SIPARISDURUMLAR>(); }
        }

        public static SIPARISDURUMLAR SelectItem(Decimal ID)
        {
            return R.Query<SIPARISDURUMLAR>().First(t => t.ID == ID);
        }

        public static List<SIPARISDURUMLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SIPARISDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SIPARISDURUMLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SIPARISDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

