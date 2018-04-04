using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("553a51af-a065-4763-8273-79cb18bc9075")]
    [DbTableInfoAttribute(TableTypes.Table, "ESAIYINIYETGARANTIDURUMLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "CASENO", typeof(String), null, DbFieldFlags.None, 16, 0, 0, "")]
    [DbField(3, "XML", typeof(String), null, DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(4, "LASTUPDATE", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(5, "REQID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ESAIYINIYETGARANTIDURUMLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ESAIYINIYETGARANTIDURUMLAR_U02", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"REQID"})]
    [DbIndex("ESAIYINIYETGARANTIDURUMLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"CASENO"})]
    public abstract class Table_ESAIYINIYETGARANTIDURUMLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ESAIYINIYETGARANTIDURUMLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String CASENO { get; set; }
            protected virtual String XML { get; set; }
            protected virtual DateTime LASTUPDATE { get; set; }
            protected virtual Decimal REQID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String CASENO { get; set; }
            public virtual String XML { get; set; }
            public virtual DateTime LASTUPDATE { get; set; }
            public virtual Decimal REQID { get; set; }
        }
    }
}

