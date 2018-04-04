using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("e3a738b3-9f15-437e-b62b-754febff437e")]
    [DbTableInfoAttribute(TableTypes.Table, "MALZEMESERVISLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "MALZEMEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("MALZEMESERVISLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("MALZEMESERVISLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"SERVISID","MALZEMEID"})]
    public abstract class Table_MALZEMESERVISLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_MALZEMESERVISLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal MALZEMEID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal MALZEMEID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

