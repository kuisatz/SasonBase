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
    public class VW_BAKIMGRUPLAR : SasonBase.Sason.Views.View_VW_BAKIMGRUPLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<VW_BAKIMGRUPLAR>
        {
            Dictionary<Decimal, VW_BAKIMGRUPLAR> dict = new Dictionary<Decimal, VW_BAKIMGRUPLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<VW_BAKIMGRUPLAR> items) : base(items) { }


            public VW_BAKIMGRUPLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public VW_BAKIMGRUPLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<VW_BAKIMGRUPLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<VW_BAKIMGRUPLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(VW_BAKIMGRUPLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(VW_BAKIMGRUPLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<VW_BAKIMGRUPLAR> Select
        {
            get { return R.Query<VW_BAKIMGRUPLAR>(); }
        }

        public static VW_BAKIMGRUPLAR SelectItem(Decimal ID)
        {
            return R.Query<VW_BAKIMGRUPLAR>().First(t => t.ID == ID);
        }

        public static List<VW_BAKIMGRUPLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<VW_BAKIMGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<VW_BAKIMGRUPLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<VW_BAKIMGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

