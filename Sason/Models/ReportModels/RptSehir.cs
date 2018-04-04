using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptSehir : SasonBase.Sason.Tables.Table_ILLER.RawItem
    {
        protected virtual Decimal ID { get; set; }
        [DbTargetField("AD")] public String Adi { get; set; }
    }

    public class RptSehirUlke : RptSehir
    {
        protected virtual Decimal ULKEID { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("ULKEID","ID")]
        RptUlke UlkeInfo { get; set; }

        public string UlkeAdi { get { return UlkeInfo?.UlkeAdi; } }
    }
}
