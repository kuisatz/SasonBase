using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("f2f8728c-1311-4902-9af9-fb1fb4c8ce25")]
    [DbTableInfoAttribute(TableTypes.Table, "WSGLBRCONT", "Sason.Tables", "Yok")]
    [DbField(1, "CONDITION", typeof(String), null, DbFieldFlags.None, 2, 0, 0, "")]
    [DbField(2, "TEXT", typeof(String), null, DbFieldFlags.None, 100, 0, 0, "")]
    [DbField(3, "STATUS", typeof(String), null, DbFieldFlags.None, 1, 0, 0, "")]
    [DbField(4, "CHANGEDATE", typeof(String), null, DbFieldFlags.None, 8, 0, 0, "")]
    [DbIndex("WSGLBRCONT_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"CONDITION"})]
    public abstract class Table_WSGLBRCONT : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_WSGLBRCONT))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual String CONDITION { get; set; }
            protected virtual String TEXT { get; set; }
            protected virtual String STATUS { get; set; }
            protected virtual String CHANGEDATE { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual String CONDITION { get; set; }
            public virtual String TEXT { get; set; }
            public virtual String STATUS { get; set; }
            public virtual String CHANGEDATE { get; set; }
        }
    }
}

