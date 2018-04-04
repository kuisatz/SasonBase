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
    public class SERVISSTOKGRUPLAR : SasonBase.Sason.Tables.Table_SERVISSTOKGRUPLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSTOKGRUPLAR>
        {
            Dictionary<Decimal, SERVISSTOKGRUPLAR> dict = new Dictionary<Decimal, SERVISSTOKGRUPLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSTOKGRUPLAR> items) : base(items) { }


            public SERVISSTOKGRUPLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSTOKGRUPLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSTOKGRUPLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSTOKGRUPLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSTOKGRUPLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSTOKGRUPLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSTOKGRUPLAR> Select
        {
            get { return R.Query<SERVISSTOKGRUPLAR>(); }
        }

        public static SERVISSTOKGRUPLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISSTOKGRUPLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISSTOKGRUPLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSTOKGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSTOKGRUPLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSTOKGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

