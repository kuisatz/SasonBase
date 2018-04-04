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
    public class KONTAKLAR : SasonBase.Sason.Tables.Table_KONTAKLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<KONTAKLAR>
        {
            Dictionary<Decimal, KONTAKLAR> dict = new Dictionary<Decimal, KONTAKLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<KONTAKLAR> items) : base(items) { }


            public KONTAKLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public KONTAKLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<KONTAKLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<KONTAKLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(KONTAKLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(KONTAKLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<KONTAKLAR> Select
        {
            get { return R.Query<KONTAKLAR>(); }
        }

        public static KONTAKLAR SelectItem(Decimal ID)
        {
            return R.Query<KONTAKLAR>().First(t => t.ID == ID);
        }

        public static List<KONTAKLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<KONTAKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<KONTAKLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<KONTAKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

