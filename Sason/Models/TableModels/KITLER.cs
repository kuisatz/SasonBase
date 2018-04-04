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
    public class KITLER : SasonBase.Sason.Tables.Table_KITLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<KITLER>
        {
            Dictionary<Decimal, KITLER> dict = new Dictionary<Decimal, KITLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<KITLER> items) : base(items) { }


            public KITLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public KITLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<KITLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<KITLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(KITLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(KITLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<KITLER> Select
        {
            get { return R.Query<KITLER>(); }
        }

        public static KITLER SelectItem(Decimal ID)
        {
            return R.Query<KITLER>().First(t => t.ID == ID);
        }

        public static List<KITLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<KITLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<KITLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<KITLER>().Where(t => t.ID.In(IDs)).ToList();
        }


        public static decimal NewSeqId
        {
            get
            {
                return Convert.ToDecimal(SasonBaseApplicationPool.Get.EbaTestConnector.ExecuteScalar("select KITLER_SEQ.NEXTVAL from dual"));
            }
        }


    }
}

