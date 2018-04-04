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
    public class AKSIYONUYGULAMAMANEDENLER : SasonBase.Sason.Tables.Table_AKSIYONUYGULAMAMANEDENLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<AKSIYONUYGULAMAMANEDENLER>
        {
            Dictionary<Decimal, AKSIYONUYGULAMAMANEDENLER> dict = new Dictionary<Decimal, AKSIYONUYGULAMAMANEDENLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<AKSIYONUYGULAMAMANEDENLER> items) : base(items) { }


            public AKSIYONUYGULAMAMANEDENLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AKSIYONUYGULAMAMANEDENLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AKSIYONUYGULAMAMANEDENLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AKSIYONUYGULAMAMANEDENLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(AKSIYONUYGULAMAMANEDENLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AKSIYONUYGULAMAMANEDENLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AKSIYONUYGULAMAMANEDENLER> Select
        {
            get { return R.Query<AKSIYONUYGULAMAMANEDENLER>(); }
        }

        public static AKSIYONUYGULAMAMANEDENLER SelectItem(Decimal ID)
        {
            return R.Query<AKSIYONUYGULAMAMANEDENLER>().First(t => t.ID == ID);
        }

        public static List<AKSIYONUYGULAMAMANEDENLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AKSIYONUYGULAMAMANEDENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AKSIYONUYGULAMAMANEDENLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AKSIYONUYGULAMAMANEDENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

