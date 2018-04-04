using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace SasonBase.Reports.KartOkutma
{
    /// <summary>
    /// Merkez Yedek Parça Faaliyet Raporu
    /// </summary>
    public class KO_TeknisyenDurumBilgisiNow:Base.KartOkutmaReporter
    {
        public KO_TeknisyenDurumBilgisiNow()
        {
            Text = "Teknisyen Durum Bilgileri";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name; 

        }
          
        public override object ExecuteReport(MethodReturn refMr = null)
        {
 

            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"
            SELECT 
                a.SERVISID, 
                MAX(a.id) maxid, 
                b.teknisyenid, 
                a.giristarihi,
                a.CIKISTARIHI,  
                a.ISEMIRISLEMID,
                a.ISEMIRID,  
                concat(concat(c.ad,' ') ,c.soyad) as adsoyad,
                sse.ISEMIRNO,
                sse.SASENO,
                sse.plaka,
                SSE.KAYITTARIH,
                SSE.MUSTERIAD,
                CASE 
                    WHEN a.CIKISTARIHI > '01.01.2000' THEN cast(EXTRACT(MINUTE FROM (a.CIKISTARIHI - a.giristarihi) DAY TO SECOND)|| ' dk ' as  NVARCHAR2(50)) 
                    ELSE cast('Devam Ediyor...'as  NVARCHAR2(50)) END as Durum, 
                (SELECT isem.aciklama FROM servisisemirler isem WHERE isem.id = a.ISEMIRID) as emir,
                (SELECT isemis.aciklama FROM servisisemirislemler isemis WHERE isemis.id = (SELECT isemx.id FROM servisisemirler isemx WHERE isemx.id = a.ISEMIRID )) as islem 
            FROM teknisyenhareket a 
            INNER JOIN servisteknisyenler b ON b.servisid = a.servisid and b.id = a.servisteknisyenid 
            INNER JOIN teknisyenler c ON c.id = b.teknisyenid  
            INNER JOIN THRKNEDEN d ON d.id = a.girisnedenid  
            INNER JOIN THRKNEDEN dx ON dx.id = a.cikisnedenid  
            INNER JOIN servisisemirler sse ON sse.id = a.ISEMIRID     
            WHERE 
                a.SERVISID = {{ServisId}} and 
                a.id = (SELECT MAX(xx.id) FROM  teknisyenhareket xx WHERE xx.servisteknisyenid  = a.servisteknisyenid)
            GROUP BY a.SERVISID, a.id, b.teknisyenid, a.giristarihi, a.CIKISTARIHI, A.ISEMIRISLEMID, a.ISEMIRID, c.ad, c.soyad, sse.ISEMIRNO, sse.SASENO, sse.plaka, SSE.KAYITTARIH, SSE.MUSTERIAD
            ORDER BY a.SERVISID, c.ad, c.soyad, a.id DESC 
 
            
            ")
            .Parameter("ServisId", ServisId  )
            .GetDataTable(mr)
            .ToModels();



            CloseCustomAppPool();
            return queryResults;
        }

    }
}