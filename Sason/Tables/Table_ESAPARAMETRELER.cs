using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("c5e8de31-a165-478b-aea8-fbb717715c1d")]
    [DbTableInfoAttribute(TableTypes.Table, "ESAPARAMETRELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "PARTNERCODE", typeof(String), null, DbFieldFlags.None, 4, 0, 0, "")]
    [DbField(3, "USERID", typeof(String), null, DbFieldFlags.None, 12, 0, 0, "")]
    [DbField(4, "USERNAME", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(5, "PASSWORD", typeof(String), null, DbFieldFlags.Nullable, 15, 0, 0, "")]
    [DbField(6, "CUSTOMERNUM_WTY", typeof(String), null, DbFieldFlags.None, 9, 0, 0, "")]
    [DbField(7, "CUSTOMERNUM_PART", typeof(String), null, DbFieldFlags.None, 10, 0, 0, "")]
    [DbField(8, "DEBITOR", typeof(String), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(9, "VENDOR", typeof(String), null, DbFieldFlags.None, 9, 0, 0, "")]
    [DbIndex("SERVISESASISTEMLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ESASISTEMPARAMETRELER_PK", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_ESAPARAMETRELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ESAPARAMETRELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String PARTNERCODE { get; set; }
            protected virtual String USERID { get; set; }
            protected virtual String USERNAME { get; set; }
            protected virtual String PASSWORD { get; set; }
            protected virtual String CUSTOMERNUM_WTY { get; set; }
            protected virtual String CUSTOMERNUM_PART { get; set; }
            protected virtual String DEBITOR { get; set; }
            protected virtual String VENDOR { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String PARTNERCODE { get; set; }
            public virtual String USERID { get; set; }
            public virtual String USERNAME { get; set; }
            public virtual String PASSWORD { get; set; }
            public virtual String CUSTOMERNUM_WTY { get; set; }
            public virtual String CUSTOMERNUM_PART { get; set; }
            public virtual String DEBITOR { get; set; }
            public virtual String VENDOR { get; set; }
        }
    }
}

