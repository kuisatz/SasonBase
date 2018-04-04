using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("7872c9b3-4732-41e0-b460-b730c66d695a")]
    [DbTableInfoAttribute(TableTypes.Table, "BAKIMGRUPAGREGALAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "BAKIMAGREGATIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "BAKIMGRUPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("BAKIMGRUPAGREGALAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("BAKIMGRUPAGREGALAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"BAKIMAGREGATIPID","BAKIMGRUPID"})]
    public abstract class Table_BAKIMGRUPAGREGALAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_BAKIMGRUPAGREGALAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal BAKIMAGREGATIPID { get; set; }
            protected virtual Decimal BAKIMGRUPID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal BAKIMAGREGATIPID { get; set; }
            public virtual Decimal BAKIMGRUPID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

