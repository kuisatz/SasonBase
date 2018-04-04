using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("c4cf499c-8082-4344-9da4-aedfc9264457")]
    [DbTableInfoAttribute(TableTypes.Table, "MUSTERILER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "VARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("MUSTERILER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("MUSTERILER_U02", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KOD"})]
    [DbIndex("MUSTERILER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"VARLIKID"})]
    public abstract class Table_MUSTERILER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_MUSTERILER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual Decimal VARLIKID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal VARLIKID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

