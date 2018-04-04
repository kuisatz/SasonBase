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
    public class RECETELER : SasonBase.Sason.Tables.Table_RECETELER.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<RECETELER>
        {
            Dictionary<Decimal, RECETELER> dict = new Dictionary<Decimal, RECETELER>();
            Dictionary<string, RECETELER> kodDict = new Dictionary<string, RECETELER>();

            public CONTAINER() { }
            public CONTAINER(IEnumerable<RECETELER> items) : base(items) { }


            public RECETELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public RECETELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<RECETELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<RECETELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public RECETELER Get(string kod)
            {
                return kodDict.find(kod);
            }

            protected override void OnBeforeInsert(RECETELER item, ref bool cancel)
            {
                kodDict.set(item.KOD, item, out cancel);
                if (!cancel)
                    dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(RECETELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<RECETELER> Select
        {
            get { return R.Query<RECETELER>(); }
        }

        public static RECETELER SelectItem(Decimal ID)
        {
            return R.Query<RECETELER>().First(t => t.ID == ID);
        }

        public static List<RECETELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<RECETELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<RECETELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<RECETELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

