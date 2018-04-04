using Antibiotic.Extensions;
using SasonBase.Sason.Models.PdksModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Models
{
    public class RptTeknisyenHareket : TeknisyenHareket
    {
        public DateParts DPGirisTarihi => new DateParts(GIRISTARIHI);
        public DateParts DPCikisTarihi => new DateParts(AktifCikisTarih);

        public HareketNeden GirisNeden { get; set; }
        public HareketNeden CikisNeden { get; set; }

        public TeknisyenHareketDagilimSonuclari PSonuc { get; set; }

        public int Calisma { get; set; }
        public string CalismaStr { get { return Calisma.toTimeString(); } }
    }
}