using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("bd0fe798-b46d-4bc9-a347-fa945ca869fe")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISISORTAKZIYARETLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISISORTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "SERVISISORTAKKONTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "TARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(5, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "KULLANICIID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(7, "NOTLAR", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(8, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISISORTAKZIYARETLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISMUSTERIZIYARETLER_PK", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISISORTAKZIYARETLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISISORTAKZIYARETLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISISORTAKID { get; set; }
            protected virtual Decimal SERVISISORTAKKONTAKID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual String KULLANICIID { get; set; }
            protected virtual String NOTLAR { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISISORTAKID { get; set; }
            public virtual Decimal SERVISISORTAKKONTAKID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual String KULLANICIID { get; set; }
            public virtual String NOTLAR { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

