using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptFaturaTuru : SasonBase.Sason.Tables.Table_FATURATURLER.RawItem
    {
        public decimal  ID      { get; set; }
        public String   KOD     { get; set; }
    }
}