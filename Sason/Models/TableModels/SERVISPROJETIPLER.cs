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
    public class SERVISPROJETIPLER : SasonBase.Sason.Tables.Table_SERVISPROJETIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISPROJETIPLER>
        {
            Dictionary<Decimal, SERVISPROJETIPLER> dict = new Dictionary<Decimal, SERVISPROJETIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISPROJETIPLER> items) : base(items) { }


            public SERVISPROJETIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISPROJETIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISPROJETIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISPROJETIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISPROJETIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISPROJETIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISPROJETIPLER> Select
        {
            get { return R.Query<SERVISPROJETIPLER>(); }
        }

        public static SERVISPROJETIPLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISPROJETIPLER>().First(t => t.ID == ID);
        }

        public static List<SERVISPROJETIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISPROJETIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISPROJETIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISPROJETIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

