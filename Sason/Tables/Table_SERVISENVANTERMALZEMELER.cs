using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("07496350-8f4a-40fc-8e20-df0a750bca51")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISENVANTERMALZEMELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISENVANTERID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(3, "SERVISSTOKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "MIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 22, 2, "")]
    [DbField(5, "BIRIMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "DURUMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "MACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(8, "STOKMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISENVANTERMALZEMELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISENVANTERMALZEMELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISENVANTERMALZEMELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISENVANTERID { get; set; }
            protected virtual Decimal SERVISSTOKID { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual Decimal BIRIMID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual String MACIKLAMA { get; set; }
            protected virtual Decimal STOKMIKTAR { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISENVANTERID { get; set; }
            public virtual Decimal SERVISSTOKID { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual Decimal BIRIMID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String MACIKLAMA { get; set; }
            public virtual Decimal STOKMIKTAR { get; set; }
        }
    }
}

