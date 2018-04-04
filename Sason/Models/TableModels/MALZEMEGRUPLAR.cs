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
    public class MALZEMEGRUPLAR : SasonBase.Sason.Tables.Table_MALZEMEGRUPLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<MALZEMEGRUPLAR>
        {
            Dictionary<Decimal, MALZEMEGRUPLAR> dict = new Dictionary<Decimal, MALZEMEGRUPLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<MALZEMEGRUPLAR> items) : base(items) { }


            public MALZEMEGRUPLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public MALZEMEGRUPLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MALZEMEGRUPLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MALZEMEGRUPLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(MALZEMEGRUPLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(MALZEMEGRUPLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<MALZEMEGRUPLAR> Select
        {
            get { return R.Query<MALZEMEGRUPLAR>(); }
        }

        public static MALZEMEGRUPLAR SelectItem(Decimal ID)
        {
            return R.Query<MALZEMEGRUPLAR>().First(t => t.ID == ID);
        }

        public static List<MALZEMEGRUPLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MALZEMEGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MALZEMEGRUPLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MALZEMEGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

