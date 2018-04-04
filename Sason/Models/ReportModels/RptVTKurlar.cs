using Antibiotic.Database.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptVTKurlar : SasonBase.Sason.Views.View_VX_KURLAR.RawItem
    {
        protected virtual Decimal KURID { get; set; }
        protected virtual DateTime TARIH { get; set; }
        //protected virtual Decimal PARABIRIMID { get; set; }
        protected virtual String CURRENCYCODE { get; set; }
        //protected virtual Decimal CROSSORDER { get; set; }
        //protected virtual Decimal UNIT { get; set; }
        //protected virtual Decimal FOREXBUYING { get; set; }
        //protected virtual Decimal FOREXSELLING { get; set; }
        [DbTargetField("BANKNOTEBUYING")] public Decimal Alis { get; set; }
        [DbTargetField("BANKNOTESELLING")] public Decimal Satis { get; set; }
        //protected virtual Decimal CROSSRATEUSD { get; set; }
        //protected virtual Decimal CROSSRATEOTHER { get; set; }
    }
}
