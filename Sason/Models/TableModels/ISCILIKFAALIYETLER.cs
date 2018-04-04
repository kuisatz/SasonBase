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
    public class ISCILIKFAALIYETLER : SasonBase.Sason.Tables.Table_ISCILIKFAALIYETLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISCILIKFAALIYETLER>
        {
            Dictionary<Decimal, ISCILIKFAALIYETLER> dict = new Dictionary<Decimal, ISCILIKFAALIYETLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISCILIKFAALIYETLER> items) : base(items) { }


            public ISCILIKFAALIYETLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISCILIKFAALIYETLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISCILIKFAALIYETLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISCILIKFAALIYETLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISCILIKFAALIYETLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISCILIKFAALIYETLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISCILIKFAALIYETLER> Select
        {
            get { return R.Query<ISCILIKFAALIYETLER>(); }
        }

        public static ISCILIKFAALIYETLER SelectItem(Decimal ID)
        {
            return R.Query<ISCILIKFAALIYETLER>().First(t => t.ID == ID);
        }

        public static List<ISCILIKFAALIYETLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISCILIKFAALIYETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISCILIKFAALIYETLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISCILIKFAALIYETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

