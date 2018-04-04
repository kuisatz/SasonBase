using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("f475bec4-d86b-40d5-bed9-7ee027af82b9")]
    [DbTableInfoAttribute(TableTypes.Table, "FATURALAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "CARIUNVAN", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(3, "VNO", typeof(String), null, DbFieldFlags.Nullable, 11, 0, 0, "")]
    [DbField(4, "VERGIDAIRESI", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(5, "ADRES", typeof(String), null, DbFieldFlags.Nullable, 400, 0, 0, "")]
    [DbField(6, "IL", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(7, "ILCE", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(8, "TELNO", typeof(String), null, DbFieldFlags.Nullable, 16, 0, 0, "")]
    [DbField(9, "ILGILIKISI", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(10, "ILGILIKISITELNO", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(11, "ISLEMTARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(12, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 400, 0, 0, "")]
    [DbField(13, "ISLEMNO", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "ISLEMTIPI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "BRUTTOPLAM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "INDIRIMTOPLAM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "NETKDVTOPLAM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "NETTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "DURUMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(20, "SERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(21, "ISEMIRNO", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(22, "FATURADOSYA", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(23, "ICMALNO", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(24, "TOPLAM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(25, "KUR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(26, "FATURATURID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(27, "MANKARTKAZANILAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(28, "MANKARTHARCANAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(29, "FATURANO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(30, "SERVISSIPARISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(31, "FATURAVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(32, "TEVKIFATTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(33, "SONODEMETARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(34, "INETTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(35, "MNETTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(36, "DNETTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(37, "ARACTIPI", typeof(String), null, DbFieldFlags.Nullable, 30, 0, 0, "")]
    [DbField(38, "FATURAYIKESEN", typeof(String), null, DbFieldFlags.Nullable, 40, 0, 0, "")]
    [DbField(39, "TEVKIFATORAN", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(40, "IRSALIYENO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(41, "IRSALIYETARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(42, "EBADOCID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(43, "TOPLAMISCEUR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(44, "TOPLAMMLZEUR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(45, "TOPLAMPIYASAFATEUR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(46, "TOPLAMISLETIMEUR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(47, "NETTUTAREUR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(48, "KDVTUTAREUR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(49, "TOPLAMTUTAREUR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(50, "ICMALALTBILGI", typeof(String), null, DbFieldFlags.Nullable, 1000, 0, 0, "")]
    [DbField(51, "FATURANOT", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(52, "TEVKIFATACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(53, "SERVISSTOKHAREKETID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(54, "CARIKOD", typeof(String), null, DbFieldFlags.Nullable, 30, 0, 0, "")]
    [DbIndex("FATURALAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] { "ID" })]
    public abstract class Table_FATURALAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_FATURALAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String CARIUNVAN { get; set; }
            protected virtual String VNO { get; set; }
            protected virtual String VERGIDAIRESI { get; set; }
            protected virtual String ADRES { get; set; }
            protected virtual String IL { get; set; }
            protected virtual String ILCE { get; set; }
            protected virtual String TELNO { get; set; }
            protected virtual String ILGILIKISI { get; set; }
            protected virtual String ILGILIKISITELNO { get; set; }
            protected virtual DateTime ISLEMTARIHI { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal ISLEMNO { get; set; }
            protected virtual Decimal ISLEMTIPI { get; set; }
            protected virtual Decimal BRUTTOPLAM { get; set; }
            protected virtual Decimal INDIRIMTOPLAM { get; set; }
            protected virtual Decimal NETKDVTOPLAM { get; set; }
            protected virtual Decimal NETTUTAR { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual String ISEMIRNO { get; set; }
            protected virtual String FATURADOSYA { get; set; }
            protected virtual String ICMALNO { get; set; }
            protected virtual Decimal TOPLAM { get; set; }
            protected virtual Decimal KUR { get; set; }
            protected virtual Decimal FATURATURID { get; set; }
            protected virtual Decimal MANKARTKAZANILAN { get; set; }
            protected virtual Decimal MANKARTHARCANAN { get; set; }
            protected virtual String FATURANO { get; set; }
            protected virtual Decimal SERVISSIPARISID { get; set; }
            protected virtual Decimal FATURAVARLIKID { get; set; }
            protected virtual Decimal TEVKIFATTUTAR { get; set; }
            protected virtual DateTime SONODEMETARIHI { get; set; }
            protected virtual Decimal INETTUTAR { get; set; }
            protected virtual Decimal MNETTUTAR { get; set; }
            protected virtual Decimal DNETTUTAR { get; set; }
            protected virtual String ARACTIPI { get; set; }
            protected virtual String FATURAYIKESEN { get; set; }
            protected virtual String TEVKIFATORAN { get; set; }
            protected virtual String IRSALIYENO { get; set; }
            protected virtual DateTime IRSALIYETARIHI { get; set; }
            protected virtual Decimal EBADOCID { get; set; }
            protected virtual Decimal TOPLAMISCEUR { get; set; }
            protected virtual Decimal TOPLAMMLZEUR { get; set; }
            protected virtual Decimal TOPLAMPIYASAFATEUR { get; set; }
            protected virtual Decimal TOPLAMISLETIMEUR { get; set; }
            protected virtual Decimal NETTUTAREUR { get; set; }
            protected virtual Decimal KDVTUTAREUR { get; set; }
            protected virtual Decimal TOPLAMTUTAREUR { get; set; }
            protected virtual String ICMALALTBILGI { get; set; }
            protected virtual String FATURANOT { get; set; }
            protected virtual String TEVKIFATACIKLAMA { get; set; }
            protected virtual Decimal SERVISSTOKHAREKETID { get; set; }
            protected virtual String CARIKOD { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String CARIUNVAN { get; set; }
            public virtual String VNO { get; set; }
            public virtual String VERGIDAIRESI { get; set; }
            public virtual String ADRES { get; set; }
            public virtual String IL { get; set; }
            public virtual String ILCE { get; set; }
            public virtual String TELNO { get; set; }
            public virtual String ILGILIKISI { get; set; }
            public virtual String ILGILIKISITELNO { get; set; }
            public virtual DateTime ISLEMTARIHI { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal ISLEMNO { get; set; }
            public virtual Decimal ISLEMTIPI { get; set; }
            public virtual Decimal BRUTTOPLAM { get; set; }
            public virtual Decimal INDIRIMTOPLAM { get; set; }
            public virtual Decimal NETKDVTOPLAM { get; set; }
            public virtual Decimal NETTUTAR { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual String ISEMIRNO { get; set; }
            public virtual String FATURADOSYA { get; set; }
            public virtual String ICMALNO { get; set; }
            public virtual Decimal TOPLAM { get; set; }
            public virtual Decimal KUR { get; set; }
            public virtual Decimal FATURATURID { get; set; }
            public virtual Decimal MANKARTKAZANILAN { get; set; }
            public virtual Decimal MANKARTHARCANAN { get; set; }
            public virtual String FATURANO { get; set; }
            public virtual Decimal SERVISSIPARISID { get; set; }
            public virtual Decimal FATURAVARLIKID { get; set; }
            public virtual Decimal TEVKIFATTUTAR { get; set; }
            public virtual DateTime SONODEMETARIHI { get; set; }
            public virtual Decimal INETTUTAR { get; set; }
            public virtual Decimal MNETTUTAR { get; set; }
            public virtual Decimal DNETTUTAR { get; set; }
            public virtual String ARACTIPI { get; set; }
            public virtual String FATURAYIKESEN { get; set; }
            public virtual String TEVKIFATORAN { get; set; }
            public virtual String IRSALIYENO { get; set; }
            public virtual DateTime IRSALIYETARIHI { get; set; }
            public virtual Decimal EBADOCID { get; set; }
            public virtual Decimal TOPLAMISCEUR { get; set; }
            public virtual Decimal TOPLAMMLZEUR { get; set; }
            public virtual Decimal TOPLAMPIYASAFATEUR { get; set; }
            public virtual Decimal TOPLAMISLETIMEUR { get; set; }
            public virtual Decimal NETTUTAREUR { get; set; }
            public virtual Decimal KDVTUTAREUR { get; set; }
            public virtual Decimal TOPLAMTUTAREUR { get; set; }
            public virtual String ICMALALTBILGI { get; set; }
            public virtual String FATURANOT { get; set; }
            public virtual String TEVKIFATACIKLAMA { get; set; }
            public virtual Decimal SERVISSTOKHAREKETID { get; set; }
            public virtual String CARIKOD { get; set; }
        }
    }
}
