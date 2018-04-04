using Antibiotic.Database.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptFatura : SasonBase.Sason.Tables.Table_FATURALAR.RawItem
    {
        protected virtual Decimal ID { get; set; }
        //protected virtual Decimal CARIKOD { get; set; }
        //protected virtual String CARIUNVAN { get; set; }
        //protected virtual String VNO { get; set; }
        //protected virtual String VERGIDAIRESI { get; set; }
        //protected virtual String ADRES { get; set; }
        //protected virtual String IL { get; set; }
        //protected virtual String ILCE { get; set; }
        //protected virtual String TELNO { get; set; }
        //protected virtual String ILGILIKISI { get; set; }
        //protected virtual String ILGILIKISITELNO { get; set; }
        //protected virtual DateTime ISLEMTARIHI { get; set; }
        //protected virtual String ACIKLAMA { get; set; }
        //protected virtual Decimal ISLEMNO { get; set; }
        //protected virtual Decimal ISLEMTIPI { get; set; }
        //protected virtual Decimal BRUTTOPLAM { get; set; }
        //protected virtual Decimal INDIRIMTOPLAM { get; set; }
        //protected virtual Decimal NETKDVTOPLAM { get; set; }
        //protected virtual Decimal NETTUTAR { get; set; }
        //protected virtual Decimal DURUMID { get; set; }
        //protected virtual Decimal SERVISID { get; set; }
        //protected virtual String ISEMIRNO { get; set; }
        //protected virtual String FATURADOSYA { get; set; }
        //protected virtual String ICMALNO { get; set; }
        //protected virtual Decimal TOPLAM { get; set; }
        //protected virtual Decimal KUR { get; set; }
        //protected virtual Decimal FATURATURID { get; set; }
        //protected virtual Decimal MANKARTKAZANILAN { get; set; }
        //protected virtual Decimal MANKARTHARCANAN { get; set; }
        [DbTargetField("FATURANO")] public String FaturaNo { get; set; }
        //protected virtual Decimal SERVISSIPARISID { get; set; }
        //protected virtual Decimal FATURAVARLIKID { get; set; }
        //protected virtual Decimal TEVKIFATTUTAR { get; set; }
        //protected virtual DateTime SONODEMETARIHI { get; set; }
        //protected virtual Decimal INETTUTAR { get; set; }
        //protected virtual Decimal MNETTUTAR { get; set; }
        //protected virtual Decimal DNETTUTAR { get; set; }
        //protected virtual String ARACTIPI { get; set; }
        //protected virtual String FATURAYIKESEN { get; set; }
        //protected virtual String TEVKIFATORAN { get; set; }
        //protected virtual String IRSALIYENO { get; set; }
        //protected virtual DateTime IRSALIYETARIHI { get; set; }
        //protected virtual Decimal EBADOCID { get; set; }
        //protected virtual Decimal TOPLAMISCEUR { get; set; }
        //protected virtual Decimal TOPLAMMLZEUR { get; set; }
        //protected virtual Decimal TOPLAMPIYASAFATEUR { get; set; }
        //protected virtual Decimal TOPLAMISLETIMEUR { get; set; }
        //protected virtual Decimal NETTUTAREUR { get; set; }
        //protected virtual Decimal KDVTUTAREUR { get; set; }
        //protected virtual Decimal TOPLAMTUTAREUR { get; set; }
        //protected virtual String ICMALALTBILGI { get; set; }
        //protected virtual String FATURANOT { get; set; }
        //protected virtual String TEVKIFATACIKLAMA { get; set; }
        //protected virtual Decimal SERVISSTOKHAREKETID { get; set; }
    }
}