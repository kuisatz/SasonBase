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
    public class VW_BIRIMLER : SasonBase.Sason.Views.View_VW_BIRIMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<VW_BIRIMLER>
        {
            Dictionary<Decimal, VW_BIRIMLER> dict = new Dictionary<Decimal, VW_BIRIMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<VW_BIRIMLER> items) : base(items) { }


            public VW_BIRIMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public VW_BIRIMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<VW_BIRIMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<VW_BIRIMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(VW_BIRIMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(VW_BIRIMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<VW_BIRIMLER> Select
        {
            get { return R.Query<VW_BIRIMLER>(); }
        }

        public static VW_BIRIMLER SelectItem(Decimal ID)
        {
            return R.Query<VW_BIRIMLER>().First(t => t.ID == ID);
        }

        public static List<VW_BIRIMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<VW_BIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<VW_BIRIMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<VW_BIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

