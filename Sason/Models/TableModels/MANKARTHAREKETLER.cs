using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Database.Row;

namespace SasonBase.Sason.Models.TableModels
{
    [Serializable()]
    public class MANKARTHAREKETLER : Tables.Table_MANKARTHAREKETLER.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<MANKARTHAREKETLER>
        {
            Dictionary<Decimal, MANKARTHAREKETLER> dict = new Dictionary<Decimal, MANKARTHAREKETLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<MANKARTHAREKETLER> items) : base(items) { }


            public MANKARTHAREKETLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public MANKARTHAREKETLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MANKARTHAREKETLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MANKARTHAREKETLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(MANKARTHAREKETLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(MANKARTHAREKETLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<MANKARTHAREKETLER> Select
        {
            get { return R.Query<MANKARTHAREKETLER>(); }
        }

        public static MANKARTHAREKETLER SelectItem(Decimal ID)
        {
            return R.Query<MANKARTHAREKETLER>().First(t => t.ID == ID);
        }

        public static List<MANKARTHAREKETLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MANKARTHAREKETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MANKARTHAREKETLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MANKARTHAREKETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static MANKARTHAREKETLER SelectFromFatura(Decimal faturaId)
        {
            return Select.First(t => t.FATURAID == faturaId);
        }

        public static decimal SelectBakiye(Decimal mankart_id)
        {
            return SasonBaseApplicationPool.Get.EbaTestConnector.GetDataTable("SELECT SUM(nvl(KAZANILANPUAN,0)) - sum(nvl(HARCANANPUAN,0)) FROM MANKARTHAREKETLER WHERE MANKARTID = " + mankart_id)
                .Result
                .FirstRowFirstColumnValue()
                .cto<decimal>();
        }


        

    }
}