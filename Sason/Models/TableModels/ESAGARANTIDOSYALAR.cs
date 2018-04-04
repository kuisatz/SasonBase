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
    public class ESAGARANTIDOSYALAR : SasonBase.Sason.Tables.Table_ESAGARANTIDOSYALAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ESAGARANTIDOSYALAR>
        {
            Dictionary<Decimal, ESAGARANTIDOSYALAR> dict = new Dictionary<Decimal, ESAGARANTIDOSYALAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ESAGARANTIDOSYALAR> items) : base(items) { }


            public ESAGARANTIDOSYALAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ESAGARANTIDOSYALAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ESAGARANTIDOSYALAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ESAGARANTIDOSYALAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ESAGARANTIDOSYALAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ESAGARANTIDOSYALAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ESAGARANTIDOSYALAR> Select
        {
            get { return R.Query<ESAGARANTIDOSYALAR>(); }
        }

        public static ESAGARANTIDOSYALAR SelectItem(Decimal ID)
        {
            return R.Query<ESAGARANTIDOSYALAR>().First(t => t.ID == ID);
        }

        public static List<ESAGARANTIDOSYALAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ESAGARANTIDOSYALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ESAGARANTIDOSYALAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ESAGARANTIDOSYALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

