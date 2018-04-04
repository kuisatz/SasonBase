using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Models
{
    public class RptIscilik : SasonBase.Sason.Tables.Table_ISCILIKLER.RawItem
    {
        public virtual decimal ID { get; set; }
        public virtual String MIKTAR { get; set; }


        // 1 aw = 6 dk.
        public string AWAciklama
        {
            get
            {
                if (MIKTAR.like("*"))
                    return "Süre Girilmemiş";
                else
                    return $"{Convert.ToDecimal(MIKTAR).toString()} AW";
            }
        }

        public decimal AWDegeri
        {
            get
            {
                decimal ret = 0;
                if (MIKTAR.like("*") == false)
                    ret = Convert.ToDecimal(MIKTAR);
                return ret;
            }
        }

        public decimal DakikaDegeri
        {
            get
            {
                return AWDegeri * 6;
            }
        }
    }
}