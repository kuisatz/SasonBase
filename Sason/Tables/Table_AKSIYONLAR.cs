using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("a45b6a30-d876-4611-ae88-15c9e5405675")]
    [DbTableInfoAttribute(TableTypes.Table, "AKSIYONLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AD", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(3, "TRAKSIYONU", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "AKSIYONTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "BASTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(6, "BITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(7, "UCRETLIMI", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "AKSIYONNO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(9, "HARICINO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(10, "ARIZAKODU", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(11, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 1000, 0, 0, "")]
    [DbField(12, "NOTLAR", typeof(String), null, DbFieldFlags.Nullable, 1000, 0, 0, "")]
    [DbField(13, "NOTSERVISDURUMU", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(15, "REFAKSIYONID", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbIndex("AKSIYONLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("AKSIYONLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"AKSIYONNO"})]
    public abstract class Table_AKSIYONLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_AKSIYONLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String AD { get; set; }
            protected virtual Decimal TRAKSIYONU { get; set; }
            protected virtual Decimal AKSIYONTIPID { get; set; }
            protected virtual DateTime BASTARIH { get; set; }
            protected virtual DateTime BITTARIH { get; set; }
            protected virtual Decimal UCRETLIMI { get; set; }
            protected virtual String AKSIYONNO { get; set; }
            protected virtual String HARICINO { get; set; }
            protected virtual String ARIZAKODU { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual String NOTLAR { get; set; }
            protected virtual Decimal NOTSERVISDURUMU { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual String REFAKSIYONID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String AD { get; set; }
            public virtual Decimal TRAKSIYONU { get; set; }
            public virtual Decimal AKSIYONTIPID { get; set; }
            public virtual DateTime BASTARIH { get; set; }
            public virtual DateTime BITTARIH { get; set; }
            public virtual Decimal UCRETLIMI { get; set; }
            public virtual String AKSIYONNO { get; set; }
            public virtual String HARICINO { get; set; }
            public virtual String ARIZAKODU { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual String NOTLAR { get; set; }
            public virtual Decimal NOTSERVISDURUMU { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String REFAKSIYONID { get; set; }
        }
    }
}