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
    public class VT_SERVISLER : SasonBase.Sason.Views.View_VT_SERVISLER.PublicItem
    {
        #region Static Methods
        public static IOrderedQueryable<VT_SERVISLER> Select
        {
            get { return R.Query<VT_SERVISLER>(); }
        }

        public static VT_SERVISLER SelectItem(Decimal servisId)
        {
            return R.Query<VT_SERVISLER>().First(t => t.SERVISID == servisId);
        }

        public static List<VT_SERVISLER> SelectItems(params Decimal[] servisIds)
        {
            return R.Query<VT_SERVISLER>().Where(t => t.SERVISID.In(servisIds)).ToList();
        }

        public static List<VT_SERVISLER> SelectItems(IEnumerable<Decimal> servisIds)
        {
            return R.Query<VT_SERVISLER>().Where(t => t.SERVISID.In(servisIds)).ToList();
        }
        #endregion
    }
}