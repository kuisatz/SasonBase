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
    public class SERVISONERILER : SasonBase.Sason.Tables.Table_SERVISONERILER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISONERILER>
        {
            Dictionary<Decimal, SERVISONERILER> dict = new Dictionary<Decimal, SERVISONERILER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISONERILER> items) : base(items) { }


            public SERVISONERILER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISONERILER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISONERILER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISONERILER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISONERILER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISONERILER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISONERILER> Select
        {
            get { return R.Query<SERVISONERILER>(); }
        }

        public static SERVISONERILER SelectItem(Decimal ID)
        {
            return R.Query<SERVISONERILER>().First(t => t.ID == ID);
        }

        public static List<SERVISONERILER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISONERILER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISONERILER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISONERILER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

