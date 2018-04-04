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
    public class SERVISKALIBRASYONLAR : SasonBase.Sason.Tables.Table_SERVISKALIBRASYONLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISKALIBRASYONLAR>
        {
            Dictionary<Decimal, SERVISKALIBRASYONLAR> dict = new Dictionary<Decimal, SERVISKALIBRASYONLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISKALIBRASYONLAR> items) : base(items) { }


            public SERVISKALIBRASYONLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISKALIBRASYONLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISKALIBRASYONLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISKALIBRASYONLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISKALIBRASYONLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISKALIBRASYONLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISKALIBRASYONLAR> Select
        {
            get { return R.Query<SERVISKALIBRASYONLAR>(); }
        }

        public static SERVISKALIBRASYONLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISKALIBRASYONLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISKALIBRASYONLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISKALIBRASYONLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISKALIBRASYONLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISKALIBRASYONLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

