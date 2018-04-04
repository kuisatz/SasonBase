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
    public class SERVISLER : SasonBase.Sason.Tables.Table_SERVISLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISLER>
        {
            Dictionary<Decimal, SERVISLER> dict = new Dictionary<Decimal, SERVISLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISLER> items) : base(items) { }


            public SERVISLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISLER> Select
        {
            get { return R.Query<SERVISLER>(); }
        }

        public static SERVISLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISLER>().First(t => t.ID == ID);
        }

        public static List<SERVISLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

