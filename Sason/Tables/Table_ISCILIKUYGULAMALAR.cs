using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("45a97189-f710-4db1-a0c0-d2100b7036b7")]
    [DbTableInfoAttribute(TableTypes.Table, "ISCILIKUYGULAMALAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 2, 0, 0, "")]
    [DbField(3, "DTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ISCILIKUYGULAMALAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ISCILIKUYGULAMALAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KOD"})]
    public abstract class Table_ISCILIKUYGULAMALAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ISCILIKUYGULAMALAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual DateTime DTARIH { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual DateTime DTARIH { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

