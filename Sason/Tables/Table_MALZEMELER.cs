using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("9bc53831-692d-43e9-b09b-3c6f265fe8e9")]
    [DbTableInfoAttribute(TableTypes.Table, "MALZEMELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "GKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "MALZEMESINIFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "MALZEMEGRUPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "BRUTAGIRLIK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "NETAGIRLIK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "BIRIMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "VERGISINIFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "ENAZSIPARISMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "HIYERARSI", typeof(String), null, DbFieldFlags.Nullable, 5, 0, 0, "")]
    [DbField(12, "ONCEKIMALZEMEKOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(13, "ONCEKIMALZEMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "MALZEMEOZELKODID1", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "MALZEMEOZELKODID2", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "MALZEMEOZELKODID3", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "MALZEMEOZELKODID4", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "MALZEMEOZELKODID5", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "URETICIVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(20, "URETICIKOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(21, "MUADILKONTROL", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(22, "SASEKONTROL", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(23, "ORJINALMALZEMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(24, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(25, "ENAZSIPARISMIKTARDEGISTIR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(26, "DFXPARCA", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(27, "DFXINDIRIMORAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(28, "DFXMAXSIPARISMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(29, "DFXSTOKMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(30, "DFXMINSTOKMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("MALZEMELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("MALZEMELER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KOD"})]
    [DbIndex("MALZEMELER_U02", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ONCEKIMALZEMEKOD"})]
    [DbIndex("MALZEMELER_U03", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"GKOD"})]
    [DbIndex("MUADIL_IDX", DbIndexType.Index, DbIndexFlags.None, new string[] {"SYS_NC00025$"})]
    public abstract class Table_MALZEMELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_MALZEMELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String GKOD { get; set; }
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
            protected virtual Decimal DURUMID { get; set; }
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
            public virtual Decimal? MALZEMESINIFID { get; set; }
            public virtual Decimal? MALZEMEGRUPID { get; set; }
            public virtual Decimal? BRUTAGIRLIK { get; set; }
            public virtual Decimal? NETAGIRLIK { get; set; }
            public virtual Decimal BIRIMID { get; set; }
            public virtual Decimal VERGISINIFID { get; set; }
            public virtual Decimal? ENAZSIPARISMIKTAR { get; set; }
            public virtual String HIYERARSI { get; set; }
            public virtual String ONCEKIMALZEMEKOD { get; set; }
            public virtual Decimal? ONCEKIMALZEMEID { get; set; }
            public virtual Decimal MALZEMEOZELKODID1 { get; set; }
            public virtual Decimal? MALZEMEOZELKODID2 { get; set; }
            public virtual Decimal? MALZEMEOZELKODID3 { get; set; }
            public virtual Decimal? MALZEMEOZELKODID4 { get; set; }
            public virtual Decimal? MALZEMEOZELKODID5 { get; set; }
            public virtual Decimal? URETICIVARLIKID { get; set; }
            public virtual String URETICIKOD { get; set; }
            public virtual Decimal? MUADILKONTROL { get; set; }
            public virtual Decimal? SASEKONTROL { get; set; }
            public virtual Decimal? ORJINALMALZEMEID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal ENAZSIPARISMIKTARDEGISTIR { get; set; }
            public virtual Decimal? DFXPARCA { get; set; }
            public virtual Decimal? DFXINDIRIMORAN { get; set; }
            public virtual Decimal? DFXMAXSIPARISMIKTAR { get; set; }
            public virtual Decimal? DFXSTOKMIKTAR { get; set; }
            public virtual Decimal? DFXMINSTOKMIKTAR { get; set; }
        }
    }
}

