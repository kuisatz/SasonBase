﻿using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SasonBase.Reports.Sason.Merkez
{
    /// <summary>
    /// Merkez Stok Raporu
    /// </summary>
    public class MrkzStokRaporu : Base.SasonMerkezReporter
    {
        public MrkzStokRaporu()
        {
            Text = "[YP-9] Stok Raporu";
            SubjectCode = "MrkzStokRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Tarih" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));           
            Disabled = false;
        }
        public MrkzStokRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
            this.StartDate = startDate; 
        }

        public DateTime StartDate
        {
            get { return GetParameter("param_start_date").ReporterValue.cast<DateTime>(); }
            set { SetParameterReporterValue("param_start_date", value.startOfDay()); }
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
              servisIdQuery = $" in( {selectedServisId} )";
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
            dateQuery = "to_date('" + StartDate.ToString("dd/MM/yyyy") + "')";

            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"   
                    SELECT 
                        p.HSERVISID, (select vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = p.HSERVISID  and vtsx.dilkod = 'Turkish') as partnercode,
                        (Select vtsxy.ISORTAKAD FROM vt_servisler vtsxy where  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = p.HSERVISID   )  as servisad,
          
                       a.kod tur,
                       p.ID,
                       P.AD,
                       p.HSERVISID,
                       p.KOD,
                       p.servisstokturid,
                       P.STOKMIKTAR STOKMIKTAR,
                       p.BIRIMAD,
                       P.INDFIYAT EUROINDFIYAT,
                       P.FIYAT EUROLISTEFIYAT,
                       P.ORTALAMAMALIYET ORTALAMAMALIYET,
                       p.SERVISDEPOAD,
                       p.SERVISDEPORAFAD,
                       p.stokmiktar * p.ortalamamaliyet stoktutar,
                       p.orjinalkod
                  FROM(SELECT servisstokturid,
                               a.id,
                               a.servisid hservisid,
                               a.kod,
                               C.STOKMIKTAR,
                               r.ad BIRIMAD,
                               kurlar_pkg.servisstokfiyatgetir(a.id, 2, TRUNC({dateQuery}))
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
                               a.ad, 
                               CASE
                                 WHEN (SELECT orjinalmalzemeid
                                         FROM malzemeler
                                        WHERE id = a.malzemeid)
                                         IS NULL
                                 THEN
                                        ''
                                 ELSE
                                    (SELECT CONCAT ('', gkod)
                                       FROM malzemeler
                                      WHERE id = (SELECT orjinalmalzemeid
                                                    FROM malzemeler
                                                   WHERE id = a.malzemeid))
                              END
                                 orjinalkod
                             
                          FROM(SELECT DISTINCT servisstokid
                                  FROM sason.servisstokhareketdetaylar) h,
                               sason.servisstoklar a,
                               -- sason.vt_genelstok c, 
                                ( 
                                        SELECT CASE
                                                 WHEN servisstokid IS NULL THEN 0 - ambarstokmiktar
                                                 ELSE stokmiktar
                                              END
                                                 stokmiktar,
                                              CASE
                                                 WHEN servisstokid IS NULL THEN ambarstokid
                                                 ELSE servisstokid
                                              END
                                                 servisstokid,
                                              servisid
                                         FROM (SELECT a.stokmiktar - NVL (b.stokmiktar, 0) stokmiktar,
                                                      a.servisstokid,
                                                      b.servisstokid ambarstokid,
                                                      b.stokmiktar ambarstokmiktar,
                                                      a.servisid
                                                 FROM (  SELECT SUM (stokmiktar) STOKMIKTAR,
                                                                servisid,
                                                                servisstokid
                                                           FROM(SELECT servisid,
                                                                        servisstokid,
                                                                        amiktar * stokislemtipdeger STOKMIKTAR
                                                                   FROM servisstokhareketdetaylar s,
                                                                        servisstokhareketler h
                                                                  WHERE     h.id = S.SERVISSTOKHAREKETID
                                                                        AND s.servisdepoid NOT IN(21, 22))
                                                       GROUP BY servisid, servisstokid) a
                                                      FULL OUTER JOIN
                                                      (SELECT SUM (a.miktar) stokmiktar,
                                                                a.servisstokid,
                                                                c.servisid
                                                           FROM servisismislemmalzemeler a,
                                                                servisisemirislemler b,
                                                                servisisemirler c
                                                          WHERE c.id = b.servisisemirid
                                                                AND b.id = A.SERVISISEMIRISLEMID
                                                                AND a.durumid = 1
                                                                AND c.teknikolaraktamamla = 0
                                                       GROUP BY servisstokid, servisid) b
                                                 ON(a.servisstokid = b.servisstokid))
                                            ) c,    
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
                 order by  p.HSERVISID 
  
                ")
              .GetDataTable(mr)
            .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}