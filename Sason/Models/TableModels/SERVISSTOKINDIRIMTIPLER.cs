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
    public class SERVISSTOKINDIRIMTIPLER : SasonBase.Sason.Tables.Table_SERVISSTOKINDIRIMTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSTOKINDIRIMTIPLER>
        {
            Dictionary<Decimal, SERVISSTOKINDIRIMTIPLER> dict = new Dictionary<Decimal, SERVISSTOKINDIRIMTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSTOKINDIRIMTIPLER> items) : base(items) { }


            public SERVISSTOKINDIRIMTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSTOKINDIRIMTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSTOKINDIRIMTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSTOKINDIRIMTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSTOKINDIRIMTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSTOKINDIRIMTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSTOKINDIRIMTIPLER> Select
        {
            get { return R.Query<SERVISSTOKINDIRIMTIPLER>(); }
        }

        public static SERVISSTOKINDIRIMTIPLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISSTOKINDIRIMTIPLER>().First(t => t.ID == ID);
        }

        public static List<SERVISSTOKINDIRIMTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSTOKINDIRIMTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSTOKINDIRIMTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSTOKINDIRIMTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

