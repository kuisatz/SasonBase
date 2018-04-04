using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("7b3fa8e3-1272-4ad1-9773-1201d1f91383")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISSTOKLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "AD", typeof(String), null, DbFieldFlags.None, 200, 0, 0, "")]
    [DbField(4, "SERVISSTOKTURID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "OZELKOD1", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(6, "OZELKOD2", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(7, "OZELKOD3", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(8, "SERVISSTOKSINIFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "SERVISSTOKGRUPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "BRUTAGIRLIK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "NETAGIRLIK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "BIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(13, "VERGISINIFID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(14, "ENAZSIPARISMIKTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(15, "SERVISSTOKOZELKODID1", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "SERVISSTOKOZELKODID2", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "SERVISSTOKOZELKODID3", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "SERVISSTOKOZELKODID4", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "SERVISSTOKOZELKODID5", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(20, "ENAZSTOK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(21, "ENFAZLASTOK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(22, "URETICIVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(23, "URETICIKOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(24, "TEDARIKCIVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(25, "MALZEMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(26, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(27, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(28, "SERVISDEPOID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(29, "SERVISDEPORAFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(30, "HAREKETSAYI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISSTOKLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISSTOKLAR_U001", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KOD","SERVISID"})]
    [DbIndex("SERVISSTOKLAR_SERVISID_IDX", DbIndexType.Index, DbIndexFlags.None, new string[] {"SERVISID"})]
    [DbIndex("SERVISSTOKLAR_IDX01", DbIndexType.Index, DbIndexFlags.None, new string[] {"MALZEMEID","SERVISID"})]
    public abstract class Table_SERVISSTOKLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISSTOKLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String AD { get; set; }
            protected virtual Decimal SERVISSTOKTURID { get; set; }
            protected virtual String OZELKOD1 { get; set; }
            protected virtual String OZELKOD2 { get; set; }
            protected virtual String OZELKOD3 { get; set; }
            protected virtual Decimal SERVISSTOKSINIFID { get; set; }
            protected virtual Decimal SERVISSTOKGRUPID { get; set; }
            protected virtual Decimal BRUTAGIRLIK { get; set; }
            protected virtual Decimal NETAGIRLIK { get; set; }
            protected virtual Decimal BIRIMID { get; set; }
            protected virtual Decimal VERGISINIFID { get; set; }
            protected virtual Decimal ENAZSIPARISMIKTAR { get; set; }
            protected virtual Decimal SERVISSTOKOZELKODID1 { get; set; }
            protected virtual Decimal SERVISSTOKOZELKODID2 { get; set; }
            protected virtual Decimal SERVISSTOKOZELKODID3 { get; set; }
            protected virtual Decimal SERVISSTOKOZELKODID4 { get; set; }
            protected virtual Decimal SERVISSTOKOZELKODID5 { get; set; }
            protected virtual Decimal ENAZSTOK { get; set; }
            protected virtual Decimal ENFAZLASTOK { get; set; }
            protected virtual Decimal URETICIVARLIKID { get; set; }
            protected virtual String URETICIKOD { get; set; }
            protected virtual Decimal TEDARIKCIVARLIKID { get; set; }
            protected virtual Decimal MALZEMEID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal SERVISDEPOID { get; set; }
            protected virtual Decimal SERVISDEPORAFID { get; set; }
            protected virtual Decimal HAREKETSAYI { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal  ID { get; set; }
            public virtual String   KOD { get; set; }
            public virtual String   AD { get; set; }
            public virtual Decimal  SERVISSTOKTURID { get; set; }
            public virtual String   OZELKOD1 { get; set; }
            public virtual String   OZELKOD2 { get; set; }
            public virtual String   OZELKOD3 { get; set; }
            public virtual Decimal?  SERVISSTOKSINIFID { get; set; }
            public virtual Decimal?  SERVISSTOKGRUPID { get; set; }
            public virtual Decimal?  BRUTAGIRLIK { get; set; }
            public virtual Decimal?  NETAGIRLIK { get; set; }
            public virtual Decimal  BIRIMID { get; set; }
            public virtual Decimal  VERGISINIFID { get; set; }
            public virtual Decimal  ENAZSIPARISMIKTAR { get; set; }
            public virtual Decimal?  SERVISSTOKOZELKODID1 { get; set; }
            public virtual Decimal?  SERVISSTOKOZELKODID2 { get; set; }
            public virtual Decimal?  SERVISSTOKOZELKODID3 { get; set; }
            public virtual Decimal?  SERVISSTOKOZELKODID4 { get; set; }
            public virtual Decimal?  SERVISSTOKOZELKODID5 { get; set; }
            public virtual Decimal?  ENAZSTOK { get; set; }
            public virtual Decimal?  ENFAZLASTOK { get; set; }
            public virtual Decimal?  URETICIVARLIKID { get; set; }
            public virtual String   URETICIKOD { get; set; }
            public virtual Decimal?  TEDARIKCIVARLIKID { get; set; }
            public virtual Decimal  MALZEMEID { get; set; }
            public virtual Decimal  DURUMID { get; set; }
            public virtual Decimal  SERVISID { get; set; }
            public virtual Decimal? SERVISDEPOID { get; set; }
            public virtual Decimal? SERVISDEPORAFID { get; set; }
            public virtual Decimal?  HAREKETSAYI { get; set; }
        }
    }
}

