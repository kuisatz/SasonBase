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
    public class SIKAYETTURLER : SasonBase.Sason.Tables.Table_SIKAYETTURLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SIKAYETTURLER>
        {
            Dictionary<Decimal, SIKAYETTURLER> dict = new Dictionary<Decimal, SIKAYETTURLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SIKAYETTURLER> items) : base(items) { }


            public SIKAYETTURLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SIKAYETTURLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SIKAYETTURLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SIKAYETTURLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SIKAYETTURLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SIKAYETTURLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SIKAYETTURLER> Select
        {
            get { return R.Query<SIKAYETTURLER>(); }
        }

        public static SIKAYETTURLER SelectItem(Decimal ID)
        {
            return R.Query<SIKAYETTURLER>().First(t => t.ID == ID);
        }

        public static List<SIKAYETTURLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SIKAYETTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SIKAYETTURLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SIKAYETTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

