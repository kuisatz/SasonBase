using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class ReportData_VT_ISEMIRDETAYLARFATURA : SasonBase.Sason.Views.View_VT_ISEMIRDETAYLARFATURA.RawItem
    {
        decimal REFERANSID              { get; set; }
        public string ISEMIRNO          { get; set; }

        public Decimal SERVISID         { get; set; }

        public string KOD               { get; set; }
        public string ORJINALKOD        { get; set; }
    }
}