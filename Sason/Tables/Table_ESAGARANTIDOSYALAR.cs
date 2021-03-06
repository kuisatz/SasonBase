using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("93a9090a-294c-44e7-8214-43c93ba202f6")]
    [DbTableInfoAttribute(TableTypes.Table, "ESAGARANTIDOSYALAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "CLAIMNO", typeof(String), null, DbFieldFlags.None, 12, 0, 0, "")]
    [DbField(3, "DOCNAME", typeof(String), null, DbFieldFlags.None, 12, 0, 0, "")]
    [DbField(4, "XML", typeof(String), null, DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(5, "LASTUPDATE", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(6, "REQID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ESAGARANTIDOSYALAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ESAGARANTIDOSYALAR_U02", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"REQID"})]
    [DbIndex("ESAGARANTIDOSYALAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"CLAIMNO","DOCNAME"})]
    public abstract class Table_ESAGARANTIDOSYALAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ESAGARANTIDOSYALAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String CLAIMNO { get; set; }
            protected virtual String DOCNAME { get; set; }
            protected virtual String XML { get; set; }
            protected virtual DateTime LASTUPDATE { get; set; }
            protected virtual Decimal REQID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String CLAIMNO { get; set; }
            public virtual String DOCNAME { get; set; }
            public virtual String XML { get; set; }
            public virtual DateTime LASTUPDATE { get; set; }
            public virtual Decimal REQID { get; set; }
        }
    }
}

