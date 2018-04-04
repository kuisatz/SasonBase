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
    public class ISORTAKKONTAKLAR : SasonBase.Sason.Tables.Table_ISORTAKKONTAKLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISORTAKKONTAKLAR>
        {
            Dictionary<Decimal, ISORTAKKONTAKLAR> dict = new Dictionary<Decimal, ISORTAKKONTAKLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISORTAKKONTAKLAR> items) : base(items) { }


            public ISORTAKKONTAKLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISORTAKKONTAKLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISORTAKKONTAKLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISORTAKKONTAKLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISORTAKKONTAKLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISORTAKKONTAKLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISORTAKKONTAKLAR> Select
        {
            get { return R.Query<ISORTAKKONTAKLAR>(); }
        }

        public static ISORTAKKONTAKLAR SelectItem(Decimal ID)
        {
            return R.Query<ISORTAKKONTAKLAR>().First(t => t.ID == ID);
        }

        public static List<ISORTAKKONTAKLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISORTAKKONTAKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISORTAKKONTAKLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISORTAKKONTAKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

