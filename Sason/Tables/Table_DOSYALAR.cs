using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("ebea671e-2e8d-4a4c-a779-ea723e900131")]
    [DbTableInfoAttribute(TableTypes.Table, "DOSYALAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AD", typeof(String), null, DbFieldFlags.None, 128, 0, 0, "")]
    [DbField(3, "DIZIN", typeof(String), null, DbFieldFlags.None, 512, 0, 0, "")]
    [DbField(4, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 512, 0, 0, "")]
    [DbField(5, "DOSYADIZIN", typeof(String), null, DbFieldFlags.None, 64, 0, 0, "")]
    [DbField(6, "DOSYAKATEGORI", typeof(String), null, DbFieldFlags.Nullable, 64, 0, 0, "")]
    [DbField(7, "DOSYAREFID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(9, "TARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(10, "SERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "KULLANICIID", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbIndex("DOSYALAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_DOSYALAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_DOSYALAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String AD { get; set; }
            protected virtual String DIZIN { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual String DOSYADIZIN { get; set; }
            protected virtual String DOSYAKATEGORI { get; set; }
            protected virtual Decimal DOSYAREFID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual String KULLANICIID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String AD { get; set; }
            public virtual String DIZIN { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual String DOSYADIZIN { get; set; }
            public virtual String DOSYAKATEGORI { get; set; }
            public virtual Decimal DOSYAREFID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual String KULLANICIID { get; set; }
        }
    }
}

