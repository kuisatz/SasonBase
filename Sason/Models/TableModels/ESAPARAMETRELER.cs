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
    public class ESAPARAMETRELER : SasonBase.Sason.Tables.Table_ESAPARAMETRELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ESAPARAMETRELER>
        {
            Dictionary<Decimal, ESAPARAMETRELER> dict = new Dictionary<Decimal, ESAPARAMETRELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ESAPARAMETRELER> items) : base(items) { }


            public ESAPARAMETRELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ESAPARAMETRELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ESAPARAMETRELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ESAPARAMETRELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ESAPARAMETRELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ESAPARAMETRELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ESAPARAMETRELER> Select
        {
            get { return R.Query<ESAPARAMETRELER>(); }
        }

        public static ESAPARAMETRELER SelectItem(Decimal ID)
        {
            return R.Query<ESAPARAMETRELER>().First(t => t.ID == ID);
        }

        public static List<ESAPARAMETRELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ESAPARAMETRELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ESAPARAMETRELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ESAPARAMETRELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

