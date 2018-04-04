using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("48d3ce7f-c000-4e4f-9404-bfc5b5d3f780")]
    [DbTableInfoAttribute(TableTypes.View, "VW_MALZEMELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "GKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "AD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(5, "MALZEMESINIFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "MALZEMEGRUPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "BRUTAGIRLIK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "NETAGIRLIK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "BIRIMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "VERGISINIFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "ENAZSIPARISMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "HIYERARSI", typeof(String), null, DbFieldFlags.Nullable, 5, 0, 0, "")]
    [DbField(13, "ONCEKIMALZEMEKOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(14, "ONCEKIMALZEMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "MALZEMEOZELKODID1", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "MALZEMEOZELKODID2", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "MALZEMEOZELKODID3", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "MALZEMEOZELKODID4", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "MALZEMEOZELKODID5", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(20, "URETICIVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(21, "URETICIKOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(22, "MUADILKONTROL", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(23, "SASEKONTROL", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(24, "ORJINALMALZEMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(25, "KITID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(26, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(27, "DURUMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(28, "DILID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(29, "DILKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(30, "ADLISTEALANID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(31, "ADCEVIRIID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(32, "ENAZSIPARISMIKTARDEGISTIR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(33, "DFXPARCA", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(34, "DFXINDIRIMORAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(35, "DFXMAXSIPARISMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(36, "DFXSTOKMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(37, "DFXMINSTOKMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("AutoCreatePk", DbIndexType.PrimaryKey, DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class View_VW_MALZEMELER : SasonDbView
    {
        [Serializable()]
        [DbTableType(typeof(View_VW_MALZEMELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String GKOD { get; set; }
            protected virtual String AD { get; set; }
            protected virtual Decimal MALZEMESINIFID { get; set; }
            protected virtual Decimal MALZEMEGRUPID { get; set; }
            protected virtual Decimal BRUTAGIRLIK { get; set; }
            protected virtual Decimal NETAGIRLIK { get; set; }
            protected virtual Decimal BIRIMID { get; set; }
            protected virtual Decimal VERGISINIFID { get; set; }
            protected virtual Decimal ENAZSIPARISMIKTAR { get; set; }
            protected virtual String HIYERARSI { get; set; }
            protected virtual String ONCEKIMALZEMEKOD { get; set; }
            protected virtual Decimal ONCEKIMALZEMEID { get; set; }
            protected virtual Decimal MALZEMEOZELKODID1 { get; set; }
            protected virtual Decimal MALZEMEOZELKODID2 { get; set; }
            protected virtual Decimal MALZEMEOZELKODID3 { get; set; }
            protected virtual Decimal MALZEMEOZELKODID4 { get; set; }
            protected virtual Decimal MALZEMEOZELKODID5 { get; set; }
            protected virtual Decimal URETICIVARLIKID { get; set; }
            protected virtual String URETICIKOD { get; set; }
            protected virtual Decimal MUADILKONTROL { get; set; }
            protected virtual Decimal SASEKONTROL { get; set; }
            protected virtual Decimal ORJINALMALZEMEID { get; set; }
            protected virtual Decimal KITID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual String DURUMAD { get; set; }
            protected virtual Decimal DILID { get; set; }
            protected virtual String DILKOD { get; set; }
            protected virtual Decimal ADLISTEALANID { get; set; }
            protected virtual Decimal ADCEVIRIID { get; set; }
            protected virtual Decimal ENAZSIPARISMIKTARDEGISTIR { get; set; }
            protected virtual Decimal DFXPARCA { get; set; }
            protected virtual Decimal DFXINDIRIMORAN { get; set; }
            protected virtual Decimal DFXMAXSIPARISMIKTAR { get; set; }
            protected virtual Decimal DFXSTOKMIKTAR { get; set; }
            protected virtual Decimal DFXMINSTOKMIKTAR { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual String GKOD { get; set; }
            public virtual String AD { get; set; }
            public virtual Decimal MALZEMESINIFID { get; set; }
            public virtual Decimal MALZEMEGRUPID { get; set; }
            public virtual Decimal BRUTAGIRLIK { get; set; }
            public virtual Decimal NETAGIRLIK { get; set; }
            public virtual Decimal BIRIMID { get; set; }
            public virtual Decimal VERGISINIFID { get; set; }
            public virtual Decimal ENAZSIPARISMIKTAR { get; set; }
            public virtual String HIYERARSI { get; set; }
            public virtual String ONCEKIMALZEMEKOD { get; set; }
            public virtual Decimal ONCEKIMALZEMEID { get; set; }
            public virtual Decimal MALZEMEOZELKODID1 { get; set; }
            public virtual Decimal MALZEMEOZELKODID2 { get; set; }
            public virtual Decimal MALZEMEOZELKODID3 { get; set; }
            public virtual Decimal MALZEMEOZELKODID4 { get; set; }
            public virtual Decimal MALZEMEOZELKODID5 { get; set; }
            public virtual Decimal URETICIVARLIKID { get; set; }
            public virtual String URETICIKOD { get; set; }
            public virtual Decimal MUADILKONTROL { get; set; }
            public virtual Decimal SASEKONTROL { get; set; }
            public virtual Decimal ORJINALMALZEMEID { get; set; }
            public virtual Decimal KITID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String DURUMAD { get; set; }
            public virtual Decimal DILID { get; set; }
            public virtual String DILKOD { get; set; }
            public virtual Decimal ADLISTEALANID { get; set; }
            public virtual Decimal ADCEVIRIID { get; set; }
            public virtual Decimal ENAZSIPARISMIKTARDEGISTIR { get; set; }
            public virtual Decimal DFXPARCA { get; set; }
            public virtual Decimal DFXINDIRIMORAN { get; set; }
            public virtual Decimal DFXMAXSIPARISMIKTAR { get; set; }
            public virtual Decimal DFXSTOKMIKTAR { get; set; }
            public virtual Decimal DFXMINSTOKMIKTAR { get; set; }
        }
    }
}

