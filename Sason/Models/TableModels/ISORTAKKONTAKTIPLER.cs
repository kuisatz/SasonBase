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
    public class ISORTAKKONTAKTIPLER : SasonBase.Sason.Tables.Table_ISORTAKKONTAKTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISORTAKKONTAKTIPLER>
        {
            Dictionary<Decimal, ISORTAKKONTAKTIPLER> dict = new Dictionary<Decimal, ISORTAKKONTAKTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISORTAKKONTAKTIPLER> items) : base(items) { }


            public ISORTAKKONTAKTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISORTAKKONTAKTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISORTAKKONTAKTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISORTAKKONTAKTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISORTAKKONTAKTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISORTAKKONTAKTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISORTAKKONTAKTIPLER> Select
        {
            get { return R.Query<ISORTAKKONTAKTIPLER>(); }
        }

        public static ISORTAKKONTAKTIPLER SelectItem(Decimal ID)
        {
            return R.Query<ISORTAKKONTAKTIPLER>().First(t => t.ID == ID);
        }

        public static List<ISORTAKKONTAKTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISORTAKKONTAKTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISORTAKKONTAKTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISORTAKKONTAKTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

