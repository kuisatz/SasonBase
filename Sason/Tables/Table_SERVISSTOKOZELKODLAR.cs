using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("2e9a6ddd-d8ec-4838-a8b0-b7783ab4b723")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISSTOKOZELKODLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISSTOKOZELKODLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISSTOKOZELKODLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KOD","SERVISID"})]
    public abstract class Table_SERVISSTOKOZELKODLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISSTOKOZELKODLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
        }
    }
}

