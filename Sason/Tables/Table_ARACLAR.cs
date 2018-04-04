using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;
using Antibiotic.Database.Attributes;

namespace SasonBase.Sason.Tables
{
    [Guid("6c9f8c8f-f84a-40b4-856f-e50b29bf4bcb")]
    [DbTableInfoAttribute(TableTypes.Table, "ARACLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SASENO", typeof(String), null, DbFieldFlags.None, 17, 0, 0, "")]
    [DbField(3, "KISASASENO", typeof(String), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(4, "PTO", typeof(String), null, DbFieldFlags.Nullable, 15, 0, 0, "")]
    [DbField(5, "WHEELSTRACK", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(6, "OVERHANG", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(7, "VARLIKRUHSATID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "VARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "ARACSINIFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "ARACTIPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "ARACTURID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "ARACURETICIID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(14, "ARACVARYANTID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "SERIALNUM001", typeof(String), null, DbFieldFlags.Nullable, 18, 0, 0, "")]
    [DbField(16, "KOMPONENT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "ARACPERT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "MERKEZONAY", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("ARACLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ARACLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"SASENO"})]
    [DbIndex("ARACLAR_U02", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"SYS_NC00015$"})]
    public abstract class Table_ARACLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ARACLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String SASENO { get; set; }
            protected virtual String KISASASENO { get; set; }
            protected virtual String PTO { get; set; }
            protected virtual String WHEELSTRACK { get; set; }
            protected virtual String OVERHANG { get; set; }
            protected virtual Decimal VARLIKRUHSATID { get; set; }
            protected virtual Decimal VARLIKID { get; set; }
            protected virtual Decimal ARACSINIFID { get; set; }
            protected virtual Decimal ARACTIPID { get; set; }
            protected virtual Decimal ARACTURID { get; set; }
            protected virtual Decimal ARACURETICIID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal ARACVARYANTID { get; set; }
            protected virtual String SERIALNUM001 { get; set; }
            protected virtual Decimal KOMPONENT { get; set; }
            protected virtual Decimal ARACPERT { get; set; }
            protected virtual Decimal MERKEZONAY { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String SASENO { get; set; }
            public virtual String KISASASENO { get; set; }
            public virtual String PTO { get; set; }
            public virtual String WHEELSTRACK { get; set; }
            public virtual String OVERHANG { get; set; }
            public virtual Decimal VARLIKRUHSATID { get; set; }
            public virtual Decimal ?VARLIKID { get; set; }
            public virtual Decimal ARACSINIFID { get; set; }
            public virtual Decimal ARACTIPID { get; set; }
            public virtual Decimal ARACTURID { get; set; }
            public virtual Decimal ARACURETICIID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal ARACVARYANTID { get; set; }
            public virtual String SERIALNUM001 { get; set; }
            public virtual Decimal KOMPONENT { get; set; }
            public virtual Decimal ARACPERT { get; set; }
            public virtual Decimal MERKEZONAY { get; set; }
        }
    }
}