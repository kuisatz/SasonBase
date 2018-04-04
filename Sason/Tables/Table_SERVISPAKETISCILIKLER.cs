using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("deea6b50-bc97-428e-b21a-eea7ebd313eb")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISPAKETISCILIKLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISPAKETID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ISCILIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "SERVISISCILIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "MIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISPAKETISCILIKLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISPAKETISCILIKLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISPAKETISCILIKLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISPAKETID { get; set; }
            protected virtual Decimal ISCILIKID { get; set; }
            protected virtual Decimal SERVISISCILIKID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISPAKETID { get; set; }
            public virtual Decimal ISCILIKID { get; set; }
            public virtual Decimal SERVISISCILIKID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal MIKTAR { get; set; }
        }
    }
}

