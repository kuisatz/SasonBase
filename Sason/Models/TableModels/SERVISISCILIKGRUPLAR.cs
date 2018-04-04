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
    public class SERVISISCILIKGRUPLAR : SasonBase.Sason.Tables.Table_SERVISISCILIKGRUPLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISCILIKGRUPLAR>
        {
            Dictionary<Decimal, SERVISISCILIKGRUPLAR> dict = new Dictionary<Decimal, SERVISISCILIKGRUPLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISCILIKGRUPLAR> items) : base(items) { }


            public SERVISISCILIKGRUPLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISCILIKGRUPLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISCILIKGRUPLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISCILIKGRUPLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISCILIKGRUPLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISCILIKGRUPLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISCILIKGRUPLAR> Select
        {
            get { return R.Query<SERVISISCILIKGRUPLAR>(); }
        }

        public static SERVISISCILIKGRUPLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISISCILIKGRUPLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISISCILIKGRUPLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISCILIKGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISCILIKGRUPLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISCILIKGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

