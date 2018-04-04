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
    public class GUVENIRLIKDERECELER : SasonBase.Sason.Tables.Table_GUVENIRLIKDERECELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<GUVENIRLIKDERECELER>
        {
            Dictionary<Decimal, GUVENIRLIKDERECELER> dict = new Dictionary<Decimal, GUVENIRLIKDERECELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<GUVENIRLIKDERECELER> items) : base(items) { }


            public GUVENIRLIKDERECELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public GUVENIRLIKDERECELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<GUVENIRLIKDERECELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<GUVENIRLIKDERECELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(GUVENIRLIKDERECELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(GUVENIRLIKDERECELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<GUVENIRLIKDERECELER> Select
        {
            get { return R.Query<GUVENIRLIKDERECELER>(); }
        }

        public static GUVENIRLIKDERECELER SelectItem(Decimal ID)
        {
            return R.Query<GUVENIRLIKDERECELER>().First(t => t.ID == ID);
        }

        public static List<GUVENIRLIKDERECELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<GUVENIRLIKDERECELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<GUVENIRLIKDERECELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<GUVENIRLIKDERECELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

