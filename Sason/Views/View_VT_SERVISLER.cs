using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("b89e21cb-07f0-415c-8613-577b10398ee9")]
    [DbTableInfoAttribute(TableTypes.View, "VT_SERVISLER", "Sason.Tables", "Yok")]
    [DbField(1, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "ISORTAKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ISORTAKAD", typeof(String), null, DbFieldFlags.None, 200, 0, 0, "")]
    [DbField(4, "PARTS2BKULLANICIAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(5, "VARLIKAD", typeof(String), null, DbFieldFlags.None, 200, 0, 0, "")]
    [DbField(6, "VERGINO", typeof(String), null, DbFieldFlags.Nullable, 11, 0, 0, "")]
    [DbField(7, "VARLIKTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "VARLIKTIPAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(9, "VERGIDAIREID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "VERGIDAIREAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(11, "VERGIDAIREILAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(12, "EBAFIRMAID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(13, "EBAFIRMAAD", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.Unicode, 500, 0, 0, "")]
    [DbField(14, "PARTS2BPAROLA", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(15, "ENVANTERPERIYODID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "ENVANTERPERIYODAD", typeof(String), null, DbFieldFlags.Nullable, 0, 0, 0, "")]
    [DbField(17, "GOKULLANICIAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(18, "GOPAROLA", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(19, "YPSID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(20, "YPSAD", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.Unicode, 202, 0, 0, "")]
    [DbField(21, "GSID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(22, "GSAD", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.Unicode, 202, 0, 0, "")]
    [DbField(23, "TBSID", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(24, "TBSAD", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.Unicode, 202, 0, 0, "")]
    [DbField(25, "DBSLIMITID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(26, "DBSLIMITAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(27, "ESAPARAMETREID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(28, "PARTNERCODE", typeof(String), null, DbFieldFlags.None, 4, 0, 0, "")]
    [DbField(29, "USERID", typeof(String), null, DbFieldFlags.None, 12, 0, 0, "")]
    [DbField(30, "USERNAME", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(31, "PASSWORD", typeof(String), null, DbFieldFlags.Nullable, 15, 0, 0, "")]
    [DbField(32, "CUSTOMERNUM_WTY", typeof(String), null, DbFieldFlags.None, 9, 0, 0, "")]
    [DbField(33, "CUSTOMERNUM_PART", typeof(String), null, DbFieldFlags.None, 10, 0, 0, "")]
    [DbField(34, "DEBITOR", typeof(String), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(35, "VENDOR", typeof(String), null, DbFieldFlags.None, 9, 0, 0, "")]
    [DbField(36, "SERVISESAPARAMETREID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(37, "ESASISTEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(38, "ADRESID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(39, "ADRES", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(40, "ULKEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(41, "ULKEAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(42, "ILID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(43, "ILAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(44, "ILCEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(45, "ILCEAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(46, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(47, "DURUMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(48, "DILKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(49, "SAYIMDURUM", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    public abstract partial class View_VT_SERVISLER : SasonDbView
    {
        [Serializable()]
        [DbTableType(typeof(View_VT_SERVISLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal ISORTAKID { get; set; }
            protected virtual String ISORTAKAD { get; set; }
            protected virtual String PARTS2BKULLANICIAD { get; set; }
            protected virtual String VARLIKAD { get; set; }
            protected virtual String VERGINO { get; set; }
            protected virtual Decimal VARLIKTIPID { get; set; }
            protected virtual String VARLIKTIPAD { get; set; }
            protected virtual Decimal VERGIDAIREID { get; set; }
            protected virtual String VERGIDAIREAD { get; set; }
            protected virtual String VERGIDAIREILAD { get; set; }
            protected virtual String EBAFIRMAID { get; set; }
            protected virtual String EBAFIRMAAD { get; set; }
            protected virtual String PARTS2BPAROLA { get; set; }
            protected virtual Decimal ENVANTERPERIYODID { get; set; }
            protected virtual String ENVANTERPERIYODAD { get; set; }
            protected virtual String GOKULLANICIAD { get; set; }
            protected virtual String GOPAROLA { get; set; }
            protected virtual String YPSID { get; set; }
            protected virtual String YPSAD { get; set; }
            protected virtual String GSID { get; set; }
            protected virtual String GSAD { get; set; }
            protected virtual String TBSID { get; set; }
            protected virtual String TBSAD { get; set; }
            protected virtual Decimal DBSLIMITID { get; set; }
            protected virtual String DBSLIMITAD { get; set; }
            protected virtual Decimal ESAPARAMETREID { get; set; }
            protected virtual String PARTNERCODE { get; set; }
            protected virtual String USERID { get; set; }
            protected virtual String USERNAME { get; set; }
            protected virtual String PASSWORD { get; set; }
            protected virtual String CUSTOMERNUM_WTY { get; set; }
            protected virtual String CUSTOMERNUM_PART { get; set; }
            protected virtual String DEBITOR { get; set; }
            protected virtual String VENDOR { get; set; }
            protected virtual Decimal SERVISESAPARAMETREID { get; set; }
            protected virtual Decimal ESASISTEMID { get; set; }
            protected virtual Decimal ADRESID { get; set; }
            protected virtual String ADRES { get; set; }
            protected virtual Decimal ULKEID { get; set; }
            protected virtual String ULKEAD { get; set; }
            protected virtual Decimal ILID { get; set; }
            protected virtual String ILAD { get; set; }
            protected virtual Decimal ILCEID { get; set; }
            protected virtual String ILCEAD { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual String DURUMAD { get; set; }
            protected virtual String DILKOD { get; set; }
            protected virtual Decimal SAYIMDURUM { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal ISORTAKID { get; set; }
            public virtual String ISORTAKAD { get; set; }
            public virtual String PARTS2BKULLANICIAD { get; set; }
            public virtual String VARLIKAD { get; set; }
            public virtual String VERGINO { get; set; }
            public virtual Decimal VARLIKTIPID { get; set; }
            public virtual String VARLIKTIPAD { get; set; }
            public virtual Decimal VERGIDAIREID { get; set; }
            public virtual String VERGIDAIREAD { get; set; }
            public virtual String VERGIDAIREILAD { get; set; }
            public virtual String EBAFIRMAID { get; set; }
            public virtual String EBAFIRMAAD { get; set; }
            public virtual String PARTS2BPAROLA { get; set; }
            public virtual Decimal ENVANTERPERIYODID { get; set; }
            public virtual String ENVANTERPERIYODAD { get; set; }
            public virtual String GOKULLANICIAD { get; set; }
            public virtual String GOPAROLA { get; set; }
            public virtual String YPSID { get; set; }
            public virtual String YPSAD { get; set; }
            public virtual String GSID { get; set; }
            public virtual String GSAD { get; set; }
            public virtual String TBSID { get; set; }
            public virtual String TBSAD { get; set; }
            public virtual Decimal DBSLIMITID { get; set; }
            public virtual String DBSLIMITAD { get; set; }
            public virtual Decimal ESAPARAMETREID { get; set; }
            public virtual String PARTNERCODE { get; set; }
            public virtual String USERID { get; set; }
            public virtual String USERNAME { get; set; }
            public virtual String PASSWORD { get; set; }
            public virtual String CUSTOMERNUM_WTY { get; set; }
            public virtual String CUSTOMERNUM_PART { get; set; }
            public virtual String DEBITOR { get; set; }
            public virtual String VENDOR { get; set; }
            public virtual Decimal SERVISESAPARAMETREID { get; set; }
            public virtual Decimal ESASISTEMID { get; set; }
            public virtual Decimal ADRESID { get; set; }
            public virtual String ADRES { get; set; }
            public virtual Decimal ULKEID { get; set; }
            public virtual String ULKEAD { get; set; }
            public virtual Decimal ILID { get; set; }
            public virtual String ILAD { get; set; }
            public virtual Decimal ILCEID { get; set; }
            public virtual String ILCEAD { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String DURUMAD { get; set; }
            public virtual String DILKOD { get; set; }
            public virtual Decimal SAYIMDURUM { get; set; }
        }
    }
}

