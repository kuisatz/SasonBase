using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptBirimInfo01 : SasonBase.Sason.Tables.Table_BIRIMLER.RawItem
    {
        protected virtual Decimal ID { get; set; }
        [DbTargetField("KOD")] public String Kod { get; set; }
    }

    public class RptBirimInfo02 : RptBirimInfo01
    {
        [ReadOnlyMappedRelation]
        [RelationCondition("ID", "ALANID")]
        [RelationCondition("app:LanguageId", "DILID")]
        [RelationCondition("83", "LISTEALANID")]
        RptCeviri Ceviri { get; set; }
        public string BirimAdi { get { return Ceviri?.DEGER; } }
    }

    //public class RptBirimInfo03 : RptBirimInfo02
    //{
    //    protected virtual Decimal DURUMID { get; set; }

    //    [ReadOnlyMappedRelation]
    //    [RelationCondition("DURUMID","ID")]
    //    protected RptDurumlar Durum { get; set; }
    //}
}