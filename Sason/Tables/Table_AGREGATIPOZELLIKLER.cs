using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("12540687-0044-484e-8750-a82d8243a8ae")]
    [DbTableInfoAttribute(TableTypes.Table, "AGREGATIPOZELLIKLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AGREGAOZELLIKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "DEGER", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "AGREGATIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("AGREGATIPOZELLIKLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("AGREGATIPOZELLIKLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"AGREGAOZELLIKID","AGREGATIPID"})]
    public abstract class Table_AGREGATIPOZELLIKLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_AGREGATIPOZELLIKLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal AGREGAOZELLIKID { get; set; }
            protected virtual Decimal DEGER { get; set; }
            protected virtual Decimal AGREGATIPID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal AGREGAOZELLIKID { get; set; }
            public virtual Decimal DEGER { get; set; }
            public virtual Decimal AGREGATIPID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

