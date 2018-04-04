using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("96abe36e-d688-42f0-aaba-f83cf8468886")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISTEKLIFISTEKLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "TEKLIFISTEKSERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "BELGENO", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "BASTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(5, "BITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(6, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 2000, 0, 0, "")]
    [DbField(7, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(9, "PARABIRIMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "REVIZESERVISTEKLIFISTEKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "TEKLIFISTEKSERVISISORTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(12, "SEVKADRESI", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(13, "ACIKLAMA2", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(14, "ACIKLAMAMERKEZ", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbIndex("SERVISTEKLIFISTEKLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISTEKLIFISTEKLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISTEKLIFISTEKLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal TEKLIFISTEKSERVISID { get; set; }
            protected virtual String BELGENO { get; set; }
            protected virtual DateTime BASTARIH { get; set; }
            protected virtual DateTime BITTARIH { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal PARABIRIMID { get; set; }
            protected virtual Decimal REVIZESERVISTEKLIFISTEKID { get; set; }
            protected virtual Decimal TEKLIFISTEKSERVISISORTAKID { get; set; }
            protected virtual String SEVKADRESI { get; set; }
            protected virtual String ACIKLAMA2 { get; set; }
            protected virtual String ACIKLAMAMERKEZ { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal TEKLIFISTEKSERVISID { get; set; }
            public virtual String BELGENO { get; set; }
            public virtual DateTime BASTARIH { get; set; }
            public virtual DateTime BITTARIH { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal PARABIRIMID { get; set; }
            public virtual Decimal REVIZESERVISTEKLIFISTEKID { get; set; }
            public virtual Decimal TEKLIFISTEKSERVISISORTAKID { get; set; }
            public virtual String SEVKADRESI { get; set; }
            public virtual String ACIKLAMA2 { get; set; }
            public virtual String ACIKLAMAMERKEZ { get; set; }
        }
    }
}

