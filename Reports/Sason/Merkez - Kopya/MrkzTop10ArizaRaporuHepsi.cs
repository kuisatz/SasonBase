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
    /// Top 20 Arıza Listesi Raporu
    /// </summary>
    public class MrkzTop10ArizaRaporuHepsi : Base.SasonMerkezReporter
    {
        public MrkzTop10ArizaRaporuHepsi()
        {
            Text = "Top 10 Arıza Listesi Raporu (Hepsi)";
            SubjectCode = "MrkzTop10ArizaRaporuHepsi";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            AddParameter(new ReporterParameter() { Name = "param_ariza_kod", Text = "Arıza Kod" }.CreateTextBox("İsteğe Bağlı Arıza Kod (7) Girebilirsiniz"));
            Disabled = false;
        }
        public MrkzTop10ArizaRaporuHepsi(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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

        public string ArizaKod
        {
            get { return GetParameter("param_ariza_kod").ReporterValue.toString(); }
            set { SetParameterReporterValue("param_ariza_kod", value.toString()); }
        }

        public List<decimal> ServisIds
        {
            get { return GetParameter("param_servisler").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_servisler", value); }
        }

        public string SaseNo
        {
            get { return GetParameter("param_sase_no").ReporterValue.toString(); }
            set { SetParameterReporterValue("param_sase_no", value.toString()); }
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
                case "param_ariza_kod":
                    ArizaKod = value.toString();
                    break;
                case "param_sase_no":
                    SaseNo = value.toString();
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
            servisIdQuery = $" = {selectedServisId}";
#endif

            if (ServisIds.isNotEmpty())
                servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            else
            {
                //    servisIdQuery = $" > 1 ";
                selectedServisId = ServisId;
                servisIdQuery = $" in( {selectedServisId} )";
            }

            #region arizakod
            string arizaKodQuery = "";

            if (ArizaKod.Length == 7)
                arizaKodQuery =
                       $" AND (SUBSTR(a.arizakodu, 1, 7) ) =  '{ArizaKod}' ";
            else
                arizaKodQuery = "";

            #endregion

            #region saseNo
            string saseNoQuery = "";

            if (SaseNo.isNotEmpty())
                saseNoQuery =
                       $" AND si.saseno = '{SaseNo}' ";
            else
                saseNoQuery = "";

            #endregion


            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";

            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 

                            SELECT v.partnercode servis_kodu,
                                   v.isortakad servis_adi,
                                   TO_CHAR (si.tamamlanmatarih, 'DD.MM.YYYY') isemri_kapanma_tarihi,
                                   EXTRACT (YEAR FROM si.tamamlanmatarih) isemri_tamamlanma_yili,
                                   t.kod ayristirma_tipi,
                                   (CASE
                                      WHEN si.arackazali = 1
                                           THEN 'EVET'
                                      WHEN si.arackazali <> 1
                                           THEN 'HAYIR'
                                   END) AS arackazali,
                                   ROUND (si.tamamlanmatarih - si.kayittarih, 2) acik_kalma_suresi,
                                   (CASE
                                       WHEN si.hizmetyerid = 1
                                           THEN 'SERVIS'
                                       WHEN si.hizmetyerid = 2
                                           THEN 'SANTIYE'
                                       WHEN si.hizmetyerid = 3
                                           THEN 'YOL YARDIM'
                                   END) AS hizmet_yeri,
                                   si.turasist,
                                   a.servisgarantino,
                                   TO_CHAR (a.sonokumazamani, 'DD.MM.YYYY') garanti_kapanma_tarihi,
                                   (CASE
                                      WHEN a.claimstatus = 'Z110'
                                      tHEN
                                         TO_CHAR (EXTRACT (YEAR FROM a.sonokumazamani))
                                      WHEN a.claimstatus IN ('Z107', 'Z109', 'Z999')
                                      THEN
                                         ('GARANTI_RED')
                                      ELSE
                                         ''
                                   END) AS garanti_kapanma_yili,
                                   a.claimno,
                                   a.claimstatus,
                                   t.garantituru,
                                   r.plaka,
                                   r.saseno,
                                   vm.vehiclenum kisa_sase,
                                   vm.vehicletype arac_tipi,
                                   vm.modelnum arac_modeli,
                                   a.pdfkmdurumu garanti_km,
                                   si.km isemri_km,
                                   vm.schadstkl emisyon_sinifi,
                                   sv.ad musteri_adi,
                                   sv.vergino,
                                   a.arizakodu,
                                   a.id,
                                   si.tutar,
                                   si.indirimlitutar,
                                   si.ttutar tahmini_tutar,
                                   si.aciklama,
                                   si.arackazaaciklama kaza_aciklama,
                                   si.sfnotu servis_fisi_notu,
                                   a.gtutar ic_tutari,
                                   a.pdftalepgeneltoplam oc_tutari,
                                   v.gsad servis_garanti_sorumlusu,
                                   v.tbsad teknik_bolge_sorumlusu

                            FROM vt_servisler v,
                                 ayristirmalar a,
                                 servisvarlikruhsatlar r,
                                 esaaraclar ea,
                                 vx_vis_vehiclemaster vm,
                                 ayristirmatipler t,
                                 servisvarliklar sv,
                                 servisisemirler si

                            WHERE v.dilkod = 'Turkish'
                                 AND a.servisid = v.servisid
                                 AND si.isemirno = a.isemirno
                                 AND r.saseno = ea.vin
                                 AND ea.id = vm.esaaracid
                                 AND a.ayristirmatipid = t.id
                                 AND sv.id = r.servisvarlikid
                                 AND r.servisid = a.servisid
                                 AND si.saseno = r.saseno
                                 AND a.durumid = 1
                                 AND si.tamamlanmatarih BETWEEN '{dateQuery}'
                                 AND a.servisid {servisIdQuery}
                                 {saseNoQuery}
                                 {arizaKodQuery} 
                            order by servis_kodu, si.tamamlanmatarih desc

                ")
            .GetDataTable(mr)
            .ToModels();


            CloseCustomAppPool();
            return queryResults;
        }

    }
}