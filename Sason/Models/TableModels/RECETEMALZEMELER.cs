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
    public class RECETEMALZEMELER : SasonBase.Sason.Tables.Table_RECETEMALZEMELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<RECETEMALZEMELER>
        {
            Dictionary<Decimal, RECETEMALZEMELER> dict = new Dictionary<Decimal, RECETEMALZEMELER>();
            Dictionary<decimal, Dictionary<decimal, RECETEMALZEMELER>> malDict = new Dictionary<decimal, Dictionary<decimal, RECETEMALZEMELER>>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<RECETEMALZEMELER> items) : base(items) { }


            public RECETEMALZEMELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public RECETEMALZEMELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<RECETEMALZEMELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<RECETEMALZEMELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public RECETEMALZEMELER Get(decimal receteId, decimal malzemeId)
            {
                return malDict.find(receteId).find(malzemeId);
            }

            protected override void OnBeforeInsert(RECETEMALZEMELER item, ref bool cancel)
            {
                malDict.check(item.RECETEID).set(item.MALZEMEID, item, out cancel);
                if (!cancel)
                    dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(RECETEMALZEMELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<RECETEMALZEMELER> Select
        {
            get { return R.Query<RECETEMALZEMELER>(); }
        }

        public static RECETEMALZEMELER SelectItem(Decimal ID)
        {
            return R.Query<RECETEMALZEMELER>().First(t => t.ID == ID);
        }

        public static List<RECETEMALZEMELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<RECETEMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<RECETEMALZEMELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<RECETEMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

