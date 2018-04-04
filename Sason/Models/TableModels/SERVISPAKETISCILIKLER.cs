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
    public class SERVISPAKETISCILIKLER : SasonBase.Sason.Tables.Table_SERVISPAKETISCILIKLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISPAKETISCILIKLER>
        {
            Dictionary<Decimal, SERVISPAKETISCILIKLER> dict = new Dictionary<Decimal, SERVISPAKETISCILIKLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISPAKETISCILIKLER> items) : base(items) { }


            public SERVISPAKETISCILIKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISPAKETISCILIKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISPAKETISCILIKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISPAKETISCILIKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISPAKETISCILIKLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISPAKETISCILIKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISPAKETISCILIKLER> Select
        {
            get { return R.Query<SERVISPAKETISCILIKLER>(); }
        }

        public static SERVISPAKETISCILIKLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISPAKETISCILIKLER>().First(t => t.ID == ID);
        }

        public static List<SERVISPAKETISCILIKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISPAKETISCILIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISPAKETISCILIKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISPAKETISCILIKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

