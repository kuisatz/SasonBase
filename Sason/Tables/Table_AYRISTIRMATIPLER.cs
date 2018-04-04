using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("f02cb60d-20ec-4369-9fee-e52ce22c8361")]
    [DbTableInfoAttribute(TableTypes.Table, "AYRISTIRMATIPLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "GARANTITIPI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "GARANTITURU", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "GARANTIKATEGORISI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("AYRISTIRMATIPLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_AYRISTIRMATIPLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_AYRISTIRMATIPLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual Decimal GARANTITIPI { get; set; }
            protected virtual String GARANTITURU { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal GARANTIKATEGORISI { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal GARANTITIPI { get; set; }
            public virtual String GARANTITURU { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal GARANTIKATEGORISI { get; set; }
        }
    }
}

