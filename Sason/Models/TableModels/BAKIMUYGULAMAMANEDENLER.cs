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
    public class BAKIMUYGULAMAMANEDENLER : SasonBase.Sason.Tables.Table_BAKIMUYGULAMAMANEDENLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMUYGULAMAMANEDENLER>
        {
            Dictionary<Decimal, BAKIMUYGULAMAMANEDENLER> dict = new Dictionary<Decimal, BAKIMUYGULAMAMANEDENLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMUYGULAMAMANEDENLER> items) : base(items) { }


            public BAKIMUYGULAMAMANEDENLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMUYGULAMAMANEDENLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMUYGULAMAMANEDENLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMUYGULAMAMANEDENLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BAKIMUYGULAMAMANEDENLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMUYGULAMAMANEDENLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMUYGULAMAMANEDENLER> Select
        {
            get { return R.Query<BAKIMUYGULAMAMANEDENLER>(); }
        }

        public static BAKIMUYGULAMAMANEDENLER SelectItem(Decimal ID)
        {
            return R.Query<BAKIMUYGULAMAMANEDENLER>().First(t => t.ID == ID);
        }

        public static List<BAKIMUYGULAMAMANEDENLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMUYGULAMAMANEDENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMUYGULAMAMANEDENLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMUYGULAMAMANEDENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

