using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("ace4a9c0-e72a-489c-92f2-baa8034c185c")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISISEMIRISLEMLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISISEMIRID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ISEMIRTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "ISEMIRUYGULAMAMANEDENID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "TEKNIKOLARAKTAMAMLA", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 4000, 0, 0, "")]
    [DbField(8, "ISLEMDURUMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "REZERVTARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(10, "INDIRIMORAN1", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "INDIRIMORAN2", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "INDIRIMORAN3", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "TISCTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "TIISCTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "TMLZTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "TIKLMTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "TKLMTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "THZTTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "TIHZTTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(20, "SIRANO", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(21, "TIMLZTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(22, "ARIZAKODU", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(23, "ARIZANEDENMALZEMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(24, "ARIZAMLZMKYPNEDENID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(25, "JOBONAY", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(26, "AKSIYONID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(27, "AKSIYONISLEMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(28, "BAKIMSTATU", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(29, "BAKIMNO", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(30, "DTOPLAM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(31, "DITOPLAM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(32, "BAKIMTOPLU", typeof(String), null, DbFieldFlags.Nullable, 1000, 0, 0, "")]
    [DbField(33, "YPONAY", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(34, "REFAKSIYONID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(35, "BAKIMISCILIKSURE", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(36, "FATURAID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISISEMIRISLMR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISISEMIRISLEMLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISISEMIRISLEMLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISISEMIRID { get; set; }
            protected virtual Decimal ISEMIRTIPID { get; set; }
            protected virtual Decimal ISEMIRUYGULAMAMANEDENID { get; set; }
            protected virtual Decimal TEKNIKOLARAKTAMAMLA { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal ISLEMDURUMID { get; set; }
            protected virtual DateTime REZERVTARIHI { get; set; }
            protected virtual Decimal INDIRIMORAN1 { get; set; }
            protected virtual Decimal INDIRIMORAN2 { get; set; }
            protected virtual Decimal INDIRIMORAN3 { get; set; }
            protected virtual Decimal TISCTUTAR { get; set; }
            protected virtual Decimal TIISCTUTAR { get; set; }
            protected virtual Decimal TMLZTUTAR { get; set; }
            protected virtual Decimal TIKLMTUTAR { get; set; }
            protected virtual Decimal TKLMTUTAR { get; set; }
            protected virtual Decimal THZTTUTAR { get; set; }
            protected virtual Decimal TIHZTTUTAR { get; set; }
            protected virtual Decimal SIRANO { get; set; }
            protected virtual Decimal TIMLZTUTAR { get; set; }
            protected virtual String ARIZAKODU { get; set; }
            protected virtual Decimal ARIZANEDENMALZEMEID { get; set; }
            protected virtual Decimal ARIZAMLZMKYPNEDENID { get; set; }
            protected virtual Decimal JOBONAY { get; set; }
            protected virtual Decimal AKSIYONID { get; set; }
            protected virtual Decimal AKSIYONISLEMID { get; set; }
            protected virtual Decimal BAKIMSTATU { get; set; }
            protected virtual Decimal BAKIMNO { get; set; }
            protected virtual Decimal DTOPLAM { get; set; }
            protected virtual Decimal DITOPLAM { get; set; }
            protected virtual String BAKIMTOPLU { get; set; }
            protected virtual Decimal YPONAY { get; set; }
            protected virtual Decimal REFAKSIYONID { get; set; }
            protected virtual String BAKIMISCILIKSURE { get; set; }
            protected virtual Decimal FATURAID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISISEMIRID { get; set; }
            public virtual Decimal ISEMIRTIPID { get; set; }
            public virtual Decimal ISEMIRUYGULAMAMANEDENID { get; set; }
            public virtual Decimal TEKNIKOLARAKTAMAMLA { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal ISLEMDURUMID { get; set; }
            public virtual DateTime REZERVTARIHI { get; set; }
            public virtual Decimal INDIRIMORAN1 { get; set; }
            public virtual Decimal INDIRIMORAN2 { get; set; }
            public virtual Decimal INDIRIMORAN3 { get; set; }
            public virtual Decimal TISCTUTAR { get; set; }
            public virtual Decimal TIISCTUTAR { get; set; }
            public virtual Decimal TMLZTUTAR { get; set; }
            public virtual Decimal TIKLMTUTAR { get; set; }
            public virtual Decimal TKLMTUTAR { get; set; }
            public virtual Decimal THZTTUTAR { get; set; }
            public virtual Decimal TIHZTTUTAR { get; set; }
            public virtual Decimal SIRANO { get; set; }
            public virtual Decimal TIMLZTUTAR { get; set; }
            public virtual String ARIZAKODU { get; set; }
            public virtual Decimal ARIZANEDENMALZEMEID { get; set; }
            public virtual Decimal ARIZAMLZMKYPNEDENID { get; set; }
            public virtual Decimal JOBONAY { get; set; }
            public virtual Decimal AKSIYONID { get; set; }
            public virtual Decimal AKSIYONISLEMID { get; set; }
            public virtual Decimal BAKIMSTATU { get; set; }
            public virtual Decimal BAKIMNO { get; set; }
            public virtual Decimal DTOPLAM { get; set; }
            public virtual Decimal DITOPLAM { get; set; }
            public virtual String BAKIMTOPLU { get; set; }
            public virtual Decimal YPONAY { get; set; }
            public virtual Decimal REFAKSIYONID { get; set; }
            public virtual String BAKIMISCILIKSURE { get; set; }
            public virtual Decimal FATURAID { get; set; }
        }
    }
}

