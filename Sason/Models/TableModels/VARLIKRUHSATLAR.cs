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
    public class VARLIKRUHSATLAR : SasonBase.Sason.Tables.Table_VARLIKRUHSATLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<VARLIKRUHSATLAR>
        {
            Dictionary<Decimal, VARLIKRUHSATLAR> dict = new Dictionary<Decimal, VARLIKRUHSATLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<VARLIKRUHSATLAR> items) : base(items) { }


            public VARLIKRUHSATLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public VARLIKRUHSATLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<VARLIKRUHSATLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<VARLIKRUHSATLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(VARLIKRUHSATLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(VARLIKRUHSATLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<VARLIKRUHSATLAR> Select
        {
            get { return R.Query<VARLIKRUHSATLAR>(); }
        }

        public static VARLIKRUHSATLAR SelectItem(Decimal ID)
        {
            return R.Query<VARLIKRUHSATLAR>().First(t => t.ID == ID);
        }

        public static List<VARLIKRUHSATLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<VARLIKRUHSATLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<VARLIKRUHSATLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<VARLIKRUHSATLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

