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
    public class ESASISTEMLER : SasonBase.Sason.Tables.Table_ESASISTEMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ESASISTEMLER>
        {
            Dictionary<Decimal, ESASISTEMLER> dict = new Dictionary<Decimal, ESASISTEMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ESASISTEMLER> items) : base(items) { }


            public ESASISTEMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ESASISTEMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ESASISTEMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ESASISTEMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ESASISTEMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ESASISTEMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ESASISTEMLER> Select
        {
            get { return R.Query<ESASISTEMLER>(); }
        }

        public static ESASISTEMLER SelectItem(Decimal ID)
        {
            return R.Query<ESASISTEMLER>().First(t => t.ID == ID);
        }

        public static List<ESASISTEMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ESASISTEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ESASISTEMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ESASISTEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

