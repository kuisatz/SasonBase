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
    public class SERVISARACLAR : SasonBase.Sason.Tables.Table_SERVISARACLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISARACLAR>
        {
            Dictionary<Decimal, SERVISARACLAR> dict = new Dictionary<Decimal, SERVISARACLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISARACLAR> items) : base(items) { }


            public SERVISARACLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISARACLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISARACLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISARACLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISARACLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISARACLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISARACLAR> Select
        {
            get { return R.Query<SERVISARACLAR>(); }
        }

        public static SERVISARACLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISARACLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISARACLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISARACLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISARACLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISARACLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

