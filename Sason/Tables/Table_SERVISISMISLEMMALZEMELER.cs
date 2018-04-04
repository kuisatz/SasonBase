using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("3d1f3419-bb30-4605-adec-63b04ad81919")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISISMISLEMMALZEMELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISISEMIRISLEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "SERVISSTOKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "MALZEMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "MIKTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "BIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "KULLANILDI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "KENDIGETIRDI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "MALZEMEBIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(10, "MALZEMEPARABIRIMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "TUTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(12, "INDIRIMLITUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 10, 3, "")]
    [DbField(13, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(14, "SERVISPAKETID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "DISARIDAYAPTIRDI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "STOKHAREKETID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "BAKIMISLEMYNEDENID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "CIKMAHAREKETID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "SURE", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbIndex("SERVISISMISLEMMALZEMELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISISMISLEMMALZEMELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISISMISLEMMALZEMELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISISEMIRISLEMID { get; set; }
            protected virtual Decimal SERVISSTOKID { get; set; }
            protected virtual Decimal MALZEMEID { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual Decimal BIRIMID { get; set; }
            protected virtual Decimal KULLANILDI { get; set; }
            protected virtual Decimal KENDIGETIRDI { get; set; }
            protected virtual Decimal MALZEMEBIRIMFIYAT { get; set; }
            protected virtual Decimal MALZEMEPARABIRIMID { get; set; }
            protected virtual Decimal TUTAR { get; set; }
            protected virtual Decimal INDIRIMLITUTAR { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISPAKETID { get; set; }
            protected virtual Decimal DISARIDAYAPTIRDI { get; set; }
            protected virtual Decimal STOKHAREKETID { get; set; }
            protected virtual Decimal BAKIMISLEMYNEDENID { get; set; }
            protected virtual Decimal CIKMAHAREKETID { get; set; }
            protected virtual String SURE { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISISEMIRISLEMID { get; set; }
            public virtual Decimal SERVISSTOKID { get; set; }
            public virtual Decimal MALZEMEID { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual Decimal BIRIMID { get; set; }
            public virtual Decimal KULLANILDI { get; set; }
            public virtual Decimal KENDIGETIRDI { get; set; }
            public virtual Decimal MALZEMEBIRIMFIYAT { get; set; }
            public virtual Decimal MALZEMEPARABIRIMID { get; set; }
            public virtual Decimal TUTAR { get; set; }
            public virtual Decimal INDIRIMLITUTAR { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISPAKETID { get; set; }
            public virtual Decimal DISARIDAYAPTIRDI { get; set; }
            public virtual Decimal STOKHAREKETID { get; set; }
            public virtual Decimal BAKIMISLEMYNEDENID { get; set; }
            public virtual Decimal CIKMAHAREKETID { get; set; }
            public virtual String SURE { get; set; }
        }
    }
}

