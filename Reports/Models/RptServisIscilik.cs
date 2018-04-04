using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Models
{
    public class RptServisIscilik : SasonBase.Sason.Tables.Table_SERVISISCILIKLER.RawItem
    {
        public Decimal ID { get; set; }
        public String KOD { get; set; }
        public Decimal SUREGUN { get; set; }
        public Decimal SURESAAT { get; set; }
        public Decimal SUREDK { get; set; }
    }
}