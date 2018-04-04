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
    public class ESAONARIMLAR : SasonBase.Sason.Tables.Table_ESAONARIMLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ESAONARIMLAR>
        {
            Dictionary<Decimal, ESAONARIMLAR> dict = new Dictionary<Decimal, ESAONARIMLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ESAONARIMLAR> items) : base(items) { }


            public ESAONARIMLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ESAONARIMLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ESAONARIMLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ESAONARIMLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ESAONARIMLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ESAONARIMLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ESAONARIMLAR> Select
        {
            get { return R.Query<ESAONARIMLAR>(); }
        }

        public static ESAONARIMLAR SelectItem(Decimal ID)
        {
            return R.Query<ESAONARIMLAR>().First(t => t.ID == ID);
        }

        public static List<ESAONARIMLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ESAONARIMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ESAONARIMLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ESAONARIMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

