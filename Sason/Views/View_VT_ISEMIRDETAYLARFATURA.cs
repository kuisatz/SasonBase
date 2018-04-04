using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("daca24a9-723d-4a1c-8ab9-4951edd86fe8")]
    [DbTableInfoAttribute(TableTypes.View, "VT_ISEMIRDETAYLARFATURA", "Sason.Tables", "Yok")]
    [DbField(1, "SERVISISEMIRID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(2, "SERVISISEMIRISLEMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(3, "REFERANSID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "MIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "TUR", typeof(String), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(6, "BRUTTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "TUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "GTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "KOD", typeof(String), null, DbFieldFlags.Nullable, 4000, 0, 0, "")]
    [DbField(10, "AD", typeof(String), null, DbFieldFlags.Nullable, 2000, 0, 0, "")]
    [DbField(11, "SERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "TAMAMLANMATARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(13, "BIRIMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(14, "KDVORAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "TURID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "SOZLESMEADET", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "ORJINALKOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(18, "ISEMIRNO", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    public abstract partial class View_VT_ISEMIRDETAYLARFATURA : SasonDbView
    {
        [Serializable()]
        [DbTableType(typeof(View_VT_ISEMIRDETAYLARFATURA))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal SERVISISEMIRID { get; set; }
            protected virtual Decimal SERVISISEMIRISLEMID { get; set; }
            protected virtual Decimal REFERANSID { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual String TUR { get; set; }
            protected virtual Decimal BRUTTUTAR { get; set; }
            protected virtual Decimal TUTAR { get; set; }
            protected virtual Decimal GTUTAR { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String AD { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual DateTime TAMAMLANMATARIH { get; set; }
            protected virtual String BIRIMAD { get; set; }
            protected virtual Decimal KDVORAN { get; set; }
            protected virtual Decimal TURID { get; set; }
            protected virtual Decimal SOZLESMEADET { get; set; }
            protected virtual String ORJINALKOD { get; set; }
            protected virtual String ISEMIRNO { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal SERVISISEMIRID { get; set; }
            public virtual Decimal SERVISISEMIRISLEMID { get; set; }
            public virtual Decimal REFERANSID { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual String TUR { get; set; }
            public virtual Decimal BRUTTUTAR { get; set; }
            public virtual Decimal TUTAR { get; set; }
            public virtual Decimal GTUTAR { get; set; }
            public virtual String KOD { get; set; }
            public virtual String AD { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual DateTime TAMAMLANMATARIH { get; set; }
            public virtual String BIRIMAD { get; set; }
            public virtual Decimal KDVORAN { get; set; }
            public virtual Decimal TURID { get; set; }
            public virtual Decimal SOZLESMEADET { get; set; }
            public virtual String ORJINALKOD { get; set; }
            public virtual String ISEMIRNO { get; set; }
        }
    }
}

