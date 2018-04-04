using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("665cf635-f76d-4a10-9ce3-10ef6fe74680")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISTEKLIFLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "TEKLIFSERVISISORTAKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(3, "TEKLIFSERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "BELGENO", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(5, "BASTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(6, "BITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(7, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 2000, 0, 0, "")]
    [DbField(8, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(9, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(10, "PARABIRIMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "TOPLAMBIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "TOPLAMINDBIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "REVIZESERVISTEKLIFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "SEVKADRESI", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(15, "ACIKLAMA2", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(16, "ACIKLAMAMERKEZ", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(17, "MALZEMEALISAMACID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "ODEMETIPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISTEKLIFLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISTEKLIFLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISTEKLIFLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal TEKLIFSERVISISORTAKID { get; set; }
            protected virtual Decimal TEKLIFSERVISID { get; set; }
            protected virtual String BELGENO { get; set; }
            protected virtual DateTime BASTARIH { get; set; }
            protected virtual DateTime BITTARIH { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal PARABIRIMID { get; set; }
            protected virtual Decimal TOPLAMBIRIMFIYAT { get; set; }
            protected virtual Decimal TOPLAMINDBIRIMFIYAT { get; set; }
            protected virtual Decimal REVIZESERVISTEKLIFID { get; set; }
            protected virtual String SEVKADRESI { get; set; }
            protected virtual String ACIKLAMA2 { get; set; }
            protected virtual String ACIKLAMAMERKEZ { get; set; }
            protected virtual Decimal MALZEMEALISAMACID { get; set; }
            protected virtual Decimal ODEMETIPID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal TEKLIFSERVISISORTAKID { get; set; }
            public virtual Decimal TEKLIFSERVISID { get; set; }
            public virtual String BELGENO { get; set; }
            public virtual DateTime BASTARIH { get; set; }
            public virtual DateTime BITTARIH { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal PARABIRIMID { get; set; }
            public virtual Decimal TOPLAMBIRIMFIYAT { get; set; }
            public virtual Decimal TOPLAMINDBIRIMFIYAT { get; set; }
            public virtual Decimal REVIZESERVISTEKLIFID { get; set; }
            public virtual String SEVKADRESI { get; set; }
            public virtual String ACIKLAMA2 { get; set; }
            public virtual String ACIKLAMAMERKEZ { get; set; }
            public virtual Decimal MALZEMEALISAMACID { get; set; }
            public virtual Decimal ODEMETIPID { get; set; }
        }
    }
}

