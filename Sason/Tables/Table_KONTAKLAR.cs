using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("abd1e847-2398-49b2-a455-c62c1bb74b05")]
    [DbTableInfoAttribute(TableTypes.Table, "KONTAKLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "AD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "EPOSTA", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(4, "EPOSTAIZIN", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("KONTAKLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_KONTAKLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_KONTAKLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String AD { get; set; }
            protected virtual String EPOSTA { get; set; }
            protected virtual Decimal EPOSTAIZIN { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String AD { get; set; }
            public virtual String EPOSTA { get; set; }
            public virtual Decimal EPOSTAIZIN { get; set; }
        }
    }
}

