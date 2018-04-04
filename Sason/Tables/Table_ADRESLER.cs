using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("5ae56a9a-50ba-448d-845d-23014ca8966b")]
    [DbTableInfoAttribute(TableTypes.Table, "ADRESLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "ADRES", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(3, "ULKEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "ILID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "ILCEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ADRESLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_ADRESLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ADRESLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String ADRES { get; set; }
            protected virtual Decimal ULKEID { get; set; }
            protected virtual Decimal ILID { get; set; }
            protected virtual Decimal ILCEID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String ADRES { get; set; }
            public virtual Decimal ULKEID { get; set; }
            public virtual Decimal ILID { get; set; }
            public virtual Decimal ILCEID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

