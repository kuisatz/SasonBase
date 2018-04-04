using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("6202870c-de5f-4ba4-974e-d10ee579a23b")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISDISHIZMETALIMLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISISORTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ACIKLAMA", typeof(String), null, DbFieldFlags.None, 500, 0, 0, "")]
    [DbField(4, "TTUTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "TUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "FATURANO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(7, "PARABIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(9, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(10, "SERVISISEMIRISLEMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "SERVISISEMIRID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "FATURAID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISDISHIZMETALIMLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISDISHIZMETALIMLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISDISHIZMETALIMLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISISORTAKID { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal TTUTAR { get; set; }
            protected virtual Decimal TUTAR { get; set; }
            protected virtual String FATURANO { get; set; }
            protected virtual Decimal PARABIRIMID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal SERVISISEMIRISLEMID { get; set; }
            protected virtual Decimal SERVISISEMIRID { get; set; }
            protected virtual Decimal FATURAID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISISORTAKID { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal TTUTAR { get; set; }
            public virtual Decimal TUTAR { get; set; }
            public virtual String FATURANO { get; set; }
            public virtual Decimal PARABIRIMID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal SERVISISEMIRISLEMID { get; set; }
            public virtual Decimal SERVISISEMIRID { get; set; }
            public virtual Decimal FATURAID { get; set; }
        }
    }
}

