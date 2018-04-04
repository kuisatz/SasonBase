using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("7dd1981a-a277-4569-9ae8-b72a80540010")]
    [DbTableInfoAttribute(TableTypes.Table, "CIKMAIRSALIYELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "TARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(3, "KULLANICIID", typeof(String), null, DbFieldFlags.Nullable, 30, 0, 0, "")]
    [DbField(4, "SERVISCIKMALISTEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("CIKMAIRSALIYELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_CIKMAIRSALIYELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_CIKMAIRSALIYELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual String KULLANICIID { get; set; }
            protected virtual Decimal SERVISCIKMALISTEID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual String KULLANICIID { get; set; }
            public virtual Decimal SERVISCIKMALISTEID { get; set; }
        }
    }
}

