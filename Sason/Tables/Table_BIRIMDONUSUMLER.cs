using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("eaa2df67-3d2e-484a-a636-578cdb38008f")]
    [DbTableInfoAttribute(TableTypes.Table, "BIRIMDONUSUMLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "BASLANGICBIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "HEDEFBIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "KATSAYI", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("BIRIMDONUSUMLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("BIRIMDONUSUMLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"BASLANGICBIRIMID","HEDEFBIRIMID"})]
    public abstract class Table_BIRIMDONUSUMLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_BIRIMDONUSUMLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal BASLANGICBIRIMID { get; set; }
            protected virtual Decimal HEDEFBIRIMID { get; set; }
            protected virtual Decimal KATSAYI { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal BASLANGICBIRIMID { get; set; }
            public virtual Decimal HEDEFBIRIMID { get; set; }
            public virtual Decimal KATSAYI { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

