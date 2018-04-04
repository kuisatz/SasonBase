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
    public class OTOBUSGRUPLAR : SasonBase.Sason.Tables.Table_OTOBUSGRUPLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<OTOBUSGRUPLAR>
        {
            Dictionary<Decimal, OTOBUSGRUPLAR> dict = new Dictionary<Decimal, OTOBUSGRUPLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<OTOBUSGRUPLAR> items) : base(items) { }


            public OTOBUSGRUPLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public OTOBUSGRUPLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<OTOBUSGRUPLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<OTOBUSGRUPLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(OTOBUSGRUPLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(OTOBUSGRUPLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<OTOBUSGRUPLAR> Select
        {
            get { return R.Query<OTOBUSGRUPLAR>(); }
        }

        public static OTOBUSGRUPLAR SelectItem(Decimal ID)
        {
            return R.Query<OTOBUSGRUPLAR>().First(t => t.ID == ID);
        }

        public static List<OTOBUSGRUPLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<OTOBUSGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<OTOBUSGRUPLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<OTOBUSGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

