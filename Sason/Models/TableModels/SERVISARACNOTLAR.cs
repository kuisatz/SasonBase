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
    public class SERVISARACNOTLAR : SasonBase.Sason.Tables.Table_SERVISARACNOTLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISARACNOTLAR>
        {
            Dictionary<Decimal, SERVISARACNOTLAR> dict = new Dictionary<Decimal, SERVISARACNOTLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISARACNOTLAR> items) : base(items) { }


            public SERVISARACNOTLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISARACNOTLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISARACNOTLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISARACNOTLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISARACNOTLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISARACNOTLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISARACNOTLAR> Select
        {
            get { return R.Query<SERVISARACNOTLAR>(); }
        }

        public static SERVISARACNOTLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISARACNOTLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISARACNOTLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISARACNOTLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISARACNOTLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISARACNOTLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

