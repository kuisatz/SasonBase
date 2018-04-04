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
    public class SERVISSTOKSINIFLAR : SasonBase.Sason.Tables.Table_SERVISSTOKSINIFLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSTOKSINIFLAR>
        {
            Dictionary<Decimal, SERVISSTOKSINIFLAR> dict = new Dictionary<Decimal, SERVISSTOKSINIFLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSTOKSINIFLAR> items) : base(items) { }


            public SERVISSTOKSINIFLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSTOKSINIFLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSTOKSINIFLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSTOKSINIFLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSTOKSINIFLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSTOKSINIFLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSTOKSINIFLAR> Select
        {
            get { return R.Query<SERVISSTOKSINIFLAR>(); }
        }

        public static SERVISSTOKSINIFLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISSTOKSINIFLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISSTOKSINIFLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSTOKSINIFLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSTOKSINIFLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSTOKSINIFLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

