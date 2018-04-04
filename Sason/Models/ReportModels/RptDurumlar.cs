using Antibiotic.Database.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptDurumlar : SasonBase.Sason.Tables.Table_DURUMLAR.RawItem
    {
        internal Decimal ID { get; set; }
        [DbTargetField("KOD")] public String Kod { get; set; }
    }
}