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
    public class MALZEMEFIYATLAR : SasonBase.Sason.Tables.Table_MALZEMEFIYATLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<MALZEMEFIYATLAR>
        {
            Dictionary<Decimal, MALZEMEFIYATLAR> dict = new Dictionary<Decimal, MALZEMEFIYATLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<MALZEMEFIYATLAR> items) : base(items) { }


            public MALZEMEFIYATLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public MALZEMEFIYATLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MALZEMEFIYATLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MALZEMEFIYATLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(MALZEMEFIYATLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(MALZEMEFIYATLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<MALZEMEFIYATLAR> Select
        {
            get { return R.Query<MALZEMEFIYATLAR>(); }
        }

        public static MALZEMEFIYATLAR SelectItem(Decimal ID)
        {
            return R.Query<MALZEMEFIYATLAR>().First(t => t.ID == ID);
        }

        public static List<MALZEMEFIYATLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MALZEMEFIYATLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MALZEMEFIYATLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MALZEMEFIYATLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static decimal NewSeqId
        {
            get
            {
                return Convert.ToDecimal(SasonBaseApplicationPool.Get.EbaTestConnector.ExecuteScalar("select MALZEMEFIYATLAR_SEQ.NEXTVAL from dual"));
            }
        }


    }
}

