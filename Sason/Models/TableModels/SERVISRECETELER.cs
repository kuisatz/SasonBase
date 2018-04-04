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
    public class SERVISRECETELER : SasonBase.Sason.Tables.Table_SERVISRECETELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISRECETELER>
        {
            Dictionary<Decimal, SERVISRECETELER> dict = new Dictionary<Decimal, SERVISRECETELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISRECETELER> items) : base(items) { }


            public SERVISRECETELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISRECETELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISRECETELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISRECETELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISRECETELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISRECETELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISRECETELER> Select
        {
            get { return R.Query<SERVISRECETELER>(); }
        }

        public static SERVISRECETELER SelectItem(Decimal ID)
        {
            return R.Query<SERVISRECETELER>().First(t => t.ID == ID);
        }

        public static List<SERVISRECETELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISRECETELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISRECETELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISRECETELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

