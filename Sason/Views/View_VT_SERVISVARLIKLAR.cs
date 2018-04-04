using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("3d377ca3-9c13-4c09-bd20-655ae8ae9589")]
    [DbTableInfoAttribute(TableTypes.View, "VT_SERVISVARLIKLAR", "Sason.Tables", "Yok")]
    [DbField(1, "SERVISVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(2, "AD", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(3, "VARLIKTIPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "VARLIKTIPAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(5, "VERGINO", typeof(String), null, DbFieldFlags.Nullable, 11, 0, 0, "")]
    [DbField(6, "VERGIDAIREID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "VERGIDAIREAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(8, "VERGIDAIREILID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "VERGIDAIREILAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(10, "VARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "KVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "EBAFIRMAID", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(13, "ODEMETIPID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "ODEMETIPAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(15, "SERVISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "DILKOD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(17, "VARLIKADRES", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(18, "VARLIKULKEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(19, "VARLIKULKEIDAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(20, "VARLIKILID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(21, "VARLIKILIDAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(22, "VARLIKILCEID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(23, "VARLIKILCEIDAD", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(24, "VARLIKEFATURA", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(25, "VARLIKEFATURAADRES", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(26, "VARLIKTELEFON", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(27, "VARLIKFAX", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(28, "VARLIKEPOSTA", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    public abstract partial class View_VT_SERVISVARLIKLAR : SasonDbView
    {
        [Serializable()]
        [DbTableType(typeof(View_VT_SERVISVARLIKLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal SERVISVARLIKID { get; set; }
            protected virtual String AD { get; set; }
            protected virtual Decimal VARLIKTIPID { get; set; }
            protected virtual String VARLIKTIPAD { get; set; }
            protected virtual String VERGINO { get; set; }
            protected virtual Decimal VERGIDAIREID { get; set; }
            protected virtual String VERGIDAIREAD { get; set; }
            protected virtual Decimal VERGIDAIREILID { get; set; }
            protected virtual String VERGIDAIREILAD { get; set; }
            protected virtual Decimal VARLIKID { get; set; }
            protected virtual Decimal KVARLIKID { get; set; }
            protected virtual String EBAFIRMAID { get; set; }
            protected virtual Decimal ODEMETIPID { get; set; }
            protected virtual String ODEMETIPAD { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual String DILKOD { get; set; }
            protected virtual String VARLIKADRES { get; set; }
            protected virtual Decimal VARLIKULKEID { get; set; }
            protected virtual String VARLIKULKEIDAD { get; set; }
            protected virtual Decimal VARLIKILID { get; set; }
            protected virtual String VARLIKILIDAD { get; set; }
            protected virtual Decimal VARLIKILCEID { get; set; }
            protected virtual String VARLIKILCEIDAD { get; set; }
            protected virtual Decimal VARLIKEFATURA { get; set; }
            protected virtual String VARLIKEFATURAADRES { get; set; }
            protected virtual String VARLIKTELEFON { get; set; }
            protected virtual String VARLIKFAX { get; set; }
            protected virtual String VARLIKEPOSTA { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal SERVISVARLIKID { get; set; }
            public virtual String AD { get; set; }
            public virtual Decimal VARLIKTIPID { get; set; }
            public virtual String VARLIKTIPAD { get; set; }
            public virtual String VERGINO { get; set; }
            public virtual Decimal VERGIDAIREID { get; set; }
            public virtual String VERGIDAIREAD { get; set; }
            public virtual Decimal VERGIDAIREILID { get; set; }
            public virtual String VERGIDAIREILAD { get; set; }
            public virtual Decimal VARLIKID { get; set; }
            public virtual Decimal KVARLIKID { get; set; }
            public virtual String EBAFIRMAID { get; set; }
            public virtual Decimal ODEMETIPID { get; set; }
            public virtual String ODEMETIPAD { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual String DILKOD { get; set; }
            public virtual String VARLIKADRES { get; set; }
            public virtual Decimal VARLIKULKEID { get; set; }
            public virtual String VARLIKULKEIDAD { get; set; }
            public virtual Decimal VARLIKILID { get; set; }
            public virtual String VARLIKILIDAD { get; set; }
            public virtual Decimal VARLIKILCEID { get; set; }
            public virtual String VARLIKILCEIDAD { get; set; }
            public virtual Decimal VARLIKEFATURA { get; set; }
            public virtual String VARLIKEFATURAADRES { get; set; }
            public virtual String VARLIKTELEFON { get; set; }
            public virtual String VARLIKFAX { get; set; }
            public virtual String VARLIKEPOSTA { get; set; }
        }
    }
}

