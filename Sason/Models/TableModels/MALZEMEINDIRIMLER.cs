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
    public class MALZEMEINDIRIMLER : SasonBase.Sason.Tables.Table_MALZEMEINDIRIMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<MALZEMEINDIRIMLER>
        {
            Dictionary<Decimal, MALZEMEINDIRIMLER> dict = new Dictionary<Decimal, MALZEMEINDIRIMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<MALZEMEINDIRIMLER> items) : base(items) { }


            public MALZEMEINDIRIMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public MALZEMEINDIRIMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MALZEMEINDIRIMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MALZEMEINDIRIMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(MALZEMEINDIRIMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(MALZEMEINDIRIMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<MALZEMEINDIRIMLER> Select
        {
            get { return R.Query<MALZEMEINDIRIMLER>(); }
        }

        public static MALZEMEINDIRIMLER SelectItem(Decimal ID)
        {
            return R.Query<MALZEMEINDIRIMLER>().First(t => t.ID == ID);
        }

        public static List<MALZEMEINDIRIMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MALZEMEINDIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MALZEMEINDIRIMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MALZEMEINDIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

