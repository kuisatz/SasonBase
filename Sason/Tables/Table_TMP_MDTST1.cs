using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("4420ba80-7a40-4499-a3d3-7e4d187a225c")]
    [DbTableInfoAttribute(TableTypes.Table, "TMP_MDTST1", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "F_ADI", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(3, "F_SOYADI", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(4, "N1", typeof(Boolean), null, DbFieldFlags.Nullable, 22, 1, 0, "")]
    [DbField(5, "N4", typeof(Int32), null, DbFieldFlags.Nullable, 22, 4, 0, "")]
    [DbField(6, "N3", typeof(Byte), null, DbFieldFlags.Nullable, 22, 3, 0, "")]
    [DbField(7, "I1", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "T1", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "T2", typeof(Byte[]), null, DbFieldFlags.Nullable, 0, 0, 0, "")]
    [DbIndex("TMP_MDTST1_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_TMP_MDTST1 : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_TMP_MDTST1))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String F_ADI { get; set; }
            protected virtual String F_SOYADI { get; set; }
            protected virtual Boolean N1 { get; set; }
            protected virtual Int32 N4 { get; set; }
            protected virtual Byte N3 { get; set; }
            protected virtual Decimal I1 { get; set; }
            protected virtual Decimal T1 { get; set; }
            protected virtual Byte[] T2 { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String F_ADI { get; set; }
            public virtual String F_SOYADI { get; set; }
            public virtual Boolean N1 { get; set; }
            public virtual Int32 N4 { get; set; }
            public virtual Byte N3 { get; set; }
            public virtual Decimal I1 { get; set; }
            public virtual Decimal T1 { get; set; }
            public virtual Byte[] T2 { get; set; }
        }
    }
}

