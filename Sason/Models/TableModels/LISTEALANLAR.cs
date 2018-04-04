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
    public class LISTEALANLAR : SasonBase.Sason.Tables.Table_LISTEALANLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<LISTEALANLAR>
        {
            Dictionary<Decimal, LISTEALANLAR> dict = new Dictionary<Decimal, LISTEALANLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<LISTEALANLAR> items) : base(items) { }


            public LISTEALANLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public LISTEALANLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<LISTEALANLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<LISTEALANLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(LISTEALANLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(LISTEALANLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<LISTEALANLAR> Select
        {
            get { return R.Query<LISTEALANLAR>(); }
        }

        public static LISTEALANLAR SelectItem(Decimal ID)
        {
            return R.Query<LISTEALANLAR>().First(t => t.ID == ID);
        }

        public static List<LISTEALANLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<LISTEALANLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<LISTEALANLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<LISTEALANLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

