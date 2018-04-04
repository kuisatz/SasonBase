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
    public class BAKIMAGREGALAR : SasonBase.Sason.Tables.Table_BAKIMAGREGALAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMAGREGALAR>
        {
            Dictionary<Decimal, BAKIMAGREGALAR> dict = new Dictionary<Decimal, BAKIMAGREGALAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMAGREGALAR> items) : base(items) { }


            public BAKIMAGREGALAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMAGREGALAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMAGREGALAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMAGREGALAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMAGREGALAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMAGREGALAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMAGREGALAR> Select
        {
            get { return R.Query<BAKIMAGREGALAR>(); }
        }

        public static BAKIMAGREGALAR SelectItem(Decimal ID)
        {
            return R.Query<BAKIMAGREGALAR>().First(t => t.ID == ID);
        }

        public static List<BAKIMAGREGALAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMAGREGALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMAGREGALAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMAGREGALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

