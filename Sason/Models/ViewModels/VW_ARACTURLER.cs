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
    public class VW_ARACTURLER : SasonBase.Sason.Views.View_VW_ARACTURLER.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<VW_ARACTURLER>
        {
            Dictionary<Decimal, VW_ARACTURLER> dict = new Dictionary<Decimal, VW_ARACTURLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<VW_ARACTURLER> items) : base(items) { }


            public VW_ARACTURLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public VW_ARACTURLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<VW_ARACTURLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<VW_ARACTURLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(VW_ARACTURLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(VW_ARACTURLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<VW_ARACTURLER> Select
        {
            get { return R.Query<VW_ARACTURLER>(); }
        }

        public static VW_ARACTURLER SelectItem(Decimal ID)
        {
            return R.Query<VW_ARACTURLER>().First(t => t.ID == ID);
        }

        public static List<VW_ARACTURLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<VW_ARACTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<VW_ARACTURLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<VW_ARACTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

