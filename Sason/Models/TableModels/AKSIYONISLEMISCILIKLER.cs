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
    public class AKSIYONISLEMISCILIKLER : SasonBase.Sason.Tables.Table_AKSIYONISLEMISCILIKLER.PublicItem
    {

        public class CONTAINER : Antibiotic.Collections.ListContainer<AKSIYONISLEMISCILIKLER>
        {
            Dictionary<Decimal, AKSIYONISLEMISCILIKLER> dict = new Dictionary<Decimal, AKSIYONISLEMISCILIKLER>();

            Dictionary<decimal, Dictionary<decimal, AKSIYONISLEMISCILIKLER>> gdict = new Dictionary<decimal, Dictionary<decimal, AKSIYONISLEMISCILIKLER>>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<AKSIYONISLEMISCILIKLER> items) : base(items) { }


            public AKSIYONISLEMISCILIKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AKSIYONISLEMISCILIKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AKSIYONISLEMISCILIKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AKSIYONISLEMISCILIKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }


            public AKSIYONISLEMISCILIKLER FindIscilik(decimal aksiyonIslemId, decimal iscilikId)
            {
                return gdict.find(aksiyonIslemId).find(iscilikId);
            }

            protected override void OnBeforeInsert(AKSIYONISLEMISCILIKLER item, ref bool cancel)
            {
                gdict.check(item.AKSIYONISLEMID).set(item.ISCILIKID, item, out cancel);
                if (!cancel)
                    dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AKSIYONISLEMISCILIKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AKSIYONISLEMISCILIKLER> Select
        {
            get { return R.Query<AKSIYONISLEMISCILIKLER>(); }
        }

        public static AKSIYONISLEMISCILIKLER SelectItem(Decimal ID)
        {
            return R.Query<AKSIYONISLEMISCILIKLER>().First(t => t.ID == ID);
        }

        public static List<AKSIYONISLEMISCILIKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AKSIYONISLEMISCILIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AKSIYONISLEMISCILIKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AKSIYONISLEMISCILIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

