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
    public class SERVISISORTAKKONTAKTIPLER : SasonBase.Sason.Tables.Table_SERVISISORTAKKONTAKTIPLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISORTAKKONTAKTIPLER>
        {
            Dictionary<Decimal, SERVISISORTAKKONTAKTIPLER> dict = new Dictionary<Decimal, SERVISISORTAKKONTAKTIPLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISORTAKKONTAKTIPLER> items) : base(items) { }


            public SERVISISORTAKKONTAKTIPLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISORTAKKONTAKTIPLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISORTAKKONTAKTIPLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISORTAKKONTAKTIPLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISORTAKKONTAKTIPLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISORTAKKONTAKTIPLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISORTAKKONTAKTIPLER> Select
        {
            get { return R.Query<SERVISISORTAKKONTAKTIPLER>(); }
        }

        public static SERVISISORTAKKONTAKTIPLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISISORTAKKONTAKTIPLER>().First(t => t.ID == ID);
        }

        public static List<SERVISISORTAKKONTAKTIPLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISORTAKKONTAKTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISORTAKKONTAKTIPLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISORTAKKONTAKTIPLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

