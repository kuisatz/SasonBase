using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("488d7fb9-bd29-4661-b995-2f55687cd6ac")]
    [DbTableInfoAttribute(TableTypes.Table, "WSGLBRLOCT", "Sason.Tables", "Yok")]
    [DbField(1, "LOCATION", typeof(String), null, DbFieldFlags.None, 2, 0, 0, "")]
    [DbField(2, "TEXT", typeof(String), null, DbFieldFlags.None, 100, 0, 0, "")]
    [DbField(3, "STATUS", typeof(String), null, DbFieldFlags.None, 1, 0, 0, "")]
    [DbField(4, "CHANGEDATE", typeof(String), null, DbFieldFlags.None, 8, 0, 0, "")]
    [DbIndex("WSGLBRLOCT_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"LOCATION"})]
    public abstract class Table_WSGLBRLOCT : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_WSGLBRLOCT))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual String LOCATION { get; set; }
            protected virtual String TEXT { get; set; }
            protected virtual String STATUS { get; set; }
            protected virtual String CHANGEDATE { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual String LOCATION { get; set; }
            public virtual String TEXT { get; set; }
            public virtual String STATUS { get; set; }
            public virtual String CHANGEDATE { get; set; }
        }
    }
}

