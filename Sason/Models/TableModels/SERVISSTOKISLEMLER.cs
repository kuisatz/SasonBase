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
    public class SERVISSTOKISLEMLER : SasonBase.Sason.Tables.Table_SERVISSTOKISLEMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSTOKISLEMLER>
        {
            Dictionary<Decimal, SERVISSTOKISLEMLER> dict = new Dictionary<Decimal, SERVISSTOKISLEMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSTOKISLEMLER> items) : base(items) { }


            public SERVISSTOKISLEMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSTOKISLEMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSTOKISLEMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSTOKISLEMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSTOKISLEMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSTOKISLEMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSTOKISLEMLER> Select
        {
            get { return R.Query<SERVISSTOKISLEMLER>(); }
        }

        public static SERVISSTOKISLEMLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISSTOKISLEMLER>().First(t => t.ID == ID);
        }

        public static List<SERVISSTOKISLEMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSTOKISLEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSTOKISLEMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSTOKISLEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

