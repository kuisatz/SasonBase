using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("b0527137-910f-4ad8-99bc-29b566277f10")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISSTOKISLEMLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "STOKISLEMTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "SERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "TESELLUM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("STOKISLEMLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISSTOKISLEMLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KOD","SERVISID"})]
    public abstract class Table_SERVISSTOKISLEMLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISSTOKISLEMLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual Decimal STOKISLEMTIPID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal TESELLUM { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal STOKISLEMTIPID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal TESELLUM { get; set; }
        }
    }
}

