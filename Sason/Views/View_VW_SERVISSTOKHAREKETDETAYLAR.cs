using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("11c6aa45-2d34-4ef6-916d-f1a45be0a6e0")]
    [DbTableInfoAttribute(TableTypes.View, "VW_SERVISSTOKHAREKETDETAYLAR", "Sason.Tables", "Yok")]
    [DbField(1, "SERVISSTOKHAREKETDETAYID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISSTOKHAREKETID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "SERVISSTOKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "SERVISSTOKAD", typeof(String), null, DbFieldFlags.None, 200, 0, 0, "")]
    [DbField(5, "TARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(6, "SERVISSTOKISLEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "SERVISSTOKISLEMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(8, "MIKTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(9, "BIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(10, "BIRIMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(11, "BIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "ABIRIMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "ABIRIMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(14, "AMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "ABIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "VERGISINIFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "VERGISINIFAD", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "SERVISDEPOID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "SERVISDEPOAD", typeof(String), null, DbFieldFlags.None, 200, 0, 0, "")]
    [DbField(20, "SERVISDEPORAFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(21, "SERVISDEPORAFAD", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(22, "STOKISLEMTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(23, "STOKISLEMTIPAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(24, "CARI", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(25, "REFERANS", typeof(String), null, DbFieldFlags.Nullable, 42, 0, 0, "")]
    [DbField(26, "DURUMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(27, "DILKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(28, "TOPLAMBIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(29, "TOPLAMINDBIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    public abstract partial class View_VW_SERVISSTOKHAREKETDETAYLAR : SasonDbView
    {
        [Serializable()]
        [DbTableType(typeof(View_VW_SERVISSTOKHAREKETDETAYLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal SERVISSTOKHAREKETDETAYID { get; set; }
            protected virtual Decimal SERVISSTOKHAREKETID { get; set; }
            protected virtual Decimal SERVISSTOKID { get; set; }
            protected virtual String SERVISSTOKAD { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual Decimal SERVISSTOKISLEMID { get; set; }
            protected virtual String SERVISSTOKISLEMAD { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual Decimal BIRIMID { get; set; }
            protected virtual String BIRIMAD { get; set; }
            protected virtual Decimal BIRIMFIYAT { get; set; }
            protected virtual Decimal ABIRIMID { get; set; }
            protected virtual String ABIRIMAD { get; set; }
            protected virtual Decimal AMIKTAR { get; set; }
            protected virtual Decimal ABIRIMFIYAT { get; set; }
            protected virtual Decimal VERGISINIFID { get; set; }
            protected virtual Decimal VERGISINIFAD { get; set; }
            protected virtual Decimal SERVISDEPOID { get; set; }
            protected virtual String SERVISDEPOAD { get; set; }
            protected virtual Decimal SERVISDEPORAFID { get; set; }
            protected virtual String SERVISDEPORAFAD { get; set; }
            protected virtual Decimal STOKISLEMTIPID { get; set; }
            protected virtual String STOKISLEMTIPAD { get; set; }
            protected virtual String CARI { get; set; }
            protected virtual String REFERANS { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual String DILKOD { get; set; }
            protected virtual Decimal TOPLAMBIRIMFIYAT { get; set; }
            protected virtual Decimal TOPLAMINDBIRIMFIYAT { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal SERVISSTOKHAREKETDETAYID { get; set; }
            public virtual Decimal SERVISSTOKHAREKETID { get; set; }
            public virtual Decimal SERVISSTOKID { get; set; }
            public virtual String SERVISSTOKAD { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual Decimal SERVISSTOKISLEMID { get; set; }
            public virtual String SERVISSTOKISLEMAD { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual Decimal BIRIMID { get; set; }
            public virtual String BIRIMAD { get; set; }
            public virtual Decimal BIRIMFIYAT { get; set; }
            public virtual Decimal ABIRIMID { get; set; }
            public virtual String ABIRIMAD { get; set; }
            public virtual Decimal AMIKTAR { get; set; }
            public virtual Decimal ABIRIMFIYAT { get; set; }
            public virtual Decimal VERGISINIFID { get; set; }
            public virtual Decimal VERGISINIFAD { get; set; }
            public virtual Decimal SERVISDEPOID { get; set; }
            public virtual String SERVISDEPOAD { get; set; }
            public virtual Decimal SERVISDEPORAFID { get; set; }
            public virtual String SERVISDEPORAFAD { get; set; }
            public virtual Decimal STOKISLEMTIPID { get; set; }
            public virtual String STOKISLEMTIPAD { get; set; }
            public virtual String CARI { get; set; }
            public virtual String REFERANS { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String DILKOD { get; set; }
            public virtual Decimal TOPLAMBIRIMFIYAT { get; set; }
            public virtual Decimal TOPLAMINDBIRIMFIYAT { get; set; }
        }
    }
}

