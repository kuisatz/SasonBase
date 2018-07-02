using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Sason.Merkez
{
    public class MrkzDownTime : Base.SasonMerkezReporter
    {
        public MrkzDownTime()
        {
            Text = "Down Time (Liste)";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_aractur", Text = "Araç Türü" }.CreateAracTurSelect(false));
            Disabled = false;
          
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
        public List<decimal> AracTurIds
        {
            get { return GetParameter("param_aractur").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_aractur", value); }
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
                case "param_aractur":
                    AracTurIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();                    
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            string servisIdQuery = "";
            string dateQuery = "";

            if (ServisIds.isNotEmpty())
                servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            else
                servisIdQuery = $" > 1 ";

            string addSQLAracTur = ""; 
            addSQLAracTur = "";
            string addSQLAracTurGroupBy = "";
            string addSQLAracTurConcat1 = " vtsrv.isortakad,  ";
            string addSQLAracTurConcat2 = " 'Türkiye Geneli' isortakad,  ";

            if (AracTurIds.isNotEmpty())
            {
                addSQLAracTur = $"  AND ar.id in ({AracTurIds.joinNumeric(",")}) ";
                addSQLAracTurGroupBy = ", ar.kod ";
                addSQLAracTurConcat1 = " CONCAT(CONCAT(vtsrv.isortakad, '  - '),ar.kod) isortakad, ";
                addSQLAracTurConcat2 = " CONCAT(CONCAT('Türkiye Geneli', '  - '),ar.kod) isortakad, ";
            }


            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";

            List<object> reportDataSource = AppPool.EbaTestConnector.CreateQuery($@"

            SELECT * FROM ( 
                    SELECT 
                        trunc(round( sum((case when ie.araccikiszamani is not null then ie.araccikiszamani else ie.tamamlanmatarih end ) - ie.kayittarih)/count(ie.id),2)) ||','||
                            (trunc((round( sum((case when ie.araccikiszamani is not null then ie.araccikiszamani else ie.tamamlanmatarih end ) - ie.kayittarih)/count(ie.id),2)-
                            trunc(round( sum((case when ie.araccikiszamani is not null then ie.araccikiszamani else ie.tamamlanmatarih end ) - ie.kayittarih)/count(ie.id),2)))*24))||'' DOWNTIME ,
                        to_char(ie.tamamlanmatarih,'YYYY.MM') DONEM, 
                        ie.servisid,
                        {addSQLAracTurConcat1}
                        vtsrv.partnercode                      
                    FROM 
                        servisisemirler ie,
                        vt_servisler vtsrv,
                        aracturler ar ,
                        servisvarliklar servar
                    WHERE ie.tamamlanmatarih between  '{dateQuery}' and ie.teknikolaraktamamla=1 and ie.servisid {servisIdQuery}
                        and (ie.arackazali <> 1 or ie.arackazaaciklama is null or ie.arackazaaciklama = '')
                        and vtsrv.dilkod(+) = 'Turkish' and vtsrv.servisid(+)=ie.servisid
                        and IE.SERVISVARLIKID=servar.id
                        and SERVAR.VARLIKTIPID<>3
                        and ar.kod =  ie.aractipad and ar.durumid =1
                        {addSQLAracTur}
                    GROUP BY to_char(ie.tamamlanmatarih,'YYYY.MM'), ie.servisid, vtsrv.isortakad, vtsrv.partnercode {addSQLAracTurGroupBy}
                                   
                    UNION 
                    
                    SELECT 
                        trunc(round( sum((case when ie.araccikiszamani is not null then ie.araccikiszamani else ie.tamamlanmatarih end ) - ie.kayittarih)/count(ie.id),2)) ||','||
                            (trunc((round( sum((case when ie.araccikiszamani is not null then ie.araccikiszamani else ie.tamamlanmatarih end ) - ie.kayittarih)/count(ie.id),2)-
                            trunc(round( sum((case when ie.araccikiszamani is not null then ie.araccikiszamani else ie.tamamlanmatarih end ) - ie.kayittarih)/count(ie.id),2)))*24))||'' DOWNTIME ,
                        to_char(ie.tamamlanmatarih,'YYYY.MM') DONEM, 
                        -1 servisid,
                        {addSQLAracTurConcat2} 
                        'R001' partnercode                      
                    FROM 
                        servisisemirler ie,
                        vt_servisler vtsrv,
                        aracturler ar ,
                        servisvarliklar servar
                    WHERE ie.tamamlanmatarih between  '{dateQuery}' and ie.teknikolaraktamamla=1  
                        and (ie.arackazali <> 1 or ie.arackazaaciklama is null or ie.arackazaaciklama = '')
                        and IE.SERVISVARLIKID=servar.id
                        and SERVAR.VARLIKTIPID<>3
                        and vtsrv.dilkod(+) = 'Turkish' and vtsrv.servisid(+)=ie.servisid
                        and ar.kod =  ie.aractipad and ar.durumid =1 
                        {addSQLAracTur}
                    GROUP BY to_char(ie.tamamlanmatarih,'YYYY.MM'){addSQLAracTurGroupBy}
            )  asd 
           ORDER BY DONEM , servisid 
  

            ") 
            .GetDataTable()
            .ToModels();

            CloseCustomAppPool();
            return reportDataSource;
        }
    }
}