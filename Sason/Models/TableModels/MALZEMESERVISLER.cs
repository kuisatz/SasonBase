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
    public class MALZEMESERVISLER : SasonBase.Sason.Tables.Table_MALZEMESERVISLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<MALZEMESERVISLER>
        {
            Dictionary<Decimal, MALZEMESERVISLER> dict = new Dictionary<Decimal, MALZEMESERVISLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<MALZEMESERVISLER> items) : base(items) { }


            public MALZEMESERVISLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public MALZEMESERVISLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MALZEMESERVISLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MALZEMESERVISLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(MALZEMESERVISLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(MALZEMESERVISLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<MALZEMESERVISLER> Select
        {
            get { return R.Query<MALZEMESERVISLER>(); }
        }

        public static MALZEMESERVISLER SelectItem(Decimal ID)
        {
            return R.Query<MALZEMESERVISLER>().First(t => t.ID == ID);
        }

        public static List<MALZEMESERVISLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MALZEMESERVISLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MALZEMESERVISLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MALZEMESERVISLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

