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
    public class SERVISDEPOGRUPLAR : SasonBase.Sason.Tables.Table_SERVISDEPOGRUPLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISDEPOGRUPLAR>
        {
            Dictionary<Decimal, SERVISDEPOGRUPLAR> dict = new Dictionary<Decimal, SERVISDEPOGRUPLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISDEPOGRUPLAR> items) : base(items) { }


            public SERVISDEPOGRUPLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISDEPOGRUPLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISDEPOGRUPLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISDEPOGRUPLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISDEPOGRUPLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISDEPOGRUPLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISDEPOGRUPLAR> Select
        {
            get { return R.Query<SERVISDEPOGRUPLAR>(); }
        }

        public static SERVISDEPOGRUPLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISDEPOGRUPLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISDEPOGRUPLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISDEPOGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISDEPOGRUPLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISDEPOGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

