using Antibiotic.Database.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptAyristirmalarDetay : SasonBase.Sason.Tables.Table_AYRISTIRMADETAYLAR.RawItem
    {
        public decimal ID { get; set; }
        public decimal AYRISTIRMAID { get; set; }
        public decimal TURID { get; set; }
        [DbTargetField("PDFITEMKOD")] public string Kod { get; set; }
        [DbTargetField("PDFITEMTANIM")] public string Aciklama { get; set; }
        [DbTargetField("MIKTAR")] public decimal Miktar { get; set; }
        [DbTargetField("PDFONAYLANANYUZDE")] public decimal OnaylananYuzdeOran { get; set; }
        [DbTargetField("PDFTOPLAM")] public decimal Toplam { get; set; }
        [DbTargetField("PDFPARABIRIMID")] public string ParaBirimi { get; set; }
    }
}