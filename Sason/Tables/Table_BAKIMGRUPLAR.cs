using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("f91da417-b41e-41fe-93ff-64620b4aa215")]
    [DbTableInfoAttribute(TableTypes.Table, "BAKIMGRUPLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "BASTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(4, "BITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(5, "BAKIMTURID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "ENDEKS", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "KILOMETRE", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "SAAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "GUN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "BAKIMSAYISI", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(11, "BAKIMTURTOLERANS", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("BAKIMGRUPLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("BAKIMGRUPLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KOD"})]
    public abstract class Table_BAKIMGRUPLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_BAKIMGRUPLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual DateTime BASTARIH { get; set; }
            protected virtual DateTime BITTARIH { get; set; }
            protected virtual Decimal BAKIMTURID { get; set; }
            protected virtual Decimal ENDEKS { get; set; }
            protected virtual Decimal KILOMETRE { get; set; }
            protected virtual Decimal SAAT { get; set; }
            protected virtual Decimal GUN { get; set; }
            protected virtual Decimal BAKIMSAYISI { get; set; }
            protected virtual Decimal BAKIMTURTOLERANS { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual DateTime BASTARIH { get; set; }
            public virtual DateTime BITTARIH { get; set; }
            public virtual Decimal BAKIMTURID { get; set; }
            public virtual Decimal ENDEKS { get; set; }
            public virtual Decimal KILOMETRE { get; set; }
            public virtual Decimal SAAT { get; set; }
            public virtual Decimal GUN { get; set; }
            public virtual Decimal BAKIMSAYISI { get; set; }
            public virtual Decimal BAKIMTURTOLERANS { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

