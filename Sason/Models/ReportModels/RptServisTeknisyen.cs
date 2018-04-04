using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptServisTeknisyen01 : SasonBase.Sason.Tables.Table_SERVISTEKNISYENLER.RawItem
    {
        public Decimal ID { get; set; }
        protected Decimal TEKNISYENID { get; set; }
        public Decimal SERVISID { get; set; }
        public Decimal DURUMID { get; set; }
        public string KARTNO { get; set; }


        [RelationCondition("TEKNISYENID", "ID")]
        public RptTeknisyen01 Teknisyen { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("SERVISID", "ID")]
        public RptServis01 Servis { get; set; }


        public string AdSoyad
        {
            get { return Teknisyen?.AdSoyad; }
        }


        public string ServisAdi
        {
            get { return Servis?.IsOrtak?.Adi; }
        }
    }
}
