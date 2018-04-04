using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("563ed551-67de-434d-8963-cbb1444115ac")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISRANDEVUISLEMLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "ISEMIRTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "RANDEVUISLEMLER", typeof(String), null, DbFieldFlags.None, 500, 0, 0, "")]
    [DbField(4, "SERVISRANDEVUID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISRANDEVUISLEMLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISRANDEVUISLEMLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISRANDEVUISLEMLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal ISEMIRTIPID { get; set; }
            protected virtual String RANDEVUISLEMLER { get; set; }
            protected virtual Decimal SERVISRANDEVUID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal ISEMIRTIPID { get; set; }
            public virtual String RANDEVUISLEMLER { get; set; }
            public virtual Decimal SERVISRANDEVUID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

