using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class ReportData_VW_SIPARISMALZEMELER : SasonBase.Sason.Views.View_VW_SIPARISMALZEMELER.RawItem
    {
        protected Decimal SIPARISID { get; set; }
        protected Decimal TURID { get; set; }
        protected Decimal SERVISSIPARISMLZID { get; set; }

        public String KOD { get; set; }
        public String ACIKLAMA { get; set; }
        public Decimal MIKTAR { get; set; }
        public String BIRIMAD { get; set; }
        public Decimal BIRIMFIYAT { get; set; }
        public Decimal TUTAR { get; set; }
        public Decimal BRUTFIYAT { get; set; }
        protected Decimal DEPOKODU { get; set; }
        public Decimal KDVORAN { get; set; }
        protected Decimal SERVISID { get; set; }
        protected Decimal FATURAID { get; set; }

    }
}
