using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("31eaef04-51b6-4ebe-b5aa-4c8995c51b3c")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISISCILIKGRUPLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "SERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISISCILIKGRUPLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISISCILIKGRUPLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISISCILIKGRUPLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

