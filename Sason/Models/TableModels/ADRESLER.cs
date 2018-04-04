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
    public class ADRESLER : SasonBase.Sason.Tables.Table_ADRESLER.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<ADRESLER>
        {
            Dictionary<Decimal, ADRESLER> dict = new Dictionary<Decimal, ADRESLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ADRESLER> items) : base(items) { }


            public ADRESLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ADRESLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ADRESLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ADRESLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ADRESLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ADRESLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ADRESLER> Select
        {
            get { return R.Query<ADRESLER>(); }
        }

        public static ADRESLER SelectItem(Decimal ID)
        {
            return R.Query<ADRESLER>().First(t => t.ID == ID);
        }

        public static List<ADRESLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ADRESLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ADRESLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ADRESLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

