using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("1cb65f6d-42f8-4420-8429-5672578c35c7")]
    [DbTableInfoAttribute(TableTypes.Table, "ISORTAKZIYARETARCL", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "MODELYILI", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ARACTURID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "ARACTURAD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(5, "ARACTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "ARACTIPAD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(7, "ADET", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "ISORTAKZIYARETID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(9, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ISORTAKZIYARETARCL_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_ISORTAKZIYARETARCL : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ISORTAKZIYARETARCL))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal MODELYILI { get; set; }
            protected virtual Decimal ARACTURID { get; set; }
            protected virtual String ARACTURAD { get; set; }
            protected virtual Decimal ARACTIPID { get; set; }
            protected virtual String ARACTIPAD { get; set; }
            protected virtual Decimal ADET { get; set; }
            protected virtual Decimal ISORTAKZIYARETID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal MODELYILI { get; set; }
            public virtual Decimal ARACTURID { get; set; }
            public virtual String ARACTURAD { get; set; }
            public virtual Decimal ARACTIPID { get; set; }
            public virtual String ARACTIPAD { get; set; }
            public virtual Decimal ADET { get; set; }
            public virtual Decimal ISORTAKZIYARETID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

