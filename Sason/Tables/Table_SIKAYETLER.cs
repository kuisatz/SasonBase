using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("7ae0027a-a585-4200-9804-adb70d983c52")]
    [DbTableInfoAttribute(TableTypes.Table, "SIKAYETLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(3, "SERVISARACID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "SIKAYETTURID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "SIKAYETDURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "TARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(7, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(8, "SERVISRANDEVUID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "KULLANICIID", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(10, "SERVISISEMIRID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "SIKAYETKAPAMANEDENID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "SERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "ISLEMLER", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(14, "YAPILANISLER", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(15, "MKULLANICIID", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(16, "SIKAYETYONLENDIRMETURID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(18, "SKULLANICIID", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(19, "ANKETSONUCID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(20, "GERIBILDIRIM", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbIndex("SERVISSIKAYETLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SIKAYETLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SIKAYETLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISVARLIKID { get; set; }
            protected virtual Decimal SERVISARACID { get; set; }
            protected virtual Decimal SIKAYETTURID { get; set; }
            protected virtual Decimal SIKAYETDURUMID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal SERVISRANDEVUID { get; set; }
            protected virtual String KULLANICIID { get; set; }
            protected virtual Decimal SERVISISEMIRID { get; set; }
            protected virtual Decimal SIKAYETKAPAMANEDENID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual String ISLEMLER { get; set; }
            protected virtual String YAPILANISLER { get; set; }
            protected virtual String MKULLANICIID { get; set; }
            protected virtual Decimal SIKAYETYONLENDIRMETURID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual String SKULLANICIID { get; set; }
            protected virtual Decimal ANKETSONUCID { get; set; }
            protected virtual String GERIBILDIRIM { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISVARLIKID { get; set; }
            public virtual Decimal SERVISARACID { get; set; }
            public virtual Decimal SIKAYETTURID { get; set; }
            public virtual Decimal SIKAYETDURUMID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal SERVISRANDEVUID { get; set; }
            public virtual String KULLANICIID { get; set; }
            public virtual Decimal SERVISISEMIRID { get; set; }
            public virtual Decimal SIKAYETKAPAMANEDENID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual String ISLEMLER { get; set; }
            public virtual String YAPILANISLER { get; set; }
            public virtual String MKULLANICIID { get; set; }
            public virtual Decimal SIKAYETYONLENDIRMETURID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String SKULLANICIID { get; set; }
            public virtual Decimal ANKETSONUCID { get; set; }
            public virtual String GERIBILDIRIM { get; set; }
        }
    }
}

