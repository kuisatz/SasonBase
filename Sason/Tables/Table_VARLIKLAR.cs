using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("6eeabd31-bf9b-41f4-94d7-230e58ef37e3")]
    [DbTableInfoAttribute(TableTypes.Table, "VARLIKLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AD", typeof(String), null, DbFieldFlags.None, 200, 0, 0, "")]
    [DbField(3, "VARLIKTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "VERGINO", typeof(String), null, DbFieldFlags.Nullable, 11, 0, 0, "")]
    [DbField(5, "VERGIDAIREID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "ODEMETIPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "ULKEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "ILID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "ILCEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "ADRES", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(11, "EFATURA", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "EFATURAADRES", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(13, "TELEFON", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(14, "FAX", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(15, "EPOSTA", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbIndex("VARLIKLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("VARLIKLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"VERGINO"})]
    public abstract class Table_VARLIKLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_VARLIKLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String AD { get; set; }
            protected virtual Decimal VARLIKTIPID { get; set; }
            protected virtual String VERGINO { get; set; }
            protected virtual Decimal VERGIDAIREID { get; set; }
            protected virtual Decimal ODEMETIPID { get; set; }
            protected virtual Decimal ULKEID { get; set; }
            protected virtual Decimal ILID { get; set; }
            protected virtual Decimal ILCEID { get; set; }
            protected virtual String ADRES { get; set; }
            protected virtual Decimal EFATURA { get; set; }
            protected virtual String EFATURAADRES { get; set; }
            protected virtual String TELEFON { get; set; }
            protected virtual String FAX { get; set; }
            protected virtual String EPOSTA { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String AD { get; set; }
            public virtual Decimal VARLIKTIPID { get; set; }
            public virtual String VERGINO { get; set; }
            public virtual Decimal? VERGIDAIREID { get; set; }
            public virtual Decimal ODEMETIPID { get; set; }
            public virtual Decimal? ULKEID { get; set; }
            public virtual Decimal? ILID { get; set; }
            public virtual Decimal? ILCEID { get; set; }
            public virtual String ADRES { get; set; }
            public virtual Decimal EFATURA { get; set; }
            public virtual String EFATURAADRES { get; set; }
            public virtual String TELEFON { get; set; }
            public virtual String FAX { get; set; }
            public virtual String EPOSTA { get; set; }
        }
    }
}

