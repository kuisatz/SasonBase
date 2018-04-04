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
    public class ARACNOTLAR : SasonBase.Sason.Tables.Table_ARACNOTLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ARACNOTLAR>
        {
            Dictionary<Decimal, ARACNOTLAR> dict = new Dictionary<Decimal, ARACNOTLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ARACNOTLAR> items) : base(items) { }


            public ARACNOTLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ARACNOTLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ARACNOTLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ARACNOTLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ARACNOTLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ARACNOTLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ARACNOTLAR> Select
        {
            get { return R.Query<ARACNOTLAR>(); }
        }

        public static ARACNOTLAR SelectItem(Decimal ID)
        {
            return R.Query<ARACNOTLAR>().First(t => t.ID == ID);
        }

        public static List<ARACNOTLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ARACNOTLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ARACNOTLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ARACNOTLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

