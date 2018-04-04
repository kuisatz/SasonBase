using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("09967513-0669-43af-b757-15f2b52bb275")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISISORTAKZIYARETKNL", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "FORMKONUID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "NOTLAR", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(4, "SERVISISORTAKZIYARETID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISISORTAKZIYARETKNL_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISISORTAKZIYARETKNL : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISISORTAKZIYARETKNL))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal FORMKONUID { get; set; }
            protected virtual String NOTLAR { get; set; }
            protected virtual Decimal SERVISISORTAKZIYARETID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal FORMKONUID { get; set; }
            public virtual String NOTLAR { get; set; }
            public virtual Decimal SERVISISORTAKZIYARETID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

