using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("c02dae7a-5355-4c96-b083-b51b29863fd9")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISONERILER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "TARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(3, "KULLANICIID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "SERVISONERIKONUID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "ACIKLAMA", typeof(String), null, DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(6, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("SERVISONERILER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISONERILER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISONERILER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual String KULLANICIID { get; set; }
            protected virtual Decimal SERVISONERIKONUID { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual String KULLANICIID { get; set; }
            public virtual Decimal SERVISONERIKONUID { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
        }
    }
}

