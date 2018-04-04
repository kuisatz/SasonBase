using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("ec93539c-8440-4af1-9b07-81f06ca23b4b")]
    [DbTableInfoAttribute(TableTypes.Table, "AKSIYONISLEMISCILIKLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AKSIYONISLEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ISCILIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "ZORUNLU", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "MIKTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "KOD", typeof(String), null, DbFieldFlags.Nullable, 17, 0, 0, "")]
    [DbIndex("AKSIYONISLEMISCILIKLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_AKSIYONISLEMISCILIKLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_AKSIYONISLEMISCILIKLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal AKSIYONISLEMID { get; set; }
            protected virtual Decimal ISCILIKID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal ZORUNLU { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual String KOD { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal AKSIYONISLEMID { get; set; }
            public virtual Decimal ISCILIKID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal ZORUNLU { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual String KOD { get; set; }
        }
    }
}

