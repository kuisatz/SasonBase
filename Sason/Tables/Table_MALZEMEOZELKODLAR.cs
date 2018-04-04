using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("e0dacb08-374d-45df-9101-be1d11678dae")]
    [DbTableInfoAttribute(TableTypes.Table, "MALZEMEOZELKODLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("MALZEMEOZELKODLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("MALZEMEOZELKODLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KOD"})]
    public abstract class Table_MALZEMEOZELKODLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_MALZEMEOZELKODLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

