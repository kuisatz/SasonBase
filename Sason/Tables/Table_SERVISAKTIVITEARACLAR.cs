using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("70d9b907-f415-4fdc-ac0c-733854693efe")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISAKTIVITEARACLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISARACID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "SERVISAKTIVITEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISAKTIVITEARACLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISAKTIVITEARACLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISAKTIVITEARACLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISARACID { get; set; }
            protected virtual Decimal SERVISAKTIVITEID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISARACID { get; set; }
            public virtual Decimal SERVISAKTIVITEID { get; set; }
        }
    }
}

