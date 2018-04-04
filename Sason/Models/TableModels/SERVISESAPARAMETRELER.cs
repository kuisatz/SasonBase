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
    public class SERVISESAPARAMETRELER : SasonBase.Sason.Tables.Table_SERVISESAPARAMETRELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISESAPARAMETRELER>
        {
            Dictionary<Decimal, SERVISESAPARAMETRELER> dict = new Dictionary<Decimal, SERVISESAPARAMETRELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISESAPARAMETRELER> items) : base(items) { }


            public SERVISESAPARAMETRELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISESAPARAMETRELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISESAPARAMETRELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISESAPARAMETRELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISESAPARAMETRELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISESAPARAMETRELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISESAPARAMETRELER> Select
        {
            get { return R.Query<SERVISESAPARAMETRELER>(); }
        }

        public static SERVISESAPARAMETRELER SelectItem(Decimal ID)
        {
            return R.Query<SERVISESAPARAMETRELER>().First(t => t.ID == ID);
        }

        public static List<SERVISESAPARAMETRELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISESAPARAMETRELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISESAPARAMETRELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISESAPARAMETRELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

