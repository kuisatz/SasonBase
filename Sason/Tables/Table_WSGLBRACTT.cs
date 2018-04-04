using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("fdbe6391-0aee-45da-81a1-4130884b5f66")]
    [DbTableInfoAttribute(TableTypes.Table, "WSGLBRACTT", "Sason.Tables", "Yok")]
    [DbField(1, "ACTIVITY", typeof(String), null, DbFieldFlags.None, 3, 0, 0, "")]
    [DbField(2, "TEXT", typeof(String), null, DbFieldFlags.None, 100, 0, 0, "")]
    [DbField(3, "STATUS", typeof(String), null, DbFieldFlags.None, 1, 0, 0, "")]
    [DbField(4, "CHANGEDATE", typeof(String), null, DbFieldFlags.None, 8, 0, 0, "")]
    [DbIndex("WSGLBRACTT_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ACTIVITY"})]
    public abstract class Table_WSGLBRACTT : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_WSGLBRACTT))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual String ACTIVITY { get; set; }
            protected virtual String TEXT { get; set; }
            protected virtual String STATUS { get; set; }
            protected virtual String CHANGEDATE { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual String ACTIVITY { get; set; }
            public virtual String TEXT { get; set; }
            public virtual String STATUS { get; set; }
            public virtual String CHANGEDATE { get; set; }
        }
    }
}

