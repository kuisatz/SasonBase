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
    public class SERVISRANDEVULAR : SasonBase.Sason.Tables.Table_SERVISRANDEVULAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISRANDEVULAR>
        {
            Dictionary<Decimal, SERVISRANDEVULAR> dict = new Dictionary<Decimal, SERVISRANDEVULAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISRANDEVULAR> items) : base(items) { }


            public SERVISRANDEVULAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISRANDEVULAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISRANDEVULAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISRANDEVULAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISRANDEVULAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISRANDEVULAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISRANDEVULAR> Select
        {
            get { return R.Query<SERVISRANDEVULAR>(); }
        }

        public static SERVISRANDEVULAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISRANDEVULAR>().First(t => t.ID == ID);
        }

        public static List<SERVISRANDEVULAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISRANDEVULAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISRANDEVULAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISRANDEVULAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

