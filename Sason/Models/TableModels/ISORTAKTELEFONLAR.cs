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
    public class ISORTAKTELEFONLAR : SasonBase.Sason.Tables.Table_ISORTAKTELEFONLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISORTAKTELEFONLAR>
        {
            Dictionary<Decimal, ISORTAKTELEFONLAR> dict = new Dictionary<Decimal, ISORTAKTELEFONLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISORTAKTELEFONLAR> items) : base(items) { }


            public ISORTAKTELEFONLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISORTAKTELEFONLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISORTAKTELEFONLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISORTAKTELEFONLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISORTAKTELEFONLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISORTAKTELEFONLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISORTAKTELEFONLAR> Select
        {
            get { return R.Query<ISORTAKTELEFONLAR>(); }
        }

        public static ISORTAKTELEFONLAR SelectItem(Decimal ID)
        {
            return R.Query<ISORTAKTELEFONLAR>().First(t => t.ID == ID);
        }

        public static List<ISORTAKTELEFONLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISORTAKTELEFONLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISORTAKTELEFONLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISORTAKTELEFONLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

