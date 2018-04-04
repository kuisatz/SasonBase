using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("f908c5fb-c818-43bd-99d1-295da9f51280")]
    [DbTableInfoAttribute(TableTypes.View, "VW_SERVISISCILIKLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "AD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(4, "FIYAT", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "PARABIRIMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "SUREGUN", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "SURESAAT", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "SUREDK", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(9, "MIKTAR", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "SERVISISCILIKGRUPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(11, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(12, "DURUMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "DURUMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(14, "DILID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(15, "DILKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(16, "ADLISTEALANID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(17, "ADCEVIRIID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("AutoCreatePk", DbIndexType.PrimaryKey, DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class View_VW_SERVISISCILIKLER : SasonDbView
    {
        [Serializable()]
        [DbTableType(typeof(View_VW_SERVISISCILIKLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String AD { get; set; }
            protected virtual Decimal FIYAT { get; set; }
            protected virtual Decimal PARABIRIMID { get; set; }
            protected virtual Decimal SUREGUN { get; set; }
            protected virtual Decimal SURESAAT { get; set; }
            protected virtual Decimal SUREDK { get; set; }
            protected virtual Decimal MIKTAR { get; set; }
            protected virtual Decimal SERVISISCILIKGRUPID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual String DURUMAD { get; set; }
            protected virtual Decimal DILID { get; set; }
            protected virtual String DILKOD { get; set; }
            protected virtual Decimal ADLISTEALANID { get; set; }
            protected virtual Decimal ADCEVIRIID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual String AD { get; set; }
            public virtual Decimal FIYAT { get; set; }
            public virtual Decimal PARABIRIMID { get; set; }
            public virtual Decimal SUREGUN { get; set; }
            public virtual Decimal SURESAAT { get; set; }
            public virtual Decimal SUREDK { get; set; }
            public virtual Decimal MIKTAR { get; set; }
            public virtual Decimal SERVISISCILIKGRUPID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String DURUMAD { get; set; }
            public virtual Decimal DILID { get; set; }
            public virtual String DILKOD { get; set; }
            public virtual Decimal ADLISTEALANID { get; set; }
            public virtual Decimal ADCEVIRIID { get; set; }
        }
    }
}