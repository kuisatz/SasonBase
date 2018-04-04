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
    public class MALZEMEALISAMACLAR : SasonBase.Sason.Tables.Table_MALZEMEALISAMACLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<MALZEMEALISAMACLAR>
        {
            Dictionary<Decimal, MALZEMEALISAMACLAR> dict = new Dictionary<Decimal, MALZEMEALISAMACLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<MALZEMEALISAMACLAR> items) : base(items) { }


            public MALZEMEALISAMACLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public MALZEMEALISAMACLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MALZEMEALISAMACLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MALZEMEALISAMACLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(MALZEMEALISAMACLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(MALZEMEALISAMACLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<MALZEMEALISAMACLAR> Select
        {
            get { return R.Query<MALZEMEALISAMACLAR>(); }
        }

        public static MALZEMEALISAMACLAR SelectItem(Decimal ID)
        {
            return R.Query<MALZEMEALISAMACLAR>().First(t => t.ID == ID);
        }

        public static List<MALZEMEALISAMACLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MALZEMEALISAMACLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MALZEMEALISAMACLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MALZEMEALISAMACLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

