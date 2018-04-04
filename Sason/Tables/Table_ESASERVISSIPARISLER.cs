using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("fb7ba2b7-59bf-4e6f-b050-30edfec66c9b")]
    [DbTableInfoAttribute(TableTypes.Table, "ESASERVISSIPARISLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISSIPARISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "TYPE", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(4, "RESPINDEX", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(5, "DOCNUM", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(6, "XML", typeof(String), null, DbFieldFlags.UnlimitedSize, 4000, 0, 0, "")]
    [DbField(7, "LASTUPDATE", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(8, "REQID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ESASERVISSIPARISLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ESASERVISSIPARISLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"SERVISSIPARISID","TYPE","DOCNUM","RESPINDEX"})]
    public abstract class Table_ESASERVISSIPARISLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ESASERVISSIPARISLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISSIPARISID { get; set; }
            protected virtual String TYPE { get; set; }
            protected virtual Decimal RESPINDEX { get; set; }
            protected virtual String DOCNUM { get; set; }
            protected virtual String XML { get; set; }
            protected virtual DateTime LASTUPDATE { get; set; }
            protected virtual Decimal REQID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISSIPARISID { get; set; }
            public virtual String TYPE { get; set; }
            public virtual Decimal RESPINDEX { get; set; }
            public virtual String DOCNUM { get; set; }
            public virtual String XML { get; set; }
            public virtual DateTime LASTUPDATE { get; set; }
            public virtual Decimal REQID { get; set; }
        }
    }
}

