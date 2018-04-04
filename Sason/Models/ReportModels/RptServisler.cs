using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptServis01 : SasonBase.Sason.Tables.Table_SERVISLER.RawItem
    {
        protected Decimal ID { get; set; }
        protected Decimal ISORTAKID { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("ISORTAKID", "ID")]
        public RptIsOrtak IsOrtak { get; set; }
    }

    public class RptServislerInfo00 : SasonBase.Sason.Tables.Table_SERVISLER.RawItem
    {
        [DbTargetField("ID")] public Decimal ServisId { get; set; }

        protected virtual Decimal ISORTAKID { get; set; }
        [ReadOnlyMappedRelation]
        [RelationCondition("ISORTAKID", "ID")]
        internal RptIsOrtak01 IsOrtakInfo { get; set; }
        public string ServisAdi { get { return IsOrtakInfo?.Adi; } }
        public string VergiNo { get { return IsOrtakInfo?.VarlikInfo?.VergiNo; } }
        public string VergiDairesiAdi { get { return IsOrtakInfo?.VarlikInfo?.VergiDaireAd; } }
        public string VarlikAdi { get { return IsOrtakInfo?.VarlikAdi; } }
        
        //protected virtual String EBAFIRMAID { get; set; }
        //protected virtual String YPSID { get; set; }
        //protected virtual String GSID { get; set; }
        //protected virtual String TBSID { get; set; }
        //protected virtual String GOKULLANICIAD { get; set; }
        //protected virtual String GOPAROLA { get; set; }
        //protected virtual String PARTS2BKULLANICIAD { get; set; }
        //protected virtual String PARTS2BPAROLA { get; set; }
        //protected virtual Decimal ENVANTERPERIYODID { get; set; }
        //protected virtual Decimal DBSLIMITID { get; set; }
        //protected virtual Decimal ADRESID { get; set; }
        //protected virtual Decimal DURUMID { get; set; }
        //protected virtual Decimal AKYSONAY { get; set; }
        //protected virtual Decimal SAYIMDURUM { get; set; }
        //protected virtual String KILITACIKLAMA { get; set; }
        //protected virtual Decimal RECETEKILIT { get; set; }
    }
}