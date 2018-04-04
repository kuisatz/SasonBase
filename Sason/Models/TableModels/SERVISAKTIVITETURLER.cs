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
    public class SERVISAKTIVITETURLER : SasonBase.Sason.Tables.Table_SERVISAKTIVITETURLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISAKTIVITETURLER>
        {
            Dictionary<Decimal, SERVISAKTIVITETURLER> dict = new Dictionary<Decimal, SERVISAKTIVITETURLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISAKTIVITETURLER> items) : base(items) { }


            public SERVISAKTIVITETURLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISAKTIVITETURLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISAKTIVITETURLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISAKTIVITETURLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISAKTIVITETURLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISAKTIVITETURLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISAKTIVITETURLER> Select
        {
            get { return R.Query<SERVISAKTIVITETURLER>(); }
        }

        public static SERVISAKTIVITETURLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISAKTIVITETURLER>().First(t => t.ID == ID);
        }

        public static List<SERVISAKTIVITETURLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISAKTIVITETURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISAKTIVITETURLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISAKTIVITETURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

