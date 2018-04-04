using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("11752eb9-a524-4753-bb59-9440ca2e1f9d")]
    [DbTableInfoAttribute(TableTypes.Table, "KONTAKTELEFONLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "NO", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "KONTAKTELEFONTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "SMSIZIN", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "ARAMAIZIN", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "KONTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("KONTAKTELEFONLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_KONTAKTELEFONLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_KONTAKTELEFONLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String NO { get; set; }
            protected virtual Decimal KONTAKTELEFONTIPID { get; set; }
            protected virtual Decimal SMSIZIN { get; set; }
            protected virtual Decimal ARAMAIZIN { get; set; }
            protected virtual Decimal KONTAKID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String NO { get; set; }
            public virtual Decimal KONTAKTELEFONTIPID { get; set; }
            public virtual Decimal SMSIZIN { get; set; }
            public virtual Decimal ARAMAIZIN { get; set; }
            public virtual Decimal KONTAKID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

