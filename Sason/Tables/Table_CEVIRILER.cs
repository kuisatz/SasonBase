using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("50f3b525-60d9-4a32-991e-a7f6146ddde6")]
    [DbTableInfoAttribute(TableTypes.Table, "CEVIRILER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "LISTEALANID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "DILID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "ALANID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "DEGER", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbIndex("CEVIRILER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("CEVIRILER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"LISTEALANID","DILID","ALANID"})]
    public abstract class Table_CEVIRILER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_CEVIRILER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal LISTEALANID { get; set; }
            protected virtual Decimal DILID { get; set; }
            protected virtual Decimal ALANID { get; set; }
            protected virtual String DEGER { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal LISTEALANID { get; set; }
            public virtual Decimal DILID { get; set; }
            public virtual Decimal ALANID { get; set; }
            public virtual String DEGER { get; set; }
        }
    }
}

