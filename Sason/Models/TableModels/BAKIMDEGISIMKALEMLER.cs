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
    public class BAKIMDEGISIMKALEMLER : SasonBase.Sason.Tables.Table_BAKIMDEGISIMKALEMLER.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMDEGISIMKALEMLER>
        {
            Dictionary<Decimal, BAKIMDEGISIMKALEMLER> dict = new Dictionary<Decimal, BAKIMDEGISIMKALEMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMDEGISIMKALEMLER> items) : base(items) { }


            public BAKIMDEGISIMKALEMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMDEGISIMKALEMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMDEGISIMKALEMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMDEGISIMKALEMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public BAKIMDEGISIMKALEMLER GetFromCode(string kod)
            {
                return Items.first(t => t.KOD.removeTrChars().like(kod.removeTrChars()));
            }

            protected override void OnBeforeInsert(BAKIMDEGISIMKALEMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMDEGISIMKALEMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMDEGISIMKALEMLER> Select
        {
            get { return R.Query<BAKIMDEGISIMKALEMLER>(); }
        }

        public static BAKIMDEGISIMKALEMLER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMDEGISIMKALEMLER>().First(t => t.ID == ID);
        }

        public static List<BAKIMDEGISIMKALEMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMDEGISIMKALEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMDEGISIMKALEMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMDEGISIMKALEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

