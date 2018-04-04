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
    public class FATURATURLER : SasonBase.Sason.Tables.Table_FATURATURLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<FATURATURLER>
        {
            Dictionary<Decimal, FATURATURLER> dict = new Dictionary<Decimal, FATURATURLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<FATURATURLER> items) : base(items) { }


            public FATURATURLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public FATURATURLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<FATURATURLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<FATURATURLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(FATURATURLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(FATURATURLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<FATURATURLER> Select
        {
            get { return R.Query<FATURATURLER>(); }
        }

        public static FATURATURLER SelectItem(Decimal ID)
        {
            return R.Query<FATURATURLER>().First(t => t.ID == ID);
        }

        public static List<FATURATURLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<FATURATURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<FATURATURLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<FATURATURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

