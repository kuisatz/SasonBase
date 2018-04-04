using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("75f2f816-cedc-45fc-bc81-592eb723cd02")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISISORTAKWEBADRESLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "URL", typeof(String), null, DbFieldFlags.None, 128, 0, 0, "")]
    [DbField(3, "WEBADRESTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "SERVISISORTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISISORTAKWEBADRESLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISVARLIKWEBADRESLER_PK", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISVARLIKWEBADRESLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"URL"})]
    public abstract class Table_SERVISISORTAKWEBADRESLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISISORTAKWEBADRESLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String URL { get; set; }
            protected virtual Decimal WEBADRESTIPID { get; set; }
            protected virtual Decimal SERVISISORTAKID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String URL { get; set; }
            public virtual Decimal WEBADRESTIPID { get; set; }
            public virtual Decimal SERVISISORTAKID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

