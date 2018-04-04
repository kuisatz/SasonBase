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
    public class SERVISRANDEVUTIPLER : SasonBase.Sason.Tables.Table_SERVISRANDEVUTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISRANDEVUTIPLER>
        {
            Dictionary<Decimal, SERVISRANDEVUTIPLER> dict = new Dictionary<Decimal, SERVISRANDEVUTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISRANDEVUTIPLER> items) : base(items) { }


            public SERVISRANDEVUTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISRANDEVUTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISRANDEVUTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISRANDEVUTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISRANDEVUTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISRANDEVUTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISRANDEVUTIPLER> Select
        {
            get { return R.Query<SERVISRANDEVUTIPLER>(); }
        }

        public static SERVISRANDEVUTIPLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISRANDEVUTIPLER>().First(t => t.ID == ID);
        }

        public static List<SERVISRANDEVUTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISRANDEVUTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISRANDEVUTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISRANDEVUTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

