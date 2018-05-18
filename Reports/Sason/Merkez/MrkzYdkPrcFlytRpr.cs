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
    /// Merkez Yedek Parça Faaliyet Raporu
    /// </summary>
    public class MrkzYdkPrcFlytRpr : Base.SasonMerkezReporter
    {
        public MrkzYdkPrcFlytRpr()
        {
            Text = "Yedek Parça Faaliyet Raporu";
            SubjectCode = "MrkzYdkPrcFlytRpr";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(false));
            Disabled = false;
        }
        public MrkzYdkPrcFlytRpr(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
            servisIdQuery = $"=  {selectedServisId}";
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

            MethodReturn mr = new MethodReturn();
            List<ReportData> reportDataSource = new List<ReportData>(); 
            QueryResult qr = new QueryResult();
           
            #region query2
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"                 
            SELECT vts.partnercode, vts.ISORTAKAD , 
                            stok.stok_toplam, 
                            stok.stok_oes,
                            stok.stok_oeM,
                            stok.stok_essanayi,
                            stok.stok_my,
                            stok.stok_yansanayi,
            dfdfdf.* FROM ( 

             SELECT servisid, 
                sum(servisicioem) servisicioem ,
                sum(servisicioes) servisicioes ,
                sum(servisiciesdeger) servisiciesdeger,
                sum(servisicimyok) servisicimyok,
                sum(servisicitoplam) servisicitoplam,
                sum(servisiciuygunparca) servisiciuygunparca,
                sum(servisiciucretliuygunparca) servisiciucretliuygunparca ,
                sum(servisicigaranti) servisicigaranti,
                sum(servisicioem2el) servisicioem2el,
                sum(servisicioes2el) servisicioes2el,
                sum(servisiciesdeger2el) servisiciesdeger2el ,
                sum(servisiciyansanayi2el) servisiciyansanayi2el,
                sum(servisicimyok2el) servisicimyok2el,
                sum(servisicitoplam2el) servisicitoplam2el,
                sum(servisiciuygunparca2el) servisiciuygunparca2el,
                sum(servisiciucretliuygunparca2el) servisiciucretliuygunparca2el ,
                sum(servisicigaranti2el) servisicigaranti2el,

                sum(servisdisioem) servisdisioem,
                sum(servisdisioes) servisdisioes,
                sum(servisdisiesdeger) servisdisiesdeger,
                sum(servisdisimyok) servisdisimyok ,
                sum(servisdisitoplam) servisdisitoplam,
                sum(servisdisiystoplam) servisdisiystoplam,
                sum(servisdisiuygunparca) servisdisiuygunparca , 

                sum(servisiciyansanayi) servisiciyansanayi,
                sum(servisdisiyansanayi) servisdisiyansanayi,
                sum(servisiciyansanayitoplam) servisiciyansanayitoplam,
                sum(servisdisiyansanayitoplam) servisdisiyansanayitoplam,

                sum(servisiciyag) servisiciyag,
                sum(servisiciyag2el) servisiciyag2el,
                sum(servisdisiyag) servisdisiyag,
                sum(yagtoplam) yagtoplam,
                sum(yedekparcatoplami) yedekparcatoplami ,
                sum(ambar) ambar,
                sum(BAKIMPAKETI) BAKIMPAKETI ,
                sum(uukko) uukko  
               
                 
                FROM  sason.ypfaaliyet dsf
              
               
             WHERE
                    dsf.servisid {servisIdQuery} and                                 
                    dsf.YEDEKPARCAFALIYETRAPORTARIHI BETWEEN '{dateQuery}' 

             group by   servisid  
                 ) dfdfdf
                    inner join (
               select    HSERVISID,
                        sum(nvl(stok_oes,0)) as stok_oes,
                        sum(nvl(stok_oeM,0)) as stok_oeM,
                        sum(nvl(stok_essanayi,0)) as stok_essanayi,
                        sum(nvl(stok_my,0)) as stok_my,

                           sum(nvl(stok_yag,0)) as stok_yag,
                        sum(nvl(stok_yansanayi,0)) as stok_yansanayi,
                        sum(nvl(stok_yag,0) + nvl(stok_oes,0) +nvl(stok_oeM,0) + nvl(stok_essanayi,0) + nvl(stok_my,0) +nvl(stok_yansanayi,0)) as stok_toplam
                      FROM (


                      SELECT   asd.HSERVISID,

                                case asd.SERVISSTOKTURID
                                        when 1 then  sum(nvl(asd.ORTALAMAMALIYET,0) * asd.STOKMIKTAR)
                                     end   as stok_oem,
                                case asd.SERVISSTOKTURID
                                        when 6 then  sum(nvl(asd.ORTALAMAMALIYET,0)*asd.STOKMIKTAR)
                                     end   as stok_yag,
                                case asd.SERVISSTOKTURID
                                        when 7 then  sum(nvl(asd.ORTALAMAMALIYET,0) * asd.STOKMIKTAR)                   
                                     end   as stok_oes,
                                case asd.SERVISSTOKTURID
                                        when 8 then  sum(nvl(asd.ORTALAMAMALIYET,0)*asd.STOKMIKTAR)
                                     end   as stok_essanayi,
                                case asd.SERVISSTOKTURID
                                        when 9 then  sum(nvl(asd.ORTALAMAMALIYET,0)*asd.STOKMIKTAR)
                                     end   as stok_yansanayi,
                                case asd.SERVISSTOKTURID
                                        when 11 then sum(nvl(asd.ORTALAMAMALIYET,0) *asd.STOKMIKTAR)
                                     end   as stok_my
                              FROM(

                SELECT
                       a.kod tur,
                       p.fiyat,
                       p.ID,
                       p.HSERVISID,
                       p.servisstokturid,
                       P.INDFIYAT EUROINDFIYAT,
                       P.FIYAT EUROLISTEFIYAT,
                       P.ORTALAMAMALIYET ORTALAMAMALIYET,
                       p.STOKMIKTAR

                  FROM(SELECT servisstokturid,
                               a.id,
                               a.servisid hservisid,
                               a.kod,
                               C.STOKMIKTAR, 
                               kurlar_pkg.servisstokfiyatgetir(a.id, 2, TRUNC(SYSDATE))
                                  fiyat,
                               KURLAR_PKG.STOKFIYATINDGETIR(a.id,
                                                             2,
                                                             2,
                                                             1,
                                                             0)
                                  INDFIYAT,
                               kurlar_pkg.ORTALAMAMALIYET(a.id) ORTALAMAMALIYET 
                          FROM(SELECT DISTINCT servisstokid
                                  FROM sason.servisstokhareketdetaylar
                                            ) h,
                               sason.servisstoklar a,
                               sason.vt_genelstok c 
                         WHERE  h.servisstokid = a.id
                               AND A.ID = C.SERVISSTOKID
                               AND C.STOKMIKTAR <> 0
                               AND a.servisid = c.servisid
                       
                               AND a.SERVISID  {servisIdQuery}
                            ) p,
                       servisstokturler a
                 WHERE p.servisstokturid = a.id
                 ) asd
                 group by  asd.SERVISSTOKTURID ,asd.HSERVISID
              ) asasd
              group  by asasd.HSERVISID


            ) 
            stok on  servisid = STOK.HSERVISID
            inner join vt_servisler vts on vts.servisid= dfdfdf.servisid and vts.dilkod = 'Turkish'           
 
 
 
                ")
         
             .GetDataTable(mr) 
            .ToModels();
            #endregion
             
         
            CloseCustomAppPool(); 
            return queryResults;
        }

        public class ReportData
        {
            public List<QueryResult> queryr { get; set; }
            public List<QueryResultStok> queryrStk { get; set; }

        }
        public class QueryResult
        {
            public decimal STOK_OES { get; set; }
            public decimal STOK_OEM { get; set; }
            public decimal STOK_ES_SANAYI { get; set; }
            public decimal STOK_MY { get; set; }
            public decimal STOK_YANSANAYI { get; set; }
            public decimal STOK_TOPLAM { get; set; }
            public decimal YEDEKPARCATOPLAMI { get; set; }
            public decimal AMBAR { get; set; }


            #region servisici
            public decimal SERVISICIOEM { get; set; }
            public decimal SERVISICIOES { get; set; }
            public decimal SERVISICIESDEGER { get; set; }
            public decimal SERVISICIMYOK { get; set; }
            public decimal SERVISICITOPLAM { get; set; }
            public decimal SERVISICIYANSANAYI { get; set; }
            public decimal SERVISICIYANSANAYITOPLAM { get; set; }
            public decimal SERVISICIUYGUNPARCA { get; set; }
            public decimal SERVISICIUCRETLIUYGUNPARCA { get; set; }
            public decimal SERVISICIGARANTI { get; set; }
            #endregion
            #region servisdisi
            public decimal SERVISDISIOEM { get; set; }
            public decimal SERVISDISIOES { get; set; }
            public decimal SERVISDISIESDEGER { get; set; }
            public decimal SERVISDISIMYOK { get; set; }
            public decimal SERVISDISITOPLAM { get; set; }
            public decimal SERVISDISIYANSANAYI { get; set; }
            public decimal SERVISDISIYSTOPLAM { get; set; }
            public decimal SERVISDISIUYGUNPARCA { get; set; }
            public decimal SERVISDISIUCRETLIUYGUNPARCA { get; set; }
            public decimal SERVISDISIGARANTI { get; set; }
            #endregion
            #region yag
            public decimal SERVISICIYAG { get; set; }
            public decimal SERVISDISIYAG { get; set; }
            public decimal YAGTOPLAM { get; set; }
            #endregion
            #region servisici2.el
            public decimal SERVISICIOEM2EL { get; set; }
            public decimal SERVISICIOES2EL { get; set; }
            public decimal SERVISICIESDEGER2EL { get; set; }
            public decimal SERVISICIYANSANAYI2EL { get; set; }
            public decimal SERVISICIMYOK2EL { get; set; }
            public decimal SERVISICITOPLAM2EL { get; set; }
            public decimal SERVISICIUYGUNPARCA2EL { get; set; }
            public decimal SERVISICIMUCRETLIUYGUNPARCA2EL { get; set; }
            public decimal SERVISICIGARANTI2EL { get; set; }
            #endregion
            //    public decimal BAKIMPAKETI { get; set; }
            //   public decimal YEDEKPARCATOPLAM { get => SERVISICITOPLAM + SERVISDISITOPLAM; }

        }
        public class QueryResultStok
        {
            public decimal STOK_OES { get; set; }
            public decimal STOK_OEM { get; set; }
            public decimal STOK_ES_SANAYI { get; set; }
            public decimal STOK_MY { get; set; }
            public decimal STOK_YANSANAYI { get; set; }
            //   public decimal STOK_TOPLAM { get => STOK_OEM + STOK_OES + STOK_ES_SANAYI + STOK_MY + STOK_YANSANAYI; }
            public decimal STOK_TOPLAM { get; set; }
            //      public decimal AMBARCEVIRIM { get; set; }
            public string YEDEKPARCATOPLAM { get; set; }
        }

    }
}