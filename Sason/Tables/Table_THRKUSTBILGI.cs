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
    [Guid("E9B58F08-3A1D-4B17-BF53-E8836604B1A8")]
    [DbTableInfo(Antibiotic.Database.Connectors.TableTypes.Table, "THRKUSTBILGI", "Sason.Tables", "Hareket Tablosu")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.AutoIncrement, 22, 0, 0, "AUTO")]
    [DbField(2, "SERVISID", typeof(Decimal), null, DbFieldFlags.SmartField, 22, 0, 0, "")]
    [DbField(3, "ISEMIRID", typeof(Decimal), null, DbFieldFlags.SmartField, 22, 0, 0, "")]
    [DbField(4, "ISEMIRISLEMID", typeof(Decimal), null, DbFieldFlags.SmartField, 22, 0, 0, "")]
    [DbField(5, "ISEMIRISLEMISCILIKID", typeof(Decimal), null, DbFieldFlags.SmartField, 22, 0, 0, "")]
    [DbField(6, "PLANLANANSURE", typeof(Int32), null, DbFieldFlags.Nullable, 4, 10, 0, "")]
    [DbField(7, "CALISILANSURE", typeof(Int32), null, DbFieldFlags.Nullable, 4, 10, 0, "")]
    [DbField(8, "BASLANGICTARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(9, "BITISTARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(10, "DURUM", typeof(Int32), null, DbFieldFlags.Nullable, 4, 10, 0, "")]
    [DbField(11, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize | DbFieldFlags.Unicode, 2147483646, 1073741823, 0, "")]
    [DbIndex("PK_THRKUSTBILGI", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] { "ID" })]
    [DbIndex("IX_THRKUSTBILGI", DbIndexType.Index, DbIndexFlags.Unique, new string[] { "SERVISID", "ISEMIRID", "ISEMIRISLEMID", "ISEMIRISLEMISCILIKID" })]
    public abstract class Table_THRKUSTBILGI : DbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_THRKUSTBILGI))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal ISEMIRID { get; set; }
            protected virtual Decimal ISEMIRISLEMID { get; set; }
            protected virtual Decimal ISEMIRISLEMISCILIKID { get; set; }
            protected virtual Int32 PLANLANANSURE { get; set; }
            protected virtual Int32 CALISILANSURE { get; set; }
            protected virtual DateTime BASLANGICTARIHI { get; set; }
            protected virtual DateTime BITISTARIHI { get; set; }
            protected virtual Int32 DURUM { get; set; }
            protected virtual String ACIKLAMA { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal ISEMIRID { get; set; }
            public virtual Decimal ISEMIRISLEMID { get; set; }
            public virtual Decimal ISEMIRISLEMISCILIKID { get; set; }
            public virtual Int32 PLANLANANSURE { get; set; }
            public virtual Int32 CALISILANSURE { get; set; }
            public virtual DateTime BASLANGICTARIHI { get; set; }
            public virtual DateTime BITISTARIHI { get; set; }
            public virtual Int32 DURUM { get; set; }
            public virtual String ACIKLAMA { get; set; }
        }
    }
}