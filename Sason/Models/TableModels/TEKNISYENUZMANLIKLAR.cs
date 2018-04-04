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
    public class TEKNISYENUZMANLIKLAR : SasonBase.Sason.Tables.Table_TEKNISYENUZMANLIKLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<TEKNISYENUZMANLIKLAR>
        {
            Dictionary<Decimal, TEKNISYENUZMANLIKLAR> dict = new Dictionary<Decimal, TEKNISYENUZMANLIKLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<TEKNISYENUZMANLIKLAR> items) : base(items) { }


            public TEKNISYENUZMANLIKLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public TEKNISYENUZMANLIKLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<TEKNISYENUZMANLIKLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<TEKNISYENUZMANLIKLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(TEKNISYENUZMANLIKLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(TEKNISYENUZMANLIKLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<TEKNISYENUZMANLIKLAR> Select
        {
            get { return R.Query<TEKNISYENUZMANLIKLAR>(); }
        }

        public static TEKNISYENUZMANLIKLAR SelectItem(Decimal ID)
        {
            return R.Query<TEKNISYENUZMANLIKLAR>().First(t => t.ID == ID);
        }

        public static List<TEKNISYENUZMANLIKLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<TEKNISYENUZMANLIKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<TEKNISYENUZMANLIKLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<TEKNISYENUZMANLIKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

