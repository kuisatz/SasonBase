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
    ///  Stok Raporu
    /// </summary>
    public class SrvsOluStokRaporu : Base.SasonReporter
    {
        public SrvsOluStokRaporu()
        {
            Text = "Ölü Stok Raporu";
            SubjectCode = "SrvsOluStokRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Tarih" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_tarih_grup", Text = "Tarih Aralığı" }.CreateTarihGrupSelect(false));

            Disabled = false;
        }
        public SrvsOluStokRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
            this.StartDate = startDate; 
        }

        public DateTime StartDate
        {
            get { return GetParameter("param_start_date").ReporterValue.cast<DateTime>(); }
            set { SetParameterReporterValue("param_start_date", value.startOfDay()); }
        }
        public List<decimal> TarihGrupIds
        {
            get { return GetParameter("param_tarih_grup").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_tarih_grup", value); }
        }



        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {
                //Dışarıdan Gelen Format 20171231235959 Şeklinde Olmalıdır
                case "param_start_date":
                    StartDate = Convert.ToInt64(value).toDateTime(); 
                    break;
                case "param_tarih_grup":
                    TarihGrupIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
         
            string servisIdQuery = $" = {ServisId}";
            string dateQuery = "";
            decimal TarihGrupId = TarihGrupIds.first().toString("0").cto<decimal>();
            string dateBetweenQuery = "";
            string dateBetweenQuery2 = "";

            StartDate = StartDate.startOfDay();

            dateQuery = "to_date('" + StartDate.ToString("dd/MM/yyyy") + "')";

            if (TarihGrupId > 0)
            {
                dateBetweenQuery = " AND TO_DATE(sysdate, 'DD/MM/YYYY') - TO_DATE(ssh.TARIH, 'DD/MM/YYYY')  <= " + TarihGrupId.ToString();
                dateBetweenQuery2 = " AND TO_DATE(sysdate, 'DD/MM/YYYY') - TO_DATE(KayitTARIH, 'DD/MM/YYYY')  <= " + TarihGrupId.ToString();
            }

            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
                    
                    SELECT   distinct p.STOKISLEMTIPDEGER,
                        (select vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = p.HSERVISID  and vtsx.dilkod = 'Turkish') as partnercode,
                        (Select vtsxy.ISORTAKAD FROM vt_servisler vtsxy where  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = p.HSERVISID )  as servisad,

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
                     
                  FROM(SELECT servisstokturid, h.STOKISLEMTIPDEGER,
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

                          FROM(
                                  SELECT DISTINCT *
                                  FROM sason.servisstokhareketdetaylar sshd
                                  inner join  servisstokhareketler ssh on ssh.id = sshd.servisstokhareketid
                                  where  sshd.STOKISLEMTIPDEGER != -1 AND 
                                         ssh.servisid {servisIdQuery} 
                                         {dateBetweenQuery} 

                                ) h,
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
                                                                   FROM servisstokhareketdetaylar sshd,
                                                                        servisstokhareketler ssh
                                                                  WHERE 
                                                                        sshd.STOKISLEMTIPDEGER != -1 AND
                                                                        ssh.id = sshd.SERVISSTOKHAREKETID AND
                                                                        sshd.servisdepoid NOT IN(21, 22) AND
                                                                        ssh.servisid  {servisIdQuery} 
                                                                        {dateBetweenQuery} 
                                                        )
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
                                                                AND c.servisid {servisIdQuery} 
                                                                {dateBetweenQuery2} 
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
                               AND r.id = a.birimid
                               /*****************************************/
                               
                                and 
                    a.id not in
                    (
                     
                    SELECT  distinct --  p.STOKISLEMTIPDEGER, 
                       p.ID  
                  FROM(SELECT servisstokturid, h.STOKISLEMTIPDEGER,
                               a.id,
                               a.servisid hservisid,
                               a.kod,
                               C.STOKMIKTAR 
                             
                          FROM(
                                  SELECT DISTINCT *
                                  FROM sason.servisstokhareketdetaylar sshd
                                  inner join  servisstokhareketler ssh on ssh.id = sshd.servisstokhareketid
                                  where 
                                         SSHD.STOKISLEMTIPDEGER = -1 AND  
                                         ssh.servisid {servisIdQuery}   
                                        {dateBetweenQuery} 

                                ) h,
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
                                                                   FROM servisstokhareketdetaylar sshd,
                                                                        servisstokhareketler ssh
                                                                  WHERE ssh.id = sshd.SERVISSTOKHAREKETID AND
                                                                        sshd.servisdepoid NOT IN(21, 22) AND
                                                                        SSHD.STOKISLEMTIPDEGER = -1 AND 
                                                                        ssh.servisid {servisIdQuery} 
                                                                        {dateBetweenQuery} 
                                                        )
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
                                                                AND c.servisid {servisIdQuery} 
                                                               {dateBetweenQuery2} 
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
                               AND r.id = a.birimid 
                               AND a.servisid {servisIdQuery} 
                           
                        ) p,
                       servisstokturler a
                 WHERE
                    p.servisstokturid = a.id AND hservisid {servisIdQuery}    
                    
                    ) 
                               /******************************************/
                               
                               
                               
                           
                        ) p,
                       servisstokturler a
                 WHERE
                    p.servisstokturid = a.id AND hservisid {servisIdQuery}  AND
                    P.STOKMIKTAR> 0
                    -- AND p.STOKISLEMTIPDEGER != -1
 
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}