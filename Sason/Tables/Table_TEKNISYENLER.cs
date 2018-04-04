using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("d1395f05-4deb-4778-ba66-6e1a69bdcee8")]
    [DbTableInfoAttribute(TableTypes.Table, "TEKNISYENLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "TCKN", typeof(String), null, DbFieldFlags.None, 11, 0, 0, "")]
    [DbField(3, "AD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "SOYAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(5, "DOGUMTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(6, "KANGRUPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "AYAKKABINUMARAID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "ELBISEBEDENID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "EGITIMDUZEYID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "KULLANICIID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(11, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("TEKNISYENLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_TEKNISYENLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_TEKNISYENLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String TCKN { get; set; }
            protected virtual String AD { get; set; }
            protected virtual String SOYAD { get; set; }
            protected virtual DateTime DOGUMTARIH { get; set; }
            protected virtual Decimal KANGRUPID { get; set; }
            protected virtual Decimal AYAKKABINUMARAID { get; set; }
            protected virtual Decimal ELBISEBEDENID { get; set; }
            protected virtual Decimal EGITIMDUZEYID { get; set; }
            protected virtual String KULLANICIID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String TCKN { get; set; }
            public virtual String AD { get; set; }
            public virtual String SOYAD { get; set; }
            public virtual DateTime DOGUMTARIH { get; set; }
            public virtual Decimal KANGRUPID { get; set; }
            public virtual Decimal AYAKKABINUMARAID { get; set; }
            public virtual Decimal ELBISEBEDENID { get; set; }
            public virtual Decimal EGITIMDUZEYID { get; set; }
            public virtual String KULLANICIID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

