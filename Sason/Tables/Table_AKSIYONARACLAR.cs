using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("944389a3-a3c5-4c8f-923c-e21daa0b80bf")]
    [DbTableInfoAttribute(TableTypes.Table, "AKSIYONARACLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AKSIYONID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "SASENO", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "AKSIYONSTATUID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "REZERVDURUMU", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "REZERVTARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(7, "REZERVSERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "AKSIYONISLEMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "SERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(11, "NOTLAR", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(12, "NOTSERVISDURUMU", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(13, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("AKSIYONARACLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("AKSIYONARACLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"AKSIYONID","SASENO","DURUMID"})]
    public abstract class Table_AKSIYONARACLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_AKSIYONARACLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal AKSIYONID { get; set; }
            protected virtual String SASENO { get; set; }
            protected virtual Decimal AKSIYONSTATUID { get; set; }
            protected virtual Decimal REZERVDURUMU { get; set; }
            protected virtual DateTime REZERVTARIHI { get; set; }
            protected virtual Decimal REZERVSERVISID { get; set; }
            protected virtual Decimal AKSIYONISLEMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual String NOTLAR { get; set; }
            protected virtual Decimal NOTSERVISDURUMU { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal AKSIYONID { get; set; }
            public virtual String SASENO { get; set; }
            public virtual Decimal AKSIYONSTATUID { get; set; }
            public virtual Decimal REZERVDURUMU { get; set; }
            public virtual DateTime REZERVTARIHI { get; set; }
            public virtual Decimal REZERVSERVISID { get; set; }
            public virtual Decimal AKSIYONISLEMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual String NOTLAR { get; set; }
            public virtual Decimal NOTSERVISDURUMU { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}