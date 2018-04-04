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
    public class ESAIYINIYETGARANTIDURUMLAR : SasonBase.Sason.Tables.Table_ESAIYINIYETGARANTIDURUMLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ESAIYINIYETGARANTIDURUMLAR>
        {
            Dictionary<Decimal, ESAIYINIYETGARANTIDURUMLAR> dict = new Dictionary<Decimal, ESAIYINIYETGARANTIDURUMLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ESAIYINIYETGARANTIDURUMLAR> items) : base(items) { }


            public ESAIYINIYETGARANTIDURUMLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ESAIYINIYETGARANTIDURUMLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ESAIYINIYETGARANTIDURUMLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ESAIYINIYETGARANTIDURUMLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ESAIYINIYETGARANTIDURUMLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ESAIYINIYETGARANTIDURUMLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ESAIYINIYETGARANTIDURUMLAR> Select
        {
            get { return R.Query<ESAIYINIYETGARANTIDURUMLAR>(); }
        }

        public static ESAIYINIYETGARANTIDURUMLAR SelectItem(Decimal ID)
        {
            return R.Query<ESAIYINIYETGARANTIDURUMLAR>().First(t => t.ID == ID);
        }

        public static List<ESAIYINIYETGARANTIDURUMLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ESAIYINIYETGARANTIDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ESAIYINIYETGARANTIDURUMLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ESAIYINIYETGARANTIDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

