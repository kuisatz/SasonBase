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
    public class ISORTAKADRESTIPLER : SasonBase.Sason.Tables.Table_ISORTAKADRESTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISORTAKADRESTIPLER>
        {
            Dictionary<Decimal, ISORTAKADRESTIPLER> dict = new Dictionary<Decimal, ISORTAKADRESTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISORTAKADRESTIPLER> items) : base(items) { }


            public ISORTAKADRESTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISORTAKADRESTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISORTAKADRESTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISORTAKADRESTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISORTAKADRESTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISORTAKADRESTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISORTAKADRESTIPLER> Select
        {
            get { return R.Query<ISORTAKADRESTIPLER>(); }
        }

        public static ISORTAKADRESTIPLER SelectItem(Decimal ID)
        {
            return R.Query<ISORTAKADRESTIPLER>().First(t => t.ID == ID);
        }

        public static List<ISORTAKADRESTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISORTAKADRESTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISORTAKADRESTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISORTAKADRESTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

