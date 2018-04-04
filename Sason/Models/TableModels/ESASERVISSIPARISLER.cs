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
    public class ESASERVISSIPARISLER : SasonBase.Sason.Tables.Table_ESASERVISSIPARISLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ESASERVISSIPARISLER>
        {
            Dictionary<Decimal, ESASERVISSIPARISLER> dict = new Dictionary<Decimal, ESASERVISSIPARISLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ESASERVISSIPARISLER> items) : base(items) { }


            public ESASERVISSIPARISLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ESASERVISSIPARISLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ESASERVISSIPARISLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ESASERVISSIPARISLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ESASERVISSIPARISLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ESASERVISSIPARISLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ESASERVISSIPARISLER> Select
        {
            get { return R.Query<ESASERVISSIPARISLER>(); }
        }

        public static ESASERVISSIPARISLER SelectItem(Decimal ID)
        {
            return R.Query<ESASERVISSIPARISLER>().First(t => t.ID == ID);
        }

        public static List<ESASERVISSIPARISLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ESASERVISSIPARISLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ESASERVISSIPARISLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ESASERVISSIPARISLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

