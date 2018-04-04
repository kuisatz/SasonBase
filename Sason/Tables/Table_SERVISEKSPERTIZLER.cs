using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("4916b324-44f0-4743-935f-7f187628fcb4")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISEKSPERTIZLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(3, "SERVISARACID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "SERVISVARLIKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "ENDEKS", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "KM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "SAAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "DEPODURUM", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(9, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 4000, 0, 0, "")]
    [DbField(10, "GTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(11, "MUSTERIAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(12, "MUSTERITELEFON", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(13, "MUSTERIEPOSTA", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(14, "ARACKAZALI", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(15, "ARACKAZAACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 4000, 0, 0, "")]
    [DbField(16, "KULLANICIID", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(17, "KAYITTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(18, "PARABIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(19, "TUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(20, "INDIRIMLITUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(21, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(22, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(23, "REVIZYON", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(24, "AGREGAID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(25, "ISLEMSIRA", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(26, "TEKLIFDURUM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(27, "FATURAVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(28, "SASENO", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(29, "BELGENO", typeof(String), null, DbFieldFlags.Nullable, 16, 0, 0, "")]
    [DbField(30, "OKULLANICIID", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(31, "ISEMIRDONUSUM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(32, "SERVISISORTAKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISEKSPERTIZLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISEKSPERTIZLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISEKSPERTIZLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual Decimal SERVISARACID { get; set; }
            protected virtual Decimal SERVISVARLIKID { get; set; }
            protected virtual Decimal ENDEKS { get; set; }
            protected virtual Decimal KM { get; set; }
            protected virtual Decimal SAAT { get; set; }
            protected virtual String DEPODURUM { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual DateTime GTARIH { get; set; }
            protected virtual String MUSTERIAD { get; set; }
            protected virtual String MUSTERITELEFON { get; set; }
            protected virtual String MUSTERIEPOSTA { get; set; }
            protected virtual Decimal ARACKAZALI { get; set; }
            protected virtual String ARACKAZAACIKLAMA { get; set; }
            protected virtual String KULLANICIID { get; set; }
            protected virtual DateTime KAYITTARIH { get; set; }
            protected virtual Decimal PARABIRIMID { get; set; }
            protected virtual Decimal TUTAR { get; set; }
            protected virtual Decimal INDIRIMLITUTAR { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal REVIZYON { get; set; }
            protected virtual Decimal AGREGAID { get; set; }
            protected virtual Decimal ISLEMSIRA { get; set; }
            protected virtual Decimal TEKLIFDURUM { get; set; }
            protected virtual Decimal FATURAVARLIKID { get; set; }
            protected virtual String SASENO { get; set; }
            protected virtual String BELGENO { get; set; }
            protected virtual String OKULLANICIID { get; set; }
            protected virtual Decimal ISEMIRDONUSUM { get; set; }
            protected virtual Decimal SERVISISORTAKID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal SERVISARACID { get; set; }
            public virtual Decimal SERVISVARLIKID { get; set; }
            public virtual Decimal ENDEKS { get; set; }
            public virtual Decimal KM { get; set; }
            public virtual Decimal SAAT { get; set; }
            public virtual String DEPODURUM { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual DateTime GTARIH { get; set; }
            public virtual String MUSTERIAD { get; set; }
            public virtual String MUSTERITELEFON { get; set; }
            public virtual String MUSTERIEPOSTA { get; set; }
            public virtual Decimal ARACKAZALI { get; set; }
            public virtual String ARACKAZAACIKLAMA { get; set; }
            public virtual String KULLANICIID { get; set; }
            public virtual DateTime KAYITTARIH { get; set; }
            public virtual Decimal PARABIRIMID { get; set; }
            public virtual Decimal TUTAR { get; set; }
            public virtual Decimal INDIRIMLITUTAR { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal REVIZYON { get; set; }
            public virtual Decimal AGREGAID { get; set; }
            public virtual Decimal ISLEMSIRA { get; set; }
            public virtual Decimal TEKLIFDURUM { get; set; }
            public virtual Decimal FATURAVARLIKID { get; set; }
            public virtual String SASENO { get; set; }
            public virtual String BELGENO { get; set; }
            public virtual String OKULLANICIID { get; set; }
            public virtual Decimal ISEMIRDONUSUM { get; set; }
            public virtual Decimal SERVISISORTAKID { get; set; }
        }
    }
}

