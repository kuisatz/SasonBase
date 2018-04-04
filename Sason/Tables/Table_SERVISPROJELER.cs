using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("be2682e3-fa47-4136-b0ab-5ec0dd5a13ff")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISPROJELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AD", typeof(String), null, DbFieldFlags.None, 100, 0, 0, "")]
    [DbField(3, "SERVISVARLIKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "SERVISISORTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "SERVISISORTAKKONTAKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "SERVISPROJETIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "SERVISPROJEDURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(9, "KULLANICIID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(10, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(11, "SERVISPROJEKYBNEDENID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "YORUM", typeof(String), null, DbFieldFlags.Nullable, 4000, 0, 0, "")]
    [DbIndex("SERVISPROJELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISPROJELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISPROJELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String AD { get; set; }
            protected virtual Decimal SERVISVARLIKID { get; set; }
            protected virtual Decimal SERVISISORTAKID { get; set; }
            protected virtual Decimal SERVISISORTAKKONTAKID { get; set; }
            protected virtual Decimal SERVISPROJETIPID { get; set; }
            protected virtual Decimal SERVISPROJEDURUMID { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual String KULLANICIID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal SERVISPROJEKYBNEDENID { get; set; }
            protected virtual String YORUM { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String AD { get; set; }
            public virtual Decimal SERVISVARLIKID { get; set; }
            public virtual Decimal SERVISISORTAKID { get; set; }
            public virtual Decimal SERVISISORTAKKONTAKID { get; set; }
            public virtual Decimal SERVISPROJETIPID { get; set; }
            public virtual Decimal SERVISPROJEDURUMID { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual String KULLANICIID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal SERVISPROJEKYBNEDENID { get; set; }
            public virtual String YORUM { get; set; }
        }
    }
}

