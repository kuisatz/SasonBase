using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("799e44a5-8ffe-4713-b27c-9e7984e99d13")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISESAWEBSERVISISTEKLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "ESAWEBSERVISISTEKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISESAWEBSERVISISTEKLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISESAWEBSERVISISTEKLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ESAWEBSERVISISTEKID","SERVISID"})]
    public abstract class Table_SERVISESAWEBSERVISISTEKLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISESAWEBSERVISISTEKLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal ESAWEBSERVISISTEKID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal ESAWEBSERVISISTEKID { get; set; }
            public virtual Decimal SERVISID { get; set; }
        }
    }
}

