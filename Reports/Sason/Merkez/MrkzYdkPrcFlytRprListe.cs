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
    public class MrkzYdkPrcFlytRprListe : Base.SasonMerkezReporter
    {
        public MrkzYdkPrcFlytRprListe()
        {
            Text = "Yedek Parça Faliyet Raporu";
            SubjectCode = "MrkzYdkPrcFlytRprListe";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            Disabled = false;
        }
        public MrkzYdkPrcFlytRprListe(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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

            //if (ServisIds.isNotEmpty())
            //    servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            //else
            //    servisIdQuery = $" > 1 ";


            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";

            MethodReturn mr = new MethodReturn();
            List<ReportData> reportDataSource = new List<ReportData>();
            //     List<QueryResult> queryResults = AppPool.EbaTestConnector.CreateQuery($@"
            QueryResult qr = new QueryResult();

            #region query1
            //QueryResult qr = new QueryResult();
            List<QueryResultStok> queryStok = AppPool.EbaTestConnector.CreateQuery($@"
                    select    
                        sum(nvl(stok_oes,0)) as stok_oes,
                        sum(nvl(stok_oeM,0)) as stok_oeM,
                        sum(nvl(stok_essanayi,0)) as stok_essanayi,
                        sum(nvl(stok_my,0)) as stok_my,
                        
                           sum(nvl(stok_yag,0)) as stok_yag,
                        sum(nvl(stok_yansanayi,0)) as stok_yansanayi, 
                        sum(nvl(stok_yag,0) + nvl(stok_oes,0) +nvl(stok_oeM,0) + nvl(stok_essanayi,0) + nvl(stok_my,0) +nvl(stok_yansanayi,0)) as stok_toplam
                      FROM (
                      
                       SELECT   
                                
                                case SERVISSTOKTURID 
                                        when 1 then  sum(nvl(ORTALAMAMALIYET,0) * STOKMIKTAR)  
                                     end   as stok_oem,
                                case SERVISSTOKTURID 
                                        when 6 then  sum(nvl(ORTALAMAMALIYET,0)*STOKMIKTAR)  
                                     end   as stok_yag,
                                case SERVISSTOKTURID  
                                        when 7 then  sum(nvl(ORTALAMAMALIYET,0) * STOKMIKTAR)                               
                                     end   as stok_oes,  
                                case SERVISSTOKTURID  
                                        when 8 then  sum(nvl(ORTALAMAMALIYET,0)*STOKMIKTAR)  
                                     end   as stok_essanayi, 
                                case SERVISSTOKTURID  
                                        when 9 then  sum(nvl(ORTALAMAMALIYET,0)*STOKMIKTAR)  
                                     end   as stok_yansanayi,              
                                case SERVISSTOKTURID  
                                        when 11 then sum(nvl(ORTALAMAMALIYET,0) *STOKMIKTAR) 
                                     end   as stok_my
                              FROM( 
 SELECT 
                       a.kod tur,p.fiyat,
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
                               r.ad BIRIMAD,
                               kurlar_pkg.servisstokfiyatgetir(a.id, 2, TRUNC(SYSDATE))
                                  fiyat,
                               KURLAR_PKG.STOKFIYATINDGETIR(a.id,
                                                             2,
                                                             2,
                                                             1,
                                                             0)
                                  indfiyat,
                               kurlar_pkg.ORTALAMAMALIYET(a.id) ortalamamaliyet,
                               d.ad SERVISDEPOAD,
                               p.ad SERVISDEPOrafAD,
                               a.ad
                          FROM(SELECT DISTINCT servisstokid
                                  FROM sason.servisstokhareketdetaylar) h,
                               sason.servisstoklar a,
                               sason.vt_genelstok c,
                               sason.vw_birimler r,
                               sason.servisdepolar d,
                               sason.servisdeporaflar p
                         WHERE     h.servisstokid = a.id
                               AND A.ID = C.SERVISSTOKID
                               AND C.STOKMIKTAR <> 0
                               AND a.servisid = c.servisid
                               AND r.dilkod = 'Turkish'
                               AND A.SERVISDEPOID = d.id(+)
                               AND a.servisdeporafid = p.id(+)
                               AND r.id = a.birimid) p,
                       servisstokturler a
                 WHERE p.servisstokturid = a.id AND hservisid {servisIdQuery} 
                 ) asd 
                 group by SERVISSTOKTURID 
              ) asasd
                        
   
                ")
            .GetDataTable(mr)
            .ToModels<QueryResultStok>();
            #endregion

            ReportData reportData = new ReportData();
            reportData.queryrStk = queryStok;
            //  string YEDEKPARCATOPLAM1 = (reportData.queryr[0].SERVISICITOPLAM + reportData.queryr[0].SERVISDISITOPLAM).toString();

            decimal stok_oesx  = Convert.ToDecimal( (reportData.queryrStk[0].STOK_OES).toString() );
            decimal stok_oeMx = Convert.ToDecimal((reportData.queryrStk[0].STOK_OEM).toString() );
            decimal stok_essanayix = Convert.ToDecimal((reportData.queryrStk[0].STOK_ES_SANAYI).toString() );
            decimal stok_myx = Convert.ToDecimal((reportData.queryrStk[0].STOK_MY).toString() ) ;
            decimal stok_yansanayix = Convert.ToDecimal((reportData.queryrStk[0].STOK_YANSANAYI).toString() );
            decimal stok_toplamx = Convert.ToDecimal((reportData.queryrStk[0].STOK_TOPLAM).toString() );
            #region query2
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"                 
            SELECT  {ServisId}  as servisid1,    
                (Select ISORTAKAD FROM vt_servisler servis where  servis.dilkod = 'Turkish' and servis.servisid  {servisIdQuery}  and rownum < 2)  as servisad, 
            ---------- stok
                ROUND (NVL(replace('{stok_toplamx}','.',','),'0'),2) as stok_toplam, 
                ROUND (NVL(replace('{stok_oesx}','.',','),'0'),2)  as stok_oes,
                ROUND (NVL(replace('{stok_oeMx}','.',','),'0'),2)  as stok_oeM,
                ROUND (NVL(replace('{stok_essanayix}','.',','),'0'),2)  as stok_essanayi,
                ROUND (NVL(replace('{stok_myx}','.',','),'0'),2)  as stok_my,
                ROUND (NVL(replace('{stok_yansanayix}','.',','),'0'),2)  as stok_yansanayi,  
                servisicioem,
                servisicioes,
                servisiciesdeger,
                servisicimyok,
                servisicitoplam,
                servisiciuygunparca,
                servisiciucretliuygunparca,
                servisicigaranti,

                servisicioem2el,
                servisicioes2el,
                servisiciesdeger2el,
                servisiciyansanayi2el,
                servisicimyok2el,
                servisicitoplam2el,
                servisiciuygunparca2el,
                servisiciucretliuygunparca2el,
                servisicigaranti2el,

                servisdisioem,
                servisdisioes,
                servisdisiesdeger,
                servisdisimyok ,
                servisdisitoplam,
                servisdisiystoplam,
                servisdisiuygunparca,

                servisiciyansanayi,
                servisdisiyansanayi,
                servisiciyansanayitoplam,
                servisdisiyansanayitoplam,

                servisiciyag,
                servisiciyag2el,
                servisdisiyag,
                yagtoplam,
                sum (NVL(servisicitoplam,0) + NVL(servisdisitoplam,0)) as yedekparcatoplami ,
                sum (NVL(servisicitoplam,0) + NVL(servisdisitoplam,0))    as ambar,
                BAKIMPAKETI ,
                uukko  
               

                FROM (
                    SELECT distinct
                    ---- servis içi   --  isemirtipi != 6 olanlar  burada olacak olmayanlar  asagıya eklenecek
                        sum(NVL(servisicioem,0)) as servisicioem,
                        sum(NVL(servisicioes,0)) as servisicioes,
                        sum(NVL(servisiciesdeger,0)) as servisiciesdeger,
                        sum(NVL(servisicimyok,0)) as servisicimyok,
                        sum(NVL(servisicioem,0)+NVL(servisicioes,0)+NVL(servisiciesdeger,0)+NVL(servisiciyansanayi,0)+NVL(servisicimyok,0)) as servisicitoplam,
                        sum(NVL(servisicioem,0)+NVL(servisicioes,0)+NVL(servisiciesdeger,0)) as servisiciuygunparca,
                        sum (NVL(servisiciucretliuygunparca,0)) as servisiciucretliuygunparca,
                        sum(NVL(servisicigaranti,0)) as servisicigaranti, ---- bunun içindeki  bakım pakeytiini hesapla asagıya ekle
                         ---- servis içi 2 el   --  isemirtipi = 6 olanlar  burada olacak
                        sum(NVL(servisicioem2el,0)) as servisicioem2el,
                        sum(NVL(servisicioes2el,0)) as servisicioes2el,
                        sum(NVL(servisiciesdeger2el,0)) as servisiciesdeger2el,
                        sum(NVL(servisicimyok2el,0)) as servisiciyansanayi2el,
                        sum(NVL(servisicimyok2el,0)) as servisicimyok2el,
                        sum(NVL(servisicioem2el,0)+NVL(servisicioes2el,0)+NVL(servisiciesdeger2el,0)+NVL(servisiciyansanayi2el,0)+NVL(servisicimyok2el,0)) as servisicitoplam2el,
                        sum(NVL(servisicioem2el,0)+NVL(servisicioes2el,0)+NVL(servisiciesdeger2el,0)) as servisiciuygunparca2el,
                        sum(NVL(servisiciucretliuygunparca2el,0)) as servisiciucretliuygunparca2el,
                        sum(NVL(servisicigaranti2el,0)) as servisicigaranti2el, ---- bunun içindeki  bakım pakeytiini hesapla asagıya ekle
                        ---- servis dısı
                        sum(NVL(servisdisioem,0)) as servisdisioem,
                        sum(NVL(servisdisioes,0)) as servisdisioes,
                        sum(NVL(servisdisiesdeger,0)) as servisdisiesdeger,
                        sum(NVL(servisdisimyok,0)) as servisdisimyok ,
                        sum(NVL(servisdisioem,0)+NVL(servisdisioes,0)+NVL(servisdisiesdeger,0)+NVL(servisdisiyansanayi,0)+NVL(servisdisimyok,0)) as servisdisitoplam,
                        sum(NVL(servisdisiyansanayi,0)+NVL(servisdisimyok,0)) as servisdisiystoplam,
                        sum(NVL(servisdisioem,0)+NVL(servisdisioes,0)+NVL(servisdisiesdeger,0)) as servisdisiuygunparca,
                        ------ yan sanayi
                        sum(NVL(servisiciyansanayi,0)) as servisiciyansanayi,
                        sum(NVL(servisdisiyansanayi,0)) as servisdisiyansanayi,
                        sum(NVL(servisiciyansanayi,0)+NVL(servisicimyok,0)) as servisiciyansanayitoplam,
                        sum(NVL(servisdisiyansanayi,0)+NVL(servisdisimyok,0)) as servisdisiyansanayitoplam,
                        -------- yağ
                        sum(NVL(servisiciyag,0)) as servisiciyag,
                        sum(NVL(servisiciyag2el,0)) as servisiciyag2el,
                        sum(NVL(servisdisiyag,0)) as servisdisiyag,
                        sum(NVL(servisiciyag,0)+NVL(servisdisiyag,0)) as yagtoplam,
                     --   ,servisid
                        sum(NVL(BAKIMPAKETI,0)) as BAKIMPAKETI  ,
                        sum(nvl(uukko,0)) as uukko
                   FROM (
                        SELECT distinct
                            SERVISSTOKTURID,
                            case BELGETURU
                                when 'İş Emri' then
                                      case SERVISSTOKTURID
                                        when 1 then
                                             case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                         end
                                end as servisicioem,
                            case BELGETURU
                                when 'İş Emri' then
                                  case SERVISSTOKTURID
                               --     when 7 then sum(TUTAR)
                                    WHEN 7 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                     end
                                end as servisicioes,
                            case BELGETURU
                                when 'İş Emri' then
                                  case SERVISSTOKTURID
                                    -- when 6 then sum(TUTAR)
                                     WHEN 6 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                     end
                                end as  servisiciyag,
                            case BELGETURU
                                when 'İş Emri' then
                                  case SERVISSTOKTURID
                                    --when 8 then sum(TUTAR)
                                     WHEN 8 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                     end
                                end as   servisiciesdeger,
                            case BELGETURU
                                when 'İş Emri' then
                                  case SERVISSTOKTURID
                                    -- when 9 then sum(TUTAR)
                                     WHEN 9 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                     end
                                end as servisiciyansanayi,
                            case BELGETURU
                                when 'İş Emri' then
                                  case SERVISSTOKTURID
                                    --when 11 then sum(TUTAR)
                                     WHEN 11 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                     end
                                end as servisicimyok,
                            ---------------------
                            case BELGETURU
                                when 'Direk Satış' then
                                  case SERVISSTOKTURID
                                      when 1 then sum(TUTAR)
                                     end
                                end as servisdisioem,
                            case BELGETURU
                                when 'Direk Satış' then
                                  case SERVISSTOKTURID
                                    when 7 then sum(TUTAR)
                                     end
                                end as servisdisioes,
                            case BELGETURU
                                when 'Direk Satış' then
                                  case SERVISSTOKTURID
                                     when 6 then sum(TUTAR)
                                     end
                                end as  servisdisiyag,
                            case BELGETURU
                                when 'Direk Satış' then
                                  case SERVISSTOKTURID
                                     when 8 then sum(TUTAR)
                                     end
                                end as   servisdisiesdeger,
                            case BELGETURU
                                when 'Direk Satış' then
                                  case SERVISSTOKTURID
                                     when 9 then sum(TUTAR)
                                     end
                                end as   servisdisiyansanayi,
                            case BELGETURU
                                when 'Direk Satış' then
                                  case SERVISSTOKTURID
                                     when 11 then sum(TUTAR)
                                     end
                                end as servisdisimyok,

                            ----------------------------------------------------------------------- servis içi uygun parca
                            case AYRISTIRMATIPAD
                                    when 'HARICI' then
                                            case BELGETURU
                                                when 'İş Emri' then
                                                          case SERVISSTOKTURID
                                                            --when 1 then sum(TUTAR)
                                                            WHEN 1 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                                            --when 7 then sum(TUTAR)
                                                            WHEN 7 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                                            -- when 8 then sum(TUTAR)
                                                            WHEN 8 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END

                                                        end
                                            end
                                    when 'DAHILI' then
                                             case BELGETURU
                                                when 'İş Emri' then
                                                   case SERVISSTOKTURID
                                                            --when 1 then sum(TUTAR)
                                                            WHEN 1 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                                            -- when 7 then sum(TUTAR)
                                                            WHEN 7 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                                            -- when 8 then sum(TUTAR)
                                                            WHEN 8 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END

                                                    end
                                              end
                                end as servisiciucretliuygunparca,
                                 ----------------------------------------------------------------------- xxxxxxxxxxxxxxxxxxxx uukko
                            case AYRISTIRMATIPAD
                                    when 'HARICI' then
                                            case BELGETURU
                                                when 'İş Emri' then
                                                          case SERVISSTOKTURID
                                                            --when 1 then sum(TUTAR)
                                                            WHEN 1 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                                            --when 7 then sum(TUTAR)
                                                            WHEN 7 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                                            -- when 8 then sum(TUTAR)
                                                            WHEN 8 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                                            
                                                        end
                                            end
                                    when 'DAHILI' then
                                             case BELGETURU
                                                when 'İş Emri' then
                                                   case SERVISSTOKTURID
                                                            --when 1 then sum(TUTAR)
                                                            WHEN 1 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                                            -- when 7 then sum(TUTAR)
                                                            WHEN 7 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                                            -- when 8 then sum(TUTAR)
                                                            WHEN 8 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                                            
                                                    end
                                              end
                                end as uukko,

                            case AYRISTIRMATIPAD
                                    when 'HARICI' then
                                            case BELGETURU
                                                when 'İş Emri' then
                                                          case SERVISSTOKTURID
                                                            when 1 then 0
                                                            when 7 then 0
                                                            when 8 then 0
                                                        end
                                            end
                                    when 'DAHILI' then
                                             case BELGETURU
                                                when 'İş Emri' then
                                                   case SERVISSTOKTURID
                                                            when 1 then 0
                                                            when 7 then 0
                                                            when 8 then 0
                                                    end
                                              end

                                else  case BELGETURU
                                                when 'İş Emri' then
                                                          case SERVISSTOKTURID
                                                           -- when 1 then sum(TUTAR)
                                                            WHEN 1 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                                            -- when 7 then sum(TUTAR)
                                                        --    WHEN 7 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                                           -- when 8 then sum(TUTAR)
                                                        --    WHEN 8 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                                        end
                                            end
                                end as servisicigaranti,
                                     ----------------------------------------------------------------------- servis içi  garanti
                            case AYRISTIRMATIPAD
                                    when 'BAKIMPAKETI' then
                                            case ISCILIK_PARCA
                                                when 'Malzeme' then                                                     
                                                                  case SERVISSTOKTURID                                  
                                                                    WHEN 1 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN 0 else sum(TUTAR)  END
                                                                 end

                                              end
                                end as BAKIMPAKETI,


                             -------------------------------**************************
                               case BELGETURU
                                when 'İş Emri' then
                                      case SERVISSTOKTURID
                                        when 1 then
                                             case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                         end

                                end as servisicioem2el,
                            case BELGETURU
                                when 'İş Emri' then
                                  case SERVISSTOKTURID
                               --     when 7 then sum(TUTAR)
                                    WHEN 7 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                     end
                                end as servisicioes2el,
                            case BELGETURU
                                when 'İş Emri' then
                                  case SERVISSTOKTURID
                                    -- when 6 then sum(TUTAR)
                                     WHEN 6 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                     end
                                end as  servisiciyag2el,
                            case BELGETURU
                                when 'İş Emri' then
                                  case SERVISSTOKTURID
                                    --when 8 then sum(TUTAR)
                                     WHEN 8 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                     end
                                end as   servisiciesdeger2el,
                            case BELGETURU
                                when 'İş Emri' then
                                  case SERVISSTOKTURID
                                    -- when 9 then sum(TUTAR)
                                     WHEN 9 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                     end
                                end as   servisiciyansanayi2el,
                            case BELGETURU
                                when 'İş Emri' then
                                  case SERVISSTOKTURID
                                    --when 11 then sum(TUTAR)
                                     WHEN 11 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                     end
                                end as servisicimyok2el   ,
                                  case AYRISTIRMATIPAD
                                    when 'HARICI' then
                                            case BELGETURU
                                                when 'İş Emri' then
                                                          case SERVISSTOKTURID
                                                            --when 1 then sum(TUTAR)
                                                            WHEN 1 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                                            --when 7 then sum(TUTAR)
                                                            WHEN 7 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                                            -- when 8 then sum(TUTAR)
                                                            WHEN 8 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                                        end
                                            end
                                    when 'DAHILI' then
                                             case BELGETURU
                                                when 'İş Emri' then
                                                   case SERVISSTOKTURID
                                                            --when 1 then sum(TUTAR)
                                                            WHEN 1 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                                            -- when 7 then sum(TUTAR)
                                                            WHEN 7 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                                            -- when 8 then sum(TUTAR)
                                                            WHEN 8 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                                    end
                                              end
                                end as servisiciucretliuygunparca2el,
                                  case AYRISTIRMATIPAD
                                    when 'HARICI' then
                                            case BELGETURU
                                                when 'İş Emri' then
                                                          case SERVISSTOKTURID
                                                            when 1 then 0
                                                            when 7 then 0
                                                            when 8 then 0
                                                        end
                                            end
                                    when 'DAHILI' then
                                             case BELGETURU
                                                when 'İş Emri' then
                                                   case SERVISSTOKTURID
                                                            when 1 then 0
                                                            when 7 then 0
                                                            when 8 then 0
                                                    end
                                              end

                                else  case BELGETURU
                                                when 'İş Emri' then
                                                          case SERVISSTOKTURID
                                                           -- when 1 then sum(TUTAR)
                                                            WHEN 1 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                                            -- when 7 then sum(TUTAR)
                                                            WHEN 7 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                                           -- when 8 then sum(TUTAR)
                                                            WHEN 8 THEN  case ISEMIRTIPI  WHEN '2. EL ONARIM' THEN sum(TUTAR) else 0  END
                                                        end
                                            end
                                end as servisicigaranti2el

                          from (
                             select distinct * from sason.rptable_yedekparcadetay t
                              where
                                t.servisid {servisIdQuery} and                                 
                                t.tarih BETWEEN '{dateQuery}' 

                    ) rpt
                    group by  SERVISSTOKTURID,BELGETURU,AYRISTIRMATIPAD,ISEMIRTIPI ,ISCILIK_PARCA
                ) ert
            ) dsf

            group by  --- stok_oes,  stok_oeM, stok_essanayi, stok_my, stok_yansanayi, stok_toplam,
                servisicioem,  servisicioes,  servisiciesdeger, servisicimyok,  servisicitoplam,  servisiciuygunparca,
                servisiciucretliuygunparca, servisicigaranti,  servisicioem2el,   servisicioes2el,
                servisiciesdeger2el,  servisiciyansanayi2el,  servisicimyok2el,
                servisicitoplam2el,  servisiciuygunparca2el, servisiciucretliuygunparca2el,
                servisicigaranti2el,  servisdisioem, servisdisioes,  servisdisiesdeger,
                servisdisimyok , servisdisitoplam, servisdisiystoplam, servisdisiuygunparca,
                servisiciyansanayi, servisdisiyansanayi, servisiciyansanayitoplam, servisdisiyansanayitoplam,
                servisiciyag, servisiciyag2el, servisdisiyag, yagtoplam  ,BAKIMPAKETI, uukko

 
 
 
 
                ")
         //     .Parameter("stok_oesx", stok_oesx)
         //     .Parameter("stok_oeMx", stok_oeMx)
         //     .Parameter("stok_essanayix", stok_essanayix)
        //      .Parameter("stok_myx", stok_myx)
        //      .Parameter("stok_yansanayix", stok_yansanayix)
          //     .Parameter("stok_toplamx", stok_toplamx)
             .GetDataTable(mr)

                //  .ToModels<QueryResult>();                
            .ToModels();
            #endregion


            // reportDataSource.add(reportData);
            //     reportData.AMBARCEVIRIM = (reportData.queryr[0].YEDEKPARCATOPLAM / reportData.queryrStk[0].STOK_TOPLAM) * 12;

            CloseCustomAppPool();
          //  return reportData;
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