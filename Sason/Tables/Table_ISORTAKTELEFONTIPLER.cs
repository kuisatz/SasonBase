using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("00fda2c5-a95c-4ed7-9bb9-05c276eadc61")]
    [DbTableInfoAttribute(TableTypes.Table, "ISORTAKTELEFONTIPLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ISORTAKTELEFONTIPLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("VARLIKTELEFONTIPLER_PK", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("VARLIKTELEFONTIPLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KOD"})]
    public abstract class Table_ISORTAKTELEFONTIPLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ISORTAKTELEFONTIPLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

