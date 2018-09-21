using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SasonBase.Reports.Sason.Merkez
{
    /// <summary>
    /// Merkez Açık Aksiyon İşlem Kaydı
    /// </summary>
    public class MrkzAcikAksiyonIslemKaydi : Base.SasonMerkezReporter
    {
        public MrkzAcikAksiyonIslemKaydi()
        {
            Text = "[SI-1] Açık Aksiyon İşlem Kaydı Raporu";
            SubjectCode = "MrkzAcikAksiyonIslemKaydi";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            Disabled = false;
        }

        public MrkzAcikAksiyonIslemKaydi(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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

            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";


            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"   

                   SELECT srv.partnercode AS servis_kodu, 
                          aks.isortakad AS servis_adi,
                          aks.servisvarlikad AS musteri_adi, 
                          aks.saseno,
                          aks.aksiyonad,
                          si.isemirno,
                          si.kayittarih,
                          si.tamamlanmatarih,
                          ayrtip.kod,
                          ayr.claimno AS esagarantino,
                          ayr.servisgarantino,
                          ayr.garantistatus,
                          ayr.claimstatus,
                          ayr.pdfonaygeneltoplam,
                          ayr.tarih AS ayristirma_tarihi,
                          si.servisid

                     FROM vt_aksiyonisemirler aks,
                          servisisemirler si,
                          ayristirmalar ayr,
                          servisisemirislemler isl,
                          vt_servisler srv,
                          ayristirmatipler ayrtip

                    WHERE aks.dilkod='Turkish'
                          AND si.id=aks.servisisemirid
                          AND ayr.isemirno=aks.isemirno
                          AND isl.servisisemirid=si.id
                          AND si.tamamlanmatarih IS NOT NULL
                          AND isl.isemiruygulamamanedenid IS NULL
                          AND si.tutar>0
                          AND srv.servisid=si.servisid
                          AND srv.dilkod='Turkish'
                          AND ayrtip.id(+)=ayr.ayristirmatipid
                          AND si.servisid {servisIdQuery}
                          AND si.tamamlanmatarih BETWEEN '{dateQuery}' 
                    order by srv.partnercode,si.kayittarih DESC
                   
            ")
            .GetDataTable()
            .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}