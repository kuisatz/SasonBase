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
    public class FORMKONULAR : SasonBase.Sason.Tables.Table_FORMKONULAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<FORMKONULAR>
        {
            Dictionary<Decimal, FORMKONULAR> dict = new Dictionary<Decimal, FORMKONULAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<FORMKONULAR> items) : base(items) { }


            public FORMKONULAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public FORMKONULAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<FORMKONULAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<FORMKONULAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(FORMKONULAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(FORMKONULAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<FORMKONULAR> Select
        {
            get { return R.Query<FORMKONULAR>(); }
        }

        public static FORMKONULAR SelectItem(Decimal ID)
        {
            return R.Query<FORMKONULAR>().First(t => t.ID == ID);
        }

        public static List<FORMKONULAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<FORMKONULAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<FORMKONULAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<FORMKONULAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

