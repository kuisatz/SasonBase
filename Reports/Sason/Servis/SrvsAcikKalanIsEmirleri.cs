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
    public class SrvsAcikKalanIsEmirleri : Base.SasonReporter
    {
        public SrvsAcikKalanIsEmirleri()
        {
            Text = "Açık Kalan İş Emirleri";
            SubjectCode = "SrvsAcikKalanIsEmirleri";
 
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_min_gun", Text = "Min Gün" }.CreateTextBox("İsteğe Bağlı Min Gün Sayısı"));
            AddParameter(new ReporterParameter() { Name = "param_max_gun", Text = "Max Gün" }.CreateTextBox("İsteğe Bağlı Max Gün Sayısı"));
            Disabled = false;
            this.MinGun = "0";
            this.MaxGun = "0";
        }

        public SrvsAcikKalanIsEmirleri(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
            this.MinGun = "0";
            this.MaxGun = "0";
        }

        public string MinGun
        {
            get { return GetParameter("param_min_gun").ReporterValue.toString(); }
            set { SetParameterReporterValue("param_min_gun", value.toString()); }
        }
        public string MaxGun
        {
            get { return GetParameter("param_max_gun").ReporterValue.toString(); }
            set { SetParameterReporterValue("param_max_gun", value.toString()); }
        }

        public override ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            switch (parameterName)
            {
                //Dışarıdan Gelen Format 20171231235959 Şeklinde Olmalıdır
                case "param_min_gun":
                    MinGun = value.toString();
                    break;
                case "param_max_gun":
                    MaxGun = value.toString();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
          
          
            string dateQuery = "";

            string dateGunQuery1 = "";
            string dateGunQuery2 = "";
            int MinGun1 = Int32.Parse(MinGun.ToString());
            int MaxGun1 = Int32.Parse(MaxGun.ToString());

            if (MinGun1 > 0)
            {
                dateGunQuery1 = " AND acikkalmagunu >= " + MinGun;
            }
            if (MaxGun1 > 0)
            {
                dateGunQuery2 = " AND acikkalmagunu <= " + MaxGun;
            }

            MethodReturn mr = new MethodReturn();
            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"  
                    select * from ( 
                        select 
                            ie1.servisid, 
                            SRV.PARTNERCODE, 
                            SRV.ISORTAKAD SERVISADI, 
                            ie1.isemirno, 
                            ie1.kayittarih KAYITTARIHI,
                            SYSDATE RAPORGUNU, 
                            round( sysdate - ie1.kayittarih) ACIKKALMAGUNU,
                            case 
                                when ie1.arackazali = 1 then 'EVET' 
                            else 'HAYIR' 
                                end ARAC_KAZALI, 
                            ie1.araccikiszamani, 
                            case 
                                when ie1.aracserviste = 0 then 'HAYIR' 
                            else 'EVET' 
                            end  arac_servis_disinda,
                            case 
                                when SERVAR.VARLIKTIPID=3 then 'EVET'
                            else 'HAYIR'
                            end KAMU,
                            ie1.aciklama
                        from (
                            select * from servisisemirler where teknikolaraktamamla = 0 and tamamlanmatarih is null) ie1
                            left join vt_servisler srv on srv.dilkod = 'Turkish' and srv.servisid = ie1.servisid
                            inner join servisvarliklar servar on SERVAR.id=ie1.servisvarlikid
                            WHERE srv.servisid = {ServisId}
                        )
                    where 
                        1=1 
                        {dateGunQuery1}
                        {dateGunQuery2}
                    order by  ACIKKALMAGUNU desc ,kayittarihi asc
 
 
                      
            ")
         //   .Parameter("StartDate", StartDate.Date)
         //   .Parameter("FinishDate", FinishDate.endOfDay())
         //   .Parameter("ServisId", ServisId)
         //   .Parameter("SaseNo", SaseNo.isNotNullOrWhiteSpace() ? null : SaseNo)
            .GetDataTable(refMr)            
            .ToModels();

            //    reportDataSource = dtb.ToModels(refMr);


            CloseCustomAppPool();
            return queryResults;
        }
    }
}