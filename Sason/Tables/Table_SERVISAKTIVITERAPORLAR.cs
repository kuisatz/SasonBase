using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("888fc020-3f01-47cc-96e0-a5e76da5e809")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISAKTIVITERAPORLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISAKTIVITEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "TARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(4, "SERVISISORTAKKONTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "TAKIPTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(6, "TAKIPSERVISAKTIVITEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "SERVISISORTAKZIYARETID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "RAPOR", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(9, "PUAN1", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "PUAN2", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "PUAN3", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "PUAN4", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "PUAN5", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISAKTIVITERAPORLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISAKTIVITERAPORLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ID","TAKIPSERVISAKTIVITEID"})]
    public abstract class Table_SERVISAKTIVITERAPORLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISAKTIVITERAPORLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISAKTIVITEID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual Decimal SERVISISORTAKKONTAKID { get; set; }
            protected virtual DateTime TAKIPTARIH { get; set; }
            protected virtual Decimal TAKIPSERVISAKTIVITEID { get; set; }
            protected virtual Decimal SERVISISORTAKZIYARETID { get; set; }
            protected virtual String RAPOR { get; set; }
            protected virtual Decimal PUAN1 { get; set; }
            protected virtual Decimal PUAN2 { get; set; }
            protected virtual Decimal PUAN3 { get; set; }
            protected virtual Decimal PUAN4 { get; set; }
            protected virtual Decimal PUAN5 { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISAKTIVITEID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual Decimal SERVISISORTAKKONTAKID { get; set; }
            public virtual DateTime TAKIPTARIH { get; set; }
            public virtual Decimal TAKIPSERVISAKTIVITEID { get; set; }
            public virtual Decimal SERVISISORTAKZIYARETID { get; set; }
            public virtual String RAPOR { get; set; }
            public virtual Decimal PUAN1 { get; set; }
            public virtual Decimal PUAN2 { get; set; }
            public virtual Decimal PUAN3 { get; set; }
            public virtual Decimal PUAN4 { get; set; }
            public virtual Decimal PUAN5 { get; set; }
        }
    }
}

