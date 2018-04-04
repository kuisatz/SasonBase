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
    public class SERVISSTOKTURLER : SasonBase.Sason.Tables.Table_SERVISSTOKTURLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSTOKTURLER>
        {
            Dictionary<Decimal, SERVISSTOKTURLER> dict = new Dictionary<Decimal, SERVISSTOKTURLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSTOKTURLER> items) : base(items) { }


            public SERVISSTOKTURLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSTOKTURLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSTOKTURLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSTOKTURLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSTOKTURLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSTOKTURLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSTOKTURLER> Select
        {
            get { return R.Query<SERVISSTOKTURLER>(); }
        }

        public static SERVISSTOKTURLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISSTOKTURLER>().First(t => t.ID == ID);
        }

        public static List<SERVISSTOKTURLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSTOKTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSTOKTURLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSTOKTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

