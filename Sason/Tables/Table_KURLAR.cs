using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("cd70053f-74fd-4df0-8951-c0db129a54fa")]
    [DbTableInfoAttribute(TableTypes.Table, "KURLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "TARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(3, "XML", typeof(String), null, DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbIndex("KURLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("KURLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"TARIH"})]
    public abstract class Table_KURLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_KURLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual String XML { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual String XML { get; set; }
        }
    }
}

