using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("7bf78aa8-c37e-4e16-871f-f88a19592b05")]
    [DbTableInfoAttribute(TableTypes.Table, "MANKART", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KARTNO", typeof(String), null, DbFieldFlags.Unicode, 100, 0, 0, "")]
    [DbField(3, "RFID", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.Unicode, 40, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "SASENO", typeof(String), null, DbFieldFlags.None, 17, 0, 0, "")]
    [DbField(7, "KAYITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(8, "BASTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(9, "BITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbIndex("MANKART_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("MANKART_UIX1", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KARTNO"})]
    public abstract class Table_MANKART : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_MANKART))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KARTNO { get; set; }
            protected virtual String RFID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual String SASENO { get; set; }
            protected virtual DateTime KAYITTARIH { get; set; }
            protected virtual DateTime BASTARIH { get; set; }
            protected virtual DateTime BITTARIH { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KARTNO { get; set; }
            public virtual String RFID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual String SASENO { get; set; }
            public virtual DateTime KAYITTARIH { get; set; }
            public virtual DateTime BASTARIH { get; set; }
            public virtual DateTime BITTARIH { get; set; }
        }
    }
}

