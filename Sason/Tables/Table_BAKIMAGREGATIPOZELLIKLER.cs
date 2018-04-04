using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("7d6f3683-03f3-4bca-8911-c758050709f7")]
    [DbTableInfoAttribute(TableTypes.Table, "BAKIMAGREGATIPOZELLIKLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AGREGAOZELLIKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "DEGER", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "BAKIMAGREGATIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("BAKIMAGREGATIPOZELLIKLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_BAKIMAGREGATIPOZELLIKLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_BAKIMAGREGATIPOZELLIKLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal AGREGAOZELLIKID { get; set; }
            protected virtual Decimal DEGER { get; set; }
            protected virtual Decimal BAKIMAGREGATIPID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal AGREGAOZELLIKID { get; set; }
            public virtual Decimal DEGER { get; set; }
            public virtual Decimal BAKIMAGREGATIPID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

