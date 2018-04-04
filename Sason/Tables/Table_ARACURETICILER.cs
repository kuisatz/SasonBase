using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;
using System.Linq;
using System.Collections.Generic;
using Antibiotic.Extensions;

namespace SasonBase.Sason.Tables
{
    [Guid("548a15f7-e20c-4092-bd88-3fdb6ca4abf9")]
    [DbTableInfoAttribute(TableTypes.Table, "ARACURETICILER", "Sason.Tables", "Yok")]
    [DbField(1, "ID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "KOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(3, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbIndex("ARACURETICILER_PK", DbIndexType.PrimaryKey, DbIndexFlags.Clustered | DbIndexFlags.Unique, new string[] {"ID"})]
    [DbIndex("ARACURETICILER_U01", DbIndexType.Index, DbIndexFlags.Unique, new string[] {"KOD"})]
    public abstract class Table_ARACURETICILER : SasonDbTable
    {
        [Serializable()]
        [DbTableType(typeof(Table_ARACURETICILER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ID { get; set; }
            protected virtual String KOD { get; set; }
            protected virtual Decimal DURUMID { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ID { get; set; }
            public virtual String KOD { get; set; }
            public virtual Decimal DURUMID { get; set; }
        }
    }




    //public class xxxx
    //{
    //    [DbTableType(typeof(Table_ARACURETICILER))]
    //    public class AracUre : ItemRawModel
    //    {
    //        [DbTargetField("ID")] public long MyId { get; set; }

    //    }


    //    public xxxx()
    //    {
    //        AracUre aracUre = R.Query<AracUre>().First(t => t.MyId == 1);

    //        var aracure2 = R.Query<AracUre>().Where(t => t.MyId.In(1, 2, 3, 4, 5)).ToList();
    //    }
    //}
}