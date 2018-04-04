using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("7e99d8e5-a1da-42a8-9ed0-7b878bf23d30")]
    [DbTableInfoAttribute(TableTypes.Table, "BAKIMSOZLESMELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "ARACID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "BAKIMGRUPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "VARLIKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "BAKIMSOZLESMETIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "BAKIMADEDI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "ONCEKIBAKIMADEDI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "BASTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(9, "BITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(10, "TUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "PARABIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(12, "NOTLAR", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(13, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(14, "ONCEKITUTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(15, "KULLANILAN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "KM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "SAAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "LITRE", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("BAKIMSOZLESMELER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class Table_BAKIMSOZLESMELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_BAKIMSOZLESMELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal ARACID { get; set; }
            protected virtual Decimal BAKIMGRUPID { get; set; }
            protected virtual Decimal VARLIKID { get; set; }
            protected virtual Decimal BAKIMSOZLESMETIPID { get; set; }
            protected virtual Decimal BAKIMADEDI { get; set; }
            protected virtual Decimal ONCEKIBAKIMADEDI { get; set; }
            protected virtual DateTime BASTARIH { get; set; }
            protected virtual DateTime BITTARIH { get; set; }
            protected virtual Decimal TUTAR { get; set; }
            protected virtual Decimal PARABIRIMID { get; set; }
            protected virtual String NOTLAR { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal ONCEKITUTAR { get; set; }
            protected virtual Decimal KULLANILAN { get; set; }
            protected virtual Decimal KM { get; set; }
            protected virtual Decimal SAAT { get; set; }
            protected virtual Decimal LITRE { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal ARACID { get; set; }
            public virtual Decimal BAKIMGRUPID { get; set; }
            public virtual Decimal ?VARLIKID { get; set; }
            public virtual Decimal BAKIMSOZLESMETIPID { get; set; }
            public virtual Decimal BAKIMADEDI { get; set; }
            public virtual Decimal ONCEKIBAKIMADEDI { get; set; }
            public virtual DateTime BASTARIH { get; set; }
            public virtual DateTime BITTARIH { get; set; }
            public virtual Decimal TUTAR { get; set; }
            public virtual Decimal PARABIRIMID { get; set; }
            public virtual String NOTLAR { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal ONCEKITUTAR { get; set; }
            public virtual Decimal KULLANILAN { get; set; }
            public virtual Decimal? KM { get; set; }
            public virtual Decimal? SAAT { get; set; }
            public virtual Decimal? LITRE { get; set; }
        }
    }
}

