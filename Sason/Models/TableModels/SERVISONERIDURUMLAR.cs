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
    public class SERVISONERIDURUMLAR : SasonBase.Sason.Tables.Table_SERVISONERIDURUMLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISONERIDURUMLAR>
        {
            Dictionary<Decimal, SERVISONERIDURUMLAR> dict = new Dictionary<Decimal, SERVISONERIDURUMLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISONERIDURUMLAR> items) : base(items) { }


            public SERVISONERIDURUMLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISONERIDURUMLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISONERIDURUMLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISONERIDURUMLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISONERIDURUMLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISONERIDURUMLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISONERIDURUMLAR> Select
        {
            get { return R.Query<SERVISONERIDURUMLAR>(); }
        }

        public static SERVISONERIDURUMLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISONERIDURUMLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISONERIDURUMLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISONERIDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISONERIDURUMLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISONERIDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

