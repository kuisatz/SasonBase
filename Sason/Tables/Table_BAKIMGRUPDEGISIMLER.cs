using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("f20c3b2c-4b6b-4e2b-9142-c8d2677fdf29")]
    [DbTableInfoAttribute(TableTypes.Table, "BAKIMGRUPDEGISIMLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "BAKIMDEGISIMKALEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "SURE", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "PERIYOT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "BAKIMGRUPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("BAKIMGRUPDEGISIMLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_BAKIMGRUPDEGISIMLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_BAKIMGRUPDEGISIMLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal BAKIMDEGISIMKALEMID { get; set; }
            protected virtual Decimal SURE { get; set; }
            protected virtual Decimal PERIYOT { get; set; }
            protected virtual Decimal BAKIMGRUPID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal BAKIMDEGISIMKALEMID { get; set; }
            public virtual Decimal SURE { get; set; }
            public virtual Decimal PERIYOT { get; set; }
            public virtual Decimal BAKIMGRUPID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

