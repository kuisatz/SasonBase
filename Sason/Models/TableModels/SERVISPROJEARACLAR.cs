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
    public class SERVISPROJEARACLAR : SasonBase.Sason.Tables.Table_SERVISPROJEARACLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISPROJEARACLAR>
        {
            Dictionary<Decimal, SERVISPROJEARACLAR> dict = new Dictionary<Decimal, SERVISPROJEARACLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISPROJEARACLAR> items) : base(items) { }


            public SERVISPROJEARACLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISPROJEARACLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISPROJEARACLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISPROJEARACLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISPROJEARACLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISPROJEARACLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISPROJEARACLAR> Select
        {
            get { return R.Query<SERVISPROJEARACLAR>(); }
        }

        public static SERVISPROJEARACLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISPROJEARACLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISPROJEARACLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISPROJEARACLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISPROJEARACLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISPROJEARACLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

