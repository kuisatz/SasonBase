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
    /// Yan sanayi kullanım nedenleri raporu
    /// </summary>
    public class MrkzYanSanayiKullanimNedenleriRaporu : Base.SasonMerkezReporter
    {
        public MrkzYanSanayiKullanimNedenleriRaporu()
        {
            Text = "Yan Sanayi Kullanım Nedenleri Raporu";
            SubjectCode = "MrkzYanSanayiKullanimNedenleriRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true)); 
            Disabled = false;
        }
        public MrkzYanSanayiKullanimNedenleriRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            decimal selectedServisId = ServisIds.first().toString("0").cto<decimal>();
            string servisIdQuery = $" = {selectedServisId}";
            string dateQuery = ""; 

            if (ServisIds.isNotEmpty())
                servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            else { 
            //    servisIdQuery = $" > 1 ";
                selectedServisId = ServisId;
                servisIdQuery = $" in( {selectedServisId} )";
            }


            StartDate = StartDate.startOfDay(); 
            FinishDate = FinishDate.endOfDay();
            dateQuery = ""+StartDate.ToString("dd/MM/yyyy") +  "' AND '"+ FinishDate.ToString("dd/MM/yyyy")+"";
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"  
                    SELECT   
                         ssip.SERVISID,
                         (select vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = ssip.SERVISID and vtsx.dilkod = 'Turkish') as partnercode,
                         (Select vtsxy.ISORTAKAD FROM vt_servisler vtsxy where  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = ssip.SERVISID )  as servisad,
                         isortak.ad,
                         ssip.belgeno SIPARIS_NO,
                         ssip.tarih SIPARIS_TARIHI,
                         srvstok.kod PARCA_NO,
                         srvstok.ad PARCA_AD,
                         ssm.miktar,
                         tdrkneden.kod TEDARIK_NEDEN,
                         srvstok.kod ,
                         CASE WHEN orj.orjinalgkod IS NULL THEN srvstok.kod ELSE orj.orjinalgkod END orjinalkod
                    from servissiparismlzler ssm 
                    inner join servissiparisler ssip ON  ssip.id=SSM.SERVISSIPARISID AND SSIP.siparisSERVISID is null
                    inner join servisstoklar srvstok ON SSM.SERVISSTOKID=srvstok.id
                    inner join muadiltedariknedenler tdrkneden ON SSM.MUADILTEDARIKNEDENID = tdrkneden.id
                    inner join servisisortaklar isortak ON ssip.siparisisortakid=isortak.id 
                    LEFT JOIN   (SELECT m1.id malzemeid,
                                                  m1.kod,
                                                  m1.gkod,
                                                  m2.kod orjinalkod,
                                                  m2.gkod orjinalgkod,
                                                  m1.orjinalmalzemeid
                                                FROM malzemeler m1, malzemeler m2
                                                WHERE m1.orjinalmalzemeid = M2.ID) orj  ON orj.malzemeid=SRVSTOK.MALZEMEID 
                    where   
                        SSM.MUADILTEDARIKNEDENID is not null and 
                        ssip.SERVISID {servisIdQuery}  AND 
                        ssip.tarih between '{dateQuery}' 
             
            ORDER BY ssip.SERVISID ,ssip.tarih desc 
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}