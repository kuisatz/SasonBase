using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("ee618042-3693-421c-85ed-ae4b4590469b")]
    [DbTableInfoAttribute(TableTypes.Table, "AYRISTIRMADETAYLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AYRISTIRMAID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "REFERANSID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "ORAN1", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "GTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "ONAY", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "ATUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "MIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "CIKMAHAREKETID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "CIKANMALZEMEID", typeof(String), null, DbFieldFlags.Nullable, 30, 0, 0, "")]
    [DbField(12, "MTBTR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "TURID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "SOZLESMEADET", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "PDFITEMKOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(16, "PDFITEMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "PDFITEMTANIM", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(18, "PDFMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "PDFONAYLANANYUZDE", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(20, "PDFNETFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(21, "PDFISLETIMUCRETI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(22, "PDFTOPLAM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(23, "PDFPARABIRIMID", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(24, "FATURAID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("AYRISTIRMADETAYLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_AYRISTIRMADETAYLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_AYRISTIRMADETAYLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal AYRISTIRMAID { get; set; }
            protected virtual Decimal REFERANSID { get; set; }
            protected virtual Decimal ORAN1 { get; set; }
            protected virtual Decimal GTUTAR { get; set; }
            protected virtual Decimal ONAY { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal ATUTAR { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual Decimal CIKMAHAREKETID { get; set; }
            protected virtual String CIKANMALZEMEID { get; set; }
            protected virtual Decimal MTBTR { get; set; }
            protected virtual Decimal TURID { get; set; }
            protected virtual Decimal SOZLESMEADET { get; set; }
            protected virtual String PDFITEMKOD { get; set; }
            protected virtual Decimal PDFITEMID { get; set; }
            protected virtual String PDFITEMTANIM { get; set; }
            protected virtual Decimal PDFMIKTAR { get; set; }
            protected virtual Decimal PDFONAYLANANYUZDE { get; set; }
            protected virtual Decimal PDFNETFIYAT { get; set; }
            protected virtual Decimal PDFISLETIMUCRETI { get; set; }
            protected virtual Decimal PDFTOPLAM { get; set; }
            protected virtual String PDFPARABIRIMID { get; set; }
            protected virtual Decimal FATURAID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal AYRISTIRMAID { get; set; }
            public virtual Decimal REFERANSID { get; set; }
            public virtual Decimal ORAN1 { get; set; }
            public virtual Decimal GTUTAR { get; set; }
            public virtual Decimal ONAY { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal ATUTAR { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual Decimal CIKMAHAREKETID { get; set; }
            public virtual String CIKANMALZEMEID { get; set; }
            public virtual Decimal MTBTR { get; set; }
            public virtual Decimal TURID { get; set; }
            public virtual Decimal SOZLESMEADET { get; set; }
            public virtual String PDFITEMKOD { get; set; }
            public virtual Decimal PDFITEMID { get; set; }
            public virtual String PDFITEMTANIM { get; set; }
            public virtual Decimal PDFMIKTAR { get; set; }
            public virtual Decimal PDFONAYLANANYUZDE { get; set; }
            public virtual Decimal PDFNETFIYAT { get; set; }
            public virtual Decimal PDFISLETIMUCRETI { get; set; }
            public virtual Decimal PDFTOPLAM { get; set; }
            public virtual String PDFPARABIRIMID { get; set; }
            public virtual Decimal FATURAID { get; set; }
        }
    }
}

