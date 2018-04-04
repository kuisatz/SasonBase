using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("a61da52a-d551-42af-99d8-30dd6b197143")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISEKSISLEMDKALEMLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISEKSPERTIZISLEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "DIGERKALEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "TUTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "INDIRIMLITUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "MIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SEVISEKSPISLEMDKALEMLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISEKSISLEMDKALEMLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISEKSISLEMDKALEMLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISEKSPERTIZISLEMID { get; set; }
            protected virtual Decimal DIGERKALEMID { get; set; }
            protected virtual Decimal TUTAR { get; set; }
            protected virtual Decimal INDIRIMLITUTAR { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISEKSPERTIZISLEMID { get; set; }
            public virtual Decimal DIGERKALEMID { get; set; }
            public virtual Decimal TUTAR { get; set; }
            public virtual Decimal INDIRIMLITUTAR { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal MIKTAR { get; set; }
        }
    }
}

