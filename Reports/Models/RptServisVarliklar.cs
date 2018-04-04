using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Models
{
    public class RptServisVarliklar : SasonBase.Sason.Tables.Table_SERVISVARLIKLAR.RawItem
    {
        public decimal ID { get; set; }
        public string AD { get; set; }
        public string ADRES { get; set; }
    }
}