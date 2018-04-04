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
    public class SERVISISORTAKTELEFONLAR : SasonBase.Sason.Tables.Table_SERVISISORTAKTELEFONLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISORTAKTELEFONLAR>
        {
            Dictionary<Decimal, SERVISISORTAKTELEFONLAR> dict = new Dictionary<Decimal, SERVISISORTAKTELEFONLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISORTAKTELEFONLAR> items) : base(items) { }


            public SERVISISORTAKTELEFONLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISORTAKTELEFONLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISORTAKTELEFONLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISORTAKTELEFONLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISORTAKTELEFONLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISORTAKTELEFONLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISORTAKTELEFONLAR> Select
        {
            get { return R.Query<SERVISISORTAKTELEFONLAR>(); }
        }

        public static SERVISISORTAKTELEFONLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISISORTAKTELEFONLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISISORTAKTELEFONLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISORTAKTELEFONLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISORTAKTELEFONLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISORTAKTELEFONLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

