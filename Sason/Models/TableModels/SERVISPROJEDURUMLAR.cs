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
    public class SERVISPROJEDURUMLAR : SasonBase.Sason.Tables.Table_SERVISPROJEDURUMLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISPROJEDURUMLAR>
        {
            Dictionary<Decimal, SERVISPROJEDURUMLAR> dict = new Dictionary<Decimal, SERVISPROJEDURUMLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISPROJEDURUMLAR> items) : base(items) { }


            public SERVISPROJEDURUMLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISPROJEDURUMLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISPROJEDURUMLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISPROJEDURUMLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISPROJEDURUMLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISPROJEDURUMLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISPROJEDURUMLAR> Select
        {
            get { return R.Query<SERVISPROJEDURUMLAR>(); }
        }

        public static SERVISPROJEDURUMLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISPROJEDURUMLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISPROJEDURUMLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISPROJEDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISPROJEDURUMLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISPROJEDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

