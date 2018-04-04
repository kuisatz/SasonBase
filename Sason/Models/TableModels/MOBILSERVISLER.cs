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
    [Serializable]
    public class MOBILSERVISLER : SasonBase.Sason.Tables.Table_MOBILSERVISLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<MOBILSERVISLER>
        {
            Dictionary<Decimal, MOBILSERVISLER> dict = new Dictionary<Decimal, MOBILSERVISLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<MOBILSERVISLER> items) : base(items) { }


            public MOBILSERVISLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public MOBILSERVISLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MOBILSERVISLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MOBILSERVISLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(MOBILSERVISLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(MOBILSERVISLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<MOBILSERVISLER> Select
        {
            get { return R.Query<MOBILSERVISLER>(); }
        }

        public static MOBILSERVISLER SelectItem(Decimal ID)
        {
            return R.Query<MOBILSERVISLER>().First(t => t.ID == ID);
        }

        public static List<MOBILSERVISLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MOBILSERVISLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MOBILSERVISLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MOBILSERVISLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

