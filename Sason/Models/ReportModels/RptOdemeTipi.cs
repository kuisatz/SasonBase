using Antibiotic.Database.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptOdemeTipi : SasonBase.Sason.Tables.Table_ODEMETIPLER.RawItem
    {
        protected virtual Decimal ID { get; set; }
        [DbTargetField("KOD")] public String Kod { get; set; }
        //protected virtual Decimal DURUMID { get; set; }
    }
}
