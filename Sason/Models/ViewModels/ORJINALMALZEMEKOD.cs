using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ViewModels
{
    public class ORJINALMALZEMEKOD : Views.View_ORJINALMALZEMEKOD.PublicItem
    {
        public static List<ORJINALMALZEMEKOD> SelectOverloadFromKods(IEnumerable<string> kods)
        {
            List<ORJINALMALZEMEKOD> ret = new List<ORJINALMALZEMEKOD>();
            Exception ex = null;
            if (kods.isEmpty())
                return ret;
            ret = Antibiotic.Database._Helpers.ItemHelpers.SelectItemsFromFieldInValues(typeof(ORJINALMALZEMEKOD), "KOD", kods.toList<string>(), out ex).toList<ORJINALMALZEMEKOD>();
            return ret;
        }
    }
}
