using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class ReportData_SERVISSIPARISMLZLER : SasonBase.Sason.Tables.Table_SERVISSIPARISMLZLER.RawItem
    {
        internal decimal ID { get; set; }
        internal decimal MALZEMEID { get; set; }
        internal decimal SERVISSTOKID { get; set; }
        internal decimal SERVISSIPARISID { get; set; }
        internal decimal FATURAID { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("SERVISSTOKID", "SERVISSTOKID")]
        [RelationCondition("app:Language", "DILKOD")]
        [RelationCondition("app:ServiceId", "SERVISID")]
        internal ReportData_VT_SERVISSTOKLAR ServisStok { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("MALZEMEID", "MALZEMEID")]
        [RelationCondition("app:Language", "DILKOD")]
        [RelationOrderBy("KOD ASC")]
        internal ReportData_VT_MALZEMELER Malzeme { get; set; }

        public string Kod
        {
            get
            {
                string ret = string.Empty;
                if (ServisStok.isNotNull())
                    ret = ServisStok.KOD;
                else if (Malzeme.isNotNull())
                    ret = Malzeme.KOD;
                return ret;
            }
        }

        public string Kod2 { get; set; } //Orjinal Kod İçin Kullanılacak
        public string Aciklama
        {
            get
            {
                string ret = string.Empty;
                if (ServisStok.isNotNull())
                    ret = ServisStok.AD;
                else if (Malzeme.isNotNull())
                    ret = Malzeme.AD;
                return ret;
            }
        }

        [DbTargetField("MIKTAR")] public decimal Miktar { get; set; }

        public string BirimAd
        {
            get
            {
                string ret = string.Empty;
                if (ServisStok.isNotNull())
                    ret = ServisStok.BIRIMAD;
                else if (Malzeme.isNotNull())
                    ret = Malzeme.BIRIMAD;
                return ret;
            }
        }

        [DbTargetField("BIRIMFIYAT")] public Decimal BirimFiyat { get; set; }
        //[DbTargetField("TESLIMTARIH")] public DateTime TeslimTarihi { get; set; }
        //[DbTargetField("SASINO")] public String SaseNo { get; set; }



        public static List<ReportData_SERVISSIPARISMLZLER> SelectOverloadFromFaturaId(IEnumerable<decimal> faturaIds)
        {
            List<ReportData_SERVISSIPARISMLZLER> ret = new List<ReportData_SERVISSIPARISMLZLER>();
            Exception ex = null;
            if (faturaIds.isEmpty())
                return ret;
            ret = Antibiotic.Database._Helpers.ItemHelpers.SelectItemsFromFieldInValues(typeof(ReportData_SERVISSIPARISMLZLER), "FATURAID", faturaIds.toList<object>(), out ex).toList<ReportData_SERVISSIPARISMLZLER>();
            return ret;
        }
    }
}