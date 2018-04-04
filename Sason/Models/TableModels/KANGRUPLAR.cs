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
    public class KANGRUPLAR : SasonBase.Sason.Tables.Table_KANGRUPLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<KANGRUPLAR>
        {
            Dictionary<Decimal, KANGRUPLAR> dict = new Dictionary<Decimal, KANGRUPLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<KANGRUPLAR> items) : base(items) { }


            public KANGRUPLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public KANGRUPLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<KANGRUPLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<KANGRUPLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(KANGRUPLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(KANGRUPLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<KANGRUPLAR> Select
        {
            get { return R.Query<KANGRUPLAR>(); }
        }

        public static KANGRUPLAR SelectItem(Decimal ID)
        {
            return R.Query<KANGRUPLAR>().First(t => t.ID == ID);
        }

        public static List<KANGRUPLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<KANGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<KANGRUPLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<KANGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

