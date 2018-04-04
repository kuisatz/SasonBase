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
    public class SERVISSTOKHAREKETLER : SasonBase.Sason.Tables.Table_SERVISSTOKHAREKETLER.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSTOKHAREKETLER>
        {
            Dictionary<Decimal, SERVISSTOKHAREKETLER> dict = new Dictionary<Decimal, SERVISSTOKHAREKETLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSTOKHAREKETLER> items) : base(items) { }


            public SERVISSTOKHAREKETLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSTOKHAREKETLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSTOKHAREKETLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSTOKHAREKETLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSTOKHAREKETLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSTOKHAREKETLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSTOKHAREKETLER> Select
        {
            get { return R.Query<SERVISSTOKHAREKETLER>(); }
        }

        public static SERVISSTOKHAREKETLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISSTOKHAREKETLER>().First(t => t.ID == ID);
        }

        public static List<SERVISSTOKHAREKETLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSTOKHAREKETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSTOKHAREKETLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSTOKHAREKETLER>().Where(t => t.ID.In(IDs)).ToList();
        }


    }
}

