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
    public class AKSIYONARACLAR : SasonBase.Sason.Tables.Table_AKSIYONARACLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<AKSIYONARACLAR>
        {
            Dictionary<Decimal, AKSIYONARACLAR> dict = new Dictionary<Decimal, AKSIYONARACLAR>();
            Dictionary<decimal, Dictionary<string, AKSIYONARACLAR>> aksSaseDict = new Dictionary<decimal, Dictionary<string, AKSIYONARACLAR>>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<AKSIYONARACLAR> items) : base(items) { }


            public AKSIYONARACLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AKSIYONARACLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AKSIYONARACLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AKSIYONARACLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public AKSIYONARACLAR GetFromAksiyon(decimal aksiyonId, string saseno)
            {
                return aksSaseDict.find(aksiyonId).find(saseno);
            }

            protected override void OnBeforeInsert(AKSIYONARACLAR item, ref bool cancel)
            {
                aksSaseDict.check(item.AKSIYONID).set(item.SASENO, item);
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AKSIYONARACLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AKSIYONARACLAR> Select
        {
            get { return R.Query<AKSIYONARACLAR>(); }
        }

        public static AKSIYONARACLAR SelectItem(Decimal ID)
        {
            return R.Query<AKSIYONARACLAR>().First(t => t.ID == ID);
        }

        public static List<AKSIYONARACLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AKSIYONARACLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AKSIYONARACLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AKSIYONARACLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

