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
    public class SERVISSTOKHAREKETDETAYLAR : SasonBase.Sason.Tables.Table_SERVISSTOKHAREKETDETAYLAR.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSTOKHAREKETDETAYLAR>
        {
            Dictionary<Decimal, SERVISSTOKHAREKETDETAYLAR> dict = new Dictionary<Decimal, SERVISSTOKHAREKETDETAYLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSTOKHAREKETDETAYLAR> items) : base(items) { }


            public SERVISSTOKHAREKETDETAYLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSTOKHAREKETDETAYLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSTOKHAREKETDETAYLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSTOKHAREKETDETAYLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSTOKHAREKETDETAYLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSTOKHAREKETDETAYLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSTOKHAREKETDETAYLAR> Select
        {
            get { return R.Query<SERVISSTOKHAREKETDETAYLAR>(); }
        }

        public static SERVISSTOKHAREKETDETAYLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISSTOKHAREKETDETAYLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISSTOKHAREKETDETAYLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSTOKHAREKETDETAYLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSTOKHAREKETDETAYLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSTOKHAREKETDETAYLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        //public static List<SERVISSTOKHAREKETDETAYLAR> SelectFromHareketler(IEnumerable<SERVISSTOKHAREKETLER> hareketler, MethodReturn refMr)
        //{
        //    return Antibiotic.Database._Helpers.ItemHelpers.SelectItemsFromFieldInValues(typeof(SERVISSTOKHAREKETDETAYLAR), "SERVISSTOKHAREKETID", hareketler.select(t=> t.ID).toList<object>(), refMr).toList<SERVISSTOKHAREKETDETAYLAR>();
        //}
    }
}