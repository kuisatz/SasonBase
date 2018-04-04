using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("93804b47-3456-48bf-b67c-7562d6e94f17")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISVARDIYATEKNISYENLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "TARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(3, "SERVISTEKNISYENID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "SERVISVARDIYAID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISTEKNISYENVARDIYALAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISVARDIYATEKNISYENLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISVARDIYATEKNISYENLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual Decimal SERVISTEKNISYENID { get; set; }
            protected virtual Decimal SERVISVARDIYAID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual Decimal SERVISTEKNISYENID { get; set; }
            public virtual Decimal SERVISVARDIYAID { get; set; }
        }
    }
}

