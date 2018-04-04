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
    public class ENVANTERPERIYODLAR : SasonBase.Sason.Tables.Table_ENVANTERPERIYODLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ENVANTERPERIYODLAR>
        {
            Dictionary<Decimal, ENVANTERPERIYODLAR> dict = new Dictionary<Decimal, ENVANTERPERIYODLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ENVANTERPERIYODLAR> items) : base(items) { }


            public ENVANTERPERIYODLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ENVANTERPERIYODLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ENVANTERPERIYODLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ENVANTERPERIYODLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ENVANTERPERIYODLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ENVANTERPERIYODLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ENVANTERPERIYODLAR> Select
        {
            get { return R.Query<ENVANTERPERIYODLAR>(); }
        }

        public static ENVANTERPERIYODLAR SelectItem(Decimal ID)
        {
            return R.Query<ENVANTERPERIYODLAR>().First(t => t.ID == ID);
        }

        public static List<ENVANTERPERIYODLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ENVANTERPERIYODLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ENVANTERPERIYODLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ENVANTERPERIYODLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

