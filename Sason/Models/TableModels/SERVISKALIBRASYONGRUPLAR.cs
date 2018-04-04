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
    public class SERVISKALIBRASYONGRUPLAR : SasonBase.Sason.Tables.Table_SERVISKALIBRASYONGRUPLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISKALIBRASYONGRUPLAR>
        {
            Dictionary<Decimal, SERVISKALIBRASYONGRUPLAR> dict = new Dictionary<Decimal, SERVISKALIBRASYONGRUPLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISKALIBRASYONGRUPLAR> items) : base(items) { }


            public SERVISKALIBRASYONGRUPLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISKALIBRASYONGRUPLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISKALIBRASYONGRUPLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISKALIBRASYONGRUPLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISKALIBRASYONGRUPLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISKALIBRASYONGRUPLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISKALIBRASYONGRUPLAR> Select
        {
            get { return R.Query<SERVISKALIBRASYONGRUPLAR>(); }
        }

        public static SERVISKALIBRASYONGRUPLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISKALIBRASYONGRUPLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISKALIBRASYONGRUPLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISKALIBRASYONGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISKALIBRASYONGRUPLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISKALIBRASYONGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

