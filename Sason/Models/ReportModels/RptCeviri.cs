using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptCeviri : SasonBase.Sason.Tables.Table_CEVIRILER.RawItem
    {
        protected virtual Decimal ID { get; set; }
        protected virtual Decimal LISTEALANID { get; set; }
        protected virtual Decimal DILID { get; set; }
        protected virtual Decimal ALANID { get; set; }
        internal String DEGER { get; set; }
    }
}