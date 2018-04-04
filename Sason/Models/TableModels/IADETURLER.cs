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
    public class IADETURLER : SasonBase.Sason.Tables.Table_IADETURLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<IADETURLER>
        {
            Dictionary<Decimal, IADETURLER> dict = new Dictionary<Decimal, IADETURLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<IADETURLER> items) : base(items) { }


            public IADETURLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public IADETURLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<IADETURLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<IADETURLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(IADETURLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(IADETURLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<IADETURLER> Select
        {
            get { return R.Query<IADETURLER>(); }
        }

        public static IADETURLER SelectItem(Decimal ID)
        {
            return R.Query<IADETURLER>().First(t => t.ID == ID);
        }

        public static List<IADETURLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<IADETURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<IADETURLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<IADETURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

