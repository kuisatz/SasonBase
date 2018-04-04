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
    public class SERVISISORTAKKONTAKLAR : SasonBase.Sason.Tables.Table_SERVISISORTAKKONTAKLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISORTAKKONTAKLAR>
        {
            Dictionary<Decimal, SERVISISORTAKKONTAKLAR> dict = new Dictionary<Decimal, SERVISISORTAKKONTAKLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISORTAKKONTAKLAR> items) : base(items) { }


            public SERVISISORTAKKONTAKLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISORTAKKONTAKLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISORTAKKONTAKLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISORTAKKONTAKLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISORTAKKONTAKLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISORTAKKONTAKLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISORTAKKONTAKLAR> Select
        {
            get { return R.Query<SERVISISORTAKKONTAKLAR>(); }
        }

        public static SERVISISORTAKKONTAKLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISISORTAKKONTAKLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISISORTAKKONTAKLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISORTAKKONTAKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISORTAKKONTAKLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISORTAKKONTAKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

