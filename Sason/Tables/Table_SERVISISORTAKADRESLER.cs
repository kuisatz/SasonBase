using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("ce78da7c-f74c-47a0-9902-178c79dd2b65")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISISORTAKADRESLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "ADRESID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "SERVISISORTAKADRESTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "SERVISISORTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "ISORTAKADRESID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISISORTAKADRESLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISVARLIKADRESLER_PK", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISISORTAKADRESLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ADRESID"})]
    [DbIndex("SERVISISORTAKADRESLER_U02", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ISORTAKADRESID"})]
    public abstract class Table_SERVISISORTAKADRESLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISISORTAKADRESLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal ADRESID { get; set; }
            protected virtual Decimal SERVISISORTAKADRESTIPID { get; set; }
            protected virtual Decimal SERVISISORTAKID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal ISORTAKADRESID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal ADRESID { get; set; }
            public virtual Decimal SERVISISORTAKADRESTIPID { get; set; }
            public virtual Decimal SERVISISORTAKID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal ISORTAKADRESID { get; set; }
        }
    }
}

