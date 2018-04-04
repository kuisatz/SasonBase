using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("b0febafc-f94b-4bc4-b64a-e9a33b7dc642")]
    [DbTableInfoAttribute(TableTypes.Table, "ESAMALZEMELER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "MATERIALNO", typeof(String), null, DbFieldFlags.None, 18, 0, 0, "")]
    [DbField(3, "VALIDFROM", typeof(String), null, DbFieldFlags.None, 8, 0, 0, "")]
    [DbField(4, "VALIDTO", typeof(String), null, DbFieldFlags.None, 8, 0, 0, "")]
    [DbField(5, "CONDITIONTYPE", typeof(String), null, DbFieldFlags.None, 4, 0, 0, "")]
    [DbField(6, "CONDITIONAMOUNT", typeof(String), null, DbFieldFlags.None, 11, 0, 0, "")]
    [DbField(7, "CURRENCYCODE", typeof(String), null, DbFieldFlags.None, 3, 0, 0, "")]
    [DbField(8, "CONDITIONPRICINGUNIT", typeof(String), null, DbFieldFlags.None, 5, 0, 0, "")]
    [DbField(9, "CONDITIONUNIT", typeof(String), null, DbFieldFlags.None, 3, 0, 0, "")]
    [DbField(10, "MATERIALTEXT", typeof(String), null, DbFieldFlags.Nullable, 40, 0, 0, "")]
    [DbField(11, "MATERIALTYPE", typeof(String), null, DbFieldFlags.None, 4, 0, 0, "")]
    [DbField(12, "MATERIALGROUP", typeof(String), null, DbFieldFlags.None, 2, 0, 0, "")]
    [DbField(13, "PRODUCTHIERACHY", typeof(String), null, DbFieldFlags.Nullable, 18, 0, 0, "")]
    [DbField(14, "MATPRICINGGROUP", typeof(String), null, DbFieldFlags.Nullable, 2, 0, 0, "")]
    [DbField(15, "DEPOSITCATEGORY", typeof(String), null, DbFieldFlags.Nullable, 5, 0, 0, "")]
    [DbField(16, "MATRIXID", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(17, "BASEUNITOFMEASURE", typeof(String), null, DbFieldFlags.None, 3, 0, 0, "")]
    [DbField(18, "TAXCLASSMAT", typeof(String), null, DbFieldFlags.Nullable, 1, 0, 0, "")]
    [DbField(19, "NOMBASEUNITCONV", typeof(String), null, DbFieldFlags.Nullable, 5, 0, 0, "")]
    [DbField(20, "PREDECESSORMAT", typeof(String), null, DbFieldFlags.Nullable, 18, 0, 0, "")]
    [DbField(21, "SUPERSESSIONMAT", typeof(String), null, DbFieldFlags.Nullable, 18, 0, 0, "")]
    [DbField(22, "GROSSWEIGHT", typeof(String), null, DbFieldFlags.Nullable, 13, 0, 0, "")]
    [DbField(23, "WEIGHTUNIT", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(24, "NETWEIGHT", typeof(String), null, DbFieldFlags.Nullable, 13, 0, 0, "")]
    [DbField(25, "SALESUNIT", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(26, "MAXSTORAGEPERIOD", typeof(String), null, DbFieldFlags.Nullable, 11, 0, 0, "")]
    [DbField(27, "DELIVERYQUANTITY", typeof(String), null, DbFieldFlags.Nullable, 11, 0, 0, "")]
    [DbIndex("ESAYEDEKPARCALAR_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ESAYEDEKPARCALAR_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"MATERIALNO"})]
    public abstract class Table_ESAMALZEMELER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ESAMALZEMELER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String MATERIALNO { get; set; }
            protected virtual String VALIDFROM { get; set; }
            protected virtual String VALIDTO { get; set; }
            protected virtual String CONDITIONTYPE { get; set; }
            protected virtual String CONDITIONAMOUNT { get; set; }
            protected virtual String CURRENCYCODE { get; set; }
            protected virtual String CONDITIONPRICINGUNIT { get; set; }
            protected virtual String CONDITIONUNIT { get; set; }
            protected virtual String MATERIALTEXT { get; set; }
            protected virtual String MATERIALTYPE { get; set; }
            protected virtual String MATERIALGROUP { get; set; }
            protected virtual String PRODUCTHIERACHY { get; set; }
            protected virtual String MATPRICINGGROUP { get; set; }
            protected virtual String DEPOSITCATEGORY { get; set; }
            protected virtual String MATRIXID { get; set; }
            protected virtual String BASEUNITOFMEASURE { get; set; }
            protected virtual String TAXCLASSMAT { get; set; }
            protected virtual String NOMBASEUNITCONV { get; set; }
            protected virtual String PREDECESSORMAT { get; set; }
            protected virtual String SUPERSESSIONMAT { get; set; }
            protected virtual String GROSSWEIGHT { get; set; }
            protected virtual String WEIGHTUNIT { get; set; }
            protected virtual String NETWEIGHT { get; set; }
            protected virtual String SALESUNIT { get; set; }
            protected virtual String MAXSTORAGEPERIOD { get; set; }
            protected virtual String DELIVERYQUANTITY { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String MATERIALNO { get; set; }
            public virtual String VALIDFROM { get; set; }
            public virtual String VALIDTO { get; set; }
            public virtual String CONDITIONTYPE { get; set; }
            public virtual String CONDITIONAMOUNT { get; set; }
            public virtual String CURRENCYCODE { get; set; }
            public virtual String CONDITIONPRICINGUNIT { get; set; }
            public virtual String CONDITIONUNIT { get; set; }
            public virtual String MATERIALTEXT { get; set; }
            public virtual String MATERIALTYPE { get; set; }
            public virtual String MATERIALGROUP { get; set; }
            public virtual String PRODUCTHIERACHY { get; set; }
            public virtual String MATPRICINGGROUP { get; set; }
            public virtual String DEPOSITCATEGORY { get; set; }
            public virtual String MATRIXID { get; set; }
            public virtual String BASEUNITOFMEASURE { get; set; }
            public virtual String TAXCLASSMAT { get; set; }
            public virtual String NOMBASEUNITCONV { get; set; }
            public virtual String PREDECESSORMAT { get; set; }
            public virtual String SUPERSESSIONMAT { get; set; }
            public virtual String GROSSWEIGHT { get; set; }
            public virtual String WEIGHTUNIT { get; set; }
            public virtual String NETWEIGHT { get; set; }
            public virtual String SALESUNIT { get; set; }
            public virtual String MAXSTORAGEPERIOD { get; set; }
            public virtual String DELIVERYQUANTITY { get; set; }
        }
    }
}

