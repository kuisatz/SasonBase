using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("62daac46-241b-4177-bad1-c18077bb8f2b")]
    [DbTableInfoAttribute(TableTypes.Table, "AKSIYONISLEMDHIZMETLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AKSIYONISLEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ACIKLAMA", typeof(String), null, DbFieldFlags.None, 500, 0, 0, "")]
    [DbField(4, "TUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "INDIRIMLITUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "ZORUNLU", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("AKSIYONISLEMDHIZMETLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_AKSIYONISLEMDHIZMETLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_AKSIYONISLEMDHIZMETLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal AKSIYONISLEMID { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal TUTAR { get; set; }
            protected virtual Decimal INDIRIMLITUTAR { get; set; }
            protected virtual Decimal ZORUNLU { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal AKSIYONISLEMID { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal TUTAR { get; set; }
            public virtual Decimal INDIRIMLITUTAR { get; set; }
            public virtual Decimal ZORUNLU { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

