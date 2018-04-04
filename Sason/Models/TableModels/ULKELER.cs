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
    public class ULKELER : SasonBase.Sason.Tables.Table_ULKELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ULKELER>
        {
            Dictionary<Decimal, ULKELER> dict = new Dictionary<Decimal, ULKELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ULKELER> items) : base(items) { }


            public ULKELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ULKELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ULKELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ULKELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ULKELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ULKELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ULKELER> Select
        {
            get { return R.Query<ULKELER>(); }
        }

        public static ULKELER SelectItem(Decimal ID)
        {
            return R.Query<ULKELER>().First(t => t.ID == ID);
        }

        public static List<ULKELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ULKELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ULKELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ULKELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

