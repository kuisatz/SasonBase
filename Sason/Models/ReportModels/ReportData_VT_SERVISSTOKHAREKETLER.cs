using Antibiotic.Database.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class ReportData_VT_SERVISSTOKHAREKETLER : SasonBase.Sason.Views.View_VT_SERVISSTOKHAREKETLER.RawItem
    {
        Decimal SERVISSTOKHAREKETID { get; set; }
        Decimal SERVISSTOKISLEMID { get; set; }

        [DbTargetField("TARIH")] public DateTime Tarih { get; set; }
        [DbTargetField("BLGNO")] private String BelgeNo { get; set; }
        [DbTargetField("BLGTARIH")] public DateTime BelgeTarihi { get; set; }

        //[DbTargetField("")]  
    }
}