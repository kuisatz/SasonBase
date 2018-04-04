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
    public class SERVISEKSISLEMDKALEMLER : SasonBase.Sason.Tables.Table_SERVISEKSISLEMDKALEMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISEKSISLEMDKALEMLER>
        {
            Dictionary<Decimal, SERVISEKSISLEMDKALEMLER> dict = new Dictionary<Decimal, SERVISEKSISLEMDKALEMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISEKSISLEMDKALEMLER> items) : base(items) { }


            public SERVISEKSISLEMDKALEMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISEKSISLEMDKALEMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISEKSISLEMDKALEMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISEKSISLEMDKALEMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISEKSISLEMDKALEMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISEKSISLEMDKALEMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISEKSISLEMDKALEMLER> Select
        {
            get { return R.Query<SERVISEKSISLEMDKALEMLER>(); }
        }

        public static SERVISEKSISLEMDKALEMLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISEKSISLEMDKALEMLER>().First(t => t.ID == ID);
        }

        public static List<SERVISEKSISLEMDKALEMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISEKSISLEMDKALEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISEKSISLEMDKALEMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISEKSISLEMDKALEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

