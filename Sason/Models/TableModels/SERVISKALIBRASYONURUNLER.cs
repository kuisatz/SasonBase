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
    public class SERVISKALIBRASYONURUNLER : SasonBase.Sason.Tables.Table_SERVISKALIBRASYONURUNLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISKALIBRASYONURUNLER>
        {
            Dictionary<Decimal, SERVISKALIBRASYONURUNLER> dict = new Dictionary<Decimal, SERVISKALIBRASYONURUNLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISKALIBRASYONURUNLER> items) : base(items) { }


            public SERVISKALIBRASYONURUNLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISKALIBRASYONURUNLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISKALIBRASYONURUNLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISKALIBRASYONURUNLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISKALIBRASYONURUNLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISKALIBRASYONURUNLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISKALIBRASYONURUNLER> Select
        {
            get { return R.Query<SERVISKALIBRASYONURUNLER>(); }
        }

        public static SERVISKALIBRASYONURUNLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISKALIBRASYONURUNLER>().First(t => t.ID == ID);
        }

        public static List<SERVISKALIBRASYONURUNLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISKALIBRASYONURUNLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISKALIBRASYONURUNLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISKALIBRASYONURUNLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

