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
    [DbTableInfoAttribute(Antibiotic.Database.Connectors.TableTypes.Table, "TEKNISYENHAREKET", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.AutoIncrement, 22, 0, 0, "AUTO")]
    [DbField(2, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "SERVISTEKNISYENID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(4, "ISEMIRID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(5, "ISEMIRISLEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(6, "ISEMIRISLEMISCILIKID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(7, "GIRISTARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(8, "CIKISTARIHI", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(9, "GIRISNEDENID", typeof(Int32), null, DbFieldFlags.Nullable, 22, 10, 0, "")]
    [DbField(10, "CIKISNEDENID", typeof(Int32), null, DbFieldFlags.Nullable, 22, 10, 0, "")]
    [DbField(11, "DURUM", typeof(Int32), null, DbFieldFlags.Nullable, 22, 10, 0, "")]
    [DbField(12, "EXTGSERVISTEKNISYENID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(13, "EXTCSERVISTEKNISYENID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbIndex("PK_TEKNISYENHAREKET", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] { "ID" })]
    [DbIndex("IX_TEKNISYENHAREKET", DbIndexType.Index, DbIndexFlags.None, new string[] { "SERVISID", "SERVISTEKNISYENID", "ISEMIRID", "ISEMIRISLEMID", "ISEMIRISLEMISCILIKID", "GIRISTARIHI", "CIKISTARIHI", "DURUM" })]
    public abstract class Table_TEKNISYENHAREKET : DbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_TEKNISYENHAREKET))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal SERVISTEKNISYENID { get; set; }
            public virtual Decimal ISEMIRID { get; set; }
            public virtual Decimal ISEMIRISLEMID { get; set; }
            public virtual Decimal ISEMIRISLEMISCILIKID { get; set; }
            public virtual DateTime GIRISTARIHI { get; set; }
            public virtual DateTime CIKISTARIHI { get; set; }
            public virtual Int32 GIRISNEDENID { get; set; }
            public virtual Int32 CIKISNEDENID { get; set; }
            public virtual Int32 DURUM { get; set; }
            public virtual Decimal EXTGSERVISTEKNISYENID { get; set; }
            public virtual Decimal EXTCSERVISTEKNISYENID { get; set; }
        }
    }
}