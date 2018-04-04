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
    public class MALZEMEFGRUPINDIRIMLER : SasonBase.Sason.Tables.Table_MALZEMEFGRUPINDIRIMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<MALZEMEFGRUPINDIRIMLER>
        {
            Dictionary<Decimal, MALZEMEFGRUPINDIRIMLER> dict = new Dictionary<Decimal, MALZEMEFGRUPINDIRIMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<MALZEMEFGRUPINDIRIMLER> items) : base(items) { }


            public MALZEMEFGRUPINDIRIMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public MALZEMEFGRUPINDIRIMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MALZEMEFGRUPINDIRIMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MALZEMEFGRUPINDIRIMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(MALZEMEFGRUPINDIRIMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(MALZEMEFGRUPINDIRIMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<MALZEMEFGRUPINDIRIMLER> Select
        {
            get { return R.Query<MALZEMEFGRUPINDIRIMLER>(); }
        }

        public static MALZEMEFGRUPINDIRIMLER SelectItem(Decimal ID)
        {
            return R.Query<MALZEMEFGRUPINDIRIMLER>().First(t => t.ID == ID);
        }

        public static List<MALZEMEFGRUPINDIRIMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MALZEMEFGRUPINDIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MALZEMEFGRUPINDIRIMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MALZEMEFGRUPINDIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

