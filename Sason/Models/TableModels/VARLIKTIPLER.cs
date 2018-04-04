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
    public class VARLIKTIPLER : SasonBase.Sason.Tables.Table_VARLIKTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<VARLIKTIPLER>
        {
            Dictionary<Decimal, VARLIKTIPLER> dict = new Dictionary<Decimal, VARLIKTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<VARLIKTIPLER> items) : base(items) { }


            public VARLIKTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public VARLIKTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<VARLIKTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<VARLIKTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(VARLIKTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(VARLIKTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<VARLIKTIPLER> Select
        {
            get { return R.Query<VARLIKTIPLER>(); }
        }

        public static VARLIKTIPLER SelectItem(Decimal ID)
        {
            return R.Query<VARLIKTIPLER>().First(t => t.ID == ID);
        }

        public static List<VARLIKTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<VARLIKTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<VARLIKTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<VARLIKTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

