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
    public class ELBISEBEDENLER : SasonBase.Sason.Tables.Table_ELBISEBEDENLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ELBISEBEDENLER>
        {
            Dictionary<Decimal, ELBISEBEDENLER> dict = new Dictionary<Decimal, ELBISEBEDENLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ELBISEBEDENLER> items) : base(items) { }


            public ELBISEBEDENLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ELBISEBEDENLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ELBISEBEDENLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ELBISEBEDENLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ELBISEBEDENLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ELBISEBEDENLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ELBISEBEDENLER> Select
        {
            get { return R.Query<ELBISEBEDENLER>(); }
        }

        public static ELBISEBEDENLER SelectItem(Decimal ID)
        {
            return R.Query<ELBISEBEDENLER>().First(t => t.ID == ID);
        }

        public static List<ELBISEBEDENLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ELBISEBEDENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ELBISEBEDENLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ELBISEBEDENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

