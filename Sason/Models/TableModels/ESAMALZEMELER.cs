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
    public class ESAMALZEMELER : SasonBase.Sason.Tables.Table_ESAMALZEMELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ESAMALZEMELER>
        {
            Dictionary<Decimal, ESAMALZEMELER> dict = new Dictionary<Decimal, ESAMALZEMELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ESAMALZEMELER> items) : base(items) { }


            public ESAMALZEMELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ESAMALZEMELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ESAMALZEMELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ESAMALZEMELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ESAMALZEMELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ESAMALZEMELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ESAMALZEMELER> Select
        {
            get { return R.Query<ESAMALZEMELER>(); }
        }

        public static ESAMALZEMELER SelectItem(Decimal ID)
        {
            return R.Query<ESAMALZEMELER>().First(t => t.ID == ID);
        }

        public static List<ESAMALZEMELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ESAMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ESAMALZEMELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ESAMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

