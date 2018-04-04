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
    public class MALZEMEGRUPINDIRIMLER : SasonBase.Sason.Tables.Table_MALZEMEGRUPINDIRIMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<MALZEMEGRUPINDIRIMLER>
        {
            Dictionary<Decimal, MALZEMEGRUPINDIRIMLER> dict = new Dictionary<Decimal, MALZEMEGRUPINDIRIMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<MALZEMEGRUPINDIRIMLER> items) : base(items) { }


            public MALZEMEGRUPINDIRIMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public MALZEMEGRUPINDIRIMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MALZEMEGRUPINDIRIMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MALZEMEGRUPINDIRIMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(MALZEMEGRUPINDIRIMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(MALZEMEGRUPINDIRIMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<MALZEMEGRUPINDIRIMLER> Select
        {
            get { return R.Query<MALZEMEGRUPINDIRIMLER>(); }
        }

        public static MALZEMEGRUPINDIRIMLER SelectItem(Decimal ID)
        {
            return R.Query<MALZEMEGRUPINDIRIMLER>().First(t => t.ID == ID);
        }

        public static List<MALZEMEGRUPINDIRIMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MALZEMEGRUPINDIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MALZEMEGRUPINDIRIMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MALZEMEGRUPINDIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

