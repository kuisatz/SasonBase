using System;
using System.Runtime.InteropServices;
using Antibiotic.Database.Row;
using Antibiotic.Database.Field;
using Antibiotic.Database.Index;
using Antibiotic.Database.Table;
using Antibiotic.Database.Connectors;

namespace SasonBase.Sason.Views
{
    [Guid("43c85b03-36e6-4370-9c91-6e0152948aaa")]
    [DbTableInfoAttribute(TableTypes.View, "VX_VIS_VEHICLEMASTER", "Sason.Tables", "Yok")]
    [DbField(1, "ESAARACID", typeof(Decimal), null, DbFieldFlags.None, 22, 0, 0, "")]
    [DbField(2, "EQUIPNUM", typeof(String), null, DbFieldFlags.Nullable, 18, 0, 0, "")]
    [DbField(3, "COMPANYCODE", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(4, "PLANT", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(5, "VIN", typeof(String), null, DbFieldFlags.Nullable, 17, 0, 0, "")]
    [DbField(6, "VEHICLENUM", typeof(String), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(7, "MODELNUM", typeof(String), null, DbFieldFlags.Nullable, 30, 0, 0, "")]
    [DbField(8, "VEHICLEMANUF", typeof(String), null, DbFieldFlags.Nullable, 2, 0, 0, "")]
    [DbField(9, "VARIANT", typeof(String), null, DbFieldFlags.Nullable, 5, 0, 0, "")]
    [DbField(10, "VARIANTTYPE", typeof(String), null, DbFieldFlags.Nullable, 5, 0, 0, "")]
    [DbField(11, "VARIANT1", typeof(String), null, DbFieldFlags.Nullable, 5, 0, 0, "")]
    [DbField(12, "CUSTNUM1", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(13, "DEBITORNUMHOLDER", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(14, "CUSTNUM", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(15, "EXWORKSDATE", typeof(String), null, DbFieldFlags.Nullable, 8, 0, 0, "")]
    [DbField(16, "IMPORTDATE", typeof(String), null, DbFieldFlags.Nullable, 8, 0, 0, "")]
    [DbField(17, "CONSTRUCTDATE", typeof(String), null, DbFieldFlags.Nullable, 8, 0, 0, "")]
    [DbField(18, "DEALERDELIVERYDATE", typeof(String), null, DbFieldFlags.Nullable, 8, 0, 0, "")]
    [DbField(19, "FIRSTREGDATE", typeof(String), null, DbFieldFlags.Nullable, 8, 0, 0, "")]
    [DbField(20, "VEHICLEREGDATE", typeof(String), null, DbFieldFlags.Nullable, 8, 0, 0, "")]
    [DbField(21, "COUNTRYKEY", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(22, "REGNUMBER", typeof(String), null, DbFieldFlags.Nullable, 15, 0, 0, "")]
    [DbField(23, "PRODCODE", typeof(String), null, DbFieldFlags.Nullable, 2, 0, 0, "")]
    [DbField(24, "VEHICLECARDNUMBER", typeof(String), null, DbFieldFlags.Nullable, 8, 0, 0, "")]
    [DbField(25, "VEHICLECARDDATE", typeof(String), null, DbFieldFlags.Nullable, 8, 0, 0, "")]
    [DbField(26, "VEHICLE_ID", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(27, "VOLUMEDATE", typeof(String), null, DbFieldFlags.Nullable, 8, 0, 0, "")]
    [DbField(28, "LASTVISITDATE", typeof(String), null, DbFieldFlags.Nullable, 8, 0, 0, "")]
    [DbField(29, "PLANTHEADQUARTERS", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(30, "VEHICLEORDERNUM", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(31, "POLICEINDICATOR", typeof(String), null, DbFieldFlags.Nullable, 1, 0, 0, "")]
    [DbField(32, "WHEELSTRACK", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(33, "OVERHANG", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(34, "TOTALWEIGHTHOMO", typeof(String), null, DbFieldFlags.Nullable, 6, 0, 0, "")]
    [DbField(35, "TRAINTOTALWEIGHT", typeof(String), null, DbFieldFlags.Nullable, 5, 0, 0, "")]
    [DbField(36, "UNLADENWEIGHT", typeof(String), null, DbFieldFlags.Nullable, 6, 0, 0, "")]
    [DbField(37, "VEHICLEHEIGHT", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(38, "HOMOLNUM", typeof(String), null, DbFieldFlags.Nullable, 30, 0, 0, "")]
    [DbField(39, "KEYSNUM", typeof(String), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(40, "DOORKEYNUM", typeof(String), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(41, "REIFGR", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(42, "AXISRATIO1", typeof(String), null, DbFieldFlags.Nullable, 2, 0, 0, "")]
    [DbField(43, "AXISRATIO2", typeof(String), null, DbFieldFlags.Nullable, 2, 0, 0, "")]
    [DbField(44, "ACHSUEBP", typeof(String), null, DbFieldFlags.Nullable, 6, 0, 0, "")]
    [DbField(45, "ACHSUEBG", typeof(String), null, DbFieldFlags.Nullable, 6, 0, 0, "")]
    [DbField(46, "SUSPENSION", typeof(String), null, DbFieldFlags.Nullable, 2, 0, 0, "")]
    [DbField(47, "PINRADIOCODE", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(48, "SERVICECARDNUM", typeof(String), null, DbFieldFlags.Nullable, 17, 0, 0, "")]
    [DbField(49, "DKVCARDNUM", typeof(String), null, DbFieldFlags.Nullable, 17, 0, 0, "")]
    [DbField(50, "GGVSINDICATOR", typeof(String), null, DbFieldFlags.Nullable, 1, 0, 0, "")]
    [DbField(51, "KFZGMM", typeof(String), null, DbFieldFlags.Nullable, 15, 0, 0, "")]
    [DbField(52, "VEHICLEDES", typeof(String), null, DbFieldFlags.Nullable, 5, 0, 0, "")]
    [DbField(53, "VEHICLEKM", typeof(String), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(54, "POSSIBLEPRODINDICATOR", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(55, "ASSETMANUF", typeof(String), null, DbFieldFlags.Nullable, 30, 0, 0, "")]
    [DbField(56, "UNITWARRANTY", typeof(String), null, DbFieldFlags.Nullable, 8, 0, 0, "")]
    [DbField(57, "VEHICLEID", typeof(String), null, DbFieldFlags.Nullable, 18, 0, 0, "")]
    [DbField(58, "ANZACHS", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(59, "ANZLACHS", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(60, "ANZGACHS", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(61, "STANDORT", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(62, "FELGGR", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(63, "FEINSATZ", typeof(String), null, DbFieldFlags.Nullable, 20, 0, 0, "")]
    [DbField(64, "REIFANZ", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(65, "REIART", typeof(String), null, DbFieldFlags.Nullable, 15, 0, 0, "")]
    [DbField(66, "ANZSITZPL", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(67, "ANZSITZP2", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(68, "ANZSTEHPL", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(69, "ANZSTEHP2", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(70, "HUBRAUM", typeof(String), null, DbFieldFlags.Nullable, 5, 0, 0, "")]
    [DbField(71, "LEISTUNG", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(72, "MOTORLPS", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(73, "BEZEICANLASSER", typeof(String), null, DbFieldFlags.Nullable, 36, 0, 0, "")]
    [DbField(74, "EDCNR", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(75, "EPUMPE", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(76, "EPUMPEFO", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(77, "FESTBRDR", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(78, "KIPPERPUMP", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(79, "KOLBEN", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(80, "KURBWELLE", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(81, "LADEGRP", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(82, "LENKPNR", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(83, "LENKPTYP", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(84, "LICHTMASCH", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(85, "SCHLNR1", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(86, "SCHLNR2", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(87, "SCHLNR3", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(88, "ZUHEIZNR", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(89, "ZUHEIZTY", typeof(String), null, DbFieldFlags.Nullable, 12, 0, 0, "")]
    [DbField(90, "DATARECNEWOBJ", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(91, "LASTUPDATEDATAREC", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(92, "LASTCHANGEDATAREC", typeof(String), null, DbFieldFlags.Nullable, 8, 0, 0, "")]
    [DbField(93, "VEHICLEDESCAVIS", typeof(String), null, DbFieldFlags.Nullable, 6, 0, 0, "")]
    [DbField(94, "TYPE", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(95, "SALESOFF", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(96, "VEHICLETYPE", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(97, "MOTBR", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(98, "RADFORMEL", typeof(String), null, DbFieldFlags.Nullable, 8, 0, 0, "")]
    [DbField(99, "SCHADSTKL", typeof(String), null, DbFieldFlags.Nullable, 6, 0, 0, "")]
    [DbField(100, "GEWINT", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(101, "KZMOD", typeof(String), null, DbFieldFlags.Nullable, 1, 0, 0, "")]
    [DbField(102, "WTYSTARTKM", typeof(String), null, DbFieldFlags.Nullable, 7, 0, 0, "")]
    [DbField(103, "WTYSTARTDATE", typeof(String), null, DbFieldFlags.Nullable, 8, 0, 0, "")]
    [DbField(104, "ETAGEMOD", typeof(String), null, DbFieldFlags.Nullable, 4, 0, 0, "")]
    [DbField(105, "UOM", typeof(String), null, DbFieldFlags.Nullable, 3, 0, 0, "")]
    [DbField(106, "TRAILERDESC", typeof(String), null, DbFieldFlags.Nullable, 6, 0, 0, "")]
    [DbField(107, "HOMEDEALER", typeof(String), null, DbFieldFlags.Nullable, 15, 0, 0, "")]
    [DbField(108, "FACODE", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(109, "CABTYP", typeof(String), null, DbFieldFlags.Nullable, 10, 0, 0, "")]
    [DbField(110, "WGETSACHNR", typeof(String), null, DbFieldFlags.Nullable, 11, 0, 0, "")]
    [DbField(111, "LENKTYP", typeof(String), null, DbFieldFlags.Nullable, 1, 0, 0, "")]
    [DbField(112, "BRCODE", typeof(String), null, DbFieldFlags.Nullable, 5, 0, 0, "")]
    public abstract partial class View_VX_VIS_VEHICLEMASTER : SasonDbView
    {
        [Serializable()]
        [DbTableType(typeof(View_VX_VIS_VEHICLEMASTER))]
        public abstract class RawItem : ItemRawModel
        {
        }
        [Serializable()]
        public abstract class ProtectedItem : RawItem
        {
            protected virtual Decimal ESAARACID { get; set; }
            protected virtual String EQUIPNUM { get; set; }
            protected virtual String COMPANYCODE { get; set; }
            protected virtual String PLANT { get; set; }
            protected virtual String VIN { get; set; }
            protected virtual String VEHICLENUM { get; set; }
            protected virtual String MODELNUM { get; set; }
            protected virtual String VEHICLEMANUF { get; set; }
            protected virtual String VARIANT { get; set; }
            protected virtual String VARIANTTYPE { get; set; }
            protected virtual String VARIANT1 { get; set; }
            protected virtual String CUSTNUM1 { get; set; }
            protected virtual String DEBITORNUMHOLDER { get; set; }
            protected virtual String CUSTNUM { get; set; }
            protected virtual String EXWORKSDATE { get; set; }
            protected virtual String IMPORTDATE { get; set; }
            protected virtual String CONSTRUCTDATE { get; set; }
            protected virtual String DEALERDELIVERYDATE { get; set; }
            protected virtual String FIRSTREGDATE { get; set; }
            protected virtual String VEHICLEREGDATE { get; set; }
            protected virtual String COUNTRYKEY { get; set; }
            protected virtual String REGNUMBER { get; set; }
            protected virtual String PRODCODE { get; set; }
            protected virtual String VEHICLECARDNUMBER { get; set; }
            protected virtual String VEHICLECARDDATE { get; set; }
            protected virtual String VEHICLE_ID { get; set; }
            protected virtual String VOLUMEDATE { get; set; }
            protected virtual String LASTVISITDATE { get; set; }
            protected virtual String PLANTHEADQUARTERS { get; set; }
            protected virtual String VEHICLEORDERNUM { get; set; }
            protected virtual String POLICEINDICATOR { get; set; }
            protected virtual String WHEELSTRACK { get; set; }
            protected virtual String OVERHANG { get; set; }
            protected virtual String TOTALWEIGHTHOMO { get; set; }
            protected virtual String TRAINTOTALWEIGHT { get; set; }
            protected virtual String UNLADENWEIGHT { get; set; }
            protected virtual String VEHICLEHEIGHT { get; set; }
            protected virtual String HOMOLNUM { get; set; }
            protected virtual String KEYSNUM { get; set; }
            protected virtual String DOORKEYNUM { get; set; }
            protected virtual String REIFGR { get; set; }
            protected virtual String AXISRATIO1 { get; set; }
            protected virtual String AXISRATIO2 { get; set; }
            protected virtual String ACHSUEBP { get; set; }
            protected virtual String ACHSUEBG { get; set; }
            protected virtual String SUSPENSION { get; set; }
            protected virtual String PINRADIOCODE { get; set; }
            protected virtual String SERVICECARDNUM { get; set; }
            protected virtual String DKVCARDNUM { get; set; }
            protected virtual String GGVSINDICATOR { get; set; }
            protected virtual String KFZGMM { get; set; }
            protected virtual String VEHICLEDES { get; set; }
            protected virtual String VEHICLEKM { get; set; }
            protected virtual String POSSIBLEPRODINDICATOR { get; set; }
            protected virtual String ASSETMANUF { get; set; }
            protected virtual String UNITWARRANTY { get; set; }
            protected virtual String VEHICLEID { get; set; }
            protected virtual String ANZACHS { get; set; }
            protected virtual String ANZLACHS { get; set; }
            protected virtual String ANZGACHS { get; set; }
            protected virtual String STANDORT { get; set; }
            protected virtual String FELGGR { get; set; }
            protected virtual String FEINSATZ { get; set; }
            protected virtual String REIFANZ { get; set; }
            protected virtual String REIART { get; set; }
            protected virtual String ANZSITZPL { get; set; }
            protected virtual String ANZSITZP2 { get; set; }
            protected virtual String ANZSTEHPL { get; set; }
            protected virtual String ANZSTEHP2 { get; set; }
            protected virtual String HUBRAUM { get; set; }
            protected virtual String LEISTUNG { get; set; }
            protected virtual String MOTORLPS { get; set; }
            protected virtual String BEZEICANLASSER { get; set; }
            protected virtual String EDCNR { get; set; }
            protected virtual String EPUMPE { get; set; }
            protected virtual String EPUMPEFO { get; set; }
            protected virtual String FESTBRDR { get; set; }
            protected virtual String KIPPERPUMP { get; set; }
            protected virtual String KOLBEN { get; set; }
            protected virtual String KURBWELLE { get; set; }
            protected virtual String LADEGRP { get; set; }
            protected virtual String LENKPNR { get; set; }
            protected virtual String LENKPTYP { get; set; }
            protected virtual String LICHTMASCH { get; set; }
            protected virtual String SCHLNR1 { get; set; }
            protected virtual String SCHLNR2 { get; set; }
            protected virtual String SCHLNR3 { get; set; }
            protected virtual String ZUHEIZNR { get; set; }
            protected virtual String ZUHEIZTY { get; set; }
            protected virtual String DATARECNEWOBJ { get; set; }
            protected virtual String LASTUPDATEDATAREC { get; set; }
            protected virtual String LASTCHANGEDATAREC { get; set; }
            protected virtual String VEHICLEDESCAVIS { get; set; }
            protected virtual String TYPE { get; set; }
            protected virtual String SALESOFF { get; set; }
            protected virtual String VEHICLETYPE { get; set; }
            protected virtual String MOTBR { get; set; }
            protected virtual String RADFORMEL { get; set; }
            protected virtual String SCHADSTKL { get; set; }
            protected virtual String GEWINT { get; set; }
            protected virtual String KZMOD { get; set; }
            protected virtual String WTYSTARTKM { get; set; }
            protected virtual String WTYSTARTDATE { get; set; }
            protected virtual String ETAGEMOD { get; set; }
            protected virtual String UOM { get; set; }
            protected virtual String TRAILERDESC { get; set; }
            protected virtual String HOMEDEALER { get; set; }
            protected virtual String FACODE { get; set; }
            protected virtual String CABTYP { get; set; }
            protected virtual String WGETSACHNR { get; set; }
            protected virtual String LENKTYP { get; set; }
            protected virtual String BRCODE { get; set; }
        }
        [Serializable()]
        public abstract class PublicItem : RawItem
        {
            public virtual Decimal ESAARACID { get; set; }
            public virtual String EQUIPNUM { get; set; }
            public virtual String COMPANYCODE { get; set; }
            public virtual String PLANT { get; set; }
            public virtual String VIN { get; set; }
            public virtual String VEHICLENUM { get; set; }
            public virtual String MODELNUM { get; set; }
            public virtual String VEHICLEMANUF { get; set; }
            public virtual String VARIANT { get; set; }
            public virtual String VARIANTTYPE { get; set; }
            public virtual String VARIANT1 { get; set; }
            public virtual String CUSTNUM1 { get; set; }
            public virtual String DEBITORNUMHOLDER { get; set; }
            public virtual String CUSTNUM { get; set; }
            public virtual String EXWORKSDATE { get; set; }
            public virtual String IMPORTDATE { get; set; }
            public virtual String CONSTRUCTDATE { get; set; }
            public virtual String DEALERDELIVERYDATE { get; set; }
            public virtual String FIRSTREGDATE { get; set; }
            public virtual String VEHICLEREGDATE { get; set; }
            public virtual String COUNTRYKEY { get; set; }
            public virtual String REGNUMBER { get; set; }
            public virtual String PRODCODE { get; set; }
            public virtual String VEHICLECARDNUMBER { get; set; }
            public virtual String VEHICLECARDDATE { get; set; }
            public virtual String VEHICLE_ID { get; set; }
            public virtual String VOLUMEDATE { get; set; }
            public virtual String LASTVISITDATE { get; set; }
            public virtual String PLANTHEADQUARTERS { get; set; }
            public virtual String VEHICLEORDERNUM { get; set; }
            public virtual String POLICEINDICATOR { get; set; }
            public virtual String WHEELSTRACK { get; set; }
            public virtual String OVERHANG { get; set; }
            public virtual String TOTALWEIGHTHOMO { get; set; }
            public virtual String TRAINTOTALWEIGHT { get; set; }
            public virtual String UNLADENWEIGHT { get; set; }
            public virtual String VEHICLEHEIGHT { get; set; }
            public virtual String HOMOLNUM { get; set; }
            public virtual String KEYSNUM { get; set; }
            public virtual String DOORKEYNUM { get; set; }
            public virtual String REIFGR { get; set; }
            public virtual String AXISRATIO1 { get; set; }
            public virtual String AXISRATIO2 { get; set; }
            public virtual String ACHSUEBP { get; set; }
            public virtual String ACHSUEBG { get; set; }
            public virtual String SUSPENSION { get; set; }
            public virtual String PINRADIOCODE { get; set; }
            public virtual String SERVICECARDNUM { get; set; }
            public virtual String DKVCARDNUM { get; set; }
            public virtual String GGVSINDICATOR { get; set; }
            public virtual String KFZGMM { get; set; }
            public virtual String VEHICLEDES { get; set; }
            public virtual String VEHICLEKM { get; set; }
            public virtual String POSSIBLEPRODINDICATOR { get; set; }
            public virtual String ASSETMANUF { get; set; }
            public virtual String UNITWARRANTY { get; set; }
            public virtual String VEHICLEID { get; set; }
            public virtual String ANZACHS { get; set; }
            public virtual String ANZLACHS { get; set; }
            public virtual String ANZGACHS { get; set; }
            public virtual String STANDORT { get; set; }
            public virtual String FELGGR { get; set; }
            public virtual String FEINSATZ { get; set; }
            public virtual String REIFANZ { get; set; }
            public virtual String REIART { get; set; }
            public virtual String ANZSITZPL { get; set; }
            public virtual String ANZSITZP2 { get; set; }
            public virtual String ANZSTEHPL { get; set; }
            public virtual String ANZSTEHP2 { get; set; }
            public virtual String HUBRAUM { get; set; }
            public virtual String LEISTUNG { get; set; }
            public virtual String MOTORLPS { get; set; }
            public virtual String BEZEICANLASSER { get; set; }
            public virtual String EDCNR { get; set; }
            public virtual String EPUMPE { get; set; }
            public virtual String EPUMPEFO { get; set; }
            public virtual String FESTBRDR { get; set; }
            public virtual String KIPPERPUMP { get; set; }
            public virtual String KOLBEN { get; set; }
            public virtual String KURBWELLE { get; set; }
            public virtual String LADEGRP { get; set; }
            public virtual String LENKPNR { get; set; }
            public virtual String LENKPTYP { get; set; }
            public virtual String LICHTMASCH { get; set; }
            public virtual String SCHLNR1 { get; set; }
            public virtual String SCHLNR2 { get; set; }
            public virtual String SCHLNR3 { get; set; }
            public virtual String ZUHEIZNR { get; set; }
            public virtual String ZUHEIZTY { get; set; }
            public virtual String DATARECNEWOBJ { get; set; }
            public virtual String LASTUPDATEDATAREC { get; set; }
            public virtual String LASTCHANGEDATAREC { get; set; }
            public virtual String VEHICLEDESCAVIS { get; set; }
            public virtual String TYPE { get; set; }
            public virtual String SALESOFF { get; set; }
            public virtual String VEHICLETYPE { get; set; }
            public virtual String MOTBR { get; set; }
            public virtual String RADFORMEL { get; set; }
            public virtual String SCHADSTKL { get; set; }
            public virtual String GEWINT { get; set; }
            public virtual String KZMOD { get; set; }
            public virtual String WTYSTARTKM { get; set; }
            public virtual String WTYSTARTDATE { get; set; }
            public virtual String ETAGEMOD { get; set; }
            public virtual String UOM { get; set; }
            public virtual String TRAILERDESC { get; set; }
            public virtual String HOMEDEALER { get; set; }
            public virtual String FACODE { get; set; }
            public virtual String CABTYP { get; set; }
            public virtual String WGETSACHNR { get; set; }
            public virtual String LENKTYP { get; set; }
            public virtual String BRCODE { get; set; }
        }
    }
}

