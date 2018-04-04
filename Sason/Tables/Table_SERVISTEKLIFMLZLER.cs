using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("4d9b5305-170b-430f-9204-1319540759d4")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISTEKLIFMLZLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISTEKLIFISTEKMLZID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(3, "BIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "ENAZSIPARISMIKTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "BASTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(6, "BITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(7, "VADEGUN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "TESLIMTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(9, "REVIZESERVISTEKLIFMLZID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(11, "INDBIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "SIPARISTURID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "SERVISTEKLIFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "MALZEMEINDIRIMTIPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "SERVISSTOKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "SERVISSTOKINDIRIMTIPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "SASINO", typeof(String), null, DbFieldFlags.Nullable, 25, 0, 0, "")]
    [DbField(18, "ISEMRINO", typeof(String), null, DbFieldFlags.Nullable, 25, 0, 0, "")]
    [DbField(19, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(20, "WORKSHOP", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(21, "AKSIYONNO", typeof(String), null, DbFieldFlags.Nullable, 25, 0, 0, "")]
    [DbField(22, "SERVISDEPOID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(23, "SERVISDEPORAFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(24, "MIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(25, "MALZEMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(26, "INDIRIMORAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(27, "SERVISEKMALIYETID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(28, "DFXSATIS", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(29, "DFXINDIRIMORAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISTEKLIFMLZLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISTEKLIFMLZLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISTEKLIFMLZLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISTEKLIFISTEKMLZID { get; set; }
            protected virtual Decimal BIRIMFIYAT { get; set; }
            protected virtual Decimal ENAZSIPARISMIKTAR { get; set; }
            protected virtual DateTime BASTARIH { get; set; }
            protected virtual DateTime BITTARIH { get; set; }
            protected virtual Decimal VADEGUN { get; set; }
            protected virtual DateTime TESLIMTARIH { get; set; }
            protected virtual Decimal REVIZESERVISTEKLIFMLZID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal INDBIRIMFIYAT { get; set; }
            protected virtual Decimal SIPARISTURID { get; set; }
            protected virtual Decimal SERVISTEKLIFID { get; set; }
            protected virtual Decimal MALZEMEINDIRIMTIPID { get; set; }
            protected virtual Decimal SERVISSTOKID { get; set; }
            protected virtual Decimal SERVISSTOKINDIRIMTIPID { get; set; }
            protected virtual String SASINO { get; set; }
            protected virtual String ISEMRINO { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal WORKSHOP { get; set; }
            protected virtual String AKSIYONNO { get; set; }
            protected virtual Decimal SERVISDEPOID { get; set; }
            protected virtual Decimal SERVISDEPORAFID { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual Decimal MALZEMEID { get; set; }
            protected virtual Decimal INDIRIMORAN { get; set; }
            protected virtual Decimal SERVISEKMALIYETID { get; set; }
            protected virtual Decimal DFXSATIS { get; set; }
            protected virtual Decimal DFXINDIRIMORAN { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISTEKLIFISTEKMLZID { get; set; }
            public virtual Decimal BIRIMFIYAT { get; set; }
            public virtual Decimal ENAZSIPARISMIKTAR { get; set; }
            public virtual DateTime BASTARIH { get; set; }
            public virtual DateTime BITTARIH { get; set; }
            public virtual Decimal VADEGUN { get; set; }
            public virtual DateTime TESLIMTARIH { get; set; }
            public virtual Decimal REVIZESERVISTEKLIFMLZID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal INDBIRIMFIYAT { get; set; }
            public virtual Decimal SIPARISTURID { get; set; }
            public virtual Decimal SERVISTEKLIFID { get; set; }
            public virtual Decimal MALZEMEINDIRIMTIPID { get; set; }
            public virtual Decimal SERVISSTOKID { get; set; }
            public virtual Decimal SERVISSTOKINDIRIMTIPID { get; set; }
            public virtual String SASINO { get; set; }
            public virtual String ISEMRINO { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal WORKSHOP { get; set; }
            public virtual String AKSIYONNO { get; set; }
            public virtual Decimal SERVISDEPOID { get; set; }
            public virtual Decimal SERVISDEPORAFID { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual Decimal MALZEMEID { get; set; }
            public virtual Decimal INDIRIMORAN { get; set; }
            public virtual Decimal SERVISEKMALIYETID { get; set; }
            public virtual Decimal DFXSATIS { get; set; }
            public virtual Decimal DFXINDIRIMORAN { get; set; }
        }
    }
}

