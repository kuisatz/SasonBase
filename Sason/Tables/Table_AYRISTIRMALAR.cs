using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("54515407-1e4e-4c55-84a9-08c569a4e239")]
    [DbTableInfoAttribute(TableTypes.Table, "AYRISTIRMALAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISISEMIRISLEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "AYRISTIRMATIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "SIKAYET", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(5, "NEDEN", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(6, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "PARABIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "GTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "ATUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "TUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "SERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "ARIZA", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(13, "SERVISVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "MALZEMEFATURANO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(15, "MALZEMEFATURATARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(16, "MALZEMEKMFARK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "GARANTIKATEGORISI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "ISEMIRNO", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(19, "ARIZAKODU", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(20, "CASENO", typeof(String), null, DbFieldFlags.Nullable, 30, 0, 0, "")]
    [DbField(21, "CLAIMNO", typeof(String), null, DbFieldFlags.Nullable, 30, 0, 0, "")]
    [DbField(22, "SERVISSTOKHAREKETID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(23, "BAKIMSOZLESMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(24, "ESAGARANTINO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(25, "SERVISGARANTINO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(26, "GARANTISTATUS", typeof(String), null, DbFieldFlags.Nullable, 30, 0, 0, "")]
    [DbField(27, "ORAN1", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(28, "ORAN2", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(29, "ORAN3", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(30, "WSDURUM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(31, "SONOKUMAZAMANI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(32, "CLAIMSTATUS", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(33, "ESASTATU", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(34, "PDFSATICI", typeof(String), null, DbFieldFlags.Nullable, 30, 0, 0, "")]
    [DbField(35, "PDFSERVISKODU", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(36, "PDFTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(37, "PDFGARANTINO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(38, "PDFDMSNO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(39, "PDFSASENO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(40, "PDFKMDURUMU", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(41, "PDFGARANTITARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(42, "PDFTAMIRTARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(43, "PDFTOPLAMMALZEMETUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(44, "PDFTOPLAMISLETIMUCRETI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(45, "PDFTOPLAMISCILIKTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(46, "PDFTOPLAMPIYASAFATURASI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(47, "PDFMATRAH", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(48, "PDFKDV", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(49, "PDFTOPLAM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(50, "PDFTALEPGENELTOPLAM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(51, "PDFONAYNETGENELTOPLAM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(52, "PDFONAYTOPLAMYUZDE", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(53, "PDFONAYKDVTOPLAM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(54, "PDFONAYGENELTOPLAM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(55, "CARE", typeof(String), null, DbFieldFlags.Nullable, 72, 0, 0, "")]
    [DbField(56, "EKBILGI", typeof(String), null, DbFieldFlags.Nullable, 72, 0, 0, "")]
    [DbField(57, "TARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(58, "ICMALID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(59, "ESAGARANTIID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(60, "GARANTICUSTOMSTATUS", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(61, "PDFHATA", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("AYRISTIRMALAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_AYRISTIRMALAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_AYRISTIRMALAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISISEMIRISLEMID { get; set; }
            protected virtual Decimal AYRISTIRMATIPID { get; set; }
            protected virtual String SIKAYET { get; set; }
            protected virtual String NEDEN { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal PARABIRIMID { get; set; }
            protected virtual Decimal GTUTAR { get; set; }
            protected virtual Decimal ATUTAR { get; set; }
            protected virtual Decimal TUTAR { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual String ARIZA { get; set; }
            protected virtual Decimal SERVISVARLIKID { get; set; }
            protected virtual String MALZEMEFATURANO { get; set; }
            protected virtual DateTime MALZEMEFATURATARIH { get; set; }
            protected virtual Decimal MALZEMEKMFARK { get; set; }
            protected virtual Decimal GARANTIKATEGORISI { get; set; }
            protected virtual String ISEMIRNO { get; set; }
            protected virtual String ARIZAKODU { get; set; }
            protected virtual String CASENO { get; set; }
            protected virtual String CLAIMNO { get; set; }
            protected virtual Decimal SERVISSTOKHAREKETID { get; set; }
            protected virtual Decimal BAKIMSOZLESMEID { get; set; }
            protected virtual String ESAGARANTINO { get; set; }
            protected virtual String SERVISGARANTINO { get; set; }
            protected virtual String GARANTISTATUS { get; set; }
            protected virtual Decimal ORAN1 { get; set; }
            protected virtual Decimal ORAN2 { get; set; }
            protected virtual Decimal ORAN3 { get; set; }
            protected virtual Decimal WSDURUM { get; set; }
            protected virtual DateTime SONOKUMAZAMANI { get; set; }
            protected virtual String CLAIMSTATUS { get; set; }
            protected virtual String ESASTATU { get; set; }
            protected virtual String PDFSATICI { get; set; }
            protected virtual String PDFSERVISKODU { get; set; }
            protected virtual DateTime PDFTARIH { get; set; }
            protected virtual String PDFGARANTINO { get; set; }
            protected virtual String PDFDMSNO { get; set; }
            protected virtual String PDFSASENO { get; set; }
            protected virtual Decimal PDFKMDURUMU { get; set; }
            protected virtual DateTime PDFGARANTITARIHI { get; set; }
            protected virtual DateTime PDFTAMIRTARIHI { get; set; }
            protected virtual Decimal PDFTOPLAMMALZEMETUTAR { get; set; }
            protected virtual Decimal PDFTOPLAMISLETIMUCRETI { get; set; }
            protected virtual Decimal PDFTOPLAMISCILIKTUTAR { get; set; }
            protected virtual Decimal PDFTOPLAMPIYASAFATURASI { get; set; }
            protected virtual Decimal PDFMATRAH { get; set; }
            protected virtual Decimal PDFKDV { get; set; }
            protected virtual Decimal PDFTOPLAM { get; set; }
            protected virtual Decimal PDFTALEPGENELTOPLAM { get; set; }
            protected virtual Decimal PDFONAYNETGENELTOPLAM { get; set; }
            protected virtual Decimal PDFONAYTOPLAMYUZDE { get; set; }
            protected virtual Decimal PDFONAYKDVTOPLAM { get; set; }
            protected virtual Decimal PDFONAYGENELTOPLAM { get; set; }
            protected virtual String CARE { get; set; }
            protected virtual String EKBILGI { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual Decimal ICMALID { get; set; }
            protected virtual Decimal ESAGARANTIID { get; set; }
            protected virtual Decimal GARANTICUSTOMSTATUS { get; set; }
            protected virtual Decimal PDFHATA { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISISEMIRISLEMID { get; set; }
            public virtual Decimal AYRISTIRMATIPID { get; set; }
            public virtual String SIKAYET { get; set; }
            public virtual String NEDEN { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal PARABIRIMID { get; set; }
            public virtual Decimal GTUTAR { get; set; }
            public virtual Decimal ATUTAR { get; set; }
            public virtual Decimal TUTAR { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual String ARIZA { get; set; }
            public virtual Decimal SERVISVARLIKID { get; set; }
            public virtual String MALZEMEFATURANO { get; set; }
            public virtual DateTime MALZEMEFATURATARIH { get; set; }
            public virtual Decimal MALZEMEKMFARK { get; set; }
            public virtual Decimal GARANTIKATEGORISI { get; set; }
            public virtual String ISEMIRNO { get; set; }
            public virtual String ARIZAKODU { get; set; }
            public virtual String CASENO { get; set; }
            public virtual String CLAIMNO { get; set; }
            public virtual Decimal SERVISSTOKHAREKETID { get; set; }
            public virtual Decimal BAKIMSOZLESMEID { get; set; }
            public virtual String ESAGARANTINO { get; set; }
            public virtual String SERVISGARANTINO { get; set; }
            public virtual String GARANTISTATUS { get; set; }
            public virtual Decimal ORAN1 { get; set; }
            public virtual Decimal ORAN2 { get; set; }
            public virtual Decimal ORAN3 { get; set; }
            public virtual Decimal WSDURUM { get; set; }
            public virtual DateTime SONOKUMAZAMANI { get; set; }
            public virtual String CLAIMSTATUS { get; set; }
            public virtual String ESASTATU { get; set; }
            public virtual String PDFSATICI { get; set; }
            public virtual String PDFSERVISKODU { get; set; }
            public virtual DateTime PDFTARIH { get; set; }
            public virtual String PDFGARANTINO { get; set; }
            public virtual String PDFDMSNO { get; set; }
            public virtual String PDFSASENO { get; set; }
            public virtual Decimal PDFKMDURUMU { get; set; }
            public virtual DateTime PDFGARANTITARIHI { get; set; }
            public virtual DateTime PDFTAMIRTARIHI { get; set; }
            public virtual Decimal PDFTOPLAMMALZEMETUTAR { get; set; }
            public virtual Decimal PDFTOPLAMISLETIMUCRETI { get; set; }
            public virtual Decimal PDFTOPLAMISCILIKTUTAR { get; set; }
            public virtual Decimal PDFTOPLAMPIYASAFATURASI { get; set; }
            public virtual Decimal PDFMATRAH { get; set; }
            public virtual Decimal PDFKDV { get; set; }
            public virtual Decimal PDFTOPLAM { get; set; }
            public virtual Decimal PDFTALEPGENELTOPLAM { get; set; }
            public virtual Decimal PDFONAYNETGENELTOPLAM { get; set; }
            public virtual Decimal PDFONAYTOPLAMYUZDE { get; set; }
            public virtual Decimal PDFONAYKDVTOPLAM { get; set; }
            public virtual Decimal PDFONAYGENELTOPLAM { get; set; }
            public virtual String CARE { get; set; }
            public virtual String EKBILGI { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual Decimal ICMALID { get; set; }
            public virtual Decimal ESAGARANTIID { get; set; }
            public virtual Decimal GARANTICUSTOMSTATUS { get; set; }
            public virtual Decimal PDFHATA { get; set; }
        }
    }
}

