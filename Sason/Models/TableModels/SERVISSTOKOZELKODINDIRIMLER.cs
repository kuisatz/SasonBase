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
    public class SERVISSTOKOZELKODINDIRIMLER : SasonBase.Sason.Tables.Table_SERVISSTOKOZELKODINDIRIMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSTOKOZELKODINDIRIMLER>
        {
            Dictionary<Decimal, SERVISSTOKOZELKODINDIRIMLER> dict = new Dictionary<Decimal, SERVISSTOKOZELKODINDIRIMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSTOKOZELKODINDIRIMLER> items) : base(items) { }


            public SERVISSTOKOZELKODINDIRIMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSTOKOZELKODINDIRIMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSTOKOZELKODINDIRIMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSTOKOZELKODINDIRIMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSTOKOZELKODINDIRIMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSTOKOZELKODINDIRIMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSTOKOZELKODINDIRIMLER> Select
        {
            get { return R.Query<SERVISSTOKOZELKODINDIRIMLER>(); }
        }

        public static SERVISSTOKOZELKODINDIRIMLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISSTOKOZELKODINDIRIMLER>().First(t => t.ID == ID);
        }

        public static List<SERVISSTOKOZELKODINDIRIMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSTOKOZELKODINDIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSTOKOZELKODINDIRIMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSTOKOZELKODINDIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

