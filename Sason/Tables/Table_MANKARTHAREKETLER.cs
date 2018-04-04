using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("08cbe9c4-b3c1-4b8b-90e3-af0af3aa44d2")]
    [DbTableInfoAttribute(TableTypes.Table, "MANKARTHAREKETLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "MANKARTID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(3, "FATURAID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "NEREDEN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "KAZANILANPUAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 126, 0, "")]
    [DbField(6, "HARCANANPUAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 126, 0, "")]
    [DbField(7, "TARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbIndex("PK_MANKARTHAREKETLER", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("MANKARTHAREKETLER_IDX", DbIndexType.Index, DbIndexFlags.None, new string[] {"MANKARTID"})]
    public abstract class Table_MANKARTHAREKETLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_MANKARTHAREKETLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal MANKARTID { get; set; }
            protected virtual Decimal FATURAID { get; set; }
            protected virtual Decimal NEREDEN { get; set; }
            protected virtual Decimal KAZANILANPUAN { get; set; }
            protected virtual Decimal HARCANANPUAN { get; set; }
            protected virtual DateTime TARIH { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal MANKARTID { get; set; }
            public virtual Decimal FATURAID { get; set; }
            public virtual Decimal NEREDEN { get; set; }
            public virtual Decimal KAZANILANPUAN { get; set; }
            public virtual Decimal HARCANANPUAN { get; set; }
            public virtual DateTime TARIH { get; set; }
        }
    }
}

