using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptVarlikInfo : SasonBase.Sason.Tables.Table_VARLIKLAR.RawItem
    {
        protected virtual Decimal ID { get; set; }

        [DbTargetField("AD")]
        public String Adi { get; set; }


        protected virtual Decimal VARLIKTIPID { get; set; }
        [ReadOnlyMappedRelation]
        [RelationCondition("VARLIKTIPID","ID")]
        internal RptVarlikTipiInfo VarlikTipiInfo { get; set; }

        [DbTargetField("VERGINO")]public String VergiNo { get; set; }
        
        protected virtual Decimal VERGIDAIREID { get; set; }
        [ReadOnlyMappedRelation]
        [RelationCondition("VERGIDAIREID","ID")]
        internal RptVergiDairesiAdiInfo VargiDaireInfo { get; set; }
        public string VergiDaireAd { get { return VargiDaireInfo?.Adi; } }
        
        //protected virtual Decimal ODEMETIPID { get; set; }
        //protected virtual Decimal ULKEID { get; set; }
        //protected virtual Decimal ILID { get; set; }
        //protected virtual Decimal ILCEID { get; set; }
        //protected virtual String ADRES { get; set; }
        //protected virtual Decimal EFATURA { get; set; }
        //protected virtual String EFATURAADRES { get; set; }
        //protected virtual String TELEFON { get; set; }
        //protected virtual String FAX { get; set; }
        //protected virtual String EPOSTA { get; set; }
    }
}