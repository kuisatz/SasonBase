using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("0682494f-327c-42f1-8b83-df30915e3f23")]
    [DbTableInfoAttribute(TableTypes.Table, "MT_ISCILIKLER", "Sason.Tables", "Yok")]
    [DbField(1, "ISCILIKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.Nullable, 16, 0, 0, "")]
    [DbField(3, "AD", typeof(String), null, DbFieldFlags.Nullable, 2000, 0, 0, "")]
    [DbField(4, "ISCILIKARACSINIFID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "ISCILIKARACSINIFKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(6, "ISCILIKARACSINIFAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(7, "ISCILIKARACVARYANTID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "ISCILIKARACVARYANTKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(9, "ISCILIKARACVARYANTAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(10, "ISCILIKNESNEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(11, "ISCILIKNESNEKOD", typeof(String), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(12, "ISCILIKNESNEAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(13, "ISCILIKNESNEKOD1", typeof(String), null, DbFieldFlags.None, 3, 0, 0, "")]
    [DbField(14, "ISCILIKNESNEKOD2", typeof(String), null, DbFieldFlags.Nullable, 1, 0, 0, "")]
    [DbField(15, "ISCILIKNESNEKOD3", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(16, "ISCILIKNESNEACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(17, "ISCILIKUYGULAMAID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(18, "ISCILIKUYGULAMAKOD", typeof(String), null, DbFieldFlags.None, 2, 0, 0, "")]
    [DbField(19, "ISCILIKUYGULAMAAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(20, "ISCILIKKONUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(21, "ISCILIKKONUMKOD", typeof(String), null, DbFieldFlags.None, 2, 0, 0, "")]
    [DbField(22, "ISCILIKKONUMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(23, "ISCILIKMONTAJDURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(24, "ISCILIKMONTAJDURUMKOD", typeof(String), null, DbFieldFlags.None, 2, 0, 0, "")]
    [DbField(25, "ISCILIKMONTAJDURUMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(26, "ISCILIKFAALIYETID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(27, "ISCILIKFAALIYETKOD", typeof(String), null, DbFieldFlags.None, 3, 0, 0, "")]
    [DbField(28, "ISCILIKFAALIYETAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(29, "ISCILIKTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(30, "ISCILIKTIPKOD", typeof(String), null, DbFieldFlags.None, 1, 0, 0, "")]
    [DbField(31, "ISCILIKTIPAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(32, "DTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(33, "MIKTAR", typeof(String), null, DbFieldFlags.None, 4, 0, 0, "")]
    [DbField(34, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(35, "DURUMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(36, "DILKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(37, "AKSIYON", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("CUSTOM_PK", DbIndexType.PrimaryKey, DbIndexFlags.Unique, new string[] { "ISCILIKID" })]
    public abstract class Table_MT_ISCILIKLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_MT_ISCILIKLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ISCILIKID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String AD { get; set; }
            protected virtual Decimal ISCILIKARACSINIFID { get; set; }
            protected virtual String ISCILIKARACSINIFKOD { get; set; }
            protected virtual String ISCILIKARACSINIFAD { get; set; }
            protected virtual Decimal ISCILIKARACVARYANTID { get; set; }
            protected virtual String ISCILIKARACVARYANTKOD { get; set; }
            protected virtual String ISCILIKARACVARYANTAD { get; set; }
            protected virtual Decimal ISCILIKNESNEID { get; set; }
            protected virtual String ISCILIKNESNEKOD { get; set; }
            protected virtual String ISCILIKNESNEAD { get; set; }
            protected virtual String ISCILIKNESNEKOD1 { get; set; }
            protected virtual String ISCILIKNESNEKOD2 { get; set; }
            protected virtual String ISCILIKNESNEKOD3 { get; set; }
            protected virtual String ISCILIKNESNEACIKLAMA { get; set; }
            protected virtual Decimal ISCILIKUYGULAMAID { get; set; }
            protected virtual String ISCILIKUYGULAMAKOD { get; set; }
            protected virtual String ISCILIKUYGULAMAAD { get; set; }
            protected virtual Decimal ISCILIKKONUMID { get; set; }
            protected virtual String ISCILIKKONUMKOD { get; set; }
            protected virtual String ISCILIKKONUMAD { get; set; }
            protected virtual Decimal ISCILIKMONTAJDURUMID { get; set; }
            protected virtual String ISCILIKMONTAJDURUMKOD { get; set; }
            protected virtual String ISCILIKMONTAJDURUMAD { get; set; }
            protected virtual Decimal ISCILIKFAALIYETID { get; set; }
            protected virtual String ISCILIKFAALIYETKOD { get; set; }
            protected virtual String ISCILIKFAALIYETAD { get; set; }
            protected virtual Decimal ISCILIKTIPID { get; set; }
            protected virtual String ISCILIKTIPKOD { get; set; }
            protected virtual String ISCILIKTIPAD { get; set; }
            protected virtual DateTime DTARIH { get; set; }
            protected virtual String MIKTAR { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual String DURUMAD { get; set; }
            protected virtual String DILKOD { get; set; }
            protected virtual Decimal AKSIYON { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ISCILIKID { get; set; }
            public virtual String KOD { get; set; }
            public virtual String AD { get; set; }
            public virtual Decimal ISCILIKARACSINIFID { get; set; }
            public virtual String ISCILIKARACSINIFKOD { get; set; }
            public virtual String ISCILIKARACSINIFAD { get; set; }
            public virtual Decimal ISCILIKARACVARYANTID { get; set; }
            public virtual String ISCILIKARACVARYANTKOD { get; set; }
            public virtual String ISCILIKARACVARYANTAD { get; set; }
            public virtual Decimal ISCILIKNESNEID { get; set; }
            public virtual String ISCILIKNESNEKOD { get; set; }
            public virtual String ISCILIKNESNEAD { get; set; }
            public virtual String ISCILIKNESNEKOD1 { get; set; }
            public virtual String ISCILIKNESNEKOD2 { get; set; }
            public virtual String ISCILIKNESNEKOD3 { get; set; }
            public virtual String ISCILIKNESNEACIKLAMA { get; set; }
            public virtual Decimal ISCILIKUYGULAMAID { get; set; }
            public virtual String ISCILIKUYGULAMAKOD { get; set; }
            public virtual String ISCILIKUYGULAMAAD { get; set; }
            public virtual Decimal ISCILIKKONUMID { get; set; }
            public virtual String ISCILIKKONUMKOD { get; set; }
            public virtual String ISCILIKKONUMAD { get; set; }
            public virtual Decimal ISCILIKMONTAJDURUMID { get; set; }
            public virtual String ISCILIKMONTAJDURUMKOD { get; set; }
            public virtual String ISCILIKMONTAJDURUMAD { get; set; }
            public virtual Decimal ISCILIKFAALIYETID { get; set; }
            public virtual String ISCILIKFAALIYETKOD { get; set; }
            public virtual String ISCILIKFAALIYETAD { get; set; }
            public virtual Decimal ISCILIKTIPID { get; set; }
            public virtual String ISCILIKTIPKOD { get; set; }
            public virtual String ISCILIKTIPAD { get; set; }
            public virtual DateTime DTARIH { get; set; }
            public virtual String MIKTAR { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String DURUMAD { get; set; }
            public virtual String DILKOD { get; set; }
            public virtual Decimal AKSIYON { get; set; }
        }
    }
}

