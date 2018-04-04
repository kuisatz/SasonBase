using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("a705f912-f4b9-4108-9f13-4ab621209f17")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISTEKLIFISTEKMLZLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "MALZEMEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "MIKTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "BIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "TESLIMTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(6, "SERVISTEKLIFISTEKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "REVIZESERVISTEKLIFISTEKMLZID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "SIPARISTURID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "SASINO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(11, "ISEMRINO", typeof(String), null, DbFieldFlags.Nullable, 25, 0, 0, "")]
    [DbField(12, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(13, "AKSIYONNO", typeof(String), null, DbFieldFlags.Nullable, 25, 0, 0, "")]
    [DbField(14, "WORKSHOP", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISTEKLIFISTEKMLZLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISTEKLIFISTEKMLZLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISTEKLIFISTEKMLZLER))]
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
            protected virtual DateTime TESLIMTARIH { get; set; }
            protected virtual Decimal SERVISTEKLIFISTEKID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal REVIZESERVISTEKLIFISTEKMLZID { get; set; }
            protected virtual Decimal SIPARISTURID { get; set; }
            protected virtual String SASINO { get; set; }
            protected virtual String ISEMRINO { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual String AKSIYONNO { get; set; }
            protected virtual Decimal WORKSHOP { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal MALZEMEID { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual Decimal BIRIMID { get; set; }
            public virtual DateTime TESLIMTARIH { get; set; }
            public virtual Decimal SERVISTEKLIFISTEKID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal REVIZESERVISTEKLIFISTEKMLZID { get; set; }
            public virtual Decimal SIPARISTURID { get; set; }
            public virtual String SASINO { get; set; }
            public virtual String ISEMRINO { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual String AKSIYONNO { get; set; }
            public virtual Decimal WORKSHOP { get; set; }
        }
    }
}

