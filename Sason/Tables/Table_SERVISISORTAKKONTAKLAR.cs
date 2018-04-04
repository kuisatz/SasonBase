using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("995c4d17-e2c6-4382-87d6-c8f4f4a25c79")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISISORTAKKONTAKLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KONTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "SERVISISORTAKKONTAKTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "SERVISISORTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "ISORTAKKONTAKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISISORTAKKONTAKLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISVARLIKKONTAKLAR_PK", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISISORTAKKONTAKLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ISORTAKKONTAKID"})]
    public abstract class Table_SERVISISORTAKKONTAKLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISISORTAKKONTAKLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal KONTAKID { get; set; }
            protected virtual Decimal SERVISISORTAKKONTAKTIPID { get; set; }
            protected virtual Decimal SERVISISORTAKID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal ISORTAKKONTAKID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal KONTAKID { get; set; }
            public virtual Decimal SERVISISORTAKKONTAKTIPID { get; set; }
            public virtual Decimal SERVISISORTAKID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal ISORTAKKONTAKID { get; set; }
        }
    }
}

