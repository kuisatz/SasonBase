using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("e462ab37-86c5-409a-95dd-b57d36ff6ec8")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISESAPARAMETRELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "ESAPARAMETREID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ESASISTEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISESAPARAMETRELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISESAPARAMETRELER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ESASISTEMID","SERVISID"})]
    public abstract class Table_SERVISESAPARAMETRELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISESAPARAMETRELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal ESAPARAMETREID { get; set; }
            protected virtual Decimal ESASISTEMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal ESAPARAMETREID { get; set; }
            public virtual Decimal ESASISTEMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
        }
    }
}

