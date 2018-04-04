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
    public class ESAIYINIYETGARANTILER : SasonBase.Sason.Tables.Table_ESAIYINIYETGARANTILER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ESAIYINIYETGARANTILER>
        {
            Dictionary<Decimal, ESAIYINIYETGARANTILER> dict = new Dictionary<Decimal, ESAIYINIYETGARANTILER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ESAIYINIYETGARANTILER> items) : base(items) { }


            public ESAIYINIYETGARANTILER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ESAIYINIYETGARANTILER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ESAIYINIYETGARANTILER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ESAIYINIYETGARANTILER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ESAIYINIYETGARANTILER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ESAIYINIYETGARANTILER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ESAIYINIYETGARANTILER> Select
        {
            get { return R.Query<ESAIYINIYETGARANTILER>(); }
        }

        public static ESAIYINIYETGARANTILER SelectItem(Decimal ID)
        {
            return R.Query<ESAIYINIYETGARANTILER>().First(t => t.ID == ID);
        }

        public static List<ESAIYINIYETGARANTILER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ESAIYINIYETGARANTILER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ESAIYINIYETGARANTILER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ESAIYINIYETGARANTILER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

