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
    public class BAKIMGRUPKONTROLLER : SasonBase.Sason.Tables.Table_BAKIMGRUPKONTROLLER.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMGRUPKONTROLLER>
        {
            Dictionary<Decimal, BAKIMGRUPKONTROLLER> dict = new Dictionary<Decimal, BAKIMGRUPKONTROLLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMGRUPKONTROLLER> items) : base(items) { }


            public BAKIMGRUPKONTROLLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMGRUPKONTROLLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMGRUPKONTROLLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMGRUPKONTROLLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMGRUPKONTROLLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMGRUPKONTROLLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMGRUPKONTROLLER> Select
        {
            get { return R.Query<BAKIMGRUPKONTROLLER>(); }
        }

        public static BAKIMGRUPKONTROLLER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMGRUPKONTROLLER>().First(t => t.ID == ID);
        }

        public static List<BAKIMGRUPKONTROLLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMGRUPKONTROLLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMGRUPKONTROLLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMGRUPKONTROLLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

