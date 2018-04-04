using Antibiotic.Database.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptParaBirimiInfo : SasonBase.Sason.Tables.Table_PARABIRIMLER.RawItem
    {
        protected virtual Decimal ID { get; set; }
        [DbTargetField("KOD")] public String Kod { get; set; }
    }
}