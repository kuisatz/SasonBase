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
    public class ISCILIKLER : SasonBase.Sason.Tables.Table_ISCILIKLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISCILIKLER>
        {
            Dictionary<Decimal, ISCILIKLER> dict = new Dictionary<Decimal, ISCILIKLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISCILIKLER> items) : base(items) { }


            public ISCILIKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISCILIKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISCILIKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISCILIKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISCILIKLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISCILIKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISCILIKLER> Select
        {
            get { return R.Query<ISCILIKLER>(); }
        }

        public static ISCILIKLER SelectItem(Decimal ID)
        {
            return R.Query<ISCILIKLER>().First(t => t.ID == ID);
        }

        public static List<ISCILIKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISCILIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISCILIKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISCILIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

