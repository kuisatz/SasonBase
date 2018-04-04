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
    public class SERVISAKTIVITEARACLAR : SasonBase.Sason.Tables.Table_SERVISAKTIVITEARACLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISAKTIVITEARACLAR>
        {
            Dictionary<Decimal, SERVISAKTIVITEARACLAR> dict = new Dictionary<Decimal, SERVISAKTIVITEARACLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISAKTIVITEARACLAR> items) : base(items) { }


            public SERVISAKTIVITEARACLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISAKTIVITEARACLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISAKTIVITEARACLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISAKTIVITEARACLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISAKTIVITEARACLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISAKTIVITEARACLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISAKTIVITEARACLAR> Select
        {
            get { return R.Query<SERVISAKTIVITEARACLAR>(); }
        }

        public static SERVISAKTIVITEARACLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISAKTIVITEARACLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISAKTIVITEARACLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISAKTIVITEARACLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISAKTIVITEARACLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISAKTIVITEARACLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

