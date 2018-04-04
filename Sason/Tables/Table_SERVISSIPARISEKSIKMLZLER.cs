using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("4ed0e372-0fd6-4e9b-9c4d-23e636e9eec2")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISSIPARISEKSIKMLZLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISSIPARISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "MIKTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "SIPARISDURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "SERVISSTOKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "MALZEMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "KOD", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(9, "SERVISSTOKISLEMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "SERVISSTOKISLEMID_TEXT", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(11, "SERVISVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "SERVISVARLIKID_TEXT", typeof(String), null, DbFieldFlags.Nullable, 250, 0, 0, "")]
    [DbField(13, "MALZEMEALISAMACID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "MALZEMEALISAMACID_TEXT", typeof(String), null, DbFieldFlags.Nullable, 250, 0, 0, "")]
    [DbField(15, "SEVKADRESI", typeof(String), null, DbFieldFlags.Nullable, 250, 0, 0, "")]
    [DbField(16, "ODEMETIPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "ODEMETIPID_TEXT", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(18, "TARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbIndex("SERVISSIPARISEKSIKMLZLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISSIPARISEKSIKMLZLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISSIPARISEKSIKMLZLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISSIPARISID { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal SIPARISDURUMID { get; set; }
            protected virtual Decimal SERVISSTOKID { get; set; }
            protected virtual Decimal MALZEMEID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual Decimal SERVISSTOKISLEMID { get; set; }
            protected virtual String SERVISSTOKISLEMID_TEXT { get; set; }
            protected virtual Decimal SERVISVARLIKID { get; set; }
            protected virtual String SERVISVARLIKID_TEXT { get; set; }
            protected virtual Decimal MALZEMEALISAMACID { get; set; }
            protected virtual String MALZEMEALISAMACID_TEXT { get; set; }
            protected virtual String SEVKADRESI { get; set; }
            protected virtual Decimal ODEMETIPID { get; set; }
            protected virtual String ODEMETIPID_TEXT { get; set; }
            protected virtual DateTime TARIH { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISSIPARISID { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal SIPARISDURUMID { get; set; }
            public virtual Decimal SERVISSTOKID { get; set; }
            public virtual Decimal MALZEMEID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal SERVISSTOKISLEMID { get; set; }
            public virtual String SERVISSTOKISLEMID_TEXT { get; set; }
            public virtual Decimal SERVISVARLIKID { get; set; }
            public virtual String SERVISVARLIKID_TEXT { get; set; }
            public virtual Decimal MALZEMEALISAMACID { get; set; }
            public virtual String MALZEMEALISAMACID_TEXT { get; set; }
            public virtual String SEVKADRESI { get; set; }
            public virtual Decimal ODEMETIPID { get; set; }
            public virtual String ODEMETIPID_TEXT { get; set; }
            public virtual DateTime TARIH { get; set; }
        }
    }
}

