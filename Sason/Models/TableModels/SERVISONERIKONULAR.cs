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
    public class SERVISONERIKONULAR : SasonBase.Sason.Tables.Table_SERVISONERIKONULAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISONERIKONULAR>
        {
            Dictionary<Decimal, SERVISONERIKONULAR> dict = new Dictionary<Decimal, SERVISONERIKONULAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISONERIKONULAR> items) : base(items) { }


            public SERVISONERIKONULAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISONERIKONULAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISONERIKONULAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISONERIKONULAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISONERIKONULAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISONERIKONULAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISONERIKONULAR> Select
        {
            get { return R.Query<SERVISONERIKONULAR>(); }
        }

        public static SERVISONERIKONULAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISONERIKONULAR>().First(t => t.ID == ID);
        }

        public static List<SERVISONERIKONULAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISONERIKONULAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISONERIKONULAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISONERIKONULAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

