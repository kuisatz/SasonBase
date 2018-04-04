using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("c691646f-3bda-4c78-bed3-53543fe2d0ea")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISSTOKBIRIMLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISSTOKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "BIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "ADET", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISSTOKBIRIMLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISSTOKBIRIMLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISSTOKBIRIMLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISSTOKID { get; set; }
            protected virtual Decimal BIRIMID { get; set; }
            protected virtual Decimal ADET { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISSTOKID { get; set; }
            public virtual Decimal BIRIMID { get; set; }
            public virtual Decimal ADET { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

