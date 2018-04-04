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
    public class BIRIMLER : SasonBase.Sason.Tables.Table_BIRIMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BIRIMLER>
        {
            Dictionary<Decimal, BIRIMLER> dict = new Dictionary<Decimal, BIRIMLER>();
            Dictionary<string, BIRIMLER> kodDict = new Dictionary<string, BIRIMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BIRIMLER> items) : base(items) { }


            public BIRIMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BIRIMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BIRIMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BIRIMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public BIRIMLER Get(string kod)
            {
                return kodDict.find(kod);
            }

            protected override void OnBeforeInsert(BIRIMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
                kodDict.set(item.KOD, item);
            }

            protected override void OnAfterRemove(BIRIMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BIRIMLER> Select
        {
            get { return R.Query<BIRIMLER>(); }
        }

        public static BIRIMLER SelectItem(Decimal ID)
        {
            return R.Query<BIRIMLER>().First(t => t.ID == ID);
        }

        public static List<BIRIMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BIRIMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

