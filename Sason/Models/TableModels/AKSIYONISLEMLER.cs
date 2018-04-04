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
    public class AKSIYONISLEMLER : SasonBase.Sason.Tables.Table_AKSIYONISLEMLER.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<AKSIYONISLEMLER>
        {
            Dictionary<Decimal, AKSIYONISLEMLER> dict = new Dictionary<Decimal, AKSIYONISLEMLER>();
            Dictionary<decimal, Dictionary<decimal, AKSIYONISLEMLER>> aksIdNoDict = new Dictionary<decimal, Dictionary<decimal, AKSIYONISLEMLER>>();


            public CONTAINER() { }

            public CONTAINER(IEnumerable<AKSIYONISLEMLER> items) : base(items) { }


            public AKSIYONISLEMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AKSIYONISLEMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AKSIYONISLEMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AKSIYONISLEMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public AKSIYONISLEMLER GetAksiyonIslem(decimal aksiyonId, decimal siraNo)
            {
                return aksIdNoDict.find(aksiyonId).find(siraNo);
            }

            protected override void OnBeforeInsert(AKSIYONISLEMLER item, ref bool cancel)
            {
                aksIdNoDict.check(item.AKSIYONID).set(item.SIRANO, item, out cancel);
                if (!cancel)
                    dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AKSIYONISLEMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AKSIYONISLEMLER> Select
        {
            get { return R.Query<AKSIYONISLEMLER>(); }
        }

        public static AKSIYONISLEMLER SelectItem(Decimal ID)
        {
            return R.Query<AKSIYONISLEMLER>().First(t => t.ID == ID);
        }

        public static List<AKSIYONISLEMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AKSIYONISLEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AKSIYONISLEMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AKSIYONISLEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

