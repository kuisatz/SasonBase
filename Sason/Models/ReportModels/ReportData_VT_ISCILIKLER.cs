using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    /// <summary>
    /// DILKOD Mutlaka Bağlanmalı
    /// </summary>
    public class ReportData_VT_ISCILIKLER : SasonBase.Sason.Views.View_VT_ISCILIKLER.RawItem
    {
        decimal ISCILIKID   { get; set; }
        string  KOD         { get; set; }
        string  DILKOD      { get; set; }
    }

    public class Rpt_VT_ISCILIKLER_02 : SasonBase.Sason.Views.View_VT_ISCILIKLER.RawItem
    {
        public decimal ISCILIKID { get; set; }
        public string KOD { get; set; }
        public string DILKOD { get; set; }
    }
}