using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Row;
using Antibiotic.Database.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Tables
{
    [Guid("3030F468-3B35-449F-855F-414697C69234")]
    [DbTableInfo(Antibiotic.Database.Connectors.TableTypes.Table, "TSERVISTMP", "Sason.Tables", "Temp Tablosu")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.AutoIncrement, 22, 0, 0, "AUTO")]
    [DbField(2, "GROUPKEY", typeof(String), null, DbFieldFlags.SmartTable, 50, 50, 0, "SMART_TABLE")]
    [DbField(3, "FKEY1", typeof(Decimal), null, DbFieldFlags.SmartField | DbFieldFlags.Nullable, 22, 0, 0, "SMART_FIELD")]
    [DbField(4, "FKEY2", typeof(Decimal), null, DbFieldFlags.SmartField | DbFieldFlags.Nullable, 22, 0, 0, "SMART_FIELD")]
    [DbField(5, "FKEY3", typeof(Decimal), null, DbFieldFlags.SmartField | DbFieldFlags.Nullable, 22, 0, 0, "SMART_FIELD")]
    [DbField(6, "FKEY4", typeof(Decimal), null, DbFieldFlags.SmartField | DbFieldFlags.Nullable, 22, 0, 0, "SMART_FIELD")]
    [DbField(7, "FKEY5", typeof(Decimal), null, DbFieldFlags.SmartField | DbFieldFlags.Nullable, 22, 0, 0, "SMART_FIELD")]
    [DbField(8, "FCODE", typeof(String), null, DbFieldFlags.SmartField | DbFieldFlags.Nullable, 50, 50, 0, "SMART_FIELD")]
    [DbField(9, "FTEXT1", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.Unicode, 100, 100, 0, "")]
    [DbField(10, "FTEXT2", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.Unicode, 100, 100, 0, "")]
    [DbField(11, "FDATE1", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(12, "FDATE2", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(13, "FTYPE", typeof(Int32), null, DbFieldFlags.Nullable, 4, 10, 0, "")]
    [DbField(14, "FFLAG", typeof(Int32), null, DbFieldFlags.Nullable, 4, 10, 0, "")]
    [DbField(15, "FORDER", typeof(Int32), null, DbFieldFlags.Nullable, 4, 10, 0, "")]
    [DbField(16, "FLONG1", typeof(Int64), null, DbFieldFlags.Nullable, 8, 19, 0, "")]
    [DbField(17, "FLONG2", typeof(Int64), null, DbFieldFlags.Nullable, 8, 19, 0, "")]
    [DbField(17, "FLONG3", typeof(Int64), null, DbFieldFlags.Nullable, 8, 19, 0, "")]
    [DbField(18, "FNOTE1", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize | DbFieldFlags.Unicode, 2147483646, 1073741823, 0, "")]
    [DbField(19, "FNOTE2", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize | DbFieldFlags.Unicode, 2147483646, 1073741823, 0, "")]
    [DbField(20, "FBINARY1", typeof(Byte[]), null, DbFieldFlags.Nullable, 2147483647, 2147483647, 0, "")]
    [DbIndex("PK_TSERVISTMP", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] { "ID" })]
    [DbIndex("IX_TSERVISTMP", DbIndexType.Index, DbIndexFlags.Unique, new string[] { "GROUPKEY", "FKEY1", "FKEY2", "FKEY3", "FKEY4", "FKEY5", "FCODE" })]
    public abstract class Table_TSERVISTMP : DbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_TSERVISTMP))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String GROUPKEY { get; set; }
            protected virtual Decimal FKEY1 { get; set; }
            protected virtual Decimal FKEY2 { get; set; }
            protected virtual Decimal FKEY3 { get; set; }
            protected virtual Decimal FKEY4 { get; set; }
            protected virtual Decimal FKEY5 { get; set; }
            protected virtual String FCODE { get; set; }
            protected virtual String FTEXT1 { get; set; }
            protected virtual String FTEXT2 { get; set; }
            protected virtual DateTime FDATE1 { get; set; }
            protected virtual DateTime FDATE2 { get; set; }
            protected virtual Int32 FTYPE { get; set; }
            protected virtual Int32 FFLAG { get; set; }
            protected virtual Int32 FORDER { get; set; }
            protected virtual Int64 FLONG1 { get; set; }
            protected virtual Int64 FLONG2 { get; set; }
            protected virtual Int64 FLONG3 { get; set; }
            protected virtual String FNOTE1 { get; set; }
            protected virtual String FNOTE2 { get; set; }
            protected virtual Byte[] FBINARY1 { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String GROUPKEY { get; set; }
            public virtual Decimal FKEY1 { get; set; }
            public virtual Decimal FKEY2 { get; set; }
            public virtual Decimal FKEY3 { get; set; }
            public virtual Decimal FKEY4 { get; set; }
            public virtual Decimal FKEY5 { get; set; }
            public virtual String FCODE { get; set; }
            public virtual String FTEXT1 { get; set; }
            public virtual String FTEXT2 { get; set; }
            public virtual DateTime FDATE1 { get; set; }
            public virtual DateTime FDATE2 { get; set; }
            public virtual Int32 FTYPE { get; set; }
            public virtual Int32 FFLAG { get; set; }
            public virtual Int32 FORDER { get; set; }
            public virtual Int64 FLONG1 { get; set; }
            public virtual Int64 FLONG2 { get; set; }
            public virtual Int64 FLONG3 { get; set; }
            public virtual String FNOTE1 { get; set; }
            public virtual String FNOTE2 { get; set; }
            public virtual Byte[] FBINARY1 { get; set; }
        }
    }
}