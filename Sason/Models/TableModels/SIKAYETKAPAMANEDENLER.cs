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
    public class SIKAYETKAPAMANEDENLER : SasonBase.Sason.Tables.Table_SIKAYETKAPAMANEDENLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SIKAYETKAPAMANEDENLER>
        {
            Dictionary<Decimal, SIKAYETKAPAMANEDENLER> dict = new Dictionary<Decimal, SIKAYETKAPAMANEDENLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SIKAYETKAPAMANEDENLER> items) : base(items) { }


            public SIKAYETKAPAMANEDENLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SIKAYETKAPAMANEDENLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SIKAYETKAPAMANEDENLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SIKAYETKAPAMANEDENLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SIKAYETKAPAMANEDENLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SIKAYETKAPAMANEDENLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SIKAYETKAPAMANEDENLER> Select
        {
            get { return R.Query<SIKAYETKAPAMANEDENLER>(); }
        }

        public static SIKAYETKAPAMANEDENLER SelectItem(Decimal ID)
        {
            return R.Query<SIKAYETKAPAMANEDENLER>().First(t => t.ID == ID);
        }

        public static List<SIKAYETKAPAMANEDENLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SIKAYETKAPAMANEDENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SIKAYETKAPAMANEDENLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SIKAYETKAPAMANEDENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

