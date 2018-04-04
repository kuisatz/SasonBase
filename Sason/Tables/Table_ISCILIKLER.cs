using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Tables
{
    [Guid("0aa5d271-6403-4ea6-a868-a0897abb0173")]
    [DbTableInfoAttribute(TableTypes.Table, "ISCILIKLER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "ISCILIKARACSINIFID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "ISCILIKARACVARYANTID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "ISCILIKNESNEID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "ISCILIKUYGULAMAID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "ISCILIKKONUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "ISCILIKMONTAJDURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(8, "ISCILIKFAALIYETID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(9, "ISCILIKTIPID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(10, "MIKTAR", typeof(String), null, DbFieldFlags.None, 4, 0, 0, "")]
    [DbField(11, "DTARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(12, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(13, "AKSIYON", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("ISCILIKLER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ISCILIKLER_IDX01", DbIndexType.Index, DbIndexFlags.None, new string[] {"ISCILIKARACSINIFID"})]
    [DbIndex("ISCILIKLER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"ISCILIKARACSINIFID","ISCILIKARACVARYANTID","ISCILIKNESNEID","ISCILIKUYGULAMAID","ISCILIKKONUMID","ISCILIKMONTAJDURUMID","ISCILIKFAALIYETID","ISCILIKTIPID"})]
    public abstract class Table_ISCILIKLER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ISCILIKLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal ISCILIKARACSINIFID { get; set; }
            protected virtual Decimal ISCILIKARACVARYANTID { get; set; }
            protected virtual Decimal ISCILIKNESNEID { get; set; }
            protected virtual Decimal ISCILIKUYGULAMAID { get; set; }
            protected virtual Decimal ISCILIKKONUMID { get; set; }
            protected virtual Decimal ISCILIKMONTAJDURUMID { get; set; }
            protected virtual Decimal ISCILIKFAALIYETID { get; set; }
            protected virtual Decimal ISCILIKTIPID { get; set; }
            protected virtual String MIKTAR { get; set; }
            protected virtual DateTime DTARIH { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual Decimal AKSIYON { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal ISCILIKARACSINIFID { get; set; }
            public virtual Decimal ISCILIKARACVARYANTID { get; set; }
            public virtual Decimal ISCILIKNESNEID { get; set; }
            public virtual Decimal ISCILIKUYGULAMAID { get; set; }
            public virtual Decimal ISCILIKKONUMID { get; set; }
            public virtual Decimal ISCILIKMONTAJDURUMID { get; set; }
            public virtual Decimal ISCILIKFAALIYETID { get; set; }
            public virtual Decimal ISCILIKTIPID { get; set; }
            public virtual String MIKTAR { get; set; }
            public virtual DateTime DTARIH { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual Decimal AKSIYON { get; set; }
        }
    }
}

