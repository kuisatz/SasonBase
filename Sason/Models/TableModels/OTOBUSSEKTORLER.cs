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
    public class OTOBUSSEKTORLER : SasonBase.Sason.Tables.Table_OTOBUSSEKTORLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<OTOBUSSEKTORLER>
        {
            Dictionary<Decimal, OTOBUSSEKTORLER> dict = new Dictionary<Decimal, OTOBUSSEKTORLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<OTOBUSSEKTORLER> items) : base(items) { }


            public OTOBUSSEKTORLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public OTOBUSSEKTORLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<OTOBUSSEKTORLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<OTOBUSSEKTORLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(OTOBUSSEKTORLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(OTOBUSSEKTORLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<OTOBUSSEKTORLER> Select
        {
            get { return R.Query<OTOBUSSEKTORLER>(); }
        }

        public static OTOBUSSEKTORLER SelectItem(Decimal ID)
        {
            return R.Query<OTOBUSSEKTORLER>().First(t => t.ID == ID);
        }

        public static List<OTOBUSSEKTORLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<OTOBUSSEKTORLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<OTOBUSSEKTORLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<OTOBUSSEKTORLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

