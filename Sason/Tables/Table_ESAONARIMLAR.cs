using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("5f1a954e-9a39-44d7-93bd-f74d7156beef")]
    [DbTableInfoAttribute(TableTypes.Table, "ESAONARIMLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "VIN", typeof(String), null, DbFieldFlags.None, 17, 0, 0, "")]
    [DbField(3, "EXTERNALREF", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "XML", typeof(String), null, DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(5, "LASTUPDATE", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(6, "REQID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ESAONARIMLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ESAONARIMLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"VIN","EXTERNALREF"})]
    [DbIndex("ESAONARIMLAR_U02", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"REQID"})]
    public abstract class Table_ESAONARIMLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ESAONARIMLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String VIN { get; set; }
            protected virtual String EXTERNALREF { get; set; }
            protected virtual String XML { get; set; }
            protected virtual DateTime LASTUPDATE { get; set; }
            protected virtual Decimal REQID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String VIN { get; set; }
            public virtual String EXTERNALREF { get; set; }
            public virtual String XML { get; set; }
            public virtual DateTime LASTUPDATE { get; set; }
            public virtual Decimal REQID { get; set; }
        }
    }
}

