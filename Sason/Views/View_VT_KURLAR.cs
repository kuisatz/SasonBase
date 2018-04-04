using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("0d85cd5b-79bb-4276-828b-fe2611bacdf3")]
    [DbTableInfoAttribute(TableTypes.Table, "VT_KURLAR", "Sason.Tables", "Yok")]
    [DbField(1, "KURID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "TARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(3, "PARABIRIMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(4, "CURRENCYCODE", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(5, "CROSSORDER", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(6, "UNIT", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(7, "FOREXBUYING", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(8, "FOREXSELLING", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(9, "BANKNOTEBUYING", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "BANKNOTESELLING", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "CROSSRATEUSD", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(12, "CROSSRATEOTHER", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    public abstract partial class Table_VT_KURLAR : SasonDbTable
    {
        [Serializable]
        [DbTableType(typeof(Table_VT_KURLAR))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal KURID { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual Decimal PARABIRIMID { get; set; }
            protected virtual String CURRENCYCODE { get; set; }
            protected virtual Decimal CROSSORDER { get; set; }
            protected virtual Decimal UNIT { get; set; }
            protected virtual Decimal FOREXBUYING { get; set; }
            protected virtual Decimal FOREXSELLING { get; set; }
            protected virtual Decimal BANKNOTEBUYING { get; set; }
            protected virtual Decimal BANKNOTESELLING { get; set; }
            protected virtual Decimal CROSSRATEUSD { get; set; }
            protected virtual Decimal CROSSRATEOTHER { get; set; }
        }
        [Serializable]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal KURID { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual Decimal PARABIRIMID { get; set; }
            public virtual String CURRENCYCODE { get; set; }
            public virtual Decimal CROSSORDER { get; set; }
            public virtual Decimal UNIT { get; set; }
            public virtual Decimal FOREXBUYING { get; set; }
            public virtual Decimal FOREXSELLING { get; set; }
            public virtual Decimal BANKNOTEBUYING { get; set; }
            public virtual Decimal BANKNOTESELLING { get; set; }
            public virtual Decimal CROSSRATEUSD { get; set; }
            public virtual Decimal CROSSRATEOTHER { get; set; }
        }
    }
}
