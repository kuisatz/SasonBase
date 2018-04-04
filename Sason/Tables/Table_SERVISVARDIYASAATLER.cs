using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("efc4e6d2-e646-4db9-9641-5f7f61155df1")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISVARDIYASAATLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "SAAT", typeof(String), null, DbFieldFlags.None, 5, 0, 0, "")]
    [DbField(4, "SURE", typeof(String), null, DbFieldFlags.None, 5, 0, 0, "")]
    [DbField(5, "SERVISVARDIYAID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISVARDIYASAATLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISVARDIYACALISMASAATLER_PK", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISVARDIYASAATLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISVARDIYASAATLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String SAAT { get; set; }
            protected virtual String SURE { get; set; }
            protected virtual Decimal SERVISVARDIYAID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual String SAAT { get; set; }
            public virtual String SURE { get; set; }
            public virtual Decimal SERVISVARDIYAID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

