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
    public class ISEMIRUYGULAMAMANEDENLER : SasonBase.Sason.Tables.Table_ISEMIRUYGULAMAMANEDENLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISEMIRUYGULAMAMANEDENLER>
        {
            Dictionary<Decimal, ISEMIRUYGULAMAMANEDENLER> dict = new Dictionary<Decimal, ISEMIRUYGULAMAMANEDENLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISEMIRUYGULAMAMANEDENLER> items) : base(items) { }


            public ISEMIRUYGULAMAMANEDENLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISEMIRUYGULAMAMANEDENLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISEMIRUYGULAMAMANEDENLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISEMIRUYGULAMAMANEDENLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISEMIRUYGULAMAMANEDENLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISEMIRUYGULAMAMANEDENLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISEMIRUYGULAMAMANEDENLER> Select
        {
            get { return R.Query<ISEMIRUYGULAMAMANEDENLER>(); }
        }

        public static ISEMIRUYGULAMAMANEDENLER SelectItem(Decimal ID)
        {
            return R.Query<ISEMIRUYGULAMAMANEDENLER>().First(t => t.ID == ID);
        }

        public static List<ISEMIRUYGULAMAMANEDENLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISEMIRUYGULAMAMANEDENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISEMIRUYGULAMAMANEDENLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISEMIRUYGULAMAMANEDENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

