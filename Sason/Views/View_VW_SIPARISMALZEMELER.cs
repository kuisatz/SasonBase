using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("c0142dea-531e-4b4f-921f-afc7b9b66f43")]
    [DbTableInfoAttribute(TableTypes.View, "VW_SIPARISMALZEMELER", "Sason.Tables", "Yok")]
    [DbField(1, "SIPARISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(2, "TURID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(3, "SERVISSIPARISMLZID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "KOD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(5, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(6, "MIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "BIRIMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(8, "BIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "TUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "BRUTFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "DEPOKODU", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "KDVORAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "SERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "FATURAID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    public abstract partial class View_VW_SIPARISMALZEMELER : SasonDbView
    {
        [Serializable()]
        [DbTableType(typeof(View_VW_SIPARISMALZEMELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal SIPARISID { get; set; }
            protected virtual Decimal TURID { get; set; }
            protected virtual Decimal SERVISSIPARISMLZID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual String BIRIMAD { get; set; }
            protected virtual Decimal BIRIMFIYAT { get; set; }
            protected virtual Decimal TUTAR { get; set; }
            protected virtual Decimal BRUTFIYAT { get; set; }
            protected virtual Decimal DEPOKODU { get; set; }
            protected virtual Decimal KDVORAN { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal FATURAID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal SIPARISID { get; set; }
            public virtual Decimal TURID { get; set; }
            public virtual Decimal SERVISSIPARISMLZID { get; set; }
            public virtual String KOD { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual String BIRIMAD { get; set; }
            public virtual Decimal BIRIMFIYAT { get; set; }
            public virtual Decimal TUTAR { get; set; }
            public virtual Decimal BRUTFIYAT { get; set; }
            public virtual Decimal DEPOKODU { get; set; }
            public virtual Decimal KDVORAN { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal FATURAID { get; set; }
        }
    }
}

