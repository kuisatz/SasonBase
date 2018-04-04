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
    public class KONTAKTELEFONLAR : SasonBase.Sason.Tables.Table_KONTAKTELEFONLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<KONTAKTELEFONLAR>
        {
            Dictionary<Decimal, KONTAKTELEFONLAR> dict = new Dictionary<Decimal, KONTAKTELEFONLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<KONTAKTELEFONLAR> items) : base(items) { }


            public KONTAKTELEFONLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public KONTAKTELEFONLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<KONTAKTELEFONLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<KONTAKTELEFONLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(KONTAKTELEFONLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(KONTAKTELEFONLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<KONTAKTELEFONLAR> Select
        {
            get { return R.Query<KONTAKTELEFONLAR>(); }
        }

        public static KONTAKTELEFONLAR SelectItem(Decimal ID)
        {
            return R.Query<KONTAKTELEFONLAR>().First(t => t.ID == ID);
        }

        public static List<KONTAKTELEFONLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<KONTAKTELEFONLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<KONTAKTELEFONLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<KONTAKTELEFONLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

