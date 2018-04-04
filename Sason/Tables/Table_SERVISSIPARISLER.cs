using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("4592cc15-6d51-411c-99c3-6115ab427307")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISSIPARISLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SIPARISISORTAKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(3, "SIPARISSERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "BELGENO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(5, "TARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(6, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 2000, 0, 0, "")]
    [DbField(7, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "SERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "PARABIRIMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "TOPLAMBIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "TOPLAMINDBIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "SEVKADRESI", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(13, "SIPARISDURUMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "SERVISVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "MALZEMEALISAMACID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "ACIKLAMA2", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(17, "ACIKLAMAMERKEZ", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(18, "SIPARISTURID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(19, "SASENO", typeof(String), null, DbFieldFlags.Nullable, 17, 0, 0, "")]
    [DbField(20, "KULLANICI", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(21, "FATURATAMAM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(22, "ODEMETIPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISSIPARISLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISSIPARISLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISSIPARISLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SIPARISISORTAKID { get; set; }
            protected virtual Decimal SIPARISSERVISID { get; set; }
            protected virtual String BELGENO { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal PARABIRIMID { get; set; }
            protected virtual Decimal TOPLAMBIRIMFIYAT { get; set; }
            protected virtual Decimal TOPLAMINDBIRIMFIYAT { get; set; }
            protected virtual String SEVKADRESI { get; set; }
            protected virtual Decimal SIPARISDURUMID { get; set; }
            protected virtual Decimal SERVISVARLIKID { get; set; }
            protected virtual Decimal MALZEMEALISAMACID { get; set; }
            protected virtual String ACIKLAMA2 { get; set; }
            protected virtual String ACIKLAMAMERKEZ { get; set; }
            protected virtual Decimal SIPARISTURID { get; set; }
            protected virtual String SASENO { get; set; }
            protected virtual String KULLANICI { get; set; }
            protected virtual Decimal FATURATAMAM { get; set; }
            protected virtual Decimal ODEMETIPID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SIPARISISORTAKID { get; set; }
            public virtual Decimal SIPARISSERVISID { get; set; }
            public virtual String BELGENO { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal PARABIRIMID { get; set; }
            public virtual Decimal TOPLAMBIRIMFIYAT { get; set; }
            public virtual Decimal TOPLAMINDBIRIMFIYAT { get; set; }
            public virtual String SEVKADRESI { get; set; }
            public virtual Decimal SIPARISDURUMID { get; set; }
            public virtual Decimal SERVISVARLIKID { get; set; }
            public virtual Decimal MALZEMEALISAMACID { get; set; }
            public virtual String ACIKLAMA2 { get; set; }
            public virtual String ACIKLAMAMERKEZ { get; set; }
            public virtual Decimal SIPARISTURID { get; set; }
            public virtual String SASENO { get; set; }
            public virtual String KULLANICI { get; set; }
            public virtual Decimal FATURATAMAM { get; set; }
            public virtual Decimal ODEMETIPID { get; set; }
        }
    }
}

