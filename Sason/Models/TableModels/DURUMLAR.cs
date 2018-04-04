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
    public class DURUMLAR : SasonBase.Sason.Tables.Table_DURUMLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<DURUMLAR>
        {
            Dictionary<Decimal, DURUMLAR> dict = new Dictionary<Decimal, DURUMLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<DURUMLAR> items) : base(items) { }


            public DURUMLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public DURUMLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<DURUMLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<DURUMLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(DURUMLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(DURUMLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<DURUMLAR> Select
        {
            get { return R.Query<DURUMLAR>(); }
        }

        public static DURUMLAR SelectItem(Decimal ID)
        {
            return R.Query<DURUMLAR>().First(t => t.ID == ID);
        }

        public static List<DURUMLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<DURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<DURUMLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<DURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

