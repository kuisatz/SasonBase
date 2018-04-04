using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("b2233b7d-f98b-48f9-8fd8-616f6f3aa4a1")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISEKSISLEMISCILIKLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISEKSPERTIZISLEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ISCILIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "SERVISISCILIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "MIKTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "BIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "PARABIRIMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "TUTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(9, "INDIRIMLITUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(11, "SERVISPAKETID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 250, 0, 0, "")]
    [DbField(13, "AV", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SEVISEKSPISLEMISCILIKLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISEKSISLEMISCILIKLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISEKSISLEMISCILIKLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISEKSPERTIZISLEMID { get; set; }
            protected virtual Decimal ISCILIKID { get; set; }
            protected virtual Decimal SERVISISCILIKID { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual Decimal BIRIMFIYAT { get; set; }
            protected virtual Decimal PARABIRIMID { get; set; }
            protected virtual Decimal TUTAR { get; set; }
            protected virtual Decimal INDIRIMLITUTAR { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISPAKETID { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal AV { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISEKSPERTIZISLEMID { get; set; }
            public virtual Decimal ISCILIKID { get; set; }
            public virtual Decimal SERVISISCILIKID { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual Decimal BIRIMFIYAT { get; set; }
            public virtual Decimal PARABIRIMID { get; set; }
            public virtual Decimal TUTAR { get; set; }
            public virtual Decimal INDIRIMLITUTAR { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISPAKETID { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal AV { get; set; }
        }
    }
}

