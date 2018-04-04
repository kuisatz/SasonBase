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
    public class MUSTERILER : SasonBase.Sason.Tables.Table_MUSTERILER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<MUSTERILER>
        {
            Dictionary<Decimal, MUSTERILER> dict = new Dictionary<Decimal, MUSTERILER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<MUSTERILER> items) : base(items) { }


            public MUSTERILER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public MUSTERILER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MUSTERILER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MUSTERILER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(MUSTERILER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(MUSTERILER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<MUSTERILER> Select
        {
            get { return R.Query<MUSTERILER>(); }
        }

        public static MUSTERILER SelectItem(Decimal ID)
        {
            return R.Query<MUSTERILER>().First(t => t.ID == ID);
        }

        public static List<MUSTERILER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MUSTERILER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MUSTERILER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MUSTERILER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

