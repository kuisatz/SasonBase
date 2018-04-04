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
    public class SERVISDISHIZMETALIMLAR : SasonBase.Sason.Tables.Table_SERVISDISHIZMETALIMLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISDISHIZMETALIMLAR>
        {
            Dictionary<Decimal, SERVISDISHIZMETALIMLAR> dict = new Dictionary<Decimal, SERVISDISHIZMETALIMLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISDISHIZMETALIMLAR> items) : base(items) { }


            public SERVISDISHIZMETALIMLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISDISHIZMETALIMLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISDISHIZMETALIMLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISDISHIZMETALIMLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISDISHIZMETALIMLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISDISHIZMETALIMLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISDISHIZMETALIMLAR> Select
        {
            get { return R.Query<SERVISDISHIZMETALIMLAR>(); }
        }

        public static SERVISDISHIZMETALIMLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISDISHIZMETALIMLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISDISHIZMETALIMLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISDISHIZMETALIMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISDISHIZMETALIMLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISDISHIZMETALIMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

