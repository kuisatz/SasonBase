using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptServisStokHareketDetay : SasonBase.Sason.Tables.Table_SERVISSTOKHAREKETDETAYLAR.RawItem
    {
        protected virtual Decimal ID { get; set; }

        #region ServisStok
        protected virtual Decimal SERVISSTOKID { get; set; }
        [ReadOnlyMappedRelation]
        [RelationCondition("SERVISSTOKID", "ID")]
        RptServisStokInfo01 ServisStokInfo { get; set; }
        public string Kod { get { return ServisStokInfo?.Kod; } }
        public string Ad { get { return ServisStokInfo?.Ad; } }
        #endregion

        [DbTargetField("MIKTAR")] public Decimal Miktar { get; set; }

        #region Birim
        protected virtual Decimal BIRIMID { get; set; }
        [ReadOnlyMappedRelation]
        [RelationCondition("BIRIMID", "ID")]
        RptBirimInfo02 BirimInfo { get; set; }
        public string BirimKodu { get { return BirimInfo?.Kod; } }
        public string BirimAdi { get { return BirimInfo?.BirimAdi; } }
        #endregion

        [DbTargetField("BIRIMFIYAT")] public Decimal BirimFiyat { get; set; }
        //protected virtual Decimal VERGISINIFID { get; set; }
        [DbTargetField("KDVORAN")] public Decimal KdvOran { get; set; }
        //protected virtual Decimal SERVISDEPOID { get; set; }
        //protected virtual Decimal SERVISDEPORAFID { get; set; }
        //protected virtual Decimal DURUMID { get; set; }
        protected virtual Decimal SERVISSTOKHAREKETID { get; set; }
        //protected virtual Decimal AMIKTAR { get; set; }
        //protected virtual Decimal ABIRIMID { get; set; }
        //protected virtual Decimal ABIRIMFIYAT { get; set; }
        //protected virtual Decimal STOKISLEMTIPDEGER { get; set; }
        //protected virtual Decimal SERVISSIPARISID { get; set; }
        //protected virtual String ISEMIRNO { get; set; }
    }
}