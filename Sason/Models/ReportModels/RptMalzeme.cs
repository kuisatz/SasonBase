using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptMalzemeInfo01 : SasonBase.Sason.Tables.Table_MALZEMELER.RawItem
    {
        protected virtual Decimal ID { get; set; }
        [DbTargetField("KOD")] public String Kod { get; set; }
        [DbTargetField("GKOD")] public String GKod { get; set; }
        //protected virtual Decimal MALZEMESINIFID { get; set; }
        //protected virtual Decimal MALZEMEGRUPID { get; set; }
        //protected virtual Decimal BRUTAGIRLIK { get; set; }
        //protected virtual Decimal NETAGIRLIK { get; set; }
        //protected virtual Decimal BIRIMID { get; set; }
        //protected virtual Decimal VERGISINIFID { get; set; }
        //protected virtual Decimal ENAZSIPARISMIKTAR { get; set; }
        //protected virtual String HIYERARSI { get; set; }
        //protected virtual String ONCEKIMALZEMEKOD { get; set; }
        //protected virtual Decimal ONCEKIMALZEMEID { get; set; }
        //protected virtual Decimal MALZEMEOZELKODID1 { get; set; }
        //protected virtual Decimal MALZEMEOZELKODID2 { get; set; }
        //protected virtual Decimal MALZEMEOZELKODID3 { get; set; }
        //protected virtual Decimal MALZEMEOZELKODID4 { get; set; }
        //protected virtual Decimal MALZEMEOZELKODID5 { get; set; }
        //protected virtual Decimal URETICIVARLIKID { get; set; }
        //protected virtual String URETICIKOD { get; set; }
        //protected virtual Decimal MUADILKONTROL { get; set; }
        //protected virtual Decimal SASEKONTROL { get; set; }
        //protected virtual Decimal ORJINALMALZEMEID { get; set; }
        //protected virtual Decimal DURUMID { get; set; }
        //protected virtual Decimal ENAZSIPARISMIKTARDEGISTIR { get; set; }
        //protected virtual Decimal DFXPARCA { get; set; }
        //protected virtual Decimal DFXINDIRIMORAN { get; set; }
        //protected virtual Decimal DFXMAXSIPARISMIKTAR { get; set; }
        //protected virtual Decimal DFXSTOKMIKTAR { get; set; }
        //protected virtual Decimal DFXMINSTOKMIKTAR { get; set; }
    }

    public class RptMalzemeInfo02 : RptMalzemeInfo01
    {
        protected virtual Decimal BIRIMID { get; set; }
        [ReadOnlyMappedRelation]
        [RelationCondition("BIRIMID", "ID")]
        RptBirimInfo02 BirimInfo { get; set; }
        public string BirimKodu { get { return BirimInfo?.Kod; } }
        public string BirimAdi { get { return BirimInfo?.BirimAdi; } }
    }
}
