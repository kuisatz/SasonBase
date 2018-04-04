using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("95c4414b-ef16-4837-bf6d-9db3d3b9d831")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISTEKNISYENLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "TEKNISYENID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ISBASTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(4, "PIN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "BRUTMAAS", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "KARTNO", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.Unicode, 40, 0, 0, "")]
    [DbIndex("SERVISTEKNISYENLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISTEKNISYENLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KARTNO"})]
    public abstract class Table_SERVISTEKNISYENLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISTEKNISYENLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal TEKNISYENID { get; set; }
            protected virtual DateTime ISBASTARIH { get; set; }
            protected virtual Decimal PIN { get; set; }
            protected virtual Decimal BRUTMAAS { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual String KARTNO { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal TEKNISYENID { get; set; }
            public virtual DateTime ISBASTARIH { get; set; }
            public virtual Decimal PIN { get; set; }
            public virtual Decimal BRUTMAAS { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String KARTNO { get; set; }
        }
    }
}

