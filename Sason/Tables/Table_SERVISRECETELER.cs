using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("c048e17f-4db5-4168-8272-b2a9b2190709")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISRECETELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "RECETEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISRECETELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISRECETELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISRECETELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal RECETEID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal RECETEID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

