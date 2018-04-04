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
    public class SIKAYETDURUMLAR : SasonBase.Sason.Tables.Table_SIKAYETDURUMLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SIKAYETDURUMLAR>
        {
            Dictionary<Decimal, SIKAYETDURUMLAR> dict = new Dictionary<Decimal, SIKAYETDURUMLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SIKAYETDURUMLAR> items) : base(items) { }


            public SIKAYETDURUMLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SIKAYETDURUMLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SIKAYETDURUMLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SIKAYETDURUMLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SIKAYETDURUMLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SIKAYETDURUMLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SIKAYETDURUMLAR> Select
        {
            get { return R.Query<SIKAYETDURUMLAR>(); }
        }

        public static SIKAYETDURUMLAR SelectItem(Decimal ID)
        {
            return R.Query<SIKAYETDURUMLAR>().First(t => t.ID == ID);
        }

        public static List<SIKAYETDURUMLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SIKAYETDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SIKAYETDURUMLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SIKAYETDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

