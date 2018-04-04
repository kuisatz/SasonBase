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
    public class SERVISVARDIYATEKNISYENLER : SasonBase.Sason.Tables.Table_SERVISVARDIYATEKNISYENLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISVARDIYATEKNISYENLER>
        {
            Dictionary<Decimal, SERVISVARDIYATEKNISYENLER> dict = new Dictionary<Decimal, SERVISVARDIYATEKNISYENLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISVARDIYATEKNISYENLER> items) : base(items) { }


            public SERVISVARDIYATEKNISYENLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISVARDIYATEKNISYENLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISVARDIYATEKNISYENLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISVARDIYATEKNISYENLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISVARDIYATEKNISYENLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISVARDIYATEKNISYENLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISVARDIYATEKNISYENLER> Select
        {
            get { return R.Query<SERVISVARDIYATEKNISYENLER>(); }
        }

        public static SERVISVARDIYATEKNISYENLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISVARDIYATEKNISYENLER>().First(t => t.ID == ID);
        }

        public static List<SERVISVARDIYATEKNISYENLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISVARDIYATEKNISYENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISVARDIYATEKNISYENLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISVARDIYATEKNISYENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

