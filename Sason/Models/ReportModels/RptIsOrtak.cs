using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptIsOrtak : SasonBase.Sason.Tables.Table_ISORTAKLAR.RawItem
    {
        protected virtual Decimal ID { get; set; }
        [DbTargetField("AD")] public String Adi { get; set; }
    }

    public class RptIsOrtak01 : RptIsOrtak
    {
        protected virtual Decimal VARLIKID { get; set; }
        [ReadOnlyMappedRelation]
        [RelationCondition("VARLIKID","ID")]
        internal RptVarlikInfo VarlikInfo { get; set; }
        public string VarlikAdi { get { return VarlikInfo?.Adi; } }
    }
}