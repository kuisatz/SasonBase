using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("ec471cc1-34bd-4db9-b6e9-7c9c967c7324")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISISORTAKLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AD", typeof(String), null, DbFieldFlags.None, 200, 0, 0, "")]
    [DbField(3, "SERVISVARLIKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "IOTYPM", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "IOTYPM0", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "IOTYPM1", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "IOTSM", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "IOTSM0", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(9, "IOTSM1", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(10, "IOTS", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(11, "IOTS0", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(12, "IOTS1", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(13, "IOTYPS", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(14, "IOTYPU", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(15, "IOTYPD", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(16, "IOTYPI", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(17, "KAMYONSEKTORID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "KAMYONGRUPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "KAMYONFILOBUYUKLUKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(20, "OTOBUSSEKTORID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(21, "OTOBUSGRUPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(22, "OTOBUSFILOBUYUKLUKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(23, "FILOBUYUKLUKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(24, "SONYATIRIMTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(25, "TAHMINIYATIRIMTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(26, "YATIRIMACIKLAMA", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(27, "GUVENIRLIKDERECEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(28, "SMUSTERIDERECEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(29, "SSHMUSTERIDERECEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(30, "CIROBUYUKLUKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(31, "CALISANSAYISIBUYUKLUKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(32, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(33, "ISORTAKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(34, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(35, "CARIKOD", typeof(String), null, DbFieldFlags.Nullable, 30, 0, 0, "")]
    [DbIndex("SERVISISORTAKLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISISORTAKLAR_IDX2", DbIndexType.Index, DbIndexFlags.None, new string[] {"SERVISVARLIKID","ID"})]
    [DbIndex("SERVISISORTAKLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"AD","SERVISVARLIKID"})]
    [DbIndex("SERVISISORTAKLAR_U02", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ISORTAKID"})]
    public abstract class Table_SERVISISORTAKLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISISORTAKLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String AD { get; set; }
            protected virtual Decimal SERVISVARLIKID { get; set; }
            protected virtual Decimal IOTYPM { get; set; }
            protected virtual Decimal IOTYPM0 { get; set; }
            protected virtual Decimal IOTYPM1 { get; set; }
            protected virtual Decimal IOTSM { get; set; }
            protected virtual Decimal IOTSM0 { get; set; }
            protected virtual Decimal IOTSM1 { get; set; }
            protected virtual Decimal IOTS { get; set; }
            protected virtual Decimal IOTS0 { get; set; }
            protected virtual Decimal IOTS1 { get; set; }
            protected virtual Decimal IOTYPS { get; set; }
            protected virtual Decimal IOTYPU { get; set; }
            protected virtual Decimal IOTYPD { get; set; }
            protected virtual Decimal IOTYPI { get; set; }
            protected virtual Decimal KAMYONSEKTORID { get; set; }
            protected virtual Decimal KAMYONGRUPID { get; set; }
            protected virtual Decimal KAMYONFILOBUYUKLUKID { get; set; }
            protected virtual Decimal OTOBUSSEKTORID { get; set; }
            protected virtual Decimal OTOBUSGRUPID { get; set; }
            protected virtual Decimal OTOBUSFILOBUYUKLUKID { get; set; }
            protected virtual Decimal FILOBUYUKLUKID { get; set; }
            protected virtual DateTime SONYATIRIMTARIH { get; set; }
            protected virtual DateTime TAHMINIYATIRIMTARIH { get; set; }
            protected virtual String YATIRIMACIKLAMA { get; set; }
            protected virtual Decimal GUVENIRLIKDERECEID { get; set; }
            protected virtual Decimal SMUSTERIDERECEID { get; set; }
            protected virtual Decimal SSHMUSTERIDERECEID { get; set; }
            protected virtual Decimal CIROBUYUKLUKID { get; set; }
            protected virtual Decimal CALISANSAYISIBUYUKLUKID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal ISORTAKID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual String CARIKOD { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String AD { get; set; }
            public virtual Decimal SERVISVARLIKID { get; set; }
            public virtual Decimal IOTYPM { get; set; }
            public virtual Decimal IOTYPM0 { get; set; }
            public virtual Decimal IOTYPM1 { get; set; }
            public virtual Decimal IOTSM { get; set; }
            public virtual Decimal IOTSM0 { get; set; }
            public virtual Decimal IOTSM1 { get; set; }
            public virtual Decimal IOTS { get; set; }
            public virtual Decimal IOTS0 { get; set; }
            public virtual Decimal IOTS1 { get; set; }
            public virtual Decimal IOTYPS { get; set; }
            public virtual Decimal IOTYPU { get; set; }
            public virtual Decimal IOTYPD { get; set; }
            public virtual Decimal IOTYPI { get; set; }
            public virtual Decimal KAMYONSEKTORID { get; set; }
            public virtual Decimal KAMYONGRUPID { get; set; }
            public virtual Decimal KAMYONFILOBUYUKLUKID { get; set; }
            public virtual Decimal OTOBUSSEKTORID { get; set; }
            public virtual Decimal OTOBUSGRUPID { get; set; }
            public virtual Decimal OTOBUSFILOBUYUKLUKID { get; set; }
            public virtual Decimal FILOBUYUKLUKID { get; set; }
            public virtual DateTime SONYATIRIMTARIH { get; set; }
            public virtual DateTime TAHMINIYATIRIMTARIH { get; set; }
            public virtual String YATIRIMACIKLAMA { get; set; }
            public virtual Decimal GUVENIRLIKDERECEID { get; set; }
            public virtual Decimal SMUSTERIDERECEID { get; set; }
            public virtual Decimal SSHMUSTERIDERECEID { get; set; }
            public virtual Decimal CIROBUYUKLUKID { get; set; }
            public virtual Decimal CALISANSAYISIBUYUKLUKID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal ISORTAKID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String CARIKOD { get; set; }
        }
    }
}

