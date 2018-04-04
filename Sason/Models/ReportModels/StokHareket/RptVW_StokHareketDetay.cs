using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels.StokHareket
{
    public class RptVW_StokHareketDetay : SasonBase.Sason.Views.View_VW_SERVISSTOKHAREKETDETAYLAR.RawItem
    {
        internal Decimal SERVISSTOKHAREKETDETAYID { get; set; }
        internal Decimal SERVISSTOKHAREKETID { get; set; }
        internal Decimal SERVISSTOKID { get; set; }
        internal String DILKOD { get; set; }

        public string Kod
        {
            get
            {
                return "";// ServisStokInfo?.Kod;
            }
        }
        [DbTargetField("SERVISSTOKAD")] public virtual String Ad { get; set; }
        //public DateTime TARIH { get; set; }
        //public Decimal SERVISSTOKISLEMID { get; set; }
        //public String SERVISSTOKISLEMAD { get; set; }
        [DbTargetField("MIKTAR")] public Decimal Miktar { get; set; }
        //public Decimal BIRIMID { get; set; }
        [DbTargetField("BIRIMAD")] public String Birim { get; set; }
        [DbTargetField("BIRIMFIYAT")] public Decimal BirimFiyat { get; set; }

        //public Decimal ABIRIMID { get; set; }
        //public String ABIRIMAD { get; set; }
        //public Decimal AMIKTAR { get; set; }
        //public Decimal ABIRIMFIYAT { get; set; }
        //public Decimal VERGISINIFID { get; set; }
        //public Decimal VERGISINIFAD { get; set; }
        //public Decimal SERVISDEPOID { get; set; }
        //public String SERVISDEPOAD { get; set; }
        //public Decimal SERVISDEPORAFID { get; set; }
        //public String SERVISDEPORAFAD { get; set; }
        //public Decimal STOKISLEMTIPID { get; set; }
        //public String STOKISLEMTIPAD { get; set; }
        //public String CARI { get; set; }
        //public String REFERANS { get; set; }
        //public Decimal DURUMID { get; set; }
        //public Decimal TOPLAMBIRIMFIYAT { get; set; }
        //public Decimal TOPLAMINDBIRIMFIYAT { get; set; }

        //[ReadOnlyRelation]
        //[RelationCondition("SERVISSTOKID","SERVISSTOKID")]
        //[RelationCondition("app:ServiceId", "SERVISID")]
        //[RelationCondition("app:Language", "DILKOD")]
        //internal ReportData_VT_SERVISSTOKLAR ServisStokInfo { get; set; }

        //[ReadOnlyMappedRelation]
        //[RelationCondition("SERVISSTOKID","ID")]
        //public RptServisStokInfo02 ServisStokInfo { get; set; }


    }
    
}