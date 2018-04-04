using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("98424788-d6d8-456c-8afb-e13b70fc2869")]
    [DbTableInfoAttribute(TableTypes.View, "VT_SERVISSTOKHAREKETLER", "Sason.Tables", "Yok")]
    [DbField(1, "SERVISSTOKHAREKETID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "SERVISSTOKISLEMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(3, "SERVISSTOKISLEMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(4, "TARIH", typeof(DateTime), null, DbFieldFlags.None, 7, 0, 0, "")]
    [DbField(5, "BLGNO", typeof(String), null, DbFieldFlags.Nullable, 50, 0, 0, "")]
    [DbField(6, "BLGTARIH", typeof(DateTime), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(7, "ACIKLAMA", typeof(String), null, DbFieldFlags.Nullable, 2000, 0, 0, "")]
    [DbField(8, "SERVISVARLIKAD", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(9, "SERVISVARLIKID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(10, "PARABIRIMID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(11, "PARABIRIMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(12, "VERGINO", typeof(String), null, DbFieldFlags.Nullable, 11, 0, 0, "")]
    [DbField(13, "SERVISDEPOID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(14, "SERVISDEPOAD", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(15, "SERVISDEPORAFID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(16, "SERVISDEPORAFAD", typeof(String), null, DbFieldFlags.Nullable, 200, 0, 0, "")]
    [DbField(17, "SERVISID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(18, "DURUMID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(19, "DURUMAD", typeof(String), null, DbFieldFlags.Nullable, 500, 0, 0, "")]
    [DbField(20, "DILKOD", typeof(String), null, DbFieldFlags.None, 50, 0, 0, "")]
    [DbField(21, "IRSALIYENO", typeof(String), null, DbFieldFlags.Nullable, 100, 0, 0, "")]
    [DbField(22, "SERVISSIPARISID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(23, "FATURAID", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    [DbField(24, "IRSALIYEONAY", typeof(Decimal), null, DbFieldFlags.Nullable, 22, 0, 0, "")]
    public abstract partial class View_VT_SERVISSTOKHAREKETLER : SasonDbView
    {
        [Serializable()]
        [DbTableType(typeof(View_VT_SERVISSTOKHAREKETLER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal SERVISSTOKHAREKETID { get; set; }
            protected virtual Decimal SERVISSTOKISLEMID { get; set; }
            protected virtual String SERVISSTOKISLEMAD { get; set; }
            protected virtual DateTime TARIH { get; set; }
            protected virtual String BLGNO { get; set; }
            protected virtual DateTime BLGTARIH { get; set; }
            protected virtual String ACIKLAMA { get; set; }
            protected virtual String SERVISVARLIKAD { get; set; }
            protected virtual Decimal SERVISVARLIKID { get; set; }
            protected virtual Decimal PARABIRIMID { get; set; }
            protected virtual String PARABIRIMAD { get; set; }
            protected virtual String VERGINO { get; set; }
            protected virtual Decimal SERVISDEPOID { get; set; }
            protected virtual String SERVISDEPOAD { get; set; }
            protected virtual Decimal SERVISDEPORAFID { get; set; }
            protected virtual String SERVISDEPORAFAD { get; set; }
            protected virtual Decimal SERVISID { get; set; }
            protected virtual Decimal DURUMID { get; set; }
            protected virtual String DURUMAD { get; set; }
            protected virtual String DILKOD { get; set; }
            protected virtual String IRSALIYENO { get; set; }
            protected virtual Decimal SERVISSIPARISID { get; set; }
            protected virtual Decimal FATURAID { get; set; }
            protected virtual Decimal IRSALIYEONAY { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal SERVISSTOKHAREKETID { get; set; }
            public virtual Decimal SERVISSTOKISLEMID { get; set; }
            public virtual String SERVISSTOKISLEMAD { get; set; }
            public virtual DateTime TARIH { get; set; }
            public virtual String BLGNO { get; set; }
            public virtual DateTime BLGTARIH { get; set; }
            public virtual String ACIKLAMA { get; set; }
            public virtual String SERVISVARLIKAD { get; set; }
            public virtual Decimal SERVISVARLIKID { get; set; }
            public virtual Decimal PARABIRIMID { get; set; }
            public virtual String PARABIRIMAD { get; set; }
            public virtual String VERGINO { get; set; }
            public virtual Decimal SERVISDEPOID { get; set; }
            public virtual String SERVISDEPOAD { get; set; }
            public virtual Decimal SERVISDEPORAFID { get; set; }
            public virtual String SERVISDEPORAFAD { get; set; }
            public virtual Decimal SERVISID { get; set; }
            public virtual Decimal DURUMID { get; set; }
            public virtual String DURUMAD { get; set; }
            public virtual String DILKOD { get; set; }
            public virtual String IRSALIYENO { get; set; }
            public virtual Decimal SERVISSIPARISID { get; set; }
            public virtual Decimal FATURAID { get; set; }
            public virtual Decimal IRSALIYEONAY { get; set; }
        }
    }
}

