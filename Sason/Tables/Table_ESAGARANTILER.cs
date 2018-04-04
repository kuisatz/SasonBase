using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("844bf4a1-8cce-46d6-9863-b72ca264f4cb")]
    [DbTableInfoAttribute(TableTypes.Table, "ESAGARANTILER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "WARRANTYCLAIM_NUM", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(3, "DMSORDER_NUM", typeof(String), null, DbFieldFlags.Nullable, 40, 0, 0, "")]
    [DbField(4, "DMSJOB_NUM", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(5, "DMSREPBEG_DATE", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(6, "XML", typeof(String), null, DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(7, "LASTUPDATE", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(8, "REQID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ESAGARANTILER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ESAGARANTILER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"WARRANTYCLAIM_NUM"})]
    [DbIndex("ESAGARANTILER_U02", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"DMSORDER_NUM","DMSJOB_NUM","DMSREPBEG_DATE"})]
    [DbIndex("ESAGARANTILER_U03", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"REQID"})]
    public abstract class Table_ESAGARANTILER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ESAGARANTILER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String WARRANTYCLAIM_NUM { get; set; }
            protected virtual String DMSORDER_NUM { get; set; }
            protected virtual String DMSJOB_NUM { get; set; }
            protected virtual DateTime DMSREPBEG_DATE { get; set; }
            protected virtual String XML { get; set; }
            protected virtual DateTime LASTUPDATE { get; set; }
            protected virtual Decimal REQID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String WARRANTYCLAIM_NUM { get; set; }
            public virtual String DMSORDER_NUM { get; set; }
            public virtual String DMSJOB_NUM { get; set; }
            public virtual DateTime DMSREPBEG_DATE { get; set; }
            public virtual String XML { get; set; }
            public virtual DateTime LASTUPDATE { get; set; }
            public virtual Decimal REQID { get; set; }
        }
    }
}

