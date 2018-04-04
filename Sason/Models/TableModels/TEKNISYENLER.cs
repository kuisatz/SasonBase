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
    public class TEKNISYENLER : SasonBase.Sason.Tables.Table_TEKNISYENLER.PublicItem
    {




        public class CONTAINER : Antibiotic.Collections.ListContainer<TEKNISYENLER>
        {
            Dictionary<Decimal, TEKNISYENLER> dict = new Dictionary<Decimal, TEKNISYENLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<TEKNISYENLER> items) : base(items) { }


            public TEKNISYENLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public TEKNISYENLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<TEKNISYENLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<TEKNISYENLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(TEKNISYENLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(TEKNISYENLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<TEKNISYENLER> Select
        {
            get { return R.Query<TEKNISYENLER>(); }
        }

        public static TEKNISYENLER SelectItem(Decimal ID)
        {
            return R.Query<TEKNISYENLER>().First(t => t.ID == ID);
        }

        public static List<TEKNISYENLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<TEKNISYENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<TEKNISYENLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<TEKNISYENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

