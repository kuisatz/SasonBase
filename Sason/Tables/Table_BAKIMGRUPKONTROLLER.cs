using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("64e0d8ab-b3ce-4f4e-ae01-b1c2b8e43c78")]
    [DbTableInfoAttribute(TableTypes.Table, "BAKIMGRUPKONTROLLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "BAKIMKONTROLKALEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "SURE", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "PERIYOT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "BAKIMGRUPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("BAKIMGRUPKONTROLLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_BAKIMGRUPKONTROLLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_BAKIMGRUPKONTROLLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal BAKIMKONTROLKALEMID { get; set; }
            protected virtual Decimal SURE { get; set; }
            protected virtual Decimal PERIYOT { get; set; }
            protected virtual Decimal BAKIMGRUPID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal BAKIMKONTROLKALEMID { get; set; }
            public virtual Decimal SURE { get; set; }
            public virtual Decimal PERIYOT { get; set; }
            public virtual Decimal BAKIMGRUPID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

