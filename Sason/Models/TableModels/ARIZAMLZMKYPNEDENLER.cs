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
    public class ARIZAMLZMKYPNEDENLER : SasonBase.Sason.Tables.Table_ARIZAMLZMKYPNEDENLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ARIZAMLZMKYPNEDENLER>
        {
            Dictionary<Decimal, ARIZAMLZMKYPNEDENLER> dict = new Dictionary<Decimal, ARIZAMLZMKYPNEDENLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ARIZAMLZMKYPNEDENLER> items) : base(items) { }


            public ARIZAMLZMKYPNEDENLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ARIZAMLZMKYPNEDENLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ARIZAMLZMKYPNEDENLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ARIZAMLZMKYPNEDENLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ARIZAMLZMKYPNEDENLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ARIZAMLZMKYPNEDENLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ARIZAMLZMKYPNEDENLER> Select
        {
            get { return R.Query<ARIZAMLZMKYPNEDENLER>(); }
        }

        public static ARIZAMLZMKYPNEDENLER SelectItem(Decimal ID)
        {
            return R.Query<ARIZAMLZMKYPNEDENLER>().First(t => t.ID == ID);
        }

        public static List<ARIZAMLZMKYPNEDENLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ARIZAMLZMKYPNEDENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ARIZAMLZMKYPNEDENLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ARIZAMLZMKYPNEDENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

