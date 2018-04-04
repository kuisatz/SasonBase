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
    public class SERVISSTOKOZELKODLAR : SasonBase.Sason.Tables.Table_SERVISSTOKOZELKODLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSTOKOZELKODLAR>
        {
            Dictionary<Decimal, SERVISSTOKOZELKODLAR> dict = new Dictionary<Decimal, SERVISSTOKOZELKODLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSTOKOZELKODLAR> items) : base(items) { }


            public SERVISSTOKOZELKODLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSTOKOZELKODLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSTOKOZELKODLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSTOKOZELKODLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSTOKOZELKODLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSTOKOZELKODLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSTOKOZELKODLAR> Select
        {
            get { return R.Query<SERVISSTOKOZELKODLAR>(); }
        }

        public static SERVISSTOKOZELKODLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISSTOKOZELKODLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISSTOKOZELKODLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSTOKOZELKODLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSTOKOZELKODLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSTOKOZELKODLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

