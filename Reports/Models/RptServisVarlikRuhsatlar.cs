using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Models
{
    public class RptServisVarlikRuhsatlar : SasonBase.Sason.Tables.Table_SERVISVARLIKRUHSATLAR.RawItem
    {
        public decimal ID { get; set; }
        public string PLAKA { get; set; }
        public string SASENO { get; set; }
    }
}