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
    public class SERVISPAKETLER : SasonBase.Sason.Tables.Table_SERVISPAKETLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISPAKETLER>
        {
            Dictionary<Decimal, SERVISPAKETLER> dict = new Dictionary<Decimal, SERVISPAKETLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISPAKETLER> items) : base(items) { }


            public SERVISPAKETLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISPAKETLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISPAKETLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISPAKETLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISPAKETLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISPAKETLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISPAKETLER> Select
        {
            get { return R.Query<SERVISPAKETLER>(); }
        }

        public static SERVISPAKETLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISPAKETLER>().First(t => t.ID == ID);
        }

        public static List<SERVISPAKETLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISPAKETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISPAKETLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISPAKETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

