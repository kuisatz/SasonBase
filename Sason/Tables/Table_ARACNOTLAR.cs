using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("5be855b3-d837-4c6a-a03c-dfc4f01d1909")]
    [DbTableInfoAttribute(TableTypes.Table, "ARACNOTLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "NOTLAR", typeof(String), null, DbFieldFlags.None, 4000, 0, 0, "")]
    [DbField(3, "BASTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(4, "BITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(5, "YEREL", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "KAYITKULLANICIID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(7, "KAYITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(8, "ARACID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(9, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ARACNOTLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_ARACNOTLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ARACNOTLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String NOTLAR { get; set; }
            protected virtual DateTime BASTARIH { get; set; }
            protected virtual DateTime BITTARIH { get; set; }
            protected virtual Decimal YEREL { get; set; }
            protected virtual String KAYITKULLANICIID { get; set; }
            protected virtual DateTime KAYITTARIH { get; set; }
            protected virtual Decimal ARACID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String NOTLAR { get; set; }
            public virtual DateTime BASTARIH { get; set; }
            public virtual DateTime BITTARIH { get; set; }
            public virtual Decimal YEREL { get; set; }
            public virtual String KAYITKULLANICIID { get; set; }
            public virtual DateTime KAYITTARIH { get; set; }
            public virtual Decimal ARACID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

