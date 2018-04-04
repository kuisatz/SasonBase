using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("1655519a-23a1-4e42-a362-adf99a40c22b")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISISCILIKLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "FIYAT", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "PARABIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "SUREGUN", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "SURESAAT", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "SUREDK", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "SERVISISCILIKGRUPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(9, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(10, "DURUMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "AW", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISISCILIKLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISISCILIKLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISISCILIKLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual Decimal FIYAT { get; set; }
            protected virtual Decimal PARABIRIMID { get; set; }
            protected virtual Decimal SUREGUN { get; set; }
            protected virtual Decimal SURESAAT { get; set; }
            protected virtual Decimal SUREDK { get; set; }
            protected virtual Decimal SERVISISCILIKGRUPID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal AW { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal FIYAT { get; set; }
            public virtual Decimal PARABIRIMID { get; set; }
            public virtual Decimal SUREGUN { get; set; }
            public virtual Decimal SURESAAT { get; set; }
            public virtual Decimal SUREDK { get; set; }
            public virtual Decimal SERVISISCILIKGRUPID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal AW { get; set; }
        }
    }
}

