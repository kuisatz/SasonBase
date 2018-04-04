using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptTeknisyen01 : SasonBase.Sason.Tables.Table_TEKNISYENLER.RawItem
    {
        protected virtual Decimal ID { get; set; }
        //public String TCKN { get; set; }
        public String AD { get; set; }
        public String SOYAD { get; set; }
        //public DateTime DOGUMTARIH { get; set; }
        //public Decimal KANGRUPID { get; set; }
        //public Decimal AYAKKABINUMARAID { get; set; }
        //public Decimal ELBISEBEDENID { get; set; }
        //public Decimal EGITIMDUZEYID { get; set; }
        //public String KULLANICIID { get; set; }
        public Decimal DURUMID { get; set; }

        public string AdSoyad
        {
            get { return $"{AD} {SOYAD}"; }
        }
    }
}