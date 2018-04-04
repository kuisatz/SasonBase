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
    public class YANSANAYIURETICILER : SasonBase.Sason.Tables.Table_YANSANAYIURETICILER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<YANSANAYIURETICILER>
        {
            Dictionary<Decimal, YANSANAYIURETICILER> dict = new Dictionary<Decimal, YANSANAYIURETICILER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<YANSANAYIURETICILER> items) : base(items) { }


            public YANSANAYIURETICILER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public YANSANAYIURETICILER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<YANSANAYIURETICILER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<YANSANAYIURETICILER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(YANSANAYIURETICILER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(YANSANAYIURETICILER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<YANSANAYIURETICILER> Select
        {
            get { return R.Query<YANSANAYIURETICILER>(); }
        }

        public static YANSANAYIURETICILER SelectItem(Decimal ID)
        {
            return R.Query<YANSANAYIURETICILER>().First(t => t.ID == ID);
        }

        public static List<YANSANAYIURETICILER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<YANSANAYIURETICILER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<YANSANAYIURETICILER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<YANSANAYIURETICILER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

