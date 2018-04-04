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
    [Guid("A9BD89BB-EDFF-44EA-A76D-57AD586C8FCD")]
    [DbTableInfo(Antibiotic.Database.Connectors.TableTypes.Table, "THRKNEDEN", "Sason.Tables", "Hareket Nedenleri")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.AutoIncrement, 22, 0, 0, "AUTO")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 50, 0, "")]
    [DbField(3, "TANIM", typeof(String), null, DbFieldFlags.None, 50, 50, 0, "")]
    [DbField(4, "FORMATI", typeof(Int32), null, DbFieldFlags.Nullable, 4, 10, 0, "")]
    [DbField(5, "HAREKETTIPI", typeof(Int32), null, DbFieldFlags.Nullable, 4, 10, 0, "")]
    [DbField(6, "SIRANO", typeof(Int32), null, DbFieldFlags.Nullable, 4, 10, 0, "")]
    [DbField(7, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable | DbFieldFlags.UnlimitedSize | DbFieldFlags.Unicode, 2147483646, 1073741823, 0, "")]
    [DbField(8, "PDKS", typeof(Decimal), null, DbFieldFlags.Nullable, 22 ,0,0 , "")]
    [DbIndex("PK_THRKNEDEN", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] { "ID" })]
    [DbIndex("IX_THRKNEDEN", DbIndexType.Index, DbIndexFlags.Unique, new string[] { "KOD" })]
    public abstract class Table_THRKNEDEN : DbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_THRKNEDEN))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual String TANIM { get; set; }
            protected virtual Int32 FORMATI { get; set; }
            protected virtual Int32 HAREKETTIPI { get; set; }
            protected virtual Int32 SIRANO { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual Decimal PDKS { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual String TANIM { get; set; }
            public virtual Int32 FORMATI { get; set; }
            public virtual Int32 HAREKETTIPI { get; set; }
            public virtual Int32 SIRANO { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual Decimal PDKS { get; set; }
        }
    }
}