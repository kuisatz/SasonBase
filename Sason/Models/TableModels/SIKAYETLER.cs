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
    public class SIKAYETLER : SasonBase.Sason.Tables.Table_SIKAYETLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SIKAYETLER>
        {
            Dictionary<Decimal, SIKAYETLER> dict = new Dictionary<Decimal, SIKAYETLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SIKAYETLER> items) : base(items) { }


            public SIKAYETLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SIKAYETLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SIKAYETLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SIKAYETLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SIKAYETLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SIKAYETLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SIKAYETLER> Select
        {
            get { return R.Query<SIKAYETLER>(); }
        }

        public static SIKAYETLER SelectItem(Decimal ID)
        {
            return R.Query<SIKAYETLER>().First(t => t.ID == ID);
        }

        public static List<SIKAYETLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SIKAYETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SIKAYETLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SIKAYETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

