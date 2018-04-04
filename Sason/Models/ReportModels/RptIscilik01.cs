using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    /// <summary>
    /// İşçilikler Tablosu
    /// </summary>
    public class RptIscilik01 : SasonBase.Sason.Tables.Table_ISCILIKLER.RawItem
    {
        protected virtual Decimal ID { get; set; }
        //protected virtual Decimal ISCILIKARACSINIFID { get; set; }
        //protected virtual Decimal ISCILIKARACVARYANTID { get; set; }
        //protected virtual Decimal ISCILIKNESNEID { get; set; }
        //protected virtual Decimal ISCILIKUYGULAMAID { get; set; }
        //protected virtual Decimal ISCILIKKONUMID { get; set; }
        //protected virtual Decimal ISCILIKMONTAJDURUMID { get; set; }
        //protected virtual Decimal ISCILIKFAALIYETID { get; set; }
        //protected virtual Decimal ISCILIKTIPID { get; set; }
        protected String MIKTAR { get; set; }

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

        //protected virtual DateTime DTARIH { get; set; }
        //protected virtual Decimal DURUMID { get; set; }
        //protected virtual Decimal AKSIYON { get; set; }
    }
}
