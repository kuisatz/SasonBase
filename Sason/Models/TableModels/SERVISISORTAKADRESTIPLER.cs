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
    public class SERVISISORTAKADRESTIPLER : SasonBase.Sason.Tables.Table_SERVISISORTAKADRESTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISORTAKADRESTIPLER>
        {
            Dictionary<Decimal, SERVISISORTAKADRESTIPLER> dict = new Dictionary<Decimal, SERVISISORTAKADRESTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISORTAKADRESTIPLER> items) : base(items) { }


            public SERVISISORTAKADRESTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISORTAKADRESTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISORTAKADRESTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISORTAKADRESTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISORTAKADRESTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISORTAKADRESTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISORTAKADRESTIPLER> Select
        {
            get { return R.Query<SERVISISORTAKADRESTIPLER>(); }
        }

        public static SERVISISORTAKADRESTIPLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISISORTAKADRESTIPLER>().First(t => t.ID == ID);
        }

        public static List<SERVISISORTAKADRESTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISORTAKADRESTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISORTAKADRESTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISORTAKADRESTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

