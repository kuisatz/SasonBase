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
    public class ARACURETICILER : SasonBase.Sason.Tables.Table_ARACURETICILER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ARACURETICILER>
        {
            Dictionary<Decimal, ARACURETICILER> dict = new Dictionary<Decimal, ARACURETICILER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ARACURETICILER> items) : base(items) { }


            public ARACURETICILER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ARACURETICILER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ARACURETICILER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ARACURETICILER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ARACURETICILER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ARACURETICILER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ARACURETICILER> Select
        {
            get { return R.Query<ARACURETICILER>(); }
        }

        public static ARACURETICILER SelectItem(Decimal ID)
        {
            return R.Query<ARACURETICILER>().First(t => t.ID == ID);
        }

        public static List<ARACURETICILER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ARACURETICILER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ARACURETICILER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ARACURETICILER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

