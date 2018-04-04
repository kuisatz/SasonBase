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
    public class SERVISISMISLEMMALZEMELER : SasonBase.Sason.Tables.Table_SERVISISMISLEMMALZEMELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISMISLEMMALZEMELER>
        {
            Dictionary<Decimal, SERVISISMISLEMMALZEMELER> dict = new Dictionary<Decimal, SERVISISMISLEMMALZEMELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISMISLEMMALZEMELER> items) : base(items) { }


            public SERVISISMISLEMMALZEMELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISMISLEMMALZEMELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISMISLEMMALZEMELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISMISLEMMALZEMELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISMISLEMMALZEMELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISMISLEMMALZEMELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISMISLEMMALZEMELER> Select
        {
            get { return R.Query<SERVISISMISLEMMALZEMELER>(); }
        }

        public static SERVISISMISLEMMALZEMELER SelectItem(Decimal ID)
        {
            return R.Query<SERVISISMISLEMMALZEMELER>().First(t => t.ID == ID);
        }

        public static List<SERVISISMISLEMMALZEMELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISMISLEMMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISMISLEMMALZEMELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISMISLEMMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

