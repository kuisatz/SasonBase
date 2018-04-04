using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("975c76ec-51c4-4272-ab00-9754b06a4d08")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISONERISONUCLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISONERIID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "TARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(4, "KULLANICIID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(5, "ACIKLAMA", typeof(String), null, DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(6, "SERVISONERIDURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "PUAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "SERVISONERIKONUID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISONERISONUCLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISONERISONUCLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISONERISONUCLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISONERIID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual String KULLANICIID { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal SERVISONERIDURUMID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal PUAN { get; set; }
            protected virtual Decimal SERVISONERIKONUID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISONERIID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual String KULLANICIID { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal SERVISONERIDURUMID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal PUAN { get; set; }
            public virtual Decimal SERVISONERIKONUID { get; set; }
        }
    }
}

