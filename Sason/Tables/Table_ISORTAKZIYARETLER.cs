using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("98a7340b-0ac5-48b8-b984-f827ab79ea41")]
    [DbTableInfoAttribute(TableTypes.Table, "ISORTAKZIYARETLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "ISORTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ISORTAKKONTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "TARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(5, "KULLANICIID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(6, "NOTLAR", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(7, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ISORTAKZIYARETLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("MUSTERIZIYARETLER_PK", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_ISORTAKZIYARETLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ISORTAKZIYARETLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal ISORTAKID { get; set; }
            protected virtual Decimal ISORTAKKONTAKID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual String KULLANICIID { get; set; }
            protected virtual String NOTLAR { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal ISORTAKID { get; set; }
            public virtual Decimal ISORTAKKONTAKID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual String KULLANICIID { get; set; }
            public virtual String NOTLAR { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

