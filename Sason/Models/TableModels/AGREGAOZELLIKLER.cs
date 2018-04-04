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
    public class AGREGAOZELLIKLER : SasonBase.Sason.Tables.Table_AGREGAOZELLIKLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<AGREGAOZELLIKLER>
        {
            Dictionary<Decimal, AGREGAOZELLIKLER> dict = new Dictionary<Decimal, AGREGAOZELLIKLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<AGREGAOZELLIKLER> items) : base(items) { }


            public AGREGAOZELLIKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AGREGAOZELLIKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AGREGAOZELLIKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AGREGAOZELLIKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(AGREGAOZELLIKLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AGREGAOZELLIKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AGREGAOZELLIKLER> Select
        {
            get { return R.Query<AGREGAOZELLIKLER>(); }
        }

        public static AGREGAOZELLIKLER SelectItem(Decimal ID)
        {
            return R.Query<AGREGAOZELLIKLER>().First(t => t.ID == ID);
        }

        public static List<AGREGAOZELLIKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AGREGAOZELLIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AGREGAOZELLIKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AGREGAOZELLIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

