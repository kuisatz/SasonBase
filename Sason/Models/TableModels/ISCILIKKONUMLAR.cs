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
    public class ISCILIKKONUMLAR : SasonBase.Sason.Tables.Table_ISCILIKKONUMLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISCILIKKONUMLAR>
        {
            Dictionary<Decimal, ISCILIKKONUMLAR> dict = new Dictionary<Decimal, ISCILIKKONUMLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISCILIKKONUMLAR> items) : base(items) { }


            public ISCILIKKONUMLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISCILIKKONUMLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISCILIKKONUMLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISCILIKKONUMLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISCILIKKONUMLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISCILIKKONUMLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISCILIKKONUMLAR> Select
        {
            get { return R.Query<ISCILIKKONUMLAR>(); }
        }

        public static ISCILIKKONUMLAR SelectItem(Decimal ID)
        {
            return R.Query<ISCILIKKONUMLAR>().First(t => t.ID == ID);
        }

        public static List<ISCILIKKONUMLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISCILIKKONUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISCILIKKONUMLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISCILIKKONUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

