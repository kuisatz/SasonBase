using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("9126bfee-83f7-41ae-9cae-3a88f89b2114")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISVARDIYALAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "BASTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(4, "BITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(5, "HAFTASONU", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISVARDIYALAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISVARDIYALAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISVARDIYALAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual DateTime BASTARIH { get; set; }
            protected virtual DateTime BITTARIH { get; set; }
            protected virtual Decimal HAFTASONU { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual DateTime BASTARIH { get; set; }
            public virtual DateTime BITTARIH { get; set; }
            public virtual Decimal HAFTASONU { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

