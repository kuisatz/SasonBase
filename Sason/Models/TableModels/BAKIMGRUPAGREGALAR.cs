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
    public class BAKIMGRUPAGREGALAR : SasonBase.Sason.Tables.Table_BAKIMGRUPAGREGALAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMGRUPAGREGALAR>
        {
            Dictionary<Decimal, BAKIMGRUPAGREGALAR> dict = new Dictionary<Decimal, BAKIMGRUPAGREGALAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMGRUPAGREGALAR> items) : base(items) { }


            public BAKIMGRUPAGREGALAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMGRUPAGREGALAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMGRUPAGREGALAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMGRUPAGREGALAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMGRUPAGREGALAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMGRUPAGREGALAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMGRUPAGREGALAR> Select
        {
            get { return R.Query<BAKIMGRUPAGREGALAR>(); }
        }

        public static BAKIMGRUPAGREGALAR SelectItem(Decimal ID)
        {
            return R.Query<BAKIMGRUPAGREGALAR>().First(t => t.ID == ID);
        }

        public static List<BAKIMGRUPAGREGALAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMGRUPAGREGALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMGRUPAGREGALAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMGRUPAGREGALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

