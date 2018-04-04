using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("d53c0ace-269b-4df4-b0e6-0d3c08a59d1c")]
    [DbTableInfoAttribute(TableTypes.View, "ORJINALTOMALZEMEKOD", "Sason.Tables", "Yok")]
    [DbField(1, "SEARCH_ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SEARCH_KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "SEARCH_GKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "FOUND_ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "FOUND_KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(6, "FOUND_GKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbIndex("AutoCreatePk", DbIndexType.PrimaryKey, DbIndexFlags.Unique, new string[] { "SEARCH_ID" })]
    public abstract class View_ORJINALTOMALZEMEKOD : SasonDbView
    {
        [Serializable]
        [DbTableType(typeof(View_ORJINALTOMALZEMEKOD))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal SEARCH_ID { get; set; }
            protected virtual String SEARCH_KOD { get; set; }
            protected virtual String SEARCH_GKOD { get; set; }
            protected virtual Decimal FOUND_ID { get; set; }
            protected virtual String FOUND_KOD { get; set; }
            protected virtual String FOUND_GKOD { get; set; }
        }
        [Serializable]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal SEARCH_ID { get; set; }
            public virtual String SEARCH_KOD { get; set; }
            public virtual String SEARCH_GKOD { get; set; }
            public virtual Decimal FOUND_ID { get; set; }
            public virtual String FOUND_KOD { get; set; }
            public virtual String FOUND_GKOD { get; set; }
        }
    }
}

