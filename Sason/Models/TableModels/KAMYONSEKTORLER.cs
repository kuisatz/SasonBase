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
    public class KAMYONSEKTORLER : SasonBase.Sason.Tables.Table_KAMYONSEKTORLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<KAMYONSEKTORLER>
        {
            Dictionary<Decimal, KAMYONSEKTORLER> dict = new Dictionary<Decimal, KAMYONSEKTORLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<KAMYONSEKTORLER> items) : base(items) { }


            public KAMYONSEKTORLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public KAMYONSEKTORLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<KAMYONSEKTORLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<KAMYONSEKTORLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(KAMYONSEKTORLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(KAMYONSEKTORLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<KAMYONSEKTORLER> Select
        {
            get { return R.Query<KAMYONSEKTORLER>(); }
        }

        public static KAMYONSEKTORLER SelectItem(Decimal ID)
        {
            return R.Query<KAMYONSEKTORLER>().First(t => t.ID == ID);
        }

        public static List<KAMYONSEKTORLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<KAMYONSEKTORLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<KAMYONSEKTORLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<KAMYONSEKTORLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

