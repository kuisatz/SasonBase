using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("5f953ab4-d1da-44f1-a729-4129f4fbfdee")]
    [DbTableInfoAttribute(TableTypes.View, "VT_MALZEMELER", "Sason.Tables", "Yok")]
    [DbField(1, "MALZEMEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "GKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "AD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(5, "MALZEMESINIFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "MALZEMESINIFAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(7, "MALZEMESINIFKOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(8, "MALZEMEGRUPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "MALZEMEGRUPAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(10, "MALZEMEGRUPKOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(11, "MALZEMEGRUPINDIRIMORAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "BRUTAGIRLIK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "NETAGIRLIK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "BIRIMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "BIRIMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(16, "VERGISINIFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "VERGISINIFDEGER", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(18, "ENAZSIPARISMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "HIYERARSI", typeof(String), null, DbFieldFlags.Nullable, 5, 0, 0, "")]
    [DbField(20, "ONCEKIMALZEMEKOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(21, "ONCEKIMALZEMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(22, "MALZEMEOZELKODID1", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(23, "MALZEMEOZELKODAD1", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(24, "MALZEMEOZELKODID2", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(25, "MALZEMEOZELKODAD2", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(26, "MALZEMEOZELKODID3", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(27, "MALZEMEOZELKODAD3", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(28, "MALZEMEOZELKODID4", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(29, "MALZEMEOZELKODAD4", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(30, "MALZEMEOZELKODID5", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(31, "MALZEMEOZELKODAD5", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(32, "MUADILKONTROL", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(33, "URETICIKOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(34, "SASEKONTROL", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(35, "ORJINALMALZEMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(36, "KITID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(37, "URETICIVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(38, "URETICIVARLIKAD", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(39, "URETICIVERGIDAIREAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(40, "URETICIVERGINO", typeof(String), null, DbFieldFlags.Nullable, 11, 0, 0, "")]
    [DbField(41, "URETICIVERGIDAIREILAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(42, "URETICIVARLIKTIPAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(43, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(44, "DURUMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(45, "DILKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(46, "ADCEVIRIID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(47, "FIYATDURUM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(48, "ENAZSIPARISMIKTARDEGISTIR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(49, "DFXPARCA", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(50, "DFXINDIRIMORAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(51, "DFXMAXSIPARISMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(52, "DFXSTOKMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(53, "DFXMINSTOKMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    public abstract partial class View_VT_MALZEMELER : SasonDbView
    {
        [Serializable()]
        [DbTableType(typeof(View_VT_MALZEMELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal MALZEMEID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String GKOD { get; set; }
            protected virtual String AD { get; set; }
            protected virtual Decimal MALZEMESINIFID { get; set; }
            protected virtual String MALZEMESINIFAD { get; set; }
            protected virtual String MALZEMESINIFKOD { get; set; }
            protected virtual Decimal MALZEMEGRUPID { get; set; }
            protected virtual String MALZEMEGRUPAD { get; set; }
            protected virtual String MALZEMEGRUPKOD { get; set; }
            protected virtual Decimal MALZEMEGRUPINDIRIMORAN { get; set; }
            protected virtual Decimal BRUTAGIRLIK { get; set; }
            protected virtual Decimal NETAGIRLIK { get; set; }
            protected virtual Decimal BIRIMID { get; set; }
            protected virtual String BIRIMAD { get; set; }
            protected virtual Decimal VERGISINIFID { get; set; }
            protected virtual Decimal VERGISINIFDEGER { get; set; }
            protected virtual Decimal ENAZSIPARISMIKTAR { get; set; }
            protected virtual String HIYERARSI { get; set; }
            protected virtual String ONCEKIMALZEMEKOD { get; set; }
            protected virtual Decimal ONCEKIMALZEMEID { get; set; }
            protected virtual Decimal MALZEMEOZELKODID1 { get; set; }
            protected virtual String MALZEMEOZELKODAD1 { get; set; }
            protected virtual Decimal MALZEMEOZELKODID2 { get; set; }
            protected virtual String MALZEMEOZELKODAD2 { get; set; }
            protected virtual Decimal MALZEMEOZELKODID3 { get; set; }
            protected virtual String MALZEMEOZELKODAD3 { get; set; }
            protected virtual Decimal MALZEMEOZELKODID4 { get; set; }
            protected virtual String MALZEMEOZELKODAD4 { get; set; }
            protected virtual Decimal MALZEMEOZELKODID5 { get; set; }
            protected virtual String MALZEMEOZELKODAD5 { get; set; }
            protected virtual Decimal MUADILKONTROL { get; set; }
            protected virtual String URETICIKOD { get; set; }
            protected virtual Decimal SASEKONTROL { get; set; }
            protected virtual Decimal ORJINALMALZEMEID { get; set; }
            protected virtual Decimal KITID { get; set; }
            protected virtual Decimal URETICIVARLIKID { get; set; }
            protected virtual String URETICIVARLIKAD { get; set; }
            protected virtual String URETICIVERGIDAIREAD { get; set; }
            protected virtual String URETICIVERGINO { get; set; }
            protected virtual String URETICIVERGIDAIREILAD { get; set; }
            protected virtual String URETICIVARLIKTIPAD { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual String DURUMAD { get; set; }
            protected virtual String DILKOD { get; set; }
            protected virtual Decimal ADCEVIRIID { get; set; }
            protected virtual Decimal FIYATDURUM { get; set; }
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
            public virtual Decimal MALZEMEID { get; set; }
            public virtual String KOD { get; set; }
            public virtual String GKOD { get; set; }
            public virtual String AD { get; set; }
            public virtual Decimal MALZEMESINIFID { get; set; }
            public virtual String MALZEMESINIFAD { get; set; }
            public virtual String MALZEMESINIFKOD { get; set; }
            public virtual Decimal MALZEMEGRUPID { get; set; }
            public virtual String MALZEMEGRUPAD { get; set; }
            public virtual String MALZEMEGRUPKOD { get; set; }
            public virtual Decimal MALZEMEGRUPINDIRIMORAN { get; set; }
            public virtual Decimal BRUTAGIRLIK { get; set; }
            public virtual Decimal NETAGIRLIK { get; set; }
            public virtual Decimal BIRIMID { get; set; }
            public virtual String BIRIMAD { get; set; }
            public virtual Decimal VERGISINIFID { get; set; }
            public virtual Decimal VERGISINIFDEGER { get; set; }
            public virtual Decimal ENAZSIPARISMIKTAR { get; set; }
            public virtual String HIYERARSI { get; set; }
            public virtual String ONCEKIMALZEMEKOD { get; set; }
            public virtual Decimal ONCEKIMALZEMEID { get; set; }
            public virtual Decimal MALZEMEOZELKODID1 { get; set; }
            public virtual String MALZEMEOZELKODAD1 { get; set; }
            public virtual Decimal MALZEMEOZELKODID2 { get; set; }
            public virtual String MALZEMEOZELKODAD2 { get; set; }
            public virtual Decimal MALZEMEOZELKODID3 { get; set; }
            public virtual String MALZEMEOZELKODAD3 { get; set; }
            public virtual Decimal MALZEMEOZELKODID4 { get; set; }
            public virtual String MALZEMEOZELKODAD4 { get; set; }
            public virtual Decimal MALZEMEOZELKODID5 { get; set; }
            public virtual String MALZEMEOZELKODAD5 { get; set; }
            public virtual Decimal MUADILKONTROL { get; set; }
            public virtual String URETICIKOD { get; set; }
            public virtual Decimal SASEKONTROL { get; set; }
            public virtual Decimal ORJINALMALZEMEID { get; set; }
            public virtual Decimal KITID { get; set; }
            public virtual Decimal URETICIVARLIKID { get; set; }
            public virtual String URETICIVARLIKAD { get; set; }
            public virtual String URETICIVERGIDAIREAD { get; set; }
            public virtual String URETICIVERGINO { get; set; }
            public virtual String URETICIVERGIDAIREILAD { get; set; }
            public virtual String URETICIVARLIKTIPAD { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String DURUMAD { get; set; }
            public virtual String DILKOD { get; set; }
            public virtual Decimal ADCEVIRIID { get; set; }
            public virtual Decimal FIYATDURUM { get; set; }
            public virtual Decimal ENAZSIPARISMIKTARDEGISTIR { get; set; }
            public virtual Decimal DFXPARCA { get; set; }
            public virtual Decimal DFXINDIRIMORAN { get; set; }
            public virtual Decimal DFXMAXSIPARISMIKTAR { get; set; }
            public virtual Decimal DFXSTOKMIKTAR { get; set; }
            public virtual Decimal DFXMINSTOKMIKTAR { get; set; }
        }
    }
}

