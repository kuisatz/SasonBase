using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptVergiDairesiAdiInfo : SasonBase.Sason.Tables.Table_VERGIDAIRELER.RawItem
    {
        protected virtual Decimal ID { get; set; }
        [DbTargetField("AD")] public String Adi { get; set; }
    }

    public class RptVergiDairesiAdiSehirAdiInfo : RptVergiDairesiAdiInfo
    {
        protected virtual Decimal ILID { get; set; }
        
        [ReadOnlyMappedRelation]
        [RelationCondition("ILID","ID")]
        RptSehir SehirInfo { get; set; }
        public string Sehir { get { return SehirInfo?.Adi; } }
    }
}
