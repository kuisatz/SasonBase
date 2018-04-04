using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("63513e54-fb8e-4372-9892-a54d8e70ccd6")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISRANDEVULAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISARACID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(3, "PLAKA", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "AD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(5, "TELEFON", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(6, "TARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(7, "SIKAYETLER", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(8, "KULLANICIID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(9, "SERVISRANDEVUTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(10, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(11, "SIKAYETID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "SERVISISEMIRID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "GELECEKKM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISRANDEVULAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISRANDEVULAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISRANDEVULAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISARACID { get; set; }
            protected virtual String PLAKA { get; set; }
            protected virtual String AD { get; set; }
            protected virtual String TELEFON { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual String SIKAYETLER { get; set; }
            protected virtual String KULLANICIID { get; set; }
            protected virtual Decimal SERVISRANDEVUTIPID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal SIKAYETID { get; set; }
            protected virtual Decimal SERVISISEMIRID { get; set; }
            protected virtual Decimal GELECEKKM { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISARACID { get; set; }
            public virtual String PLAKA { get; set; }
            public virtual String AD { get; set; }
            public virtual String TELEFON { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual String SIKAYETLER { get; set; }
            public virtual String KULLANICIID { get; set; }
            public virtual Decimal SERVISRANDEVUTIPID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal SIKAYETID { get; set; }
            public virtual Decimal SERVISISEMIRID { get; set; }
            public virtual Decimal GELECEKKM { get; set; }
        }
    }
}

