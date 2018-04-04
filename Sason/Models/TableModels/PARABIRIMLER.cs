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
    public class PARABIRIMLER : SasonBase.Sason.Tables.Table_PARABIRIMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<PARABIRIMLER>
        {
            Dictionary<Decimal, PARABIRIMLER> dict = new Dictionary<Decimal, PARABIRIMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<PARABIRIMLER> items) : base(items) { }


            public PARABIRIMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public PARABIRIMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<PARABIRIMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<PARABIRIMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(PARABIRIMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(PARABIRIMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<PARABIRIMLER> Select
        {
            get { return R.Query<PARABIRIMLER>(); }
        }

        public static PARABIRIMLER SelectItem(Decimal ID)
        {
            return R.Query<PARABIRIMLER>().First(t => t.ID == ID);
        }

        public static List<PARABIRIMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<PARABIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<PARABIRIMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<PARABIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

