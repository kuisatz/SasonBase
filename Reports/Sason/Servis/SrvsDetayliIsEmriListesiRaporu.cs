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
    ///  Detaylı İş Emri Listesi Raporu
    /// </summary>
    public class SrvsDetayliIsEmriListesiRaporu : Base.SasonReporter
    {
        public SrvsDetayliIsEmriListesiRaporu()
        {
            Text = "Detaylı İş Emri Listesi Raporu";
            SubjectCode = "SrvsDetayliIsEmriListesiRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
       //     AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
        //    AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            Disabled = false;
        }
        public SrvsDetayliIsEmriListesiRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
         
            string servisIdQuery = $" = {ServisId}";
            string dateQuery = "";

//#if DEBUG
//             selectedServisId = ServisId;
//              servisIdQuery = $" in( {selectedServisId} )";
//#endif
  

            StartDate = StartDate.startOfDay(); 
            FinishDate = FinishDate.endOfDay();
            dateQuery = ""+StartDate.ToString("dd/MM/yyyy") +  "' AND '"+ FinishDate.ToString("dd/MM/yyyy")+"";
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
                             SELECT 
                                servisid,
                                partnercode,
                                servisad ,
                                isemirno, 
                                saseno, 
                                kayittarih,
                                tutar,   
                                indirimlitutar, 
                                plaka,    
                                aw,
                                tip,
                                tipkod, 
                                tipaciklama,  
                                tipmiktar,     
                                tiptutar , 
                                tipindirimlitutar, 
                                tipbirimfiyat,
                                (CASE
                                     WHEN isemirtipid = 1
                                         THEN 'BAKIM'
                                     WHEN isemirtipid = 2
                                         THEN 'AKSIYON'
                                     WHEN isemirtipid = 3
                                         THEN 'ONARIM'
                                     WHEN isemirtipid = 4
                                         THEN 'ONARIMKAZA'
                                     WHEN isemirtipid = 5
                                         THEN 'EURO6CBAKIM'
                                     WHEN isemirtipid = 6
                                         THEN '2.ELONARIM'
                                END) AS isemirtip

                        FROM( 
                                SELECT 
                                    a.servisid,
                                    (SELECT vtsx.partnercode FROM vt_servisler vtsx WHERE vtsx.servisid = a.servisid  AND vtsx.dilkod = 'Turkish') AS partnercode,
                                    (SELECT vtsxy.ISORTAKAD FROM vt_servisler vtsxy WHERE  vtsxy.dilkod = 'Turkish' AND vtsxy.servisid = a.servisid   )  AS servisad ,
                                    a.isemirno, 
                                    a.saseno, 
                                    a.kayittarih,
                                    a.tutar,   
                                    a.indirimlitutar, 
                                    a.plaka,    
                                    TO_CHAR((SELECT zx.tutar/10 FROM servisiscilikfiyatlar zx WHERE zx.servisid = a.servisid AND  zx.ayristirmatipid IS NULL )) AS aw,
                                    'iscilik' AS tip ,isciliklerxx.kod AS tipkod, 
                                    isciliklerxx.aciklama AS tipaciklama,  
                                    isciliklerxx.miktar AS tipmiktar,     
                                    isciliklerxx.tutar AS tiptutar , 
                                    isciliklerxx.indirimlitutar AS tipindirimlitutar, 
                                    0 AS tipBIRIMFIYAT,
                                    b.isemirtipid 
                                    FROM servisisemirler a 
                                        INNER JOIN servisisemirislemler b ON a.ID = b.servisisemirid AND b.durumid = 1
                                        LEFT JOIN (
                                            SELECT DISTINCT c1.servisisemirislemid, c1.tutar , c1.aciklama, c1.indirimlitutar, c1.miktar, g1.kod  
                                                    FROM servisismislemiscilikler c1 
                                                        INNER JOIN mt_iscilikler g1 ON  c1.iscilikid = g1.iscilikid AND g1.durumid = c1.durumid 
                                                        LEFT JOIN servisiscilikler h1 ON h1.id = c1.servisiscilikid AND h1.durumid = c1.durumid 
                                                    WHERE c1.durumid = 1 AND   
                                                        g1.dilkod='Turkish' 
                                                    )  isciliklerxx ON b.id = isciliklerxx.servisisemirislemid
                                    WHERE a.KAYITTARIH  BETWEEN   '{dateQuery}'  AND  
                                        a.servisid {servisIdQuery}  
               
                                    UNION
           
                                    SELECT 
                                        a.servisid,
                                        (SELECT vtsx.partnercode from vt_servisler vtsx WHERE vtsx.servisid = a.servisid  AND vtsx.dilkod = 'Turkish') AS partnercode,
                                        (SELECT vtsxy.isortakad FROM vt_servisler vtsxy WHERE  vtsxy.dilkod = 'Turkish' AND vtsxy.servisid = a.servisid   )  AS servisad ,
                                        a.isemirno, 
                                        a.saseno, 
                                        a.kayittarih,
                                        a.tutar,   
                                        a.indirimlitutar, 
                                        a.plaka,    
                                        --to_char((SELECT zx.tutar/10 FROM servisiscilikfiyatlar zx WHERE zx.servisid = a.servisid AND  zx.AYRISTIRMATIPID is null )) AS aw,, 
                                        '' AS aw,        
                                        'malzeme' AS tip , mmalzemelerxx.kod AS mmalzemelerkod , mmalzemelerxx.ad AS mmalzemelerad,  
                                        mmalzemelerxx.miktar AS mmalzemelermiktar, mmalzemelerxx.tutar AS mmalzemelertutar,    
                                        mmalzemelerxx.indirimlitutar AS mmalzemelerindirimlitutar, mmalzemelerxx.malzemebirimfiyat AS birimfiyat,
                                        b.isemirtipid 
                                    FROM servisisemirler a 
                                    INNER JOIN servisisemirislemler b ON a.ID = b.servisisemirid AND b.durumid = 1
                                    LEFT JOIN (
                                        SELECT DISTINCT c2.servisisemirislemid, g2.kod, g2.ad, c2.miktar, c2.malzemebirimfiyat, c2.tutar, c2.indirimlitutar 
                                            FROM servisismislemmalzemeler c2 
                                                    INNER JOIN servisstoklar g2 ON  c2.servisstokid = g2.id 
                                            WHERE 
                                                c2.durumid = 1  
                                            )  mmalzemelerxx ON b.id = mmalzemelerxx.servisisemirislemid        
                                    WHERE a.kayittarih  BETWEEN   '{dateQuery}'  AND 
                                        a.servisid {servisIdQuery} 
               
                                    UNION
                
                                    SELECT 
                                        a.servisid,
                                        (SELECT vtsx.partnercode FROM vt_servisler vtsx WHERE vtsx.servisid = a.servisid  AND vtsx.dilkod = 'Turkish') AS partnercode,
                                        (SELECT vtsxy.ISORTAKAD FROM vt_servisler vtsxy WHERE  vtsxy.dilkod = 'Turkish' AND vtsxy.servisid = a.servisid   )  AS servisad ,
                                        a.isemirno, 
                                        a.saseno, 
                                        a.kayittarih,
                                        a.tutar,   
                                        a.indirimlitutar, 
                                        a.plaka,    
                                        --to_char((SELECT zx.tutar/10 FROM servisiscilikfiyatlar zx WHERE zx.servisid = a.servisid AND  zx.AYRISTIRMATIPID is null )) AS aw,
                                        '' AS aw,             
                                        'kalem' AS tip , kalemlerxx.kod AS kalemlerkod,   
                                        kalemlerxx.acikalama  AS kalemler, kalemlerxx.miktar AS kalemlermiktar,
                                        kalemlerxx.tutar AS kalemlertutar, kalemlerxx.indirimlitutar AS kalemlerindirimlitutar,   
                                        0 AS birimfiyat,
                                        b.isemirtipid 
                                    FROM servisisemirler a 
                                    INNER JOIN servisisemirislemler b ON a.ID = b.servisisemirid AND b.durumid = 1        
                                    LEFT JOIN (
                                        SELECT DISTINCT c3.servisisemirislemid, c3.digerkalemid, g3.kod, c3.tutar, c3.indirimlitutar, c3.miktar, vwd.ad AS acikalama 
                                            FROM SERVISISMISLEMDKALEMLER c3 
                                                    INNER JOIN digerkalemler g3 ON  C3.DIGERKALEMID = g3.id 
                                                    INNER JOIN vw_digerkalemler vwd ON vwd.kod = g3.kod AND vwd.dilid = 0 AND vwd.durumid = 1
                                            WHERE 
                                                c3.DURUMID = 1  
                                                )  kalemlerxx ON b.id=kalemlerxx.servisisemirislemid      
                                    WHERE a.kayittarih BETWEEN   '{dateQuery}'  AND 
                                        a.servisid {servisIdQuery}
                
                                    UNION
                
                                    SELECT 
                                        a.servisid,
                                        (SELECT vtsx.partnercode FROM vt_servisler vtsx WHERE vtsx.servisid = a.servisid  AND vtsx.dilkod = 'Turkish') AS partnercode,
                                        (SELECT vtsxy.ISORTAKAD FROM vt_servisler vtsxy WHERE  vtsxy.dilkod = 'Turkish' AND vtsxy.servisid = a.servisid   )  AS servisad ,
                                        a.isemirno, 
                                        a.saseno, 
                                        a.kayittarih,
                                        a.tutar,   
                                        a.indirimlitutar, 
                                        a.plaka,    
                                        --to_char((SELECT zx.tutar/10 FROM servisiscilikfiyatlar zx WHERE zx.servisid = a.servisid AND  zx.AYRISTIRMATIPID IS NULL )) AS aw,
                                        '' AS aw,  
                                        'hizmet' AS tip , '' kod , 
                                        hizmetlerxx.aciklama AS hizmetleraciklama, 0 AS miktar, hizmetlerxx.tutar AS hizmetlertutar, 
                                        hizmetlerxx.indirimlitutar AS hizmetlerindirimlitutar , 0  AS birimfiyat,
                                        b.isemirtipid 
                                    FROM servisisemirler a 
                                        INNER JOIN servisisemirislemler b ON a.ID = b.servisisemirid AND b.durumid = 1                   
                                        LEFT JOIN (
                                            SELECT DISTINCT c4.servisisemirislemid, c4.aciklama, c4.tutar, c4.indirimlitutar 
                                            FROM SERVISISMISLEMDHIZMETLER c4         
                                            WHERE 
                                                c4.DURUMID = 1  
                                                    )  hizmetlerxx ON b.id=hizmetlerxx.servisisemirislemid  
                                    WHERE a.kayittarih BETWEEN   '{dateQuery}'  AND 
                                        a.servisid {servisIdQuery}
                                ) asd
                                WHERE tiptutar IS NOT NULL 
                        ORDER BY asd.servisid , asd.isemirno,tip
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}