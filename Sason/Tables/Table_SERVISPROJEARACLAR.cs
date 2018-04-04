using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("7eeb1e92-ab65-4c81-8182-ac216fc90909")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISPROJEARACLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISARACID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "SERVISPROJEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "REFERANS", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbIndex("SYS_C00116812", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISPROJEARACLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISPROJEARACLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISARACID { get; set; }
            protected virtual Decimal SERVISPROJEID { get; set; }
            protected virtual String REFERANS { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISARACID { get; set; }
            public virtual Decimal SERVISPROJEID { get; set; }
            public virtual String REFERANS { get; set; }
        }
    }
}

