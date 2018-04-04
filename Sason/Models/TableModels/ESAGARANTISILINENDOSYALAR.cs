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
    public class ESAGARANTISILINENDOSYALAR : SasonBase.Sason.Tables.Table_ESAGARANTISILINENDOSYALAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ESAGARANTISILINENDOSYALAR>
        {
            Dictionary<Decimal, ESAGARANTISILINENDOSYALAR> dict = new Dictionary<Decimal, ESAGARANTISILINENDOSYALAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ESAGARANTISILINENDOSYALAR> items) : base(items) { }


            public ESAGARANTISILINENDOSYALAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ESAGARANTISILINENDOSYALAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ESAGARANTISILINENDOSYALAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ESAGARANTISILINENDOSYALAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ESAGARANTISILINENDOSYALAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ESAGARANTISILINENDOSYALAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ESAGARANTISILINENDOSYALAR> Select
        {
            get { return R.Query<ESAGARANTISILINENDOSYALAR>(); }
        }

        public static ESAGARANTISILINENDOSYALAR SelectItem(Decimal ID)
        {
            return R.Query<ESAGARANTISILINENDOSYALAR>().First(t => t.ID == ID);
        }

        public static List<ESAGARANTISILINENDOSYALAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ESAGARANTISILINENDOSYALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ESAGARANTISILINENDOSYALAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ESAGARANTISILINENDOSYALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

