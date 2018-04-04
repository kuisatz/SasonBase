using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("66b7d2a7-fdb7-4c4b-a121-d48bd85f568b")]
    [DbTableInfoAttribute(TableTypes.Table, "SERVISSTOKHAREKETLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISSTOKISLEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "TARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(4, "BLGNO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(5, "BLGTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(6, "PARABIRIMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 2000, 0, 0, "")]
    [DbField(8, "SERVISVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "SERVISDEPOID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "SERVISDEPORAFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(12, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(13, "IRSALIYENO", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(14, "SERVISGARANTINO", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(15, "SERVISSIPARISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "IRSALIYEONAY", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "FATURAID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("SERVISSTOKHAREKETLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_SERVISSTOKHAREKETLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_SERVISSTOKHAREKETLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISSTOKISLEMID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual String BLGNO { get; set; }
            protected virtual DateTime BLGTARIH { get; set; }
            protected virtual Decimal PARABIRIMID { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal SERVISVARLIKID { get; set; }
            protected virtual Decimal SERVISDEPOID { get; set; }
            protected virtual Decimal SERVISDEPORAFID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual String IRSALIYENO { get; set; }
            protected virtual String SERVISGARANTINO { get; set; }
            protected virtual Decimal SERVISSIPARISID { get; set; }
            protected virtual Decimal IRSALIYEONAY { get; set; }
            protected virtual Decimal FATURAID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISSTOKISLEMID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual String BLGNO { get; set; }
            public virtual DateTime? BLGTARIH { get; set; }
            public virtual Decimal PARABIRIMID { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal? SERVISVARLIKID { get; set; }
            public virtual Decimal? SERVISDEPOID { get; set; }
            public virtual Decimal? SERVISDEPORAFID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual String IRSALIYENO { get; set; }
            public virtual String SERVISGARANTINO { get; set; }
            public virtual Decimal? SERVISSIPARISID { get; set; }
            public virtual Decimal? IRSALIYEONAY { get; set; }
            public virtual Decimal? FATURAID { get; set; }
        }
    }
}

