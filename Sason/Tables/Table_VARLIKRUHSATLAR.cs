using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("cda3d0c0-4bab-46bb-a231-c37c95c5f406")]
    [DbTableInfoAttribute(TableTypes.Table, "VARLIKRUHSATLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERINO", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(3, "PLAKA", typeof(String), null, DbFieldFlags.None, 15, 0, 0, "")]
    [DbField(4, "ILKTESCILTARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(5, "TESCILSIRANO", typeof(String), null, DbFieldFlags.Nullable, 15, 0, 0, "")]
    [DbField(6, "TESCILTARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(7, "MARKASI", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(8, "TIPI", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(9, "TICARIADI", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(10, "MODELYILI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "ARACSINIFI", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(12, "CINSI", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(13, "RENGI", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(14, "MOTORNO", typeof(String), null, DbFieldFlags.Nullable, 18, 0, 0, "")]
    [DbField(15, "SASENO", typeof(String), null, DbFieldFlags.None, 17, 0, 0, "")]
    [DbField(16, "NETAGIRLIK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(17, "AZAMIYUKLUAGIRLIK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(18, "KATARAGIRLIK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "ROMORKAZAMIYUKLUAGIRLIK", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(20, "KOLTUKSAYISI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(21, "AYAKTAYOLCUSAYISI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(22, "SILINDIRHACIMI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(23, "MOTORGUCU", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(24, "YAKITCINSI", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(25, "GUCAGIRLIKORANI", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(26, "KULLANIMAMACI", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(27, "TIPONAYNO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(28, "ADRESID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(29, "VARLIKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(30, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("VARLIKRUHSATLAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("VARLIKRUHSATLAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"SERINO"})]
    public abstract class Table_VARLIKRUHSATLAR : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_VARLIKRUHSATLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String SERINO { get; set; }
            protected virtual String PLAKA { get; set; }
            protected virtual DateTime ILKTESCILTARIHI { get; set; }
            protected virtual String TESCILSIRANO { get; set; }
            protected virtual DateTime TESCILTARIHI { get; set; }
            protected virtual String MARKASI { get; set; }
            protected virtual String TIPI { get; set; }
            protected virtual String TICARIADI { get; set; }
            protected virtual Decimal MODELYILI { get; set; }
            protected virtual String ARACSINIFI { get; set; }
            protected virtual String CINSI { get; set; }
            protected virtual String RENGI { get; set; }
            protected virtual String MOTORNO { get; set; }
            protected virtual String SASENO { get; set; }
            protected virtual Decimal NETAGIRLIK { get; set; }
            protected virtual Decimal AZAMIYUKLUAGIRLIK { get; set; }
            protected virtual Decimal KATARAGIRLIK { get; set; }
            protected virtual Decimal ROMORKAZAMIYUKLUAGIRLIK { get; set; }
            protected virtual Decimal KOLTUKSAYISI { get; set; }
            protected virtual Decimal AYAKTAYOLCUSAYISI { get; set; }
            protected virtual Decimal SILINDIRHACIMI { get; set; }
            protected virtual Decimal MOTORGUCU { get; set; }
            protected virtual String YAKITCINSI { get; set; }
            protected virtual Decimal GUCAGIRLIKORANI { get; set; }
            protected virtual String KULLANIMAMACI { get; set; }
            protected virtual String TIPONAYNO { get; set; }
            protected virtual Decimal ADRESID { get; set; }
            protected virtual Decimal VARLIKID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String SERINO { get; set; }
            public virtual String PLAKA { get; set; }
            public virtual DateTime ILKTESCILTARIHI { get; set; }
            public virtual String TESCILSIRANO { get; set; }
            public virtual DateTime TESCILTARIHI { get; set; }
            public virtual String MARKASI { get; set; }
            public virtual String TIPI { get; set; }
            public virtual String TICARIADI { get; set; }
            public virtual Decimal MODELYILI { get; set; }
            public virtual String ARACSINIFI { get; set; }
            public virtual String CINSI { get; set; }
            public virtual String RENGI { get; set; }
            public virtual String MOTORNO { get; set; }
            public virtual String SASENO { get; set; }
            public virtual Decimal NETAGIRLIK { get; set; }
            public virtual Decimal AZAMIYUKLUAGIRLIK { get; set; }
            public virtual Decimal KATARAGIRLIK { get; set; }
            public virtual Decimal ROMORKAZAMIYUKLUAGIRLIK { get; set; }
            public virtual Decimal KOLTUKSAYISI { get; set; }
            public virtual Decimal AYAKTAYOLCUSAYISI { get; set; }
            public virtual Decimal SILINDIRHACIMI { get; set; }
            public virtual Decimal MOTORGUCU { get; set; }
            public virtual String YAKITCINSI { get; set; }
            public virtual Decimal GUCAGIRLIKORANI { get; set; }
            public virtual String KULLANIMAMACI { get; set; }
            public virtual String TIPONAYNO { get; set; }
            public virtual Decimal ADRESID { get; set; }
            public virtual Decimal VARLIKID { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

