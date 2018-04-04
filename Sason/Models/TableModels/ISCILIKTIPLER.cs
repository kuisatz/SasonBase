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
    public class ISCILIKTIPLER : SasonBase.Sason.Tables.Table_ISCILIKTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISCILIKTIPLER>
        {
            Dictionary<Decimal, ISCILIKTIPLER> dict = new Dictionary<Decimal, ISCILIKTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISCILIKTIPLER> items) : base(items) { }


            public ISCILIKTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISCILIKTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISCILIKTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISCILIKTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISCILIKTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISCILIKTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISCILIKTIPLER> Select
        {
            get { return R.Query<ISCILIKTIPLER>(); }
        }

        public static ISCILIKTIPLER SelectItem(Decimal ID)
        {
            return R.Query<ISCILIKTIPLER>().First(t => t.ID == ID);
        }

        public static List<ISCILIKTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISCILIKTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISCILIKTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISCILIKTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

