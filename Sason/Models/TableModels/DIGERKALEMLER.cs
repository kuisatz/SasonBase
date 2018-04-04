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
    public class DIGERKALEMLER : SasonBase.Sason.Tables.Table_DIGERKALEMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<DIGERKALEMLER>
        {
            Dictionary<Decimal, DIGERKALEMLER> dict = new Dictionary<Decimal, DIGERKALEMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<DIGERKALEMLER> items) : base(items) { }


            public DIGERKALEMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public DIGERKALEMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<DIGERKALEMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<DIGERKALEMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(DIGERKALEMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(DIGERKALEMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<DIGERKALEMLER> Select
        {
            get { return R.Query<DIGERKALEMLER>(); }
        }

        public static DIGERKALEMLER SelectItem(Decimal ID)
        {
            return R.Query<DIGERKALEMLER>().First(t => t.ID == ID);
        }

        public static List<DIGERKALEMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<DIGERKALEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<DIGERKALEMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<DIGERKALEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

