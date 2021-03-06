using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("82f0b7cc-a310-49b8-abaf-72af09a86324")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISISORTAKTELEFONLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "NO", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "SERVISISORTAKTELEFONTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "SERVISISORTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISISORTAKTELEFONLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISVARLIKTELEFONLAR_PK", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISISORTAKTELEFONLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISISORTAKTELEFONLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String NO { get; set; }
            protected virtual Decimal SERVISISORTAKTELEFONTIPID { get; set; }
            protected virtual Decimal SERVISISORTAKID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String NO { get; set; }
            public virtual Decimal SERVISISORTAKTELEFONTIPID { get; set; }
            public virtual Decimal SERVISISORTAKID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

