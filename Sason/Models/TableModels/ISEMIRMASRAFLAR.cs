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
    public class ISEMIRMASRAFLAR : SasonBase.Sason.Tables.Table_ISEMIRMASRAFLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISEMIRMASRAFLAR>
        {
            Dictionary<Decimal, ISEMIRMASRAFLAR> dict = new Dictionary<Decimal, ISEMIRMASRAFLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISEMIRMASRAFLAR> items) : base(items) { }


            public ISEMIRMASRAFLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISEMIRMASRAFLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISEMIRMASRAFLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISEMIRMASRAFLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISEMIRMASRAFLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISEMIRMASRAFLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISEMIRMASRAFLAR> Select
        {
            get { return R.Query<ISEMIRMASRAFLAR>(); }
        }

        public static ISEMIRMASRAFLAR SelectItem(Decimal ID)
        {
            return R.Query<ISEMIRMASRAFLAR>().First(t => t.ID == ID);
        }

        public static List<ISEMIRMASRAFLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISEMIRMASRAFLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISEMIRMASRAFLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISEMIRMASRAFLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

