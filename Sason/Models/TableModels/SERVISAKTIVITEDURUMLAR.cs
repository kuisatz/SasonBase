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
    public class SERVISAKTIVITEDURUMLAR : SasonBase.Sason.Tables.Table_SERVISAKTIVITEDURUMLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISAKTIVITEDURUMLAR>
        {
            Dictionary<Decimal, SERVISAKTIVITEDURUMLAR> dict = new Dictionary<Decimal, SERVISAKTIVITEDURUMLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISAKTIVITEDURUMLAR> items) : base(items) { }


            public SERVISAKTIVITEDURUMLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISAKTIVITEDURUMLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISAKTIVITEDURUMLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISAKTIVITEDURUMLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISAKTIVITEDURUMLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISAKTIVITEDURUMLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISAKTIVITEDURUMLAR> Select
        {
            get { return R.Query<SERVISAKTIVITEDURUMLAR>(); }
        }

        public static SERVISAKTIVITEDURUMLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISAKTIVITEDURUMLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISAKTIVITEDURUMLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISAKTIVITEDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISAKTIVITEDURUMLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISAKTIVITEDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

