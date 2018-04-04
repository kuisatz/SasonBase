using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("96d45f67-31bd-403e-93d9-7464cdb3f5d3")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISTEKLIFSASELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "MALZEMEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(3, "KOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(4, "SASENO", typeof(String), null, DbFieldFlags.Nullable, 25, 0, 0, "")]
    [DbField(5, "SERVISTEKLIFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISTEKLIFSASELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISTEKLIFSASELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISTEKLIFSASELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal MALZEMEID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String SASENO { get; set; }
            protected virtual Decimal SERVISTEKLIFID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal MALZEMEID { get; set; }
            public virtual String KOD { get; set; }
            public virtual String SASENO { get; set; }
            public virtual Decimal SERVISTEKLIFID { get; set; }
        }
    }
}

