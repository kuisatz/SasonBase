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
    public class BAKIMAGREGATIPOZELLIKLER : SasonBase.Sason.Tables.Table_BAKIMAGREGATIPOZELLIKLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMAGREGATIPOZELLIKLER>
        {
            Dictionary<Decimal, BAKIMAGREGATIPOZELLIKLER> dict = new Dictionary<Decimal, BAKIMAGREGATIPOZELLIKLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMAGREGATIPOZELLIKLER> items) : base(items) { }


            public BAKIMAGREGATIPOZELLIKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMAGREGATIPOZELLIKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMAGREGATIPOZELLIKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMAGREGATIPOZELLIKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMAGREGATIPOZELLIKLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMAGREGATIPOZELLIKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMAGREGATIPOZELLIKLER> Select
        {
            get { return R.Query<BAKIMAGREGATIPOZELLIKLER>(); }
        }

        public static BAKIMAGREGATIPOZELLIKLER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMAGREGATIPOZELLIKLER>().First(t => t.ID == ID);
        }

        public static List<BAKIMAGREGATIPOZELLIKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMAGREGATIPOZELLIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMAGREGATIPOZELLIKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMAGREGATIPOZELLIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

