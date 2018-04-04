using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Models
{
    public class RptServisAraclar : SasonBase.Sason.Tables.Table_SERVISARACLAR.RawItem
    {
        public decimal ID { get; set; }
        public decimal ARACID { get; set; }
        decimal MANOLMAYAN { get; set; }
        public string SASENO { get; set; }
        public decimal SERVISVARLIKRUHSATID { get; set; }

        public bool ManAraci { get { return MANOLMAYAN == 0; } }

        [ReadOnlyRelation]
        [RelationCondition("SERVISVARLIKRUHSATID", "ID")]
        public RptServisVarlikRuhsatlar ServisVarlikRuhsat { get; set; }
    }
}