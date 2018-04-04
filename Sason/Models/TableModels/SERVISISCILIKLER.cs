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
    public class SERVISISCILIKLER : SasonBase.Sason.Tables.Table_SERVISISCILIKLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISCILIKLER>
        {
            Dictionary<Decimal, SERVISISCILIKLER> dict = new Dictionary<Decimal, SERVISISCILIKLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISCILIKLER> items) : base(items) { }


            public SERVISISCILIKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISCILIKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISCILIKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISCILIKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISCILIKLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISCILIKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISCILIKLER> Select
        {
            get { return R.Query<SERVISISCILIKLER>(); }
        }

        public static SERVISISCILIKLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISISCILIKLER>().First(t => t.ID == ID);
        }

        public static List<SERVISISCILIKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISCILIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISCILIKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISCILIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

