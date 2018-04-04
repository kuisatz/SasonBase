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
    public class ESAGARANTILER : SasonBase.Sason.Tables.Table_ESAGARANTILER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ESAGARANTILER>
        {
            Dictionary<Decimal, ESAGARANTILER> dict = new Dictionary<Decimal, ESAGARANTILER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ESAGARANTILER> items) : base(items) { }


            public ESAGARANTILER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ESAGARANTILER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ESAGARANTILER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ESAGARANTILER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ESAGARANTILER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ESAGARANTILER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ESAGARANTILER> Select
        {
            get { return R.Query<ESAGARANTILER>(); }
        }

        public static ESAGARANTILER SelectItem(Decimal ID)
        {
            return R.Query<ESAGARANTILER>().First(t => t.ID == ID);
        }

        public static List<ESAGARANTILER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ESAGARANTILER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ESAGARANTILER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ESAGARANTILER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

