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
    public class SERVISSTOKFIYATLAR : SasonBase.Sason.Tables.Table_SERVISSTOKFIYATLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSTOKFIYATLAR>
        {
            Dictionary<Decimal, SERVISSTOKFIYATLAR> dict = new Dictionary<Decimal, SERVISSTOKFIYATLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSTOKFIYATLAR> items) : base(items) { }


            public SERVISSTOKFIYATLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSTOKFIYATLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSTOKFIYATLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSTOKFIYATLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSTOKFIYATLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSTOKFIYATLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSTOKFIYATLAR> Select
        {
            get { return R.Query<SERVISSTOKFIYATLAR>(); }
        }

        public static SERVISSTOKFIYATLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISSTOKFIYATLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISSTOKFIYATLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSTOKFIYATLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSTOKFIYATLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSTOKFIYATLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

