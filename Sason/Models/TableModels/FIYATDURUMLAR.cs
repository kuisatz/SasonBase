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
    public class FIYATDURUMLAR : SasonBase.Sason.Tables.Table_FIYATDURUMLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<FIYATDURUMLAR>
        {
            Dictionary<Decimal, FIYATDURUMLAR> dict = new Dictionary<Decimal, FIYATDURUMLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<FIYATDURUMLAR> items) : base(items) { }


            public FIYATDURUMLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public FIYATDURUMLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<FIYATDURUMLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<FIYATDURUMLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(FIYATDURUMLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(FIYATDURUMLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<FIYATDURUMLAR> Select
        {
            get { return R.Query<FIYATDURUMLAR>(); }
        }

        public static FIYATDURUMLAR SelectItem(Decimal ID)
        {
            return R.Query<FIYATDURUMLAR>().First(t => t.ID == ID);
        }

        public static List<FIYATDURUMLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<FIYATDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<FIYATDURUMLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<FIYATDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

