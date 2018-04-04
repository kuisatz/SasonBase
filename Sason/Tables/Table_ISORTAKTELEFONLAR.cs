using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("bd4ba044-8530-47c5-9292-d1cdc9fff1fb")]
    [DbTableInfoAttribute(TableTypes.Table, "ISORTAKTELEFONLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "NO", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "ISORTAKTELEFONTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "ISORTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ISORTAKTELEFONLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("VARLIKTELEFONLAR_PK", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_ISORTAKTELEFONLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ISORTAKTELEFONLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String NO { get; set; }
            protected virtual Decimal ISORTAKTELEFONTIPID { get; set; }
            protected virtual Decimal ISORTAKID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String NO { get; set; }
            public virtual Decimal ISORTAKTELEFONTIPID { get; set; }
            public virtual Decimal ISORTAKID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

