using Antibiotic.Database.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptServisDepo : SasonBase.Sason.Tables.Table_SERVISDEPOLAR.RawItem
    {
        protected virtual Decimal ID { get; set; }
        [DbTargetField("KOD")] public String Kod { get; set; }
        [DbTargetField("AD")] public String Ad { get; set; }
        //protected virtual Decimal SERVISDEPOGRUPID { get; set; }
        ///protected virtual Decimal DEPOTIPID { get; set; }
        //protected virtual Decimal RAFSIZ { get; set; }
        //protected virtual Decimal DURUMID { get; set; }
        //protected virtual Decimal SERVISID { get; set; }
    }
}