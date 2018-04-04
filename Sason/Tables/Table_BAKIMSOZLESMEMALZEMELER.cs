using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("66b00d90-a876-419c-b157-33ab596d234e")]
    [DbTableInfoAttribute(TableTypes.Table, "BAKIMSOZLESMEMALZEMELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "BAKIMSOZLESMEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "MALZEMEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "ADET", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "KALANADET", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("BAKIMSOZLESMEMALZEMELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_BAKIMSOZLESMEMALZEMELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_BAKIMSOZLESMEMALZEMELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal BAKIMSOZLESMEID { get; set; }
            protected virtual Decimal MALZEMEID { get; set; }
            protected virtual Decimal ADET { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal KALANADET { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal BAKIMSOZLESMEID { get; set; }
            public virtual Decimal MALZEMEID { get; set; }
            public virtual Decimal ADET { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal KALANADET { get; set; }
        }
    }
}

