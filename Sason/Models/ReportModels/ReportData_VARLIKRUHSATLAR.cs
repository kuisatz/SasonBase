using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class ReportData_VARLIKRUHSATLAR : SasonBase.Sason.Tables.Table_VARLIKRUHSATLAR.RawItem
    {
        internal decimal ID { get; set; }
        public string PLAKA { get; set; }
        public string SERINO { get; set; }
        public string MOTORNO { get; set; }
        public DateTime ILKTESCILTARIHI { get; set; }
        public string SASENO { get; set; }
    }
}