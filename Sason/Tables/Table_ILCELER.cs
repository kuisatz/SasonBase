using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("1c073822-8b28-4a3f-9fe5-25163c1d7d1b")]
    [DbTableInfoAttribute(TableTypes.Table, "ILCELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "ILID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ILCELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ILCELER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"AD","ILID"})]
    public abstract class Table_ILCELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ILCELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String AD { get; set; }
            protected virtual Decimal ILID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String AD { get; set; }
            public virtual Decimal ILID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

