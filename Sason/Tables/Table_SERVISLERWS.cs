using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("7db61b5a-397a-43a3-a01e-287b88063eb1")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISLERWS", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(3, "WSKODU", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.Unicode, 20, 0, 0, "")]
    [DbField(4, "WSSIFRE", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.Unicode, 100, 0, 0, "")]
    [DbField(5, "SERVISADI", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.Unicode, 200, 0, 0, "")]
    [DbField(6, "BEKLEMESURESI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISLERWS_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("SERVISLERWS_UIX1", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"SERVISID"})]
    [DbIndex("SERVISLERWS_UIX2", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"WSKODU"})]
    public abstract class Table_SERVISLERWS : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISLERWS))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual String WSKODU { get; set; }
            protected virtual String WSSIFRE { get; set; }
            protected virtual String SERVISADI { get; set; }
            protected virtual Decimal BEKLEMESURESI { get; set; }

        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual String WSKODU { get; set; }
            public virtual String WSSIFRE { get; set; }
            public virtual String SERVISADI { get; set; }
            public virtual Decimal BEKLEMESURESI { get; set; }
        }
    }
}

