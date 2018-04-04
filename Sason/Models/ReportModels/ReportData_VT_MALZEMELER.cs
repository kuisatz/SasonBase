using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class ReportData_VT_MALZEMELER : SasonBase.Sason.Views.View_VT_MALZEMELER.RawItem
    {
        public decimal MALZEMEID { get; set; }
        public string KOD { get; set; }
        public string GKOD { get; set; }
        public string AD { get; set; }
        string DILKOD { get; set; }

        internal    Decimal     BIRIMID             { get; set; }
        public      String      BIRIMAD             { get; set; }
        public      decimal     ORJINALMALZEMEID    { get; set; }

        //[ReadOnlyMappedRelation]
        //[RelationCondition("MALZEMEID", "MALZEMEID")]
        //internal ReportData_MALZEME_ORJINALMALZEME Malzeme { get; set; }
    }
}