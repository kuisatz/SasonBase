using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("84bec72e-c559-4bdf-925a-54ef368d1d27")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISSTOKHAREKETDETAYLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISSTOKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "MIKTAR", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "BIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "BIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "VERGISINIFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "KDVORAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "SERVISDEPOID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "SERVISDEPORAFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "DURUMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "SERVISSTOKHAREKETID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(12, "AMIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "ABIRIMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "ABIRIMFIYAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "STOKISLEMTIPDEGER", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "SERVISSIPARISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "ISEMIRNO", typeof(String), null, DbFieldFlags.Nullable, 30, 0, 0, "")]
    [DbIndex("SERVISSTOKHAREKETDETAYLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISSTOKHAREKETDETAYLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISSTOKHAREKETDETAYLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISSTOKID { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual Decimal BIRIMID { get; set; }
            protected virtual Decimal BIRIMFIYAT { get; set; }
            protected virtual Decimal VERGISINIFID { get; set; }
            protected virtual Decimal KDVORAN { get; set; }
            protected virtual Decimal SERVISDEPOID { get; set; }
            protected virtual Decimal SERVISDEPORAFID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISSTOKHAREKETID { get; set; }
            protected virtual Decimal AMIKTAR { get; set; }
            protected virtual Decimal ABIRIMID { get; set; }
            protected virtual Decimal ABIRIMFIYAT { get; set; }
            protected virtual Decimal STOKISLEMTIPDEGER { get; set; }
            protected virtual Decimal SERVISSIPARISID { get; set; }
            protected virtual String ISEMIRNO { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISSTOKID { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual Decimal BIRIMID { get; set; }
            public virtual Decimal BIRIMFIYAT { get; set; }
            public virtual Decimal VERGISINIFID { get; set; }
            public virtual Decimal KDVORAN { get; set; }
            public virtual Decimal? SERVISDEPOID { get; set; }
            public virtual Decimal? SERVISDEPORAFID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISSTOKHAREKETID { get; set; }
            public virtual Decimal? AMIKTAR { get; set; }
            public virtual Decimal? ABIRIMID { get; set; }
            public virtual Decimal? ABIRIMFIYAT { get; set; }
            public virtual Decimal STOKISLEMTIPDEGER { get; set; }
            public virtual Decimal? SERVISSIPARISID { get; set; }
            public virtual String ISEMIRNO { get; set; }
        }
    }
}

