using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("32454c62-9f59-4c73-845b-12d9b344e486")]
    [DbTableInfoAttribute(TableTypes.Table, "PARAMETRELER", "Sason.Tables", "Yok")]
    [DbField(1, "AD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(2, "SAYI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(3, "TEXT", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(4, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbIndex("PARAMETRELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"AD"})]
    public abstract class Table_PARAMETRELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_PARAMETRELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual String AD { get; set; }
            protected virtual Decimal SAYI { get; set; }
            protected virtual String TEXT { get; set; }
            protected virtual String ACIKLAMA { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual String AD { get; set; }
            public virtual Decimal SAYI { get; set; }
            public virtual String TEXT { get; set; }
            public virtual String ACIKLAMA { get; set; }
        }
    }
}

