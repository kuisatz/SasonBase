using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("d5ad0664-e53e-4f60-a16b-5350d247c997")]
    [DbTableInfoAttribute(TableTypes.Table, "FATURADETAYLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "FATURAID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "KOD", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(4, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(5, "BIRIMAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(6, "MIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "BIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "AYRISTIRMAORANI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "TLFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "INDIRIM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "BRUTTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "TUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "KDVORAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "TURID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "MANKARTORAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "MANKARTPUAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "MANKARTHARCANAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "ISCILIKTUTAREUR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "MALZEMETUTAREUR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(20, "PIYASAFATTUTAREUR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(21, "ISLETIMTUTAREUR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(22, "SERVISSTOKHAREKETDETAYID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(23, "STOKKOD", typeof(String), null, DbFieldFlags.Nullable, 250, 0, 0, "")]
    [DbIndex("FATURADETAYLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_FATURADETAYLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_FATURADETAYLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal FATURAID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual String BIRIMAD { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual Decimal BIRIMFIYAT { get; set; }
            protected virtual Decimal AYRISTIRMAORANI { get; set; }
            protected virtual Decimal TLFIYAT { get; set; }
            protected virtual Decimal INDIRIM { get; set; }
            protected virtual Decimal BRUTTUTAR { get; set; }
            protected virtual Decimal TUTAR { get; set; }
            protected virtual Decimal KDVORAN { get; set; }
            protected virtual Decimal TURID { get; set; }
            protected virtual Decimal MANKARTORAN { get; set; }
            protected virtual Decimal MANKARTPUAN { get; set; }
            protected virtual Decimal MANKARTHARCANAN { get; set; }
            protected virtual Decimal ISCILIKTUTAREUR { get; set; }
            protected virtual Decimal MALZEMETUTAREUR { get; set; }
            protected virtual Decimal PIYASAFATTUTAREUR { get; set; }
            protected virtual Decimal ISLETIMTUTAREUR { get; set; }
            protected virtual Decimal SERVISSTOKHAREKETDETAYID { get; set; }
            protected virtual String STOKKOD { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal FATURAID { get; set; }
            public virtual String KOD { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual String BIRIMAD { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual Decimal BIRIMFIYAT { get; set; }
            public virtual Decimal AYRISTIRMAORANI { get; set; }
            public virtual Decimal TLFIYAT { get; set; }
            public virtual Decimal INDIRIM { get; set; }
            public virtual Decimal BRUTTUTAR { get; set; }
            public virtual Decimal TUTAR { get; set; }
            public virtual Decimal KDVORAN { get; set; }
            public virtual Decimal TURID { get; set; }
            public virtual Decimal MANKARTORAN { get; set; }
            public virtual Decimal MANKARTPUAN { get; set; }
            public virtual Decimal MANKARTHARCANAN { get; set; }
            public virtual Decimal ISCILIKTUTAREUR { get; set; }
            public virtual Decimal MALZEMETUTAREUR { get; set; }
            public virtual Decimal PIYASAFATTUTAREUR { get; set; }
            public virtual Decimal ISLETIMTUTAREUR { get; set; }
            public virtual Decimal SERVISSTOKHAREKETDETAYID { get; set; }
            public virtual String STOKKOD { get; set; }
        }
    }
}

