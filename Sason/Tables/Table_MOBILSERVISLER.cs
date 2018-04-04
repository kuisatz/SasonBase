using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("a13ba750-696d-4ec3-afdf-907b57c2564d")]
    [DbTableInfoAttribute(TableTypes.Table, "MOBILSERVISLER", "Sason.Tables", "Yok")]
    [DbField(1, "SERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(2, "SERVISAD", typeof(String), null, DbFieldFlags.Nullable, 35, 0, 0, "")]
    [DbField(3, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("MOBILSERVISLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_MOBILSERVISLER : SasonDbTable
    {
        [Serializable]
        [DbTableType(typeof(Table_MOBILSERVISLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal SERVISID { get; set; }
            protected virtual String SERVISAD { get; set; }
            protected virtual Decimal ID { get; set; }
        }
        [Serializable]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal SERVISID { get; set; }
            public virtual String SERVISAD { get; set; }
            public virtual Decimal ID { get; set; }
        }
    }
}