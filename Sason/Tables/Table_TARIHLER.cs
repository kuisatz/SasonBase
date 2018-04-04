using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("058c379e-f1a2-4237-8ca2-b2689a51a5eb")]
    [DbTableInfoAttribute(TableTypes.Table, "TARIHLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "TARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(3, "YIL", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "AY", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "GUN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "HAFTA", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "HAFTAGUNU", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("TARIHLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("TARIHLER_UIX1", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"TARIH"})]
    [DbIndex("TARIHLER_UIX2", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"YIL","AY","GUN"})]
    public abstract class Table_TARIHLER : SasonDbTable
    {
        [Serializable]
        [DbTableType(typeof(Table_TARIHLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual Decimal YIL { get; set; }
            protected virtual Decimal AY { get; set; }
            protected virtual Decimal GUN { get; set; }
            protected virtual Decimal HAFTA { get; set; }
            protected virtual Decimal HAFTAGUNU { get; set; }
        }
        [Serializable]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual Decimal YIL { get; set; }
            public virtual Decimal AY { get; set; }
            public virtual Decimal GUN { get; set; }
            public virtual Decimal HAFTA { get; set; }
            public virtual Decimal HAFTAGUNU { get; set; }
        }
    }
}

