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
    ///  Araç Tipi Özet Raporu
    /// </summary>
    public class MrkzAracTipiOzetBilgisi : Base.SasonMerkezReporter
    {
        public MrkzAracTipiOzetBilgisi()
        {
            Text = "[VIS-2] Araç Tipi Özet Raporu";
            SubjectCode = "MrkzAracTipiOzetBilgisi";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;            
            AddParameter(new ReporterParameter() { Name = "param_aractip", Text = "Araç Tipi" }.CreateAracTipSelect(true));
            Disabled = false;
        }
        public MrkzAracTipiOzetBilgisi(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
        }

        public List<decimal> AracTipIds
        {
            get { return GetParameter("param_aractip").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_aractip", value); }
        }

        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {
                //Dışarıdan Gelen Format 20171231235959 Şeklinde Olmalıdır
                case "param_aractip":
                    AracTipIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
          
            #region aractipz
            //     decimal selectedAracTipId = AracTipIds.first().toString("0").cto<decimal>();
            string AracTipIdQuery = ""; // $" = {selectedAracTipId}";

           //  if (AracTipIds.Count > 0 )
             if (AracTipIds.isNotEmpty())
                {       
                    AracTipIdQuery =  $" in ({AracTipIds.joinNumeric(",")}) ";
                }
            else
                {
                    AracTipIdQuery = "";
            }
            #endregion

            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 

                        SELECT  asd.atid ,
                            asd.arac_tipi ,
                            SUM(kapanan_isemri_sayisi) kapanan_isemri_sayisi,
                            SUM(garanti_sayisi) garanti_sayisi,
                            SUM(faturalanan_malzeme) faturalanan_malzeme,
                            SUM(faturalanan_iscilikler) faturalanan_iscilikler,
                            SUM(faturalanan_diger_kalemler) faturalanan_diger_kalemler,
                            SUM(faturalanan_dis_hizmetler) faturalanan_dis_hizmetler,
                            SUM(garanti_malzeme_toplam) garanti_malzeme_toplam,
                            SUM(garanti_iscilik_toplam) garanti_iscilik_toplam,
                            SUM(garanti_dkalem_toplam) garanti_dkalem_toplam,
                            SUM(garanti_dhizmet_toplam) garanti_dhizmet_toplam

                        FROM(SELECT at.id AS atid,  
                                at.ad arac_tipi ,   
                                l.saseno ,
                                (SELECT COUNT (si.isemirno)                                 
                                FROM servisisemirler si
                                WHERE si.teknikolaraktamamla = 1 
                                    AND l.saseno = si.saseno
                            )kapanan_isemri_sayisi,

                            (SELECT COUNT (ayr.isemirno)                              
                            FROM ayristirmalar ayr, 
                                servisisemirler si
                            WHERE ayr.ayristirmatipid NOT IN (1, 2, 8)
                                AND si.isemirno = ayr.isemirno
                                AND l.saseno = si.saseno
                            )garanti_sayisi,

                            (SELECT SUM (ad.atutar)
                            FROM ayristirmadetaylar ad, 
                                ayristirmalar a, 
                                servisisemirler si
                            WHERE si.isemirno = a.isemirno
                                AND a.id = ad.ayristirmaid
                                AND ad.turid = 1
                                AND a.ayristirmatipid = 1
                                AND si.teknikolaraktamamla = 1
                                AND a.durumid = 1
                                AND ad.durumid = 1
                                AND ad.faturaid IS NOT NULL
                                AND l.saseno = si.saseno
                            )faturalanan_malzeme,

                            (SELECT SUM (ad.atutar)                                    
                            FROM ayristirmadetaylar ad, 
                                ayristirmalar a, 
                                servisisemirler si
                            WHERE si.isemirno = a.isemirno
                                AND a.id = ad.ayristirmaid
                                AND ad.turid = 2
                                AND a.ayristirmatipid = 1
                                AND si.teknikolaraktamamla = 1
                                AND a.durumid = 1
                                AND ad.durumid = 1
                                AND ad.faturaid IS NOT NULL
                                AND l.saseno = si.saseno
                            )faturalanan_iscilikler,

                            (SELECT SUM (ad.atutar)                                   
                            FROM ayristirmadetaylar ad, 
                                ayristirmalar a, 
                                servisisemirler si
                            WHERE si.isemirno = a.isemirno
                                AND a.id = ad.ayristirmaid
                                AND ad.turid = 3
                                AND a.ayristirmatipid = 1
                                AND si.teknikolaraktamamla = 1
                                AND a.durumid = 1
                                AND ad.durumid = 1
                                AND ad.faturaid IS NOT NULL
                                AND l.saseno = si.saseno
                            )faturalanan_diger_kalemler,

                            (SELECT SUM (ad.atutar)                                  
                            FROM ayristirmadetaylar ad, 
                                ayristirmalar a, 
                                servisisemirler si
                            WHERE si.isemirno = a.isemirno
                                AND a.id = ad.ayristirmaid
                                AND ad.turid = 4
                                AND a.ayristirmatipid = 1
                                AND si.teknikolaraktamamla = 1
                                AND a.durumid = 1
                                AND ad.durumid = 1
                                AND ad.faturaid IS NOT NULL
                                AND l.saseno = si.saseno
                            )faturalanan_dis_hizmetler,

                            (SELECT SUM (ad.gtutar)                                      
                            FROM ayristirmadetaylar ad, 
                                ayristirmalar a, 
                                servisisemirler si
                            WHERE si.isemirno = a.isemirno
                                AND a.id = ad.ayristirmaid
                                AND ad.turid = 1
                                AND a.ayristirmatipid NOT IN (1, 2, 8)
                                AND si.teknikolaraktamamla = 1
                                AND a.durumid = 1
                                AND ad.durumid = 1
                                AND a.icmalid IS NOT NULL
                                AND l.saseno = si.saseno
                            )garanti_malzeme_toplam,

                            (SELECT SUM (ad.gtutar)
                            FROM ayristirmadetaylar ad, 
                                ayristirmalar a, 
                                servisisemirler si
                            WHERE     si.isemirno = a.isemirno
                                AND a.id = ad.ayristirmaid
                                AND ad.turid = 2
                                AND a.ayristirmatipid NOT IN (1, 2, 8)
                                AND si.teknikolaraktamamla = 1
                                AND a.durumid = 1
                                AND ad.durumid = 1
                                AND a.icmalid IS NOT NULL
                                AND l.saseno = si.saseno
                            )garanti_iscilik_toplam,

                            (SELECT SUM (ad.gtutar)  
                            FROM ayristirmadetaylar ad, 
                                ayristirmalar a, 
                                servisisemirler si
                            WHERE si.isemirno = a.isemirno
                                AND a.id = ad.ayristirmaid
                                AND ad.turid = 3
                                AND a.ayristirmatipid NOT IN (1, 2, 8)
                                AND si.teknikolaraktamamla = 1
                                AND a.durumid = 1
                                AND ad.durumid = 1
                                AND a.icmalid IS NOT NULL
                                AND l.saseno = si.saseno
                            )garanti_dkalem_toplam,

                            (SELECT SUM (ad.gtutar)     
                            FROM ayristirmadetaylar ad, 
                                ayristirmalar a, 
                                servisisemirler si
                            WHERE si.isemirno = a.isemirno
                                AND a.id = ad.ayristirmaid
                                AND ad.turid = 4
                                AND a.ayristirmatipid NOT IN (1, 2, 8)
                                AND si.teknikolaraktamamla = 1
                                AND a.durumid = 1
                                AND ad.durumid = 1
                                AND a.icmalid IS NOT NULL
                                AND l.saseno = si.saseno
                            )garanti_dhizmet_toplam

                            FROM araclar l

                            LEFT  JOIN vw_aractipler at ON at.dilkod = 'Turkish' AND l.aractipid = at.id AND  at.id = l.aractipid

                            WHERE l.saseno IN (SELECT DISTINCT si.saseno
                                              FROM servisisemirler si
                                              WHERE  si.teknikolaraktamamla = 1) 
                            ) asd
                        where asd.atid {AracTipIdQuery} 
                        GROUP BY asd.atid , asd.arac_tipi

                " )
            .GetDataTable(mr)
            .ToModels();


            CloseCustomAppPool();
            return queryResults;
        }

    }
}