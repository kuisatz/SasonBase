using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptIlce : SasonBase.Sason.Tables.Table_ILCELER.RawItem
    {
        protected virtual Decimal ID { get; set; }
        [DbTargetField("AD")] public String Adi { get; set; }
    }

    public class RptIlceSehir : RptIlce
    {
        protected virtual Decimal ILID { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("ILID","ID")]
        RptSehir SehirInfo { get; set; }

        public string SehirAdi { get { return SehirInfo?.Adi; } }
    }

    public class RptIlceSehirUlke : RptIlceSehir
    {
        [ReadOnlyMappedRelation]
        [RelationCondition("ILID", "ID")]
        RptSehirUlke SehirInfo { get; set; }

        public new string SehirAdi { get { return SehirInfo?.Adi; } }
        public string UlkeAdi { get { return SehirInfo?.UlkeAdi; } }
    }
}