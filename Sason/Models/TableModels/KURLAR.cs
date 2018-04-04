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
    public class KURLAR : SasonBase.Sason.Tables.Table_KURLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<KURLAR>
        {
            Dictionary<Decimal, KURLAR> dict = new Dictionary<Decimal, KURLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<KURLAR> items) : base(items) { }


            public KURLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public KURLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<KURLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<KURLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(KURLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(KURLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<KURLAR> Select
        {
            get { return R.Query<KURLAR>(); }
        }

        public static KURLAR SelectItem(Decimal ID)
        {
            return R.Query<KURLAR>().First(t => t.ID == ID);
        }

        public static List<KURLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<KURLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<KURLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<KURLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

