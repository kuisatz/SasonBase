using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("33c167f5-a6f3-4738-ba35-9cc51b532855")]
    [DbTableInfoAttribute(TableTypes.Table, "TMP_MIG_ARACLAR", "Sason.Tables", "Yok")]
    [DbField(1, "SASENO", typeof(String), null, DbFieldFlags.None, 17, 0, 0, "")]
    [DbField(2, "VDN", typeof(String), null, DbFieldFlags.None, 11, 0, 0, "")]
    [DbIndex("TMP_MIG_ARACLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"SASENO"})]
    public abstract class Table_TMP_MIG_ARACLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_TMP_MIG_ARACLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual String SASENO { get; set; }
            protected virtual String VDN { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual String SASENO { get; set; }
            public virtual String VDN { get; set; }
        }
    }
}

