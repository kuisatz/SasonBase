using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("855b7084-62a7-4d10-9fe4-d2f222994df3")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISSIPARISMLZLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "MALZEMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(3, "MIKTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "BIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "BIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "VADEGUN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "TESLIMTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(8, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(9, "SERVISTEKLIFMLZID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "SERVISSIPARISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(11, "SASINO", typeof(String), null, DbFieldFlags.Nullable, 25, 0, 0, "")]
    [DbField(12, "ISEMRINO", typeof(String), null, DbFieldFlags.Nullable, 25, 0, 0, "")]
    [DbField(13, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(14, "AKSIYONNO", typeof(String), null, DbFieldFlags.Nullable, 25, 0, 0, "")]
    [DbField(15, "WORKSHOP", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "SERVISDEPOID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "SERVISDEPORAFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "SERVISSTOKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "MUADILTEDARIKNEDENID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(20, "BRUTFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(21, "KDVORAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(22, "SERVISEKMALIYETID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(23, "DFXSATIS", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(24, "DFXINDIRIMORAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(25, "FATURAID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISSIPARISMLZLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISSIPARISMLZLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISSIPARISMLZLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal MALZEMEID { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual Decimal BIRIMID { get; set; }
            protected virtual Decimal BIRIMFIYAT { get; set; }
            protected virtual Decimal VADEGUN { get; set; }
            protected virtual DateTime TESLIMTARIH { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISTEKLIFMLZID { get; set; }
            protected virtual Decimal SERVISSIPARISID { get; set; }
            protected virtual String SASINO { get; set; }
            protected virtual String ISEMRINO { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual String AKSIYONNO { get; set; }
            protected virtual Decimal WORKSHOP { get; set; }
            protected virtual Decimal SERVISDEPOID { get; set; }
            protected virtual Decimal SERVISDEPORAFID { get; set; }
            protected virtual Decimal SERVISSTOKID { get; set; }
            protected virtual Decimal MUADILTEDARIKNEDENID { get; set; }
            protected virtual Decimal BRUTFIYAT { get; set; }
            protected virtual Decimal KDVORAN { get; set; }
            protected virtual Decimal SERVISEKMALIYETID { get; set; }
            protected virtual Decimal DFXSATIS { get; set; }
            protected virtual Decimal DFXINDIRIMORAN { get; set; }
            protected virtual Decimal FATURAID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal MALZEMEID { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual Decimal BIRIMID { get; set; }
            public virtual Decimal BIRIMFIYAT { get; set; }
            public virtual Decimal VADEGUN { get; set; }
            public virtual DateTime TESLIMTARIH { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISTEKLIFMLZID { get; set; }
            public virtual Decimal SERVISSIPARISID { get; set; }
            public virtual String SASINO { get; set; }
            public virtual String ISEMRINO { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual String AKSIYONNO { get; set; }
            public virtual Decimal WORKSHOP { get; set; }
            public virtual Decimal SERVISDEPOID { get; set; }
            public virtual Decimal SERVISDEPORAFID { get; set; }
            public virtual Decimal SERVISSTOKID { get; set; }
            public virtual Decimal MUADILTEDARIKNEDENID { get; set; }
            public virtual Decimal BRUTFIYAT { get; set; }
            public virtual Decimal KDVORAN { get; set; }
            public virtual Decimal SERVISEKMALIYETID { get; set; }
            public virtual Decimal DFXSATIS { get; set; }
            public virtual Decimal DFXINDIRIMORAN { get; set; }
            public virtual Decimal FATURAID { get; set; }
        }
    }
}

