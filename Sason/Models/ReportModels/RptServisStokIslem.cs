using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptServisStokIslemInfo01 : SasonBase.Sason.Tables.Table_SERVISSTOKISLEMLER.RawItem
    {
        protected virtual Decimal ID { get; set; }
        [DbTargetField("KOD")] public String Kod { get; set; }
        //protected virtual Decimal STOKISLEMTIPID { get; set; }
        //protected virtual Decimal DURUMID { get; set; }
        //protected virtual Decimal SERVISID { get; set; }
        //protected virtual Decimal TESELLUM { get; set; }
    }

    public class RptServisStokIslemInfo02 : RptServisStokIslemInfo01
    {
        [ReadOnlyMappedRelation]
        [RelationCondition("ID", "ALANID")]
        [RelationCondition("app:LanguageId", "DILID")]
        [RelationCondition("90", "LISTEALANID")]
        RptCeviri Ceviri { get; set; }
        public string Adi { get { return Ceviri?.DEGER; } }
    }
}