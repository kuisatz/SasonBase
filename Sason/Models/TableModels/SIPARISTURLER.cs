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
    public class SIPARISTURLER : SasonBase.Sason.Tables.Table_SIPARISTURLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SIPARISTURLER>
        {
            Dictionary<Decimal, SIPARISTURLER> dict = new Dictionary<Decimal, SIPARISTURLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SIPARISTURLER> items) : base(items) { }


            public SIPARISTURLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SIPARISTURLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SIPARISTURLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SIPARISTURLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SIPARISTURLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SIPARISTURLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SIPARISTURLER> Select
        {
            get { return R.Query<SIPARISTURLER>(); }
        }

        public static SIPARISTURLER SelectItem(Decimal ID)
        {
            return R.Query<SIPARISTURLER>().First(t => t.ID == ID);
        }

        public static List<SIPARISTURLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SIPARISTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SIPARISTURLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SIPARISTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

