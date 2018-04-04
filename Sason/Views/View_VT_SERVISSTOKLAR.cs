using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("f0299bd5-3f6c-48f3-9506-238fd2a296c4")]
    [DbTableInfoAttribute(TableTypes.View, "VT_SERVISSTOKLAR", "Sason.Tables", "Yok")]
    [DbField(1, "SERVISSTOKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "AD", typeof(String), null, DbFieldFlags.None, 200, 0, 0, "")]
    [DbField(4, "OZELKOD1", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(5, "OZELKOD2", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(6, "OZELKOD3", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(7, "BRUTAGIRLIK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "NETAGIRLIK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "VERGISINIFID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(10, "VERGISINIFDEGER", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "ENAZSIPARISMIKTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(12, "SERVISSTOKTURID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(13, "SERVISSTOKTURAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(14, "SERVISSTOKSINIFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "SERVISSTOKSINIFAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(16, "SERVISSTOKGRUPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "SERVISSTOKGRUPAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(18, "BIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(19, "BIRIMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(20, "SERVISSTOKOZELKODAD1", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(21, "SERVISSTOKOZELKODID1", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(22, "SERVISSTOKOZELKODAD2", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(23, "SERVISSTOKOZELKODID2", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(24, "SERVISSTOKOZELKODAD3", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(25, "SERVISSTOKOZELKODID3", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(26, "SERVISSTOKOZELKODAD4", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(27, "SERVISSTOKOZELKODID4", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(28, "SERVISSTOKOZELKODAD5", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(29, "SERVISSTOKOZELKODID5", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(30, "ENAZSTOK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(31, "ENFAZLASTOK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(32, "URETICIVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(33, "URETICIVARLIKAD", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(34, "TEDARIKCIVARLIKAD", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(35, "MALZEMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(36, "MALZEMEAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(37, "SERVISDEPOID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(38, "SERVISDEPOAD", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(39, "SERVISDEPORAFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(40, "SERVISDEPORAFAD", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(41, "HAREKETSAYI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(42, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(43, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(44, "DILKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    public abstract partial class View_VT_SERVISSTOKLAR : SasonDbView
    {
        [Serializable()]
        [DbTableType(typeof(View_VT_SERVISSTOKLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal SERVISSTOKID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String AD { get; set; }
            protected virtual String OZELKOD1 { get; set; }
            protected virtual String OZELKOD2 { get; set; }
            protected virtual String OZELKOD3 { get; set; }
            protected virtual Decimal BRUTAGIRLIK { get; set; }
            protected virtual Decimal NETAGIRLIK { get; set; }
            protected virtual Decimal VERGISINIFID { get; set; }
            protected virtual Decimal VERGISINIFDEGER { get; set; }
            protected virtual Decimal ENAZSIPARISMIKTAR { get; set; }
            protected virtual Decimal SERVISSTOKTURID { get; set; }
            protected virtual String SERVISSTOKTURAD { get; set; }
            protected virtual Decimal SERVISSTOKSINIFID { get; set; }
            protected virtual String SERVISSTOKSINIFAD { get; set; }
            protected virtual Decimal SERVISSTOKGRUPID { get; set; }
            protected virtual String SERVISSTOKGRUPAD { get; set; }
            protected virtual Decimal BIRIMID { get; set; }
            protected virtual String BIRIMAD { get; set; }
            protected virtual String SERVISSTOKOZELKODAD1 { get; set; }
            protected virtual Decimal SERVISSTOKOZELKODID1 { get; set; }
            protected virtual String SERVISSTOKOZELKODAD2 { get; set; }
            protected virtual Decimal SERVISSTOKOZELKODID2 { get; set; }
            protected virtual String SERVISSTOKOZELKODAD3 { get; set; }
            protected virtual Decimal SERVISSTOKOZELKODID3 { get; set; }
            protected virtual String SERVISSTOKOZELKODAD4 { get; set; }
            protected virtual Decimal SERVISSTOKOZELKODID4 { get; set; }
            protected virtual String SERVISSTOKOZELKODAD5 { get; set; }
            protected virtual Decimal SERVISSTOKOZELKODID5 { get; set; }
            protected virtual Decimal ENAZSTOK { get; set; }
            protected virtual Decimal ENFAZLASTOK { get; set; }
            protected virtual Decimal URETICIVARLIKID { get; set; }
            protected virtual String URETICIVARLIKAD { get; set; }
            protected virtual String TEDARIKCIVARLIKAD { get; set; }
            protected virtual Decimal MALZEMEID { get; set; }
            protected virtual String MALZEMEAD { get; set; }
            protected virtual Decimal SERVISDEPOID { get; set; }
            protected virtual String SERVISDEPOAD { get; set; }
            protected virtual Decimal SERVISDEPORAFID { get; set; }
            protected virtual String SERVISDEPORAFAD { get; set; }
            protected virtual Decimal HAREKETSAYI { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual String DILKOD { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal SERVISSTOKID { get; set; }
            public virtual String KOD { get; set; }
            public virtual String AD { get; set; }
            public virtual String OZELKOD1 { get; set; }
            public virtual String OZELKOD2 { get; set; }
            public virtual String OZELKOD3 { get; set; }
            public virtual Decimal BRUTAGIRLIK { get; set; }
            public virtual Decimal NETAGIRLIK { get; set; }
            public virtual Decimal VERGISINIFID { get; set; }
            public virtual Decimal VERGISINIFDEGER { get; set; }
            public virtual Decimal ENAZSIPARISMIKTAR { get; set; }
            public virtual Decimal SERVISSTOKTURID { get; set; }
            public virtual String SERVISSTOKTURAD { get; set; }
            public virtual Decimal SERVISSTOKSINIFID { get; set; }
            public virtual String SERVISSTOKSINIFAD { get; set; }
            public virtual Decimal SERVISSTOKGRUPID { get; set; }
            public virtual String SERVISSTOKGRUPAD { get; set; }
            public virtual Decimal BIRIMID { get; set; }
            public virtual String BIRIMAD { get; set; }
            public virtual String SERVISSTOKOZELKODAD1 { get; set; }
            public virtual Decimal SERVISSTOKOZELKODID1 { get; set; }
            public virtual String SERVISSTOKOZELKODAD2 { get; set; }
            public virtual Decimal SERVISSTOKOZELKODID2 { get; set; }
            public virtual String SERVISSTOKOZELKODAD3 { get; set; }
            public virtual Decimal SERVISSTOKOZELKODID3 { get; set; }
            public virtual String SERVISSTOKOZELKODAD4 { get; set; }
            public virtual Decimal SERVISSTOKOZELKODID4 { get; set; }
            public virtual String SERVISSTOKOZELKODAD5 { get; set; }
            public virtual Decimal SERVISSTOKOZELKODID5 { get; set; }
            public virtual Decimal ENAZSTOK { get; set; }
            public virtual Decimal ENFAZLASTOK { get; set; }
            public virtual Decimal URETICIVARLIKID { get; set; }
            public virtual String URETICIVARLIKAD { get; set; }
            public virtual String TEDARIKCIVARLIKAD { get; set; }
            public virtual Decimal MALZEMEID { get; set; }
            public virtual String MALZEMEAD { get; set; }
            public virtual Decimal SERVISDEPOID { get; set; }
            public virtual String SERVISDEPOAD { get; set; }
            public virtual Decimal SERVISDEPORAFID { get; set; }
            public virtual String SERVISDEPORAFAD { get; set; }
            public virtual Decimal HAREKETSAYI { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual String DILKOD { get; set; }
        }
    }
}

