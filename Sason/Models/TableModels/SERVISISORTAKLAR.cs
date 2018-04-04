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
    public class SERVISISORTAKLAR : SasonBase.Sason.Tables.Table_SERVISISORTAKLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISORTAKLAR>
        {
            Dictionary<Decimal, SERVISISORTAKLAR> dict = new Dictionary<Decimal, SERVISISORTAKLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISORTAKLAR> items) : base(items) { }


            public SERVISISORTAKLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISORTAKLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISORTAKLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISORTAKLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISORTAKLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISORTAKLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISORTAKLAR> Select
        {
            get { return R.Query<SERVISISORTAKLAR>(); }
        }

        public static SERVISISORTAKLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISISORTAKLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISISORTAKLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISORTAKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISORTAKLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISORTAKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

