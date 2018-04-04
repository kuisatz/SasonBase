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
    public class SERVISSIPARISMLZLER : SasonBase.Sason.Tables.Table_SERVISSIPARISMLZLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSIPARISMLZLER>
        {
            Dictionary<Decimal, SERVISSIPARISMLZLER> dict = new Dictionary<Decimal, SERVISSIPARISMLZLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSIPARISMLZLER> items) : base(items) { }


            public SERVISSIPARISMLZLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSIPARISMLZLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSIPARISMLZLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSIPARISMLZLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSIPARISMLZLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSIPARISMLZLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSIPARISMLZLER> Select
        {
            get { return R.Query<SERVISSIPARISMLZLER>(); }
        }

        public static SERVISSIPARISMLZLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISSIPARISMLZLER>().First(t => t.ID == ID);
        }

        public static List<SERVISSIPARISMLZLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSIPARISMLZLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSIPARISMLZLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSIPARISMLZLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

