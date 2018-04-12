using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SasonBase.Reports.Sason.Servis
{
    /// <summary>
    ///   Açık İşemirleri İçerisindeki Parça Durumu Raporu
    /// </summary>
    public class SrvsAcikIsEmirleriIcerisindekiParcaDurumlari : Base.SasonReporter
    {
        public SrvsAcikIsEmirleriIcerisindekiParcaDurumlari()
        {
            Text = " Açık İşemirleri İçerisindeki Parça Durumu Raporu ";
            SubjectCode = "SrvsAcikIsEmirleriIcerisindekiParcaDurumlari";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;            
            Disabled = false;
        }
        public SrvsAcikIsEmirleriIcerisindekiParcaDurumlari(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;            
        } 
         
        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {
               
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            string servisIdQuery = $" in( {ServisId} )";

#if DEBUG
             selectedServisId = ServisId;
              servisIdQuery = $" in( {selectedServisId} )";
#endif
             

            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
            SELECT
                    (SELECT vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = p.servisid  and vtsx.dilkod = 'Turkish') as partnercode,
                    (SELECT vtsxy.ISORTAKAD FROM vt_servisler vtsxy where  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = p.servisid) as servisad,
                    a.kod as tur,
                    p.ID,
                    P.AD,
                    p.servisid,
                    p.KOD,
                    p.servisstokturid,
                    REPLACE (TO_CHAR (P.STOKMIKTAR), '.', ',') as STOKMIKTAR,
                    p.BIRIMAD,
                    REPLACE (TO_CHAR (P.INDFIYAT), '.', ',') as EUROINDFIYAT,
                    REPLACE (TO_CHAR (P.FIYAT), '.', ',') as EUROLISTEFIYAT,
                    REPLACE (TO_CHAR (P.ORTALAMAMALIYET), '.', ',') as ORTALAMAMALIYET,
                    p.SERVISDEPOAD,
                    p.SERVISDEPORAFAD,
                    REPLACE (TO_CHAR (p.stokmiktar * p.ortalamamaliyet), '.', ',') as stoktutar
                FROM (SELECT 
                            servisstokturid,
                            a.id,
                            a.servisid,
                            a.kod,
                            k.STOKMIKTAR,
                            r.ad BIRIMAD,
                            kurlar_pkg.servisstokfiyatgetir (a.id, 2, TRUNC (SYSDATE)) as fiyat,
                            KURLAR_PKG.STOKFIYATINDGETIR (a.id, 2, 2, 1,0) as indfiyat,
                            kurlar_pkg.ORTALAMAMALIYET (a.id) ortalamamaliyet,
                            d.ad SERVISDEPOAD,
                            p.ad SERVISDEPOrafAD,
                            a.ad
                        FROM ( SELECT 
                                    DISTINCT servisstokid FROM sason.servisstokhareketdetaylar) h,
                               sason.servisstoklar a,
                               sason.vw_birimler r,
                               sason.servisdepolar d,
                               sason.servisdeporaflar p,
                               (SELECT 
                                    servisstokid, 
                                    SUM (miktar) as stokmiktar
                                FROM servisisemirler e, servisisemirislemler l, servisismislemmalzemeler m
                                WHERE 
                                    e.servisid {servisIdQuery} AND   
                                    e.id = L.SERVISISEMIRID AND
                                    l.id = M.SERVISISEMIRISLEMID AND
                                    E.TEKNIKOLARAKTAMAMLA = 0 AND 
                                    M.durumid=1
                                group by servisstokid) k
                        WHERE 
                            h.servisstokid = a.id AND 
                            (r.dilkod = 'Turkish' or r.dilkod is null) AND 
                            A.SERVISDEPOID = d.id(+) AND            
                            a.servisdeporafid = p.id(+) AND
                            r.id = a.birimid(+) AND 
                            k.servisstokid=a.id AND
                            a.servisid {servisIdQuery}    
                ) p, 
                servisstokturler a
                WHERE   
                        p.servisstokturid = a.id AND 
                        p.servisid  {servisIdQuery}  
                ORDER BY servisad desc
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}