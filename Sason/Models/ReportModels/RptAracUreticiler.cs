using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptAracUreticiler : SasonBase.Sason.Tables.Table_ARACURETICILER.RawItem
    {
        public decimal ID { get; set; }
        public string KOD { get; set; }
    }
}