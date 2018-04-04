using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Database.Row;
using SasonBase.Sason.Models.PdksModels;

namespace SasonBase.Sason.Models.TableModels
{
    [Serializable()]
    public class SERVISISEMIRLER : Tables.Table_SERVISISEMIRLER.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISISEMIRLER>
        {
            Dictionary<Decimal, SERVISISEMIRLER> dict = new Dictionary<Decimal, SERVISISEMIRLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISISEMIRLER> items) : base(items) { }


            public SERVISISEMIRLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISISEMIRLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISISEMIRLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISISEMIRLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISISEMIRLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISISEMIRLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISISEMIRLER> Select
        {
            get { return R.Query<SERVISISEMIRLER>(); }
        }

        public static SERVISISEMIRLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISISEMIRLER>().First(t => t.ID == ID);
        }

        public static List<SERVISISEMIRLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISISEMIRLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISISEMIRLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISISEMIRLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static SERVISISEMIRLER SelectFromIsEmirNo(string isEmirNo)
        {
            return Select.First(t => t.ISEMIRNO == isEmirNo);
        }

    }
}

