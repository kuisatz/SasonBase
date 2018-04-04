using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("4a722009-5e19-4b2a-9cd7-98faa7d9969e")]
    [DbTableInfoAttribute(TableTypes.Table, "ESASISTEMLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "DMSSYSTEMID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "DMSVERSION", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "EOIWTYVERSION", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(5, "ISSERVERID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(6, "CLIENT", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(7, "SALESORG", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(8, "WEBSERVICEURL", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbIndex("ESASISTEMLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_ESASISTEMLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ESASISTEMLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String DMSSYSTEMID { get; set; }
            protected virtual String DMSVERSION { get; set; }
            protected virtual String EOIWTYVERSION { get; set; }
            protected virtual String ISSERVERID { get; set; }
            protected virtual String CLIENT { get; set; }
            protected virtual String SALESORG { get; set; }
            protected virtual String WEBSERVICEURL { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String DMSSYSTEMID { get; set; }
            public virtual String DMSVERSION { get; set; }
            public virtual String EOIWTYVERSION { get; set; }
            public virtual String ISSERVERID { get; set; }
            public virtual String CLIENT { get; set; }
            public virtual String SALESORG { get; set; }
            public virtual String WEBSERVICEURL { get; set; }
        }
    }
}

