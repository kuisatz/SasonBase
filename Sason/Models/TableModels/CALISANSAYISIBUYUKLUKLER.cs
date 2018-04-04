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
    public class CALISANSAYISIBUYUKLUKLER : SasonBase.Sason.Tables.Table_CALISANSAYISIBUYUKLUKLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<CALISANSAYISIBUYUKLUKLER>
        {
            Dictionary<Decimal, CALISANSAYISIBUYUKLUKLER> dict = new Dictionary<Decimal, CALISANSAYISIBUYUKLUKLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<CALISANSAYISIBUYUKLUKLER> items) : base(items) { }


            public CALISANSAYISIBUYUKLUKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public CALISANSAYISIBUYUKLUKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<CALISANSAYISIBUYUKLUKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<CALISANSAYISIBUYUKLUKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(CALISANSAYISIBUYUKLUKLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(CALISANSAYISIBUYUKLUKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<CALISANSAYISIBUYUKLUKLER> Select
        {
            get { return R.Query<CALISANSAYISIBUYUKLUKLER>(); }
        }

        public static CALISANSAYISIBUYUKLUKLER SelectItem(Decimal ID)
        {
            return R.Query<CALISANSAYISIBUYUKLUKLER>().First(t => t.ID == ID);
        }

        public static List<CALISANSAYISIBUYUKLUKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<CALISANSAYISIBUYUKLUKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<CALISANSAYISIBUYUKLUKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<CALISANSAYISIBUYUKLUKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

