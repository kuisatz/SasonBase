using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptServisIsEmirlerInfo01 : SasonBase.Sason.Tables.Table_SERVISISEMIRLER.RawItem
    {
        public decimal ID { get; set; }
        public decimal SERVISARACID { get; set; }
        public Decimal SERVISID { get; set; }
        public DateTime KAYITTARIH { get; set; }
        public Decimal TEKNIKOLARAKTAMAMLA { get; set; }
    }

    public class RptServisIsEmirler : SasonBase.Sason.Tables.Table_SERVISISEMIRLER.RawItem
    {
        protected decimal ID              { get; set; }
        protected decimal SERVISARACID    { get; set; }

        protected Decimal SERVISID        { get; set; }

        [DbTargetField("MUSTERIAD")]public string AraciGetiren { get; set; }
        [DbTargetField("ACIKLAMA")]public string Aciklama { get; set; }
        [DbTargetField("ISEMIRNO")]public string IsEmirNo { get; set; }

        [DbTargetField("SASENO")]public String AracSaseNo { get; set; }
        [DbTargetField("PLAKA")]public String AracPlaka { get; set; }
        [DbTargetField("KM")]public decimal AracKm { get; set; }
        [DbTargetField("MODELNO")]public string AracModelNo { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("SERVISARACID","ID")]
        public RptServisAraclar ServisAracKaydi { get; set; }
        
        //[ReadOnlyRelation]
        //[RelationCondition("ID", "SERVISISEMIRID")]
        //internal List<ReportData_SERVISISEMIRISLEMLER> IsEmirIslemler { get; set; }
    }


}