using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("546bd0a2-3a80-4625-a6b6-bf4a7bc2105d")]
    [DbTableInfoAttribute(TableTypes.Table, "AKSIYONISLEMLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AKSIYONID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ISLEMKODU", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 4000, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "SIRANO", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("AKSIYONISLEMLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_AKSIYONISLEMLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_AKSIYONISLEMLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal AKSIYONID { get; set; }
            protected virtual String ISLEMKODU { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SIRANO { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal AKSIYONID { get; set; }
            public virtual String ISLEMKODU { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SIRANO { get; set; }
        }
    }
}

