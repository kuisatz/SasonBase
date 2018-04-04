using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("f9ae9a27-9ff8-4b0b-9d01-086074e045e8")]
    [DbTableInfoAttribute(TableTypes.Table, "VERGIDAIRELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "ILID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("VERGIDAIRELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("VERGIDAIRELER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"AD","ILID"})]
    public abstract class Table_VERGIDAIRELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_VERGIDAIRELER))]
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

