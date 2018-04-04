using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("b11e34f1-c80f-4309-a358-e7f2e64f6564")]
    [DbTableInfoAttribute(TableTypes.Table, "AGREGAOZELLIKLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "DEGER", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "BIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "HIYERARSI", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbIndex("AGREGAOZELLIKLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("AGREGAOZELLIKLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KOD"})]
    public abstract class Table_AGREGAOZELLIKLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_AGREGAOZELLIKLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual Decimal DEGER { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal BIRIMID { get; set; }
            protected virtual String HIYERARSI { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal DEGER { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal BIRIMID { get; set; }
            public virtual String HIYERARSI { get; set; }
        }
    }
}

