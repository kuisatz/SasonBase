using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("2c96d514-4b47-4d9f-b018-26c194b889b8")]
    [DbTableInfoAttribute(TableTypes.View, "ORJINALMALZEMEKOD", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "ORJINALKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbIndex("AutoCreatePk", DbIndexType.PrimaryKey, DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class View_ORJINALMALZEMEKOD : SasonDbView
    {
        [Serializable]
        [DbTableType(typeof(View_ORJINALMALZEMEKOD))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String ORJINALKOD { get; set; }
        }
        [Serializable]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual String ORJINALKOD { get; set; }
        }
    }
}

