using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;
using System.Collections;

namespace SasonBase.Sason.Models.TableModels
{
    [Serializable()]
    public class BAKIMKONTROLKALEMLER : SasonBase.Sason.Tables.Table_BAKIMKONTROLKALEMLER.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMKONTROLKALEMLER>
        {
            Dictionary<Decimal, BAKIMKONTROLKALEMLER> dict = new Dictionary<Decimal, BAKIMKONTROLKALEMLER>();
            

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMKONTROLKALEMLER> items) : base(items) { }


            public BAKIMKONTROLKALEMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMKONTROLKALEMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMKONTROLKALEMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMKONTROLKALEMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public BAKIMKONTROLKALEMLER GetFromKod(string kod)
            {
                return Items.first(t => t.KOD.removeTrChars().like(kod));
            }

            protected override void OnBeforeInsert(BAKIMKONTROLKALEMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMKONTROLKALEMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMKONTROLKALEMLER> Select
        {
            get { return R.Query<BAKIMKONTROLKALEMLER>(); }
        }

        public static BAKIMKONTROLKALEMLER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMKONTROLKALEMLER>().First(t => t.ID == ID);
        }

        public static List<BAKIMKONTROLKALEMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMKONTROLKALEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMKONTROLKALEMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMKONTROLKALEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

