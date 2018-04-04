using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("1d475f1e-a49b-442d-bd27-2fe03223a23c")]
    [DbTableInfoAttribute(TableTypes.Table, "ESAIYINIYETGARANTILER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "VIN", typeof(String), null, DbFieldFlags.None, 17, 0, 0, "")]
    [DbField(3, "DMSORDERNO", typeof(String), null, DbFieldFlags.None, 40, 0, 0, "")]
    [DbField(4, "DEFECTCODE", typeof(String), null, DbFieldFlags.None, 20, 0, 0, "")]
    [DbField(5, "KANFXML", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(6, "KANFLASTUPDATE", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(7, "KANFREQID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "KANFCASENO", typeof(String), null, DbFieldFlags.Nullable, 16, 0, 0, "")]
    [DbField(9, "KANFCLAIMNO", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(10, "REKUXML", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(11, "REKULASTUPDATE", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(12, "REKUREQID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "REKUCLAIMNO", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(14, "ERWCXML", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(15, "ERWCLASTUPDATE", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(16, "ERWCREQID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "ERWCCLAIMNO", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(18, "KVSAXML", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(19, "KVSALASTUPDATE", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(20, "KVSAREQID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(21, "KVSACASENO", typeof(String), null, DbFieldFlags.Nullable, 16, 0, 0, "")]
    [DbField(22, "KVSACLAIMNO", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbIndex("ESAIYINIYETGARANTILER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ESAIYINIYETGARANTILER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"VIN","DMSORDERNO","DEFECTCODE"})]
    [DbIndex("ESAIYINIYETGARANTILER_U02", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KANFREQID"})]
    [DbIndex("ESAIYINIYETGARANTILER_U03", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"REKUREQID"})]
    [DbIndex("ESAIYINIYETGARANTILER_U04", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ERWCREQID"})]
    [DbIndex("ESAIYINIYETGARANTILER_U05", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KVSAREQID"})]
    public abstract class Table_ESAIYINIYETGARANTILER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ESAIYINIYETGARANTILER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String VIN { get; set; }
            protected virtual String DMSORDERNO { get; set; }
            protected virtual String DEFECTCODE { get; set; }
            protected virtual String KANFXML { get; set; }
            protected virtual DateTime KANFLASTUPDATE { get; set; }
            protected virtual Decimal KANFREQID { get; set; }
            protected virtual String KANFCASENO { get; set; }
            protected virtual String KANFCLAIMNO { get; set; }
            protected virtual String REKUXML { get; set; }
            protected virtual DateTime REKULASTUPDATE { get; set; }
            protected virtual Decimal REKUREQID { get; set; }
            protected virtual String REKUCLAIMNO { get; set; }
            protected virtual String ERWCXML { get; set; }
            protected virtual DateTime ERWCLASTUPDATE { get; set; }
            protected virtual Decimal ERWCREQID { get; set; }
            protected virtual String ERWCCLAIMNO { get; set; }
            protected virtual String KVSAXML { get; set; }
            protected virtual DateTime KVSALASTUPDATE { get; set; }
            protected virtual Decimal KVSAREQID { get; set; }
            protected virtual String KVSACASENO { get; set; }
            protected virtual String KVSACLAIMNO { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String VIN { get; set; }
            public virtual String DMSORDERNO { get; set; }
            public virtual String DEFECTCODE { get; set; }
            public virtual String KANFXML { get; set; }
            public virtual DateTime KANFLASTUPDATE { get; set; }
            public virtual Decimal KANFREQID { get; set; }
            public virtual String KANFCASENO { get; set; }
            public virtual String KANFCLAIMNO { get; set; }
            public virtual String REKUXML { get; set; }
            public virtual DateTime REKULASTUPDATE { get; set; }
            public virtual Decimal REKUREQID { get; set; }
            public virtual String REKUCLAIMNO { get; set; }
            public virtual String ERWCXML { get; set; }
            public virtual DateTime ERWCLASTUPDATE { get; set; }
            public virtual Decimal ERWCREQID { get; set; }
            public virtual String ERWCCLAIMNO { get; set; }
            public virtual String KVSAXML { get; set; }
            public virtual DateTime KVSALASTUPDATE { get; set; }
            public virtual Decimal KVSAREQID { get; set; }
            public virtual String KVSACASENO { get; set; }
            public virtual String KVSACLAIMNO { get; set; }
        }
    }
}

