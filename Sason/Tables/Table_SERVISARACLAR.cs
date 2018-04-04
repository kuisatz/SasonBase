using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("d6661cd1-1268-4fed-8c4c-09443fd817f7")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISARACLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SASENO", typeof(String), null, DbFieldFlags.None, 17, 0, 0, "")]
    [DbField(3, "SERVISVARLIKRUHSATID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "SERVISVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "ARACID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "MANOLMAYAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISARACLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISARACLAR_U02", DbIndexType.Index, DbIndexFlags.None, new string[] {"SERVISVARLIKID"})]
    [DbIndex("SERVISARACLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"SASENO","SERVISID"})]
    public abstract class Table_SERVISARACLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISARACLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String SASENO { get; set; }
            protected virtual Decimal SERVISVARLIKRUHSATID { get; set; }
            protected virtual Decimal SERVISVARLIKID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal ARACID { get; set; }
            protected virtual Decimal MANOLMAYAN { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String SASENO { get; set; }
            public virtual Decimal SERVISVARLIKRUHSATID { get; set; }
            public virtual Decimal SERVISVARLIKID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal ARACID { get; set; }
            public virtual Decimal MANOLMAYAN { get; set; }
        }
    }
}

