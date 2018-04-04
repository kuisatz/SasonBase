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
    public class SERVISEKSISLEMISCILIKLER : SasonBase.Sason.Tables.Table_SERVISEKSISLEMISCILIKLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISEKSISLEMISCILIKLER>
        {
            Dictionary<Decimal, SERVISEKSISLEMISCILIKLER> dict = new Dictionary<Decimal, SERVISEKSISLEMISCILIKLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISEKSISLEMISCILIKLER> items) : base(items) { }


            public SERVISEKSISLEMISCILIKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISEKSISLEMISCILIKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISEKSISLEMISCILIKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISEKSISLEMISCILIKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISEKSISLEMISCILIKLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISEKSISLEMISCILIKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISEKSISLEMISCILIKLER> Select
        {
            get { return R.Query<SERVISEKSISLEMISCILIKLER>(); }
        }

        public static SERVISEKSISLEMISCILIKLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISEKSISLEMISCILIKLER>().First(t => t.ID == ID);
        }

        public static List<SERVISEKSISLEMISCILIKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISEKSISLEMISCILIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISEKSISLEMISCILIKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISEKSISLEMISCILIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

