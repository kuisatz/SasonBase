using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SasonBase.Reports.Sason.Servis
{
    public class Srvs3GundenFazlaAcikKalanIsEmirleri : Base.SasonReporter
    {
        public Srvs3GundenFazlaAcikKalanIsEmirleri()
        {
            Text = "3 Günden Fazla Açık Kalan İş Emirleri";
            SubjectCode = "Srvs3GundenFazlaAcikKalanIsEmirleri";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_acik_kalma", Text = "İş Emri Ne Kadar Süredir Açık?" }.CreateAcikKalmaGunu(false));
            AddParameter(new ReporterParameter() { Name = "param_kazali", Text = "Araç Kazalı Mı?" }.CreateEvetHayir(false));
            AddParameter(new ReporterParameter() { Name = "param_servis_disi", Text = "Araç Servis Dışında Mı?" }.CreateEvetHayir(false));
            AddParameter(new ReporterParameter() { Name = "param_kamu", Text = "Cari Kamu Müşterisi Mi?" }.CreateEvetHayir(false));
            AddParameter(new ReporterParameter() { Name = "param_araccikis", Text = "Araç Çıkış Tarihi Dolu Mu?" }.CreateEvetHayir(false));

            Disabled = false;
        }

        public Srvs3GundenFazlaAcikKalanIsEmirleri(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
        }

        public List<decimal> AcikKalma
        {
            get { return GetParameter("param_acik_kalma").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_acik_kalma", value); }
        }
        public List<decimal> AracKazali
        {
            get { return GetParameter("param_kazali").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_kazali", value); }
        }
        public List<decimal> AracServisDisi
        {
            get { return GetParameter("param_servis_disi").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_servis_disi", value); }
        }
        public List<decimal> CariKamu
        {
            get { return GetParameter("param_kamu").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_kamu", value); }
        }
        public List<decimal> AracCikis
        {
            get { return GetParameter("param_araccikis").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_araccikis", value); }
        }

        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {
                //Dışarıdan Gelen Format 20171231235959 Şeklinde Olmalıdır
                case "param_acik_kalma":
                    AcikKalma = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
                case "param_kazali":
                    AracKazali = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
                case "param_servis_disi":
                    AracServisDisi = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
                case "param_kamu":
                    CariKamu = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
                case "param_araccikis":
                    AracCikis = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            decimal selectedAcikKalma = AcikKalma.first().toString("0").cto<decimal>();
            string acikKalma = "";

            decimal selectedAracKazali = AracKazali.first().ToString("0").cto<decimal>();
            string aracKazali = "";

            decimal selectedServisDisi = AracServisDisi.first().ToString("0").cto<decimal>();
            string servisDisi = "";

            decimal selectedCariKamu = CariKamu.first().ToString("0").cto<decimal>();
            string cariKamu = "";

            decimal selectedAracCikis = AracCikis.first().ToString("0").cto<decimal>();
            string aracCikis = "";

            #region filtreler
            if (selectedAracKazali == 1)
                aracKazali = "='EVET'";
            else if (selectedAracKazali == 2)
                aracKazali = "='HAYIR'";
            else
                aracKazali = " = 'HAYIR' or arac_kazali = 'EVET'";

            if (selectedServisDisi == 1)
                servisDisi = "='EVET'";
            else if (selectedServisDisi == 2)
                servisDisi = "='HAYIR'";
            else
                servisDisi = " = 'HAYIR' or arac_servis_disinda = 'EVET'";

            if (selectedCariKamu == 1)
                cariKamu = "='EVET'";
            else if (selectedCariKamu == 2)
                cariKamu = "='HAYIR'";
            else
                cariKamu = " = 'HAYIR' or kamu = 'EVET'";

            if (selectedAracCikis == 1)
                aracCikis = "IS NOT NULL";
            else if (selectedAracCikis == 2)
                aracCikis = "IS NULL";
            else
                aracCikis = " IS NOT NULL or araccikiszamani IS NULL";

            if (selectedAcikKalma == 3)
                acikKalma = ">3";
            else if (selectedAcikKalma == 7)
                acikKalma = ">7";
            else if (selectedAcikKalma == 30)
                acikKalma = ">30";
            else
                acikKalma = ">0";

            #endregion


            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"  
                   
                    SELECT * 
                    FROM (
                         SELECT ie1.servisid AS servisid, 
                         srv.partnercode AS serviskodu, 
                         srv.isortakad AS servisadi, 
                         ie1.isemirno AS isemirno, 
                         ie1.kayittarih AS kayittarihi,
                         SYSDATE raporgunu, 
                         ROUND( SYSDATE - ie1.kayittarih) acikkalmagunu,
                         CASE WHEN ie1.arackazali = 1 
                                THEN 'EVET'
                              ELSE 'HAYIR' 
                         END arac_kazali, 
                         TO_CHAR(ie1.araccikiszamani,'dd.mm.yyyy') AS araccikiszamani,
                         CASE WHEN ie1.aracserviste = 0 
                                THEN 'HAYIR'
                              ELSE 'EVET'
                         END  arac_servis_disinda,
                         CASE WHEN servar.varliktipid=3 
                                THEN 'EVET'
                              ELSE 'HAYIR'
                         END kamu,
                         ie1.aciklama AS aciklama 

                         FROM (SELECT * 
                               FROM servisisemirler 
                               WHERE teknikolaraktamamla = 0 AND tamamlanmatarih IS NULL) ie1
                         LEFT JOIN vt_servisler srv ON srv.dilkod = 'Turkish' AND srv.servisid = ie1.servisid
                         INNER JOIN servisvarliklar servar ON servar.id=ie1.servisvarlikid
                    )

                    WHERE acikkalmagunu {acikKalma} 
                          AND ( servisid = {ServisId} )
                          AND ( arac_kazali {aracKazali} )
                          AND ( arac_servis_disinda {servisDisi} )
                          AND ( kamu {cariKamu} )
                          AND ( araccikiszamani {aracCikis} )
                    ORDER BY servisid,kayittarihi ASC
                      
            ")

            .GetDataTable(refMr)            
            .ToModels();

            CloseCustomAppPool();
            return queryResults;
        }
    }
}