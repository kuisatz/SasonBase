using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SasonBase.Reports.Sason.Merkez
{
    /// <summary>
    /// Merkez Aksiyon Listesi
    /// </summary>
    public class MrkzAksiyonListesi : Base.SasonMerkezReporter
    {
        public MrkzAksiyonListesi()
        {
            Text = "Aksiyon Listesi";
            SubjectCode = "MrkzAksiyonListesi";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_aksiyonturu", Text = "Aksiyon Türleri" }.CreateAksiyonTuruSelect(true));
            Disabled = false;
        }
        public MrkzAksiyonListesi(decimal servisId, decimal aksiyonTuruId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
            this.StartDate = startDate;
            this.FinishDate = finishDate;
        }

        public DateTime StartDate
        {
            get { return GetParameter("param_start_date").ReporterValue.cast<DateTime>(); }
            set { SetParameterReporterValue("param_start_date", value.startOfDay()); }
        }

        public DateTime FinishDate
        {
            get { return GetParameter("param_finish_date").ReporterValue.cast<DateTime>(); }
            set { SetParameterReporterValue("param_finish_date", value.endOfDay()); }
        }

        public List<decimal> ServisIds
        {
            get { return GetParameter("param_servisler").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_servisler", value); }
        }

        public List<decimal> AksiyonTuruIds
        {
            get { return GetParameter("param_aksiyonturu").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_aksiyonturu", value); }
        }

        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {
                //Dışarıdan Gelen Format 20171231235959 Şeklinde Olmalıdır
                case "param_start_date":
                    StartDate = Convert.ToInt64(value).toDateTime();
                    break;
                case "param_finish_date":
                    FinishDate = Convert.ToInt64(value).toDateTime();
                    break;
                case "param_servisler":
                    ServisIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
                case "param_aksiyonturu":
                    AksiyonTuruIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            decimal selectedServisId = ServisIds.first().toString("0").cto<decimal>();
            string servisIdQuery = $" = {selectedServisId}";
            string dateQuery = "";

#if DEBUG
             selectedServisId = ServisId;
              servisIdQuery = $" in( {selectedServisId} )";
#endif


            if (ServisIds.isNotEmpty())
                servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            else { 
            //    servisIdQuery = $" > 1 ";
                selectedServisId = ServisId;
                servisIdQuery = $" in ( {selectedServisId} )";
            }


            decimal selectedAksiyonTuruId = AksiyonTuruIds.first().toString("0").cto<decimal>();
            string aksiyonTuruIdQuery = $" ";
            if (AksiyonTuruIds.isNotEmpty())
                aksiyonTuruIdQuery = $"  AND a.AKSIYONTIPID   in ({AksiyonTuruIds.joinNumeric(",")}) ";
            else
            {
              //  selectedAksiyonTuruId = 2;
             //   aksiyonTuruIdQuery = $"  AND a.AKSIYONTIPID  in( {selectedAksiyonTuruId} )";
            }


            StartDate = StartDate.startOfDay(); 
            FinishDate = FinishDate.endOfDay();
            dateQuery = ""+StartDate.ToString("dd/MM/yyyy") +  "' AND '"+ FinishDate.ToString("dd/MM/yyyy")+"";
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"  
                    SELECT distinct 
                            ax.*, ROWNUM rnum,case when TOPLAM=0 or UYGULANAN=0 then 0 else round(uygulanan/toplam,2) end ORAN,TOPLAM-UYGULANAN UYGULANMAYAN
                    FROM (
                        SELECT azx.*,
                               (SELECT COUNT (*)
                                FROM aksiyonaraclar where  aksiyonid=azx.aksiyonid and durumid=1 ) TOPLAM,
                                    (SELECT COUNT (*)
                                    FROM aksiyonaraclar where  aksiyonid=azx.aksiyonid and  AKSIYONSTATUID in (4,6) ) UYGULANAN 
                                    FROM 
                                      ( SELECT 
                                            a.ID AKSIYONID,
                                            a.AD,
                                            a.TRAKSIYONU,
                                            a.AKSIYONTIPID,
                                            B.AD AKSIYONTIPAD,
                                            TO_CHAR (a.BASTARIH, 'DD.MM.YYYY') BASTARIH,
                                            TO_CHAR (a.BITTARIH, 'DD.MM.YYYY') BITTARIH,
                                            a.UCRETLIMI,
                                            a.AKSIYONNO,
                                            a.HARICINO,
                                            a.ARIZAKODU,
                                            a.ACIKLAMA,
                                            a.NOTLAR,
                                            a.NOTSERVISDURUMU,
                                            a.DURUMID,
                                            C.AD DURUMAD,
                                            a.REFAKSIYONID,
                                            d.EXTRECALLNUM,
                                            d.INTRECALLNUM,
                                            d.WARRANTYCLAIMTYPE,
                                            d.REFDATE,
                                            d.RECALLVALIDTO,
                                            d.WARRANTYCLAIMNUM,
                                            d.TXTTABLECOUNTER,
                                            d.DocAppendix,
                                            d.DamageCode,
                                            d.SIShortText,
                                            d.Priority,
                                            b.dilkod
                                        FROM aksiyonlar a,
                                        vw_aksiyontipler b,
                                        vw_durumlar c,
                                        (SELECT DISTINCT 
                                                d.EXTRECALLNUM,
                                                d.INTRECALLNUM,
                                                d.WARRANTYCLAIMTYPE,
                                                d.REFDATE,
                                                d.RECALLVALIDTO,
                                                d.WARRANTYCLAIMNUM,
                                                d.TXTTABLECOUNTER,
                                                d.DocAppendix,
                                                d.DamageCode,
                                                d.SIShortText,
                                                d.Priority
                                        FROM mX_VIS_SERVICEINFODETAILS d) d
                                    WHERE  A.AKSIYONTIPID = B.ID
                                        AND a.durumid = c.id
                                        AND c.DILKOD = b.dilkod
                                        AND A.REFAKSIYONID = D.EXTRECALLNUM(+)
                                        AND b.dilkod = 'Turkish'
                                        AND a.bastarih between '{dateQuery}'
                                         {aksiyonTuruIdQuery} 
                                  /*      AND a.id in (
                                            SELECT distinct dx.aksiyonid  FROM SERVISISEMIRISLEMLER dx WHERE  dx.SERVISISEMIRID in ( SELECT distinct  ex.id FROM SERVISISEMIRLER ex WHERE ex.servisid  {servisIdQuery}  ))
                                          )
                                  */

                                    )   azx 
                    ) ax 
 
                    ORDER BY ax.bastarih  , ax.bittarih 
                
 
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}