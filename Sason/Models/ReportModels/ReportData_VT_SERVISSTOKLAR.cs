using Antibiotic.Database.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class ReportData_VT_SERVISSTOKLAR : SasonBase.Sason.Views.View_VT_SERVISSTOKLAR.RawItem
    {
        public decimal     SERVISSTOKID    { get; set; }
        decimal     SERVISID        { get; set; }
        string      DILKOD          { get; set; }

        internal string         KOD             { get; set; }
        internal string         AD              { get; set; }

        internal virtual        Decimal BIRIMID { get; set; }
        public virtual          String  BIRIMAD { get; set; }

        [DbTargetField("SERVISSTOKTURID")] public decimal StokTurId { get; set; }
        [DbTargetField("SERVISDEPOAD")] public string DepoAdi { get; set; }
    }
}