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
    public class MALZEMEFGRUPLAR : SasonBase.Sason.Tables.Table_MALZEMEFGRUPLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<MALZEMEFGRUPLAR>
        {
            Dictionary<Decimal, MALZEMEFGRUPLAR> dict = new Dictionary<Decimal, MALZEMEFGRUPLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<MALZEMEFGRUPLAR> items) : base(items) { }


            public MALZEMEFGRUPLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public MALZEMEFGRUPLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MALZEMEFGRUPLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MALZEMEFGRUPLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(MALZEMEFGRUPLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(MALZEMEFGRUPLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<MALZEMEFGRUPLAR> Select
        {
            get { return R.Query<MALZEMEFGRUPLAR>(); }
        }

        public static MALZEMEFGRUPLAR SelectItem(Decimal ID)
        {
            return R.Query<MALZEMEFGRUPLAR>().First(t => t.ID == ID);
        }

        public static List<MALZEMEFGRUPLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MALZEMEFGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MALZEMEFGRUPLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MALZEMEFGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

