using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("7b253ca1-6bf5-471d-b979-b4df82768077")]
    [DbTableInfoAttribute(TableTypes.Table, "ESAWEBSERVISISTEKLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "REQ_TYPE", typeof(String), null, DbFieldFlags.None, 64, 0, 0, "")]
    [DbField(3, "REQ_DATA", typeof(String), null, DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(4, "REQ_TIME", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(5, "PROCESS_QUEUE_TIME", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(6, "PROCESS_ID", typeof(String), null, DbFieldFlags.Nullable, 32, 0, 0, "")]
    [DbField(7, "PROCESS_START_TIME", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(8, "PROCESS_END_TIME", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(9, "PROCESS_RESULT_CODE", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "PROCESS_RESULT_DATA", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(11, "REQ_PARENT_ID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "REQ_RETRY", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "PROCESS_RETRY", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "PROCESS_ERROR", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbIndex("ESAWEBSERVISISTEKLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ESAWEBSERVISISTEKLER_IDX1", DbIndexType.Index, DbIndexFlags.None, new string[] {"REQ_PARENT_ID"})]
    [DbIndex("FATIH_TMP", DbIndexType.Index, DbIndexFlags.None, new string[] {"REQ_TYPE","PROCESS_ID","PROCESS_START_TIME","PROCESS_END_TIME","PROCESS_QUEUE_TIME"})]
    public abstract class Table_ESAWEBSERVISISTEKLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ESAWEBSERVISISTEKLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String REQ_TYPE { get; set; }
            protected virtual String REQ_DATA { get; set; }
            protected virtual DateTime REQ_TIME { get; set; }
            protected virtual DateTime PROCESS_QUEUE_TIME { get; set; }
            protected virtual String PROCESS_ID { get; set; }
            protected virtual DateTime PROCESS_START_TIME { get; set; }
            protected virtual DateTime PROCESS_END_TIME { get; set; }
            protected virtual Decimal PROCESS_RESULT_CODE { get; set; }
            protected virtual String PROCESS_RESULT_DATA { get; set; }
            protected virtual Decimal REQ_PARENT_ID { get; set; }
            protected virtual Decimal REQ_RETRY { get; set; }
            protected virtual Decimal PROCESS_RETRY { get; set; }
            protected virtual String PROCESS_ERROR { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String REQ_TYPE { get; set; }
            public virtual String REQ_DATA { get; set; }
            public virtual DateTime REQ_TIME { get; set; }
            public virtual DateTime PROCESS_QUEUE_TIME { get; set; }
            public virtual String PROCESS_ID { get; set; }
            public virtual DateTime PROCESS_START_TIME { get; set; }
            public virtual DateTime PROCESS_END_TIME { get; set; }
            public virtual Decimal PROCESS_RESULT_CODE { get; set; }
            public virtual String PROCESS_RESULT_DATA { get; set; }
            public virtual Decimal REQ_PARENT_ID { get; set; }
            public virtual Decimal REQ_RETRY { get; set; }
            public virtual Decimal PROCESS_RETRY { get; set; }
            public virtual String PROCESS_ERROR { get; set; }
        }
    }
}

