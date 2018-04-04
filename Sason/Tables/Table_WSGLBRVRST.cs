using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("52f00497-dde1-41a8-97d2-546006a25095")]
    [DbTableInfoAttribute(TableTypes.Table, "WSGLBRVRST", "Sason.Tables", "Yok")]
    [DbField(1, "VERSION", typeof(String), null, DbFieldFlags.None, 2, 0, 0, "")]
    [DbField(2, "TEXT", typeof(String), null, DbFieldFlags.None, 100, 0, 0, "")]
    [DbField(3, "STATUS", typeof(String), null, DbFieldFlags.None, 1, 0, 0, "")]
    [DbField(4, "CHANGEDATE", typeof(String), null, DbFieldFlags.None, 8, 0, 0, "")]
    [DbIndex("WSGLBRVRST_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"VERSION"})]
    public abstract class Table_WSGLBRVRST : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_WSGLBRVRST))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual String VERSION { get; set; }
            protected virtual String TEXT { get; set; }
            protected virtual String STATUS { get; set; }
            protected virtual String CHANGEDATE { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual String VERSION { get; set; }
            public virtual String TEXT { get; set; }
            public virtual String STATUS { get; set; }
            public virtual String CHANGEDATE { get; set; }
        }
    }
}

