using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("c677ffd3-feb6-435c-8333-552c9c4d5560")]
    [DbTableInfoAttribute(TableTypes.Table, "MALZEMEGRUPINDIRIMLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "MALZEMEGRUPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "BASTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(4, "BITTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(5, "INDIRIMORAN", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("MALZEMEGRUPINDIRIMLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("MALZEMEGRUPINDIRIMLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"MALZEMEGRUPID"})]
    public abstract class Table_MALZEMEGRUPINDIRIMLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_MALZEMEGRUPINDIRIMLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal MALZEMEGRUPID { get; set; }
            protected virtual DateTime BASTARIH { get; set; }
            protected virtual DateTime BITTARIH { get; set; }
            protected virtual Decimal INDIRIMORAN { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal MALZEMEGRUPID { get; set; }
            public virtual DateTime BASTARIH { get; set; }
            public virtual DateTime BITTARIH { get; set; }
            public virtual Decimal INDIRIMORAN { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }
}

