using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("567ef673-b3aa-4317-86f3-88b9a42932bf")]
    [DbTableInfoAttribute(TableTypes.View, "VW_BAKIMKONTROLKALEMLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "AD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(4, "BASTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(5, "BITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(6, "BAKIMKONTROLID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "DURUMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(9, "DILID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(10, "DILKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(11, "ADLISTEALANID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(12, "ADCEVIRIID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("AutoCreatePk", DbIndexType.PrimaryKey, DbIndexFlags.Unique, new string[] {"ID"})]
    public abstract class View_VW_BAKIMKONTROLKALEMLER : SasonDbView
    {
        [Serializable()]
        [DbTableType(typeof(View_VW_BAKIMKONTROLKALEMLER))]
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
            protected virtual Decimal BAKIMKONTROLID { get; set; }
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
            public virtual Decimal BAKIMKONTROLID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String DURUMAD { get; set; }
            public virtual Decimal DILID { get; set; }
            public virtual String DILKOD { get; set; }
            public virtual Decimal ADLISTEALANID { get; set; }
            public virtual Decimal ADCEVIRIID { get; set; }
        }
    }
}

