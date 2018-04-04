using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("c9666c9a-dc4c-4b16-a34b-59401d471623")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISAKTIVITELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(3, "SERVISVARLIKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "SERVISISORTAKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "SERVISAKTIVITETURID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "SERVISAKTIVITEDURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "TARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(8, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(9, "SURE", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "SERVISISORTAKKONTAKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "KONTAKTELEFONID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "SERVISPROJEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "KULLANICIID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(14, "SERVISAKTIVITEIPTNEDENID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "KAYITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(16, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(17, "KAYITKULLANICIID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbIndex("SERVISAKTIVITELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISAKTIVITELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISAKTIVITELER))]
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
            protected virtual Decimal SERVISAKTIVITETURID { get; set; }
            protected virtual Decimal SERVISAKTIVITEDURUMID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal SURE { get; set; }
            protected virtual Decimal SERVISISORTAKKONTAKID { get; set; }
            protected virtual Decimal KONTAKTELEFONID { get; set; }
            protected virtual Decimal SERVISPROJEID { get; set; }
            protected virtual String KULLANICIID { get; set; }
            protected virtual Decimal SERVISAKTIVITEIPTNEDENID { get; set; }
            protected virtual DateTime KAYITTARIH { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual String KAYITKULLANICIID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String AD { get; set; }
            public virtual Decimal SERVISVARLIKID { get; set; }
            public virtual Decimal SERVISISORTAKID { get; set; }
            public virtual Decimal SERVISAKTIVITETURID { get; set; }
            public virtual Decimal SERVISAKTIVITEDURUMID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal SURE { get; set; }
            public virtual Decimal SERVISISORTAKKONTAKID { get; set; }
            public virtual Decimal KONTAKTELEFONID { get; set; }
            public virtual Decimal SERVISPROJEID { get; set; }
            public virtual String KULLANICIID { get; set; }
            public virtual Decimal SERVISAKTIVITEIPTNEDENID { get; set; }
            public virtual DateTime KAYITTARIH { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual String KAYITKULLANICIID { get; set; }
        }
    }
}

