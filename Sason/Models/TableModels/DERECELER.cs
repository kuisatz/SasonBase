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
    public class DERECELER : SasonBase.Sason.Tables.Table_DERECELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<DERECELER>
        {
            Dictionary<Decimal, DERECELER> dict = new Dictionary<Decimal, DERECELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<DERECELER> items) : base(items) { }


            public DERECELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public DERECELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<DERECELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<DERECELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(DERECELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(DERECELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<DERECELER> Select
        {
            get { return R.Query<DERECELER>(); }
        }

        public static DERECELER SelectItem(Decimal ID)
        {
            return R.Query<DERECELER>().First(t => t.ID == ID);
        }

        public static List<DERECELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<DERECELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<DERECELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<DERECELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

