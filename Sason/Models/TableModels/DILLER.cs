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
    public class DILLER : SasonBase.Sason.Tables.Table_DILLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<DILLER>
        {
            Dictionary<Decimal, DILLER> dict = new Dictionary<Decimal, DILLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<DILLER> items) : base(items) { }


            public DILLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public DILLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<DILLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<DILLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(DILLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(DILLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<DILLER> Select
        {
            get { return R.Query<DILLER>(); }
        }

        public static DILLER SelectItem(Decimal ID)
        {
            return R.Query<DILLER>().First(t => t.ID == ID);
        }

        public static List<DILLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<DILLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<DILLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<DILLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

