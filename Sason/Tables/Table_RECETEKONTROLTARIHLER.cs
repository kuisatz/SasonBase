using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("b5fd8c9b-e8a8-4937-a6d2-69afce0d2001")]
    [DbTableInfoAttribute(TableTypes.Table, "RECETEKONTROLTARIHLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "RECETEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "TARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("RECETEKONTROLTARIHLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_RECETEKONTROLTARIHLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_RECETEKONTROLTARIHLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal RECETEID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal RECETEID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}
