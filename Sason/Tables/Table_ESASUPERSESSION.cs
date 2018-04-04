using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("ecbaeb5a-d283-4a7d-83c3-6aa5d08273c8")]
    [DbTableInfoAttribute(TableTypes.Table, "ESASUPERSESSION", "Sason.Tables", "Yok")]
    [DbField(1, "MATNR", typeof(String), null, DbFieldFlags.None, 18, 0, 0, "")]
    [DbField(2, "MATKX", typeof(String), null, DbFieldFlags.None, 40, 0, 0, "")]
    [DbField(3, "DUMMY", typeof(String), null, DbFieldFlags.Nullable, 18, 0, 0, "")]
    [DbField(4, "POSTP", typeof(String), null, DbFieldFlags.None, 2, 0, 0, "")]
    [DbIndex("ESASUPERSESSION_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"MATNR"})]
    public abstract class Table_ESASUPERSESSION : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ESASUPERSESSION))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual String MATNR { get; set; }
            protected virtual String MATKX { get; set; }
            protected virtual String DUMMY { get; set; }
            protected virtual String POSTP { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual String MATNR { get; set; }
            public virtual String MATKX { get; set; }
            public virtual String DUMMY { get; set; }
            public virtual String POSTP { get; set; }
        }
    }
}

