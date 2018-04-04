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
    public class SERVISSIPARISLER : SasonBase.Sason.Tables.Table_SERVISSIPARISLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSIPARISLER>
        {
            Dictionary<Decimal, SERVISSIPARISLER> dict = new Dictionary<Decimal, SERVISSIPARISLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSIPARISLER> items) : base(items) { }


            public SERVISSIPARISLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSIPARISLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSIPARISLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSIPARISLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSIPARISLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSIPARISLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSIPARISLER> Select
        {
            get { return R.Query<SERVISSIPARISLER>(); }
        }

        public static SERVISSIPARISLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISSIPARISLER>().First(t => t.ID == ID);
        }

        public static List<SERVISSIPARISLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSIPARISLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSIPARISLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSIPARISLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

