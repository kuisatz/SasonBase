using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("a615b39c-1e0f-4893-b848-6fbc32ef86a1")]
    [DbTableInfoAttribute(TableTypes.Table, "ESAGARANTISILINENDOSYALAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "CLAIMNO", typeof(String), null, DbFieldFlags.None, 12, 0, 0, "")]
    [DbField(3, "DOCUMENTID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "XML", typeof(String), null, DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(5, "LASTUPDATE", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(6, "REQID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ESA_GARANTISILINENDOSYALAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ESAGARANTISILINENDOSYALAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"CLAIMNO","DOCUMENTID"})]
    [DbIndex("ESAGARANTISILINENDOSYALAR_U02", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"REQID"})]
    public abstract class Table_ESAGARANTISILINENDOSYALAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ESAGARANTISILINENDOSYALAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String CLAIMNO { get; set; }
            protected virtual String DOCUMENTID { get; set; }
            protected virtual String XML { get; set; }
            protected virtual DateTime LASTUPDATE { get; set; }
            protected virtual Decimal REQID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String CLAIMNO { get; set; }
            public virtual String DOCUMENTID { get; set; }
            public virtual String XML { get; set; }
            public virtual DateTime LASTUPDATE { get; set; }
            public virtual Decimal REQID { get; set; }
        }
    }
}

