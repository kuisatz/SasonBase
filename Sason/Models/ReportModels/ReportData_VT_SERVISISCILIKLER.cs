using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class ReportData_VW_SERVISISCILIKLER : SasonBase.Sason.Views.View_VW_SERVISISCILIKLER.RawItem
    {
        decimal ID                  { get; set; }
        string  KOD                 { get; set; }
        decimal SERVISID            { get; set; }
        string  DILKOD              { get; set; }
    }
}