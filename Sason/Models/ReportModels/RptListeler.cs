using Antibiotic.Database.Field;
using Antibiotic.Database.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptListeler : SasonBase.Sason.Tables.Table_LISTELER.RawItem
    {
        protected virtual Decimal ID { get; set; }
        protected virtual String KOD { get; set; }
    }

    ////[StaticField("KOD","BIRIMLER")]
    //public class RptListelerInfoBirimler : RptListelerInfo
    //{

    //}
}
