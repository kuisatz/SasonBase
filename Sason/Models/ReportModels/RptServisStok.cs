using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptServisStokInfo01 : SasonBase.Sason.Tables.Table_SERVISSTOKLAR.RawItem
    {
        protected virtual Decimal ID { get; set; }
        [DbTargetField("KOD")] public String Kod { get; set; }
        [DbTargetField("AD")] public String Ad { get; set; }
        
        //protected virtual String OZELKOD1 { get; set; }
        //protected virtual String OZELKOD2 { get; set; }
        //protected virtual String OZELKOD3 { get; set; }
        //protected virtual Decimal SERVISSTOKSINIFID { get; set; }
        //protected virtual Decimal SERVISSTOKGRUPID { get; set; }
        //protected virtual Decimal BRUTAGIRLIK { get; set; }
        //protected virtual Decimal NETAGIRLIK { get; set; }
        //protected virtual Decimal BIRIMID { get; set; }
        //protected virtual Decimal VERGISINIFID { get; set; }
        //protected virtual Decimal ENAZSIPARISMIKTAR { get; set; }
        //protected virtual Decimal SERVISSTOKOZELKODID1 { get; set; }
        //protected virtual Decimal SERVISSTOKOZELKODID2 { get; set; }
        //protected virtual Decimal SERVISSTOKOZELKODID3 { get; set; }
        //protected virtual Decimal SERVISSTOKOZELKODID4 { get; set; }
        //protected virtual Decimal SERVISSTOKOZELKODID5 { get; set; }
        //protected virtual Decimal ENAZSTOK { get; set; }
        //protected virtual Decimal ENFAZLASTOK { get; set; }
        //protected virtual Decimal URETICIVARLIKID { get; set; }
        //protected virtual String URETICIKOD { get; set; }
        //protected virtual Decimal TEDARIKCIVARLIKID { get; set; }
        protected virtual Decimal MALZEMEID { get; set; }
        //protected virtual Decimal DURUMID { get; set; }
        protected virtual Decimal SERVISID { get; set; }
        //protected virtual Decimal SERVISDEPORAFID { get; set; }
        //protected virtual Decimal HAREKETSAYI { get; set; }
    }

    public class RptServisStokInfo02 : RptServisStokInfo01
    {
        protected virtual Decimal BIRIMID { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("BIRIMID","ID")]
        RptBirimInfo02 BirimInfo { get; set; }
        public string BirimAd { get { return BirimInfo?.BirimAdi; } }
    }

    public class RptServisStokInfo03 : RptServisStokInfo02
    {
        protected virtual Decimal SERVISDEPOID { get; set; }
        [ReadOnlyMappedRelation]
        [RelationCondition("SERVISDEPOID","ID")]
        RptServisDepo ServisDepoInfo { get; set; }
        public string ServisDepoAdi { get { return ServisDepoInfo?.Ad; } }

        [DbTargetField("SERVISSTOKTURID")] public Decimal ServisStokTurId { get; set; }

        //[ReadOnlyMappedRelation]
        //[RelationCondition("SERVISSTOKTURID","ID")]
        //RptServisStokTur ServisStokTur { get; set; }
        //public string ServisStokTurKod { get { return ServisStokTur.Kod; } }
    }
}