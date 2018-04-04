using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptMtIscilik : SasonBase.Sason.Tables.Table_MT_ISCILIKLER.RawItem
    {
        protected virtual Decimal ISCILIKID { get; set; }
        protected virtual String KOD { get; set; }
        protected virtual String DILKOD { get; set; }
    }
}
