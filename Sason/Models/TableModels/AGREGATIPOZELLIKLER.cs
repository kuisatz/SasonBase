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
    public class AGREGATIPOZELLIKLER : SasonBase.Sason.Tables.Table_AGREGATIPOZELLIKLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<AGREGATIPOZELLIKLER>
        {
            Dictionary<Decimal, AGREGATIPOZELLIKLER> dict = new Dictionary<Decimal, AGREGATIPOZELLIKLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<AGREGATIPOZELLIKLER> items) : base(items) { }


            public AGREGATIPOZELLIKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AGREGATIPOZELLIKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AGREGATIPOZELLIKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AGREGATIPOZELLIKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(AGREGATIPOZELLIKLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AGREGATIPOZELLIKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AGREGATIPOZELLIKLER> Select
        {
            get { return R.Query<AGREGATIPOZELLIKLER>(); }
        }

        public static AGREGATIPOZELLIKLER SelectItem(Decimal ID)
        {
            return R.Query<AGREGATIPOZELLIKLER>().First(t => t.ID == ID);
        }

        public static List<AGREGATIPOZELLIKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AGREGATIPOZELLIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AGREGATIPOZELLIKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AGREGATIPOZELLIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

