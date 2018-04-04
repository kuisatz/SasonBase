using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptServisIsEmirIslemlerCheck : SasonBase.Sason.Tables.Table_SERVISISEMIRISLEMLER.RawItem
    {
        public Decimal ID { get; set; }
        public Decimal SERVISISEMIRID { get; set; }
    }
}
