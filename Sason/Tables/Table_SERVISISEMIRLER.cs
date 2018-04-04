using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("84f233b7-2cad-4878-851b-73267d2ccc98")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISISEMIRLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(3, "SERVISARACID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "SERVISVARLIKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "SERVISEKSPERTIZID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "ENDEKS", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "KM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "SAAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "DEPODURUM", typeof(String), null, DbFieldFlags.Nullable, 5, 0, 0, "")]
    [DbField(10, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 4000, 0, 0, "")]
    [DbField(11, "MUSTERIAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(12, "MUSTERITELEFON", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(13, "MUSTERIEPOSTA", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(14, "ARACKAZALI", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(15, "ARACKAZAACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 4000, 0, 0, "")]
    [DbField(16, "KULLANICIID", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(17, "TALANKULLANICIID", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(18, "KAYITTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(19, "PARABIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(20, "TBITISTARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(21, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(22, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(23, "SASENO", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(24, "TUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(25, "INDIRIMLITUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(26, "REVIZYON", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(27, "AGREGAID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(28, "FATURAVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(29, "SERVISRANDEVUID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(30, "TTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(31, "BELGENO", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(32, "TEKNIKOLARAKTAMAMLA", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(33, "ARACSERVISTE", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(34, "ISEMIRNO", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(35, "TAMAMLANMATARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(36, "ARACYOLDAKALDI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(37, "KUR", typeof(String), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(38, "OKULLANICIID", typeof(String), null, DbFieldFlags.Nullable, 30, 0, 0, "")]
    [DbField(39, "TARIHACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(40, "GOTURENAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(41, "GOTURENTELEFON", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(42, "GOTURENEPOSTA", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(43, "DIZAYN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(44, "SERVISISORTAKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(45, "AKSIYONREZERV", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(46, "TBITISTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(47, "HIZMETYERID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(48, "AKSIYONPROTOKOL", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(49, "SERVISFORMU", typeof(String), null, DbFieldFlags.Nullable, 300, 0, 0, "")]
    [DbField(50, "FATURAID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(51, "ARACTIPAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(52, "PLAKA", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(53, "MODELNO", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(54, "FIRSTREGDATE", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbIndex("SERVISISEMIRLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISISEMIRLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISISEMIRLER))]
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
            protected virtual Decimal SERVISEKSPERTIZID { get; set; }
            protected virtual Decimal ENDEKS { get; set; }
            protected virtual Decimal KM { get; set; }
            protected virtual Decimal SAAT { get; set; }
            protected virtual String DEPODURUM { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual String MUSTERIAD { get; set; }
            protected virtual String MUSTERITELEFON { get; set; }
            protected virtual String MUSTERIEPOSTA { get; set; }
            protected virtual Decimal ARACKAZALI { get; set; }
            protected virtual String ARACKAZAACIKLAMA { get; set; }
            protected virtual String KULLANICIID { get; set; }
            protected virtual String TALANKULLANICIID { get; set; }
            protected virtual DateTime KAYITTARIH { get; set; }
            protected virtual Decimal PARABIRIMID { get; set; }
            protected virtual DateTime TBITISTARIHI { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual String SASENO { get; set; }
            protected virtual Decimal TUTAR { get; set; }
            protected virtual Decimal INDIRIMLITUTAR { get; set; }
            protected virtual Decimal REVIZYON { get; set; }
            protected virtual Decimal AGREGAID { get; set; }
            protected virtual Decimal FATURAVARLIKID { get; set; }
            protected virtual Decimal SERVISRANDEVUID { get; set; }
            protected virtual Decimal TTUTAR { get; set; }
            protected virtual String BELGENO { get; set; }
            protected virtual Decimal TEKNIKOLARAKTAMAMLA { get; set; }
            protected virtual Decimal ARACSERVISTE { get; set; }
            protected virtual String ISEMIRNO { get; set; }
            protected virtual DateTime TAMAMLANMATARIH { get; set; }
            protected virtual Decimal ARACYOLDAKALDI { get; set; }
            protected virtual String KUR { get; set; }
            protected virtual String OKULLANICIID { get; set; }
            protected virtual String TARIHACIKLAMA { get; set; }
            protected virtual String GOTURENAD { get; set; }
            protected virtual String GOTURENTELEFON { get; set; }
            protected virtual String GOTURENEPOSTA { get; set; }
            protected virtual Decimal DIZAYN { get; set; }
            protected virtual Decimal SERVISISORTAKID { get; set; }
            protected virtual Decimal AKSIYONREZERV { get; set; }
            protected virtual DateTime TBITISTARIH { get; set; }
            protected virtual Decimal HIZMETYERID { get; set; }
            protected virtual String AKSIYONPROTOKOL { get; set; }
            protected virtual String SERVISFORMU { get; set; }
            protected virtual Decimal FATURAID { get; set; }
            protected virtual String ARACTIPAD { get; set; }
            protected virtual String PLAKA { get; set; }
            protected virtual String MODELNO { get; set; }
            protected virtual DateTime FIRSTREGDATE { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal SERVISARACID { get; set; }
            public virtual Decimal SERVISVARLIKID { get; set; }
            public virtual Decimal SERVISEKSPERTIZID { get; set; }
            public virtual Decimal ENDEKS { get; set; }
            public virtual Decimal KM { get; set; }
            public virtual Decimal SAAT { get; set; }
            public virtual String DEPODURUM { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual String MUSTERIAD { get; set; }
            public virtual String MUSTERITELEFON { get; set; }
            public virtual String MUSTERIEPOSTA { get; set; }
            public virtual Decimal ARACKAZALI { get; set; }
            public virtual String ARACKAZAACIKLAMA { get; set; }
            public virtual String KULLANICIID { get; set; }
            public virtual String TALANKULLANICIID { get; set; }
            public virtual DateTime KAYITTARIH { get; set; }
            public virtual Decimal PARABIRIMID { get; set; }
            public virtual DateTime TBITISTARIHI { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual String SASENO { get; set; }
            public virtual Decimal TUTAR { get; set; }
            public virtual Decimal INDIRIMLITUTAR { get; set; }
            public virtual Decimal REVIZYON { get; set; }
            public virtual Decimal AGREGAID { get; set; }
            public virtual Decimal FATURAVARLIKID { get; set; }
            public virtual Decimal SERVISRANDEVUID { get; set; }
            public virtual Decimal TTUTAR { get; set; }
            public virtual String BELGENO { get; set; }
            public virtual Decimal TEKNIKOLARAKTAMAMLA { get; set; }
            public virtual Decimal ARACSERVISTE { get; set; }
            public virtual String ISEMIRNO { get; set; }
            public virtual DateTime TAMAMLANMATARIH { get; set; }
            public virtual Decimal ARACYOLDAKALDI { get; set; }
            public virtual String KUR { get; set; }
            public virtual String OKULLANICIID { get; set; }
            public virtual String TARIHACIKLAMA { get; set; }
            public virtual String GOTURENAD { get; set; }
            public virtual String GOTURENTELEFON { get; set; }
            public virtual String GOTURENEPOSTA { get; set; }
            public virtual Decimal DIZAYN { get; set; }
            public virtual Decimal SERVISISORTAKID { get; set; }
            public virtual Decimal AKSIYONREZERV { get; set; }
            public virtual DateTime TBITISTARIH { get; set; }
            public virtual Decimal HIZMETYERID { get; set; }
            public virtual String AKSIYONPROTOKOL { get; set; }
            public virtual String SERVISFORMU { get; set; }
            public virtual Decimal FATURAID { get; set; }
            public virtual String ARACTIPAD { get; set; }
            public virtual String PLAKA { get; set; }
            public virtual String MODELNO { get; set; }
            public virtual DateTime FIRSTREGDATE { get; set; }
        }
    }
}

