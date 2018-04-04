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
    public class AYRISTIRMALAR : SasonBase.Sason.Tables.Table_AYRISTIRMALAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<AYRISTIRMALAR>
        {
            Dictionary<Decimal, AYRISTIRMALAR> dict = new Dictionary<Decimal, AYRISTIRMALAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<AYRISTIRMALAR> items) : base(items) { }


            public AYRISTIRMALAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AYRISTIRMALAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AYRISTIRMALAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AYRISTIRMALAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(AYRISTIRMALAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AYRISTIRMALAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AYRISTIRMALAR> Select
        {
            get { return R.Query<AYRISTIRMALAR>(); }
        }

        public static AYRISTIRMALAR SelectItem(Decimal ID)
        {
            return R.Query<AYRISTIRMALAR>().First(t => t.ID == ID);
        }

        public static List<AYRISTIRMALAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AYRISTIRMALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AYRISTIRMALAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AYRISTIRMALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

