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
    public class AKSIYONISLEMMALZEMELER : SasonBase.Sason.Tables.Table_AKSIYONISLEMMALZEMELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<AKSIYONISLEMMALZEMELER>
        {
            Dictionary<Decimal, AKSIYONISLEMMALZEMELER> dict = new Dictionary<Decimal, AKSIYONISLEMMALZEMELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<AKSIYONISLEMMALZEMELER> items) : base(items) { }


            public AKSIYONISLEMMALZEMELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AKSIYONISLEMMALZEMELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AKSIYONISLEMMALZEMELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AKSIYONISLEMMALZEMELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(AKSIYONISLEMMALZEMELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AKSIYONISLEMMALZEMELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AKSIYONISLEMMALZEMELER> Select
        {
            get { return R.Query<AKSIYONISLEMMALZEMELER>(); }
        }

        public static AKSIYONISLEMMALZEMELER SelectItem(Decimal ID)
        {
            return R.Query<AKSIYONISLEMMALZEMELER>().First(t => t.ID == ID);
        }

        public static List<AKSIYONISLEMMALZEMELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AKSIYONISLEMMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AKSIYONISLEMMALZEMELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AKSIYONISLEMMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

