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
    [Guid("202F77FD-04BA-49A5-B2EE-B08F5F875716")]
    [DbTableInfo(Antibiotic.Database.Connectors.TableTypes.Table, "TTEKNISYENHRK", "Sason.Tables", "Teknisyen Hareket Tablosu")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.AutoIncrement, 22, 0, 0, "AUTO")]
    [DbField(2, "THRKUSTBILGIID", typeof(Decimal), null, DbFieldFlags.SmartField, 22, 0, 0, "")]
    [DbField(3, "SERVISTEKNISYENID", typeof(Decimal), null, DbFieldFlags.SmartField, 22, 0, 0, "")]
    [DbField(4, "GIRISTARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(5, "CIKISTARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(6, "DURUM", typeof(Int32), null, DbFieldFlags.Nullable, 4, 10, 0, "")]
    [DbField(7, "GIRISNEDENID", typeof(Int32), null, DbFieldFlags.Nullable, 4, 10, 0, "")]
    [DbField(8, "CIKISNEDENID", typeof(Int32), null, DbFieldFlags.Nullable, 4, 10, 0, "")]
    [DbField(9, "FNOTE", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize | DbFieldFlags.Unicode, 2147483646, 1073741823, 0, "")]
    [DbIndex("PK_TTEKNISYENHRK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] { "ID" })]
    [DbIndex("IX_TTEKNISYENHRK", DbIndexType.Index, DbIndexFlags.None, new string[] { "THRKUSTBILGIID", "SERVISTEKNISYENID","GIRISTARIHI", "CIKISTARIHI","DURUM" })]
    public abstract class Table_TTEKNISYENHRK : DbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_TTEKNISYENHRK))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual Decimal THRKUSTBILGIID { get; set; }
            protected virtual Decimal SERVISTEKNISYENID { get; set; }
            protected virtual DateTime GIRISTARIHI { get; set; }
            protected virtual DateTime CIKISTARIHI { get; set; }
            protected virtual Int32 DURUM { get; set; }
            protected virtual Int32 GIRISNEDENID { get; set; }
            protected virtual Int32 CIKISNEDENID { get; set; }
            protected virtual String FNOTE { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal THRKUSTBILGIID { get; set; }
            public virtual Decimal SERVISTEKNISYENID { get; set; }
            public virtual DateTime GIRISTARIHI { get; set; }
            public virtual DateTime CIKISTARIHI { get; set; }
            public virtual Int32 DURUM { get; set; }
            public virtual Int32 GIRISNEDENID { get; set; }
            public virtual Int32 CIKISNEDENID { get; set; }
            public virtual String FNOTE { get; set; }
        }
    }
}