using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("83558e6b-12d0-4d4f-9272-d618ff377600")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISEKSPERTIZISLEMLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISEKSPERTIZID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ISEMIRTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "ISEMIRUYGULAMAMANEDENID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "INDIRIMORAN1", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "INDIRIMORAN2", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "INDIRIMORAN3", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(9, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 4000, 0, 0, "")]
    [DbField(10, "TISCTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "TIISCTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "TIMLZTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "TMLZTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "TIKLMTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "TKLMTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "TIHZTTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "THZTTUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "SIRANO", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "BAKIMISCILIKSURE", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbIndex("SERVISEKPERTIZISLEMLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISEKSPERTIZISLEMLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISEKSPERTIZISLEMLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISEKSPERTIZID { get; set; }
            protected virtual Decimal ISEMIRTIPID { get; set; }
            protected virtual Decimal ISEMIRUYGULAMAMANEDENID { get; set; }
            protected virtual Decimal INDIRIMORAN1 { get; set; }
            protected virtual Decimal INDIRIMORAN2 { get; set; }
            protected virtual Decimal INDIRIMORAN3 { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal TISCTUTAR { get; set; }
            protected virtual Decimal TIISCTUTAR { get; set; }
            protected virtual Decimal TIMLZTUTAR { get; set; }
            protected virtual Decimal TMLZTUTAR { get; set; }
            protected virtual Decimal TIKLMTUTAR { get; set; }
            protected virtual Decimal TKLMTUTAR { get; set; }
            protected virtual Decimal TIHZTTUTAR { get; set; }
            protected virtual Decimal THZTTUTAR { get; set; }
            protected virtual Decimal SIRANO { get; set; }
            protected virtual String BAKIMISCILIKSURE { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISEKSPERTIZID { get; set; }
            public virtual Decimal ISEMIRTIPID { get; set; }
            public virtual Decimal ISEMIRUYGULAMAMANEDENID { get; set; }
            public virtual Decimal INDIRIMORAN1 { get; set; }
            public virtual Decimal INDIRIMORAN2 { get; set; }
            public virtual Decimal INDIRIMORAN3 { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal TISCTUTAR { get; set; }
            public virtual Decimal TIISCTUTAR { get; set; }
            public virtual Decimal TIMLZTUTAR { get; set; }
            public virtual Decimal TMLZTUTAR { get; set; }
            public virtual Decimal TIKLMTUTAR { get; set; }
            public virtual Decimal TKLMTUTAR { get; set; }
            public virtual Decimal TIHZTTUTAR { get; set; }
            public virtual Decimal THZTTUTAR { get; set; }
            public virtual Decimal SIRANO { get; set; }
            public virtual String BAKIMISCILIKSURE { get; set; }
        }
    }
}

