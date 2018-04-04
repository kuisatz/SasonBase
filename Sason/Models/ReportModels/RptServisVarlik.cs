using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptServisVarlik : SasonBase.Sason.Tables.Table_SERVISVARLIKLAR.RawItem
    {
        protected virtual Decimal ID { get; set; }
        [DbTargetField("AD")]
        public String Adi { get; set; }

        protected virtual Decimal VARLIKTIPID { get; set; }
        [ReadOnlyMappedRelation]
        [RelationCondition("VARLIKTIPID", "ID")]
        internal RptVarlikTipiInfo VarlikTipi { get; set; }
        public string VarlikTipAdi { get { return VarlikTipi?.Kod; } }

        protected virtual Decimal ODEMETIPID { get; set; }
        [ReadOnlyMappedRelation]
        [RelationCondition("ODEMETIPID", "ID")]
        internal RptOdemeTipi OdemeTipiInfo { get; set; }
        public string OdemeTipi { get { return OdemeTipiInfo?.Kod; } }

        protected virtual Decimal VERGIDAIREID { get; set; }
        [ReadOnlyMappedRelation]
        [RelationCondition("VERGIDAIREID","ID")]
        internal RptVergiDairesiAdiSehirAdiInfo VergiDaireInfo { get; set; }

        public string VergiDairesi { get { return VergiDaireInfo?.Adi; } }
        [DbTargetField("VERGINO")] public String VergiNo { get; set; }
        public string VergiDairesiIl { get { return VergiDaireInfo?.Sehir; } }

        //protected virtual Decimal VARLIKID { get; set; }
        //protected virtual Decimal KVARLIKID { get; set; }

        [Newtonsoft.Json.JsonIgnoreAttribute]
        public virtual Decimal SERVISID { get; set; }




        [DbTargetField("ADRES")]
        public String Adres { get; set; }
        
        protected virtual Decimal ULKEID { get; set; }
        [ReadOnlyMappedRelation]
        [RelationCondition("ULKEID","ID")]
        internal RptUlke UlkeInfo { get; set; }
        public string UlkeAdi { get { return UlkeInfo?.UlkeAdi; } }
        
        protected virtual Decimal ILID { get; set; }
        [ReadOnlyMappedRelation]
        [RelationCondition("ILID","ID")]
        internal RptSehir SehirInfo { get; set; }
        public string SehirAdi { get { return SehirInfo?.Adi; } }

        protected virtual Decimal ILCEID { get; set; }
        [ReadOnlyMappedRelation]
        [RelationCondition("ILCEID","ID")]
        internal RptIlce IlceInfo { get; set; }
        public string IlceAdi { get { return IlceInfo?.Adi; } }
        //public string IlceSehir { get{ return IlceInfo?.SehirAdi; } }
        //public string IlceUlke { get { return IlceInfo?.UlkeAdi; } }

        [DbTargetField("EFATURA")] public bool EFaturaMusterisi { get; set; }
        [DbTargetField("EFATURAADRES")] public string EFaturaAdresi { get; set; }

        [DbTargetField("TELEFON")] public string Telefon { get; set; }
        [DbTargetField("EPOSTA")] public string Email { get; set; }
        [DbTargetField("FAX")] public string Fax { get; set; }
    }
}