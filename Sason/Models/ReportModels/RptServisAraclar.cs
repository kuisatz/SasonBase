using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptServisAraclar : SasonBase.Sason.Tables.Table_SERVISARACLAR.RawItem
    {
        decimal ID { get; set; }
        decimal ARACID { get; set; }
        decimal MANOLMAYAN { get; set; }
        string  SASENO { get; set; }

        public bool ManAraci { get { return MANOLMAYAN == 0; } }

        [ReadOnlyMappedRelation]
        [RelationCondition("ARACID", "ID")]
        public RptAraclar AracKaydi { get; set; }
    }
}