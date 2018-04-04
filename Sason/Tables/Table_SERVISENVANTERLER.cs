using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("bd7af4a5-d19d-4498-8cfb-f3db01258cf0")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISENVANTERLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(3, "SERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "DURUMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "SERVISSTOKHAREKETID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "TARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(7, "KULLANICIID", typeof(String), null, DbFieldFlags.Nullable, 40, 0, 0, "")]
    [DbField(8, "IPTALACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbIndex("SERVISENVANTERLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISENVANTERLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISENVANTERLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISSTOKHAREKETID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual String KULLANICIID { get; set; }
            protected virtual String IPTALACIKLAMA { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISSTOKHAREKETID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual String KULLANICIID { get; set; }
            public virtual String IPTALACIKLAMA { get; set; }
        }
    }
}

