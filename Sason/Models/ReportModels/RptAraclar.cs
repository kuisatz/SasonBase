using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptAraclar : SasonBase.Sason.Tables.Table_ARACLAR.RawItem
    {
        internal decimal ID { get; set; }
        public string SASENO { get; set; }
        public string KISASASENO { get; set; }

        decimal ARACURETICIID { get; set; }
        decimal VARLIKRUHSATID { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("VARLIKRUHSATID", "ID")]
        public ReportData_VARLIKRUHSATLAR AracRuhsatInfo { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("ARACURETICIID", "ID")]
        public RptAracUreticiler AracUreticiInfo { get; set; }
    }
}