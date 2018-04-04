using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("cc244b84-a0d9-4770-b855-a69a87482ce6")]
    [DbTableInfoAttribute(TableTypes.Table, "ESAARACLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "VIN", typeof(String), null, DbFieldFlags.None, 17, 0, 0, "")]
    [DbField(3, "XML", typeof(String), null, DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(4, "LASTUPDATE", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(5, "REQID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "RHXML", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(7, "RHLASTUPDATE", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(8, "RHREQID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "SIXML", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(10, "SILASTUPDATE", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(11, "SIREQID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "MSXML", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(13, "MSLASTUPDATE", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(14, "MSREQID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "FCXML", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(16, "FCLASTUPDATE", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(17, "FCREQID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("ESAARACLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ESAARACLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"VIN"})]
    [DbIndex("ESAARACLAR_U02", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"REQID"})]
    [DbIndex("ESAARACLAR_U03", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"RHREQID"})]
    [DbIndex("ESAARACLAR_U04", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"SIREQID"})]
    [DbIndex("ESAARACLAR_U05", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"MSREQID"})]
    [DbIndex("ESAARACLAR_U06", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"FCREQID"})]
    public abstract class Table_ESAARACLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ESAARACLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String VIN { get; set; }
            protected virtual String XML { get; set; }
            protected virtual DateTime LASTUPDATE { get; set; }
            protected virtual Decimal REQID { get; set; }
            protected virtual String RHXML { get; set; }
            protected virtual DateTime RHLASTUPDATE { get; set; }
            protected virtual Decimal RHREQID { get; set; }
            protected virtual String SIXML { get; set; }
            protected virtual DateTime SILASTUPDATE { get; set; }
            protected virtual Decimal SIREQID { get; set; }
            protected virtual String MSXML { get; set; }
            protected virtual DateTime MSLASTUPDATE { get; set; }
            protected virtual Decimal MSREQID { get; set; }
            protected virtual String FCXML { get; set; }
            protected virtual DateTime FCLASTUPDATE { get; set; }
            protected virtual Decimal FCREQID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String VIN { get; set; }
            public virtual String XML { get; set; }
            public virtual DateTime LASTUPDATE { get; set; }
            public virtual Decimal REQID { get; set; }
            public virtual String RHXML { get; set; }
            public virtual DateTime RHLASTUPDATE { get; set; }
            public virtual Decimal RHREQID { get; set; }
            public virtual String SIXML { get; set; }
            public virtual DateTime SILASTUPDATE { get; set; }
            public virtual Decimal SIREQID { get; set; }
            public virtual String MSXML { get; set; }
            public virtual DateTime MSLASTUPDATE { get; set; }
            public virtual Decimal MSREQID { get; set; }
            public virtual String FCXML { get; set; }
            public virtual DateTime FCLASTUPDATE { get; set; }
            public virtual Decimal FCREQID { get; set; }
        }
    }
}

