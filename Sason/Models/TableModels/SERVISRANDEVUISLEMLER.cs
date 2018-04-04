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
    public class SERVISRANDEVUISLEMLER : SasonBase.Sason.Tables.Table_SERVISRANDEVUISLEMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISRANDEVUISLEMLER>
        {
            Dictionary<Decimal, SERVISRANDEVUISLEMLER> dict = new Dictionary<Decimal, SERVISRANDEVUISLEMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISRANDEVUISLEMLER> items) : base(items) { }


            public SERVISRANDEVUISLEMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISRANDEVUISLEMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISRANDEVUISLEMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISRANDEVUISLEMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISRANDEVUISLEMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISRANDEVUISLEMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISRANDEVUISLEMLER> Select
        {
            get { return R.Query<SERVISRANDEVUISLEMLER>(); }
        }

        public static SERVISRANDEVUISLEMLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISRANDEVUISLEMLER>().First(t => t.ID == ID);
        }

        public static List<SERVISRANDEVUISLEMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISRANDEVUISLEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISRANDEVUISLEMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISRANDEVUISLEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

