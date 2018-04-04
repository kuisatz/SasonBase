using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("45499317-7538-41fb-8752-d02cae73d90f")]
    [DbTableInfoAttribute(TableTypes.Table, "TEKNISYENUZMANLIKLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "TEKNISYENUZMANLIKALANID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "BASTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(4, "TEKNISYENID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SYS_C00121601", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_TEKNISYENUZMANLIKLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_TEKNISYENUZMANLIKLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal TEKNISYENUZMANLIKALANID { get; set; }
            protected virtual DateTime BASTARIH { get; set; }
            protected virtual Decimal TEKNISYENID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal TEKNISYENUZMANLIKALANID { get; set; }
            public virtual DateTime BASTARIH { get; set; }
            public virtual Decimal TEKNISYENID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

