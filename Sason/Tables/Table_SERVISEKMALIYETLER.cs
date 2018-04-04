using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("a7c16920-c11f-4313-ad51-25dc62ca7e43")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISEKMALIYETLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 500, 0, 0, "")]
    [DbField(3, "MIKTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "FIYAT", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "VERGISINIFID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "BIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISEKMALIYETLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISEKMALIYETLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISEKMALIYETLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual Decimal FIYAT { get; set; }
            protected virtual Decimal VERGISINIFID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal BIRIMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual Decimal FIYAT { get; set; }
            public virtual Decimal VERGISINIFID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal BIRIMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
        }
    }
}

