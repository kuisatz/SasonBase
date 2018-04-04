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
    public class SERVISEKSISLEMMALZEMELER : SasonBase.Sason.Tables.Table_SERVISEKSISLEMMALZEMELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISEKSISLEMMALZEMELER>
        {
            Dictionary<Decimal, SERVISEKSISLEMMALZEMELER> dict = new Dictionary<Decimal, SERVISEKSISLEMMALZEMELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISEKSISLEMMALZEMELER> items) : base(items) { }


            public SERVISEKSISLEMMALZEMELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISEKSISLEMMALZEMELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISEKSISLEMMALZEMELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISEKSISLEMMALZEMELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISEKSISLEMMALZEMELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISEKSISLEMMALZEMELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISEKSISLEMMALZEMELER> Select
        {
            get { return R.Query<SERVISEKSISLEMMALZEMELER>(); }
        }

        public static SERVISEKSISLEMMALZEMELER SelectItem(Decimal ID)
        {
            return R.Query<SERVISEKSISLEMMALZEMELER>().First(t => t.ID == ID);
        }

        public static List<SERVISEKSISLEMMALZEMELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISEKSISLEMMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISEKSISLEMMALZEMELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISEKSISLEMMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

