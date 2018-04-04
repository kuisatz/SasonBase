using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("643fcc32-f651-4047-8fac-3153cdcbe867")]
    [DbTableInfoAttribute(TableTypes.Table, "RECETEMALZEMELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "RECETEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "MALZEMEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "MIKTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "BIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("RECETEMALZEMELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("RECETEMALZEMELER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"RECETEID","MALZEMEID"})]
    public abstract class Table_RECETEMALZEMELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_RECETEMALZEMELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal RECETEID { get; set; }
            protected virtual Decimal MALZEMEID { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual Decimal BIRIMID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal RECETEID { get; set; }
            public virtual Decimal MALZEMEID { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual Decimal BIRIMID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}