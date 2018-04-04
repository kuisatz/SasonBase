using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;

namespace SasonBase.Sason.Models.ViewModels
{
    [Serializable()]
    public class VW_BAKIMKONTROLKALEMLER : SasonBase.Sason.Views.View_VW_BAKIMKONTROLKALEMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<VW_BAKIMKONTROLKALEMLER>
        {
            Dictionary<Decimal, VW_BAKIMKONTROLKALEMLER> dict = new Dictionary<Decimal, VW_BAKIMKONTROLKALEMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<VW_BAKIMKONTROLKALEMLER> items) : base(items) { }


            public VW_BAKIMKONTROLKALEMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public VW_BAKIMKONTROLKALEMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<VW_BAKIMKONTROLKALEMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<VW_BAKIMKONTROLKALEMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(VW_BAKIMKONTROLKALEMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(VW_BAKIMKONTROLKALEMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<VW_BAKIMKONTROLKALEMLER> Select
        {
            get { return R.Query<VW_BAKIMKONTROLKALEMLER>(); }
        }

        public static VW_BAKIMKONTROLKALEMLER SelectItem(Decimal ID)
        {
            return R.Query<VW_BAKIMKONTROLKALEMLER>().First(t => t.ID == ID);
        }

        public static List<VW_BAKIMKONTROLKALEMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<VW_BAKIMKONTROLKALEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<VW_BAKIMKONTROLKALEMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<VW_BAKIMKONTROLKALEMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

