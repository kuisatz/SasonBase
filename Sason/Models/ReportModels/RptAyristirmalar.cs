using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptAyristirmalar : SasonBase.Sason.Tables.Table_AYRISTIRMALAR.RawItem
    {
        public decimal  ID          { get; set; }
        public string   CLAIMNO     { get; set; }

        [RelationCondition("ID","AYRISTIRMAID")]
        public List<RptAyristirmalarDetay> Detaylar { get; set; }
    }
}
