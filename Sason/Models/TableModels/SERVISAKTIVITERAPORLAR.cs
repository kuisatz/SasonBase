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
    public class SERVISAKTIVITERAPORLAR : SasonBase.Sason.Tables.Table_SERVISAKTIVITERAPORLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISAKTIVITERAPORLAR>
        {
            Dictionary<Decimal, SERVISAKTIVITERAPORLAR> dict = new Dictionary<Decimal, SERVISAKTIVITERAPORLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISAKTIVITERAPORLAR> items) : base(items) { }


            public SERVISAKTIVITERAPORLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISAKTIVITERAPORLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISAKTIVITERAPORLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISAKTIVITERAPORLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISAKTIVITERAPORLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISAKTIVITERAPORLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISAKTIVITERAPORLAR> Select
        {
            get { return R.Query<SERVISAKTIVITERAPORLAR>(); }
        }

        public static SERVISAKTIVITERAPORLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISAKTIVITERAPORLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISAKTIVITERAPORLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISAKTIVITERAPORLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISAKTIVITERAPORLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISAKTIVITERAPORLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

