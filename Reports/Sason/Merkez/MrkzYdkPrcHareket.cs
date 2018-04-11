using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Sason.Merkez
{
    public class MrkzYdkPrcHareket : Base.SasonMerkezReporter
    {
        public MrkzYdkPrcHareket()
        {
            Text = "Servis Hareket Raporu";
            SubjectCode = "MrkzYdkPrcHareket";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            Disabled = true;
        }
        public MrkzYdkPrcHareket(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
              servisIdQuery = $"  {selectedServisId}";
#endif

            //if (ServisIds.isNotEmpty())
            //    servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            //else
            //    servisIdQuery = $" > 1 ";

            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";

            MethodReturn mr = new MethodReturn();
            List<ReportData> reportDataSource = new List<ReportData>();
            List<QueryResult> queryResults = AppPool.EbaTestConnector.CreateQuery($@"
                select
                --ie.id ISEMIR_ID,
                srv.ISORTAKAD SERVIS_AD, srv.partnercode SERVIS_PARTNER_KOD,
                ie.isemirno ISEMIR_NO, ie.KAYITTARIH ISEMIR_KAYITTARIHI, ie.TAMAMLANMATARIH ISEMIR_TAMAMLANMA_TARIHI, ie.saseno ISEMIR_SASENO
                --,iei.ID ISEMIR_ISLEM_ID
                ,atip.kod GARANTI_KODU, atip.ad GARANTI_TIPI
                ,ay.ARIZAKODU AYR_ARIZAKODU, ay.CLAIMNO AYR_CLAIMNO, AY.ESAGARANTINO AYR_ESA_GARANTINO, AY.SERVISGARANTINO AYR_SERVIS_GARANTI_NO, AY.PDFGARANTINO AYR_PDF_GARANTI_NO
                ,mlz.KOD MALZEME_KODU, mlz.AD MALZEME_ADI, MLZ.MIKTAR MALZEME_MIKTAR, MLZ.BIRIM_AD MALZEME_BIRIM_AD
                from (select * from servisisemirler where TAMAMLANMATARIH BETWEEN {{startDate}} AND {{finishDate}} and TEKNIKOLARAKTAMAMLA = 1 AND SERVISID {servisIdQuery}) ie
                left join vt_servisler srv on srv.dilkod = 'Turkish' and srv.servisid = ie.servisid
                -- AYRISTIRMA TIPLER
                left join vw_ayristirmatipler atip on atip.id not in (1,2) and atip.dilkod = 'Turkish'
                -- SERVIS ISEMIR ISLEMLER 
                left join servisisemirislemler iei on iei.servisisemirid = ie.id
                -- AYRISTIRMALAR
                inner join ayristirmalar ay on ay.ayristirmatipid = atip.id and AY.SERVISISEMIRISLEMID = iei.id
                -- MALZEMELER
                inner join (
                        select
                            a.id AYRISTIRMAID, 1 GROUPID, 'MALZEME' GROUPNAME, st.kod KOD, st.ad AD, ad.miktar MIKTAR, brm.ad BIRIM_AD, ad.gtutar TUTAR, AD.PDFMIKTAR, AD.PDFNETFIYAT, AD.PDFISLETIMUCRETI, AD.PDFONAYLANANYUZDE, AD.PDFTOPLAM, AD.PDFPARABIRIMID
                        from
                            ayristirmalar a, ayristirmadetaylar ad, servisismislemmalzemeler im, servisstoklar st, vw_birimler brm
                        where
                            AD.AYRISTIRMAID(+) = a.id
                            and ad.turid = 1 --malzeme
                            and im.id(+) = ad.referansid
                            and st.id(+)= im.servisstokid
                            and brm.id(+) = st.birimid and BRM.DILKOD(+) = 'Turkish'
                       ) mlz on mlz.ayristirmaid = ay.ID
            ")
            .GetDataTable(mr)
            .ToModels<QueryResult>();

            ReportData reportData = new ReportData();
            reportData.querysrvs = queryResults;

            CloseCustomAppPool();
            CloseCustomAppPool();
            return reportData;
            //return queryResults;
        }
        public class ReportData
        {
            public List<QueryResult> querysrvs { get; set; }
        }
        public class QueryResult
        {
            //#region servisici
            public decimal SERVISNO { get; set; }
            public decimal PARCANO { get; set; }
            public decimal NUMARADEGISIKLIGI { get; set; }
            public decimal PARCAADI { get; set; }
            public decimal FATURANO { get; set; }
            public decimal HAREKETTARIHI { get; set; }
            public decimal SATISADETI { get; set; }
            public decimal ALISADETI { get; set; }
            public decimal BRUTLISTEFIYATI { get; set; }
            public decimal NETFIYAT { get; set; }
            public decimal ISKONTO { get; set; }
            public decimal KUR { get; set; }
            public decimal ARACSASENO { get; set; }
            //#endregion
        }
    }
}