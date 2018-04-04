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
    public class SERVISPAKETMALZEMELER : SasonBase.Sason.Tables.Table_SERVISPAKETMALZEMELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISPAKETMALZEMELER>
        {
            Dictionary<Decimal, SERVISPAKETMALZEMELER> dict = new Dictionary<Decimal, SERVISPAKETMALZEMELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISPAKETMALZEMELER> items) : base(items) { }


            public SERVISPAKETMALZEMELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISPAKETMALZEMELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISPAKETMALZEMELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISPAKETMALZEMELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISPAKETMALZEMELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISPAKETMALZEMELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISPAKETMALZEMELER> Select
        {
            get { return R.Query<SERVISPAKETMALZEMELER>(); }
        }

        public static SERVISPAKETMALZEMELER SelectItem(Decimal ID)
        {
            return R.Query<SERVISPAKETMALZEMELER>().First(t => t.ID == ID);
        }

        public static List<SERVISPAKETMALZEMELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISPAKETMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISPAKETMALZEMELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISPAKETMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

