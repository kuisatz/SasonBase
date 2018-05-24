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
    /// Merkez Servise Gelmeyen Araclar Raporu
    /// </summary>
    public class MrkzServiseGelmeyenAraclarRaporu : Base.SasonMerkezReporter
    {
        public MrkzServiseGelmeyenAraclarRaporu()
        {
            Text = "Servise Gelmeyen Araclar Raporu";
            SubjectCode = "MrkzServiseGelmeyenAraclarRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_sase_no", Text = "Şase No" }.CreateTextBox("İsteğe Bağlı Şase No. Girebilirsiniz"));
            //Disabled = false;
        }
        public MrkzServiseGelmeyenAraclarRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
        public string SaseNo
        {
            get { return GetParameter("param_sase_no").ReporterValue.toString(); }
            set { SetParameterReporterValue("param_sase_no", value.toString()); }
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
                case "param_sase_no":
                    SaseNo = value.toString();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            decimal selectedServisId = ServisIds.first().toString("0").cto<decimal>();
            string servisIdQuery = $" = {selectedServisId}";
            string dateQuery = "";
            string fDate = "";

#if DEBUG
            selectedServisId = ServisId;
            servisIdQuery = $" = {selectedServisId}";
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
            fDate = "'"  + FinishDate.ToString("dd/MM/yyyy") + "'";

            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 

                     SELECT * 
                       FROM(
                            SELECT  DISTINCT MAX(i.kayittarih) AS kayit_tarihi,
                                c.*,
                               (SELECT vtsx.partnercode FROM vt_servisler vtsx WHERE vtsx.servisid = c.servisid  AND vtsx.dilkod = 'Turkish') AS partnercode,
                               (SELECT vtsxy.ISORTAKAD FROM vt_servisler vtsxy WHERE  vtsxy.dilkod = 'Turkish' AND vtsxy.servisid = c.servisid) AS servisad,
                               i.plaka,
                               i.aractipad,
                               i.modelno,
                               i.isemirno,
                               s_ort.ad AS musteri_ad,
                               i.musteriad AS Araci_getiren,
                               i.musteritelefon AS Araci_getiren_tel,
                               srv_knt.ad AS Filo_yoneticisi,
                               knt_tel.no AS filo_tel
           
                               FROM( SELECT a.saseno,
                                            b.saseno AS saseyeni,
                                            a.servisid 
                                     FROM (SELECT DISTINCT saseno ,servisid
                                           FROM servisisemirler 
                                           WHERE kayittarih < SYSDATE-180 
                                                 AND saseno IS NOT NULL) a,
                             
                                          (SELECT DISTINCT saseno 
                                           FROM servisisemirler 
                                           WHERE kayittarih > SYSDATE-180 
                                                 AND saseno IS NOT NULL) b 
                             
                                      WHERE a.saseno=b.saseno(+)) c,
                                      servisisemirler i,
                                      servisisortaklar s_ort,
                                      vt_servisisortakkontaklar srv_knt,
                                      vt_kontaktelefonlar knt_tel
                  
                               WHERE saseyeni IS NULL 
                                     AND c.saseno=i.saseno 
                                     AND i.servisisortakid = s_ort.id
                                     AND i.servisisortakid = srv_knt.servisisortakid
                                     AND srv_knt.servisisortakkontaktipid = 6
                                     AND srv_knt.kontakid = knt_tel.kontakid
                                     AND knt_tel.dilkod = 'Turkish'
                                     AND i.kayittarih BETWEEN '{dateQuery}' 
                                     AND i.servisid {servisIdQuery}
                                     AND (c.saseno = NVL ('{SaseNo}', c.saseno)) 
                                     AND 0 = (select count(kayittarih) from servisisemirler where kayittarih > {fDate} AND saseno = c.saseno)
                                     AND i.kayittarih = (select max(kayittarih) from servisisemirler where kayittarih < {fDate} AND saseno = c.saseno)
                 
                                GROUP BY c.saseno, c.saseyeni, i.plaka, i.aractipad,i.modelno, i.isemirno, i.musteriad,s_ort.ad,i.musteritelefon, srv_knt.ad,knt_tel.no,c.servisid
                            ) asd
                        ORDER BY kayit_tarihi

                ")
            .GetDataTable(mr)
            .ToModels();


            CloseCustomAppPool();
            return queryResults;
        }

    }
}