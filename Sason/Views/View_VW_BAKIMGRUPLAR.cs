using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("8c758c5c-1ec8-4bff-8668-fc4ac790a7b4")]
    [DbTableInfoAttribute(TableTypes.View, "VW_BAKIMGRUPLAR", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "AD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(4, "BASTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(5, "BITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(6, "BAKIMTURID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "ENDEKS", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "KILOMETRE", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "SAAT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "GUN", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "BAKIMSAYISI", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(12, "BAKIMTURTOLERANS", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(14, "DURUMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(15, "DILID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(16, "DILKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(17, "ADLISTEALANID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(18, "ADCEVIRIID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("AutoCreatePk", DbIndexType.PrimaryKey, DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class View_VW_BAKIMGRUPLAR : SasonDbView
    {
        [Serializable()]
        [DbTableType(typeof(View_VW_BAKIMGRUPLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String AD { get; set; }
            protected virtual DateTime BASTARIH { get; set; }
            protected virtual DateTime BITTARIH { get; set; }
            protected virtual Decimal BAKIMTURID { get; set; }
            protected virtual Decimal ENDEKS { get; set; }
            protected virtual Decimal KILOMETRE { get; set; }
            protected virtual Decimal SAAT { get; set; }
            protected virtual Decimal GUN { get; set; }
            protected virtual Decimal BAKIMSAYISI { get; set; }
            protected virtual Decimal BAKIMTURTOLERANS { get; set; }
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
            public virtual DateTime BASTARIH { get; set; }
            public virtual DateTime BITTARIH { get; set; }
            public virtual Decimal BAKIMTURID { get; set; }
            public virtual Decimal ENDEKS { get; set; }
            public virtual Decimal KILOMETRE { get; set; }
            public virtual Decimal SAAT { get; set; }
            public virtual Decimal GUN { get; set; }
            public virtual Decimal BAKIMSAYISI { get; set; }
            public virtual Decimal BAKIMTURTOLERANS { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String DURUMAD { get; set; }
            public virtual Decimal DILID { get; set; }
            public virtual String DILKOD { get; set; }
            public virtual Decimal ADLISTEALANID { get; set; }
            public virtual Decimal ADCEVIRIID { get; set; }
        }
    }
}

