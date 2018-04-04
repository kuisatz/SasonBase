using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("5eea0396-7440-4e64-875d-ec4ee890ee0d")]
    [DbTableInfoAttribute(TableTypes.Table, "BAKIMSOZLESMEISCILIKLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "BAKIMSOZLESMEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ISCILIKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("BAKIMSOZLESMEISCILIKLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_BAKIMSOZLESMEISCILIKLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_BAKIMSOZLESMEISCILIKLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal BAKIMSOZLESMEID { get; set; }
            protected virtual Decimal ISCILIKID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal BAKIMSOZLESMEID { get; set; }
            public virtual Decimal ISCILIKID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

