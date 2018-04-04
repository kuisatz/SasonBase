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
    public class SERVISAKTIVITELER : SasonBase.Sason.Tables.Table_SERVISAKTIVITELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISAKTIVITELER>
        {
            Dictionary<Decimal, SERVISAKTIVITELER> dict = new Dictionary<Decimal, SERVISAKTIVITELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISAKTIVITELER> items) : base(items) { }


            public SERVISAKTIVITELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISAKTIVITELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISAKTIVITELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISAKTIVITELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISAKTIVITELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISAKTIVITELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISAKTIVITELER> Select
        {
            get { return R.Query<SERVISAKTIVITELER>(); }
        }

        public static SERVISAKTIVITELER SelectItem(Decimal ID)
        {
            return R.Query<SERVISAKTIVITELER>().First(t => t.ID == ID);
        }

        public static List<SERVISAKTIVITELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISAKTIVITELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISAKTIVITELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISAKTIVITELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

