using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("fd637463-344b-4661-9be1-2e128ded087d")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "ISORTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "EBAFIRMAID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "YPSID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(5, "GSID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(6, "TBSID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(7, "GOKULLANICIAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(8, "GOPAROLA", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(9, "PARTS2BKULLANICIAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(10, "PARTS2BPAROLA", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(11, "ENVANTERPERIYODID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "DBSLIMITID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(13, "ADRESID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(15, "AKYSONAY", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "SAYIMDURUM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "KILITACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(18, "RECETEKILIT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ISORTAKID"})]
    [DbIndex("SERVISLER_U02", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"EBAFIRMAID"})]
    public abstract class Table_SERVISLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal ISORTAKID { get; set; }
            protected virtual String EBAFIRMAID { get; set; }
            protected virtual String YPSID { get; set; }
            protected virtual String GSID { get; set; }
            protected virtual String TBSID { get; set; }
            protected virtual String GOKULLANICIAD { get; set; }
            protected virtual String GOPAROLA { get; set; }
            protected virtual String PARTS2BKULLANICIAD { get; set; }
            protected virtual String PARTS2BPAROLA { get; set; }
            protected virtual Decimal ENVANTERPERIYODID { get; set; }
            protected virtual Decimal DBSLIMITID { get; set; }
            protected virtual Decimal ADRESID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal AKYSONAY { get; set; }
            protected virtual Decimal SAYIMDURUM { get; set; }
            protected virtual String KILITACIKLAMA { get; set; }
            protected virtual Decimal RECETEKILIT { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal ISORTAKID { get; set; }
            public virtual String EBAFIRMAID { get; set; }
            public virtual String YPSID { get; set; }
            public virtual String GSID { get; set; }
            public virtual String TBSID { get; set; }
            public virtual String GOKULLANICIAD { get; set; }
            public virtual String GOPAROLA { get; set; }
            public virtual String PARTS2BKULLANICIAD { get; set; }
            public virtual String PARTS2BPAROLA { get; set; }
            public virtual Decimal ENVANTERPERIYODID { get; set; }
            public virtual Decimal DBSLIMITID { get; set; }
            public virtual Decimal ADRESID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal AKYSONAY { get; set; }
            public virtual Decimal SAYIMDURUM { get; set; }
            public virtual String KILITACIKLAMA { get; set; }
            public virtual Decimal RECETEKILIT { get; set; }
        }
    }
}

