using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ViewModels
{
    public class ORJINALTOMALZEMEKOD : Views.View_ORJINALTOMALZEMEKOD.PublicItem
    {
        public static List<ORJINALTOMALZEMEKOD> SelectOverloadFromKods(IEnumerable<string> orjinalKodlar)
        {
            List<ORJINALTOMALZEMEKOD> ret = new List<ORJINALTOMALZEMEKOD>();
            Exception ex = null;
            if (orjinalKodlar.isEmpty())
                return ret;
            ret = Antibiotic.Database._Helpers.ItemHelpers.SelectItemsFromFieldInValues(typeof(ORJINALTOMALZEMEKOD), "SEARCH_KOD", orjinalKodlar.toList<string>(), out ex).toList<ORJINALTOMALZEMEKOD>();
            return ret;
        }
    }
}