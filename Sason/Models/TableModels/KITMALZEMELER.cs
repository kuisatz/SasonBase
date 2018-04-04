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
    public class KITMALZEMELER : SasonBase.Sason.Tables.Table_KITMALZEMELER.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<KITMALZEMELER>
        {
            Dictionary<Decimal, KITMALZEMELER> dict = new Dictionary<Decimal, KITMALZEMELER>();
            Dictionary<decimal, Dictionary<decimal, KITMALZEMELER>> kitIdMlzIdDict = new Dictionary<decimal, Dictionary<decimal, KITMALZEMELER>>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<KITMALZEMELER> items) : base(items) { }


            public KITMALZEMELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public KITMALZEMELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<KITMALZEMELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<KITMALZEMELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public KITMALZEMELER Get(decimal kitId, decimal malzemeId)
            {
                return kitIdMlzIdDict.find(kitId).find(malzemeId);
            }

            protected override void OnBeforeInsert(KITMALZEMELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
                kitIdMlzIdDict.check(item.KITID).set(item.MALZEMEID, item);
            }

            protected override void OnAfterRemove(KITMALZEMELER item)
            {
                dict.remove(item.ID);
            }
        }

        public static IOrderedQueryable<KITMALZEMELER> Select
        {
            get { return R.Query<KITMALZEMELER>(); }
        }

        public static KITMALZEMELER SelectItem(Decimal ID)
        {
            return R.Query<KITMALZEMELER>().First(t => t.ID == ID);
        }

        public static List<KITMALZEMELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<KITMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<KITMALZEMELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<KITMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static decimal NewSeqId(MethodReturn refmr)
        {
            return Convert.ToDecimal(SasonBaseApplicationPool.Get.EbaTestConnector.ExecuteScalar("select KITMALZEMELER_SEQ.NEXTVAL from dual", refmr));
        }



    }
}

