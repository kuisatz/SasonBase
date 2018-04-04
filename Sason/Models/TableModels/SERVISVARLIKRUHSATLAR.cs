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
    public class SERVISVARLIKRUHSATLAR : SasonBase.Sason.Tables.Table_SERVISVARLIKRUHSATLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISVARLIKRUHSATLAR>
        {
            Dictionary<Decimal, SERVISVARLIKRUHSATLAR> dict = new Dictionary<Decimal, SERVISVARLIKRUHSATLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISVARLIKRUHSATLAR> items) : base(items) { }


            public SERVISVARLIKRUHSATLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISVARLIKRUHSATLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISVARLIKRUHSATLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISVARLIKRUHSATLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISVARLIKRUHSATLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISVARLIKRUHSATLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISVARLIKRUHSATLAR> Select
        {
            get { return R.Query<SERVISVARLIKRUHSATLAR>(); }
        }

        public static SERVISVARLIKRUHSATLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISVARLIKRUHSATLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISVARLIKRUHSATLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISVARLIKRUHSATLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISVARLIKRUHSATLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISVARLIKRUHSATLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

