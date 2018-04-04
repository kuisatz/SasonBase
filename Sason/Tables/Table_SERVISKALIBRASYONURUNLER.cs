using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("a80c9c2f-c301-46bf-ad4b-bf1c109ed704")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISKALIBRASYONURUNLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "AD", typeof(String), null, DbFieldFlags.None, 100, 0, 0, "")]
    [DbField(4, "SERVISKALIBRASYONGRUPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "MARKA", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(6, "MODEL", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(7, "URETIMYILI", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(8, "SERINUMARASI", typeof(String), null, DbFieldFlags.Nullable, 15, 0, 0, "")]
    [DbField(9, "SERTFIRMA", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(10, "SERTNO", typeof(String), null, DbFieldFlags.Nullable, 15, 0, 0, "")]
    [DbField(11, "LOKASYON", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(12, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(13, "PERIYOT", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(14, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(15, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISKALIBRASYONURUNLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISKALIBRASYONURUNLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISKALIBRASYONURUNLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String AD { get; set; }
            protected virtual Decimal SERVISKALIBRASYONGRUPID { get; set; }
            protected virtual String MARKA { get; set; }
            protected virtual String MODEL { get; set; }
            protected virtual String URETIMYILI { get; set; }
            protected virtual String SERINUMARASI { get; set; }
            protected virtual String SERTFIRMA { get; set; }
            protected virtual String SERTNO { get; set; }
            protected virtual String LOKASYON { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal PERIYOT { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual String AD { get; set; }
            public virtual Decimal SERVISKALIBRASYONGRUPID { get; set; }
            public virtual String MARKA { get; set; }
            public virtual String MODEL { get; set; }
            public virtual String URETIMYILI { get; set; }
            public virtual String SERINUMARASI { get; set; }
            public virtual String SERTFIRMA { get; set; }
            public virtual String SERTNO { get; set; }
            public virtual String LOKASYON { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal PERIYOT { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

