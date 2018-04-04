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
    public class SERVISISORTAKWEBADRESLER : SasonBase.Sason.Tables.Table_SERVISISORTAKWEBADRESLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISORTAKWEBADRESLER>
        {
            Dictionary<Decimal, SERVISISORTAKWEBADRESLER> dict = new Dictionary<Decimal, SERVISISORTAKWEBADRESLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISORTAKWEBADRESLER> items) : base(items) { }


            public SERVISISORTAKWEBADRESLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISORTAKWEBADRESLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISORTAKWEBADRESLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISORTAKWEBADRESLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISORTAKWEBADRESLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISORTAKWEBADRESLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISORTAKWEBADRESLER> Select
        {
            get { return R.Query<SERVISISORTAKWEBADRESLER>(); }
        }

        public static SERVISISORTAKWEBADRESLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISISORTAKWEBADRESLER>().First(t => t.ID == ID);
        }

        public static List<SERVISISORTAKWEBADRESLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISORTAKWEBADRESLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISORTAKWEBADRESLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISORTAKWEBADRESLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

