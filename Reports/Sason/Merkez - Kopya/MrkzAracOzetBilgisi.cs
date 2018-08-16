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
    /// Merkez Araç Özet Bilgisi Raporu
    /// </summary>
    public class MrkzAracOzetBilgisi : Base.SasonMerkezReporter
    {
        public MrkzAracOzetBilgisi()
        {
            Text = "Araç Özet Bilgisi";
            SubjectCode = "MrkzAracOzetBilgisi";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("Şase No Girişi Zorunludur!"));
            Disabled = false;
        }
        public MrkzAracOzetBilgisi(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
  
        }

        public string SaseNo
        {
            get { return GetParameter("param_sase_no").ReporterValue.toString(); }
            set { SetParameterReporterValue("param_sase_no", value.toString()); }
        }

        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {
                case "param_sase_no":
                    SaseNo = value.toString();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 
                        SELECT 
                            (SELECT DISTINCT si.saseno
                            FROM servisisemirler si
                            WHERE  si.teknikolaraktamamla = 1 
                                AND l.saseno = si.saseno) saseno,

                            (SELECT COUNT (si.isemirno)                                  
                            FROM servisisemirler si
                            WHERE si.teknikolaraktamamla = 1 
                                AND l.saseno = si.saseno
                            ) kapanan_isemri_sayisi,

                            (SELECT COUNT (ayr.isemirno)                              
                            FROM ayristirmalar ayr, servisisemirler si
                            WHERE ayr.ayristirmatipid NOT IN (1, 2, 8)
                                AND si.isemirno = ayr.isemirno
                                AND l.saseno = si.saseno
                            ) garanti_sayisi,

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
                            ) faturalanan_malzeme,

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
                            WHERE si.isemirno = a.isemirno
                                AND a.id = ad.ayristirmaid
                                AND ad.turid = 2
                                AND a.ayristirmatipid NOT IN (1, 2, 8)
                                AND si.teknikolaraktamamla = 1
                                AND a.durumid = 1
                                AND ad.durumid = 1
                                AND a.icmalid IS NOT NULL
                                AND l.saseno = si.saseno
                            ) garanti_iscilik_toplam,

                            (SELECT SUM (ad.gtutar)                                      
                            FROM ayristirmadetaylar ad, 
                                ayristirmalar a, 
                                servisisemirler si
                            WHERE     si.isemirno = a.isemirno
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
                            WHERE     si.isemirno = a.isemirno
                                AND a.id = ad.ayristirmaid
                                AND ad.turid = 4
                                AND a.ayristirmatipid NOT IN (1, 2, 8)
                                AND si.teknikolaraktamamla = 1
                                AND a.durumid = 1
                                AND ad.durumid = 1
                                AND a.icmalid IS NOT NULL
                                AND l.saseno = si.saseno
                            ) garanti_dhizmet_toplam

                        FROM araclar l
                        WHERE  l.saseno IS NOT NULL 
                            AND l.saseno  IN (SELECT DISTINCT si.saseno
                                                FROM servisisemirler si
                                                WHERE  si.teknikolaraktamamla = 1
                                                    AND si.saseno = '{SaseNo}')

                ")
            .GetDataTable(mr)
            .ToModels();

            CloseCustomAppPool();
            return queryResults;
        }

    }
}