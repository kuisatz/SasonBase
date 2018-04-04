using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("b3e79a85-d359-428e-a346-1c4363c5917a")]
    [DbTableInfoAttribute(TableTypes.Table, "BAKIMAGREGATIPLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AGREGATIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "BAKIMAGREGAID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("BAKIMAGREGATIPLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("BAKIMAGREGATIPLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"AGREGATIPID","BAKIMAGREGAID"})]
    public abstract class Table_BAKIMAGREGATIPLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_BAKIMAGREGATIPLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal AGREGATIPID { get; set; }
            protected virtual Decimal BAKIMAGREGAID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal AGREGATIPID { get; set; }
            public virtual Decimal BAKIMAGREGAID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

