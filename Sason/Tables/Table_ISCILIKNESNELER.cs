using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("9e60309a-e6ad-4eca-b110-b3a0f1709bee")]
    [DbTableInfoAttribute(TableTypes.Table, "ISCILIKNESNELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(3, "KOD1", typeof(String), null, DbFieldFlags.None, 3, 0, 0, "")]
    [DbField(4, "KOD2", typeof(String), null, DbFieldFlags.Nullable, 1, 0, 0, "")]
    [DbField(5, "KOD3", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(6, "DTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(7, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "PARENTID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("ISCILIKNESNELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ISCILIKNESNELER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KOD1","KOD2","KOD3"})]
    public abstract class Table_ISCILIKNESNELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ISCILIKNESNELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String KOD1 { get; set; }
            protected virtual String KOD2 { get; set; }
            protected virtual String KOD3 { get; set; }
            protected virtual DateTime DTARIH { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal PARENTID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual String KOD1 { get; set; }
            public virtual String KOD2 { get; set; }
            public virtual String KOD3 { get; set; }
            public virtual DateTime DTARIH { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal PARENTID { get; set; }
        }
    }
}

