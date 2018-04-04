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
    public class ISORTAKWEBADRESLER : SasonBase.Sason.Tables.Table_ISORTAKWEBADRESLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISORTAKWEBADRESLER>
        {
            Dictionary<Decimal, ISORTAKWEBADRESLER> dict = new Dictionary<Decimal, ISORTAKWEBADRESLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISORTAKWEBADRESLER> items) : base(items) { }


            public ISORTAKWEBADRESLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISORTAKWEBADRESLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISORTAKWEBADRESLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISORTAKWEBADRESLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISORTAKWEBADRESLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISORTAKWEBADRESLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISORTAKWEBADRESLER> Select
        {
            get { return R.Query<ISORTAKWEBADRESLER>(); }
        }

        public static ISORTAKWEBADRESLER SelectItem(Decimal ID)
        {
            return R.Query<ISORTAKWEBADRESLER>().First(t => t.ID == ID);
        }

        public static List<ISORTAKWEBADRESLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISORTAKWEBADRESLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISORTAKWEBADRESLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISORTAKWEBADRESLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

