using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Models
{
    public class RptIsEmir : SasonBase.Sason.Tables.Table_SERVISISEMIRLER.RawItem
    {
        public decimal ID { get; set; }
        public string ACIKLAMA { get; set; }
        public decimal SERVISID { get; set; }
        public DateTime KAYITTARIH { get; set; }
        public string ISEMIRNO { get; set; }
        public string SASENO { get; set; }
        public decimal SERVISARACID { get; set; }
        string PLAKA { get; set; }
        public decimal SERVISVARLIKID { get; set; }

        public string Plaka
        {
            get
            {
                string ret = this.PLAKA;
                if (ret.isNullOrWhiteSpace())
                    ret = ServisArac?.ServisVarlikRuhsat?.PLAKA;
                return ret;
            }
        }

        [ReadOnlyRelation]
        [RelationCondition("ID", "SERVISISEMIRID")]
        public List<RptIsEmirIslem> Islemler { get; set; }

        [ReadOnlyRelation]
        [RelationCondition("SERVISARACID","ID")]
        public RptServisAraclar ServisArac { get; set; }

        [ReadOnlyRelation]
        [RelationCondition("SERVISVARLIKID","ID")]
        public RptServisVarliklar ServisVarlik { get; set; }
    }

    public class RptIsEmirIslem : SasonBase.Sason.Tables.Table_SERVISISEMIRISLEMLER.RawItem
    {
        public decimal ID { get; set; }
        public decimal SERVISISEMIRID { get; set; }
        public string ACIKLAMA { get; set; }

        [ReadOnlyRelation]
        [RelationCondition("ID", "SERVISISEMIRISLEMID")]
        public List<RptIsEmirIslemIscilik> Iscilikler { get; set; }
    }

    public class RptIsEmirIslemIscilik : SasonBase.Sason.Tables.Table_SERVISISMISLEMISCILIKLER.RawItem
    {
        public decimal ID { get; set; }
        public Decimal SERVISISEMIRISLEMID { get; set; }
        public Decimal ISCILIKID { get; set; }
        public Decimal SERVISISCILIKID { get; set; }
        protected String ACIKLAMA { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("ISCILIKID", "ID")]
        public RptIscilik Iscilik { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("SERVISISCILIKID", "ID")]
        public RptServisIscilik ServisIscilik { get; set; }

        public string Aciklama
        {
            get
            {
                string retAciklama = this.ACIKLAMA;
                if (retAciklama.isNullOrWhiteSpace() && ServisIscilik.isNotNull())
                    retAciklama = ServisIscilik.KOD;
                return retAciklama;
            }
        }

        public int Iscilik_Dakika_Suresi
        {
            get
            {
                int ret = 0;
                if (Iscilik.isNotNull())
                    ret = (int)Iscilik.DakikaDegeri;
                else if (ServisIscilik.isNotNull())
                    ret = (int)ServisIscilik.SUREDK;
                return ret;
            }
        }

        public string Iscilik_Dakika_Suresi_Str
        {
            get { return Iscilik_Dakika_Suresi.toTimeString(); }
        }
    }
}