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
    /// Merkez Muadil Parça Satış Raporu
    /// </summary>
    public class MrkzMuadilParcaSatisRaporu : Base.SasonMerkezReporter
    {
        public MrkzMuadilParcaSatisRaporu()
        {
            Text = "[YP-4] Muadil Parça Satış Raporu";
            SubjectCode = "MrkzMuadilParcaSatisRaporu";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true)); 
            Disabled = false;
        }
        public MrkzMuadilParcaSatisRaporu(decimal servisId, DateTime startDate, DateTime finishDate) : this()
        {
            base.ServisId = servisId;
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
  
            if (ServisIds.isNotEmpty())
                servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            else { 
            //    servisIdQuery = $" > 1 ";
                selectedServisId = ServisId;
                servisIdQuery = $" in( {selectedServisId} )";
            }

            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 

              SELECT 
                    PARCA_NO,
                    PARCA_ADI,
                    STOK_TURU,
                    miktar,
                    birimfiyat,
                    isemirno,
                    servissiparisid,
                    belgeno,
                    asd.kod,
                    CASE WHEN orj.orjinalgkod IS NULL THEN '' ELSE orj.orjinalgkod END orjinalkod,
                    asd.servisid,
                    (select vtsx.partnercode from vt_servisler vtsx where vtsx.servisid = asd.SERVISID and vtsx.dilkod = 'Turkish') as partnercode,
                    (Select vtsxy.ISORTAKAD FROM vt_servisler vtsxy where  vtsxy.dilkod = 'Turkish' and vtsxy.servisid = asd.SERVISID) as servisad 
                    FROM  ( 
                        SELECT
                            ss.kod PARCA_NO,
                            ss.ad PARCA_ADI,
                            stur.kod STOK_TURU,
                            hardet.miktar,
                            hardet.birimfiyat,
                            hardet.isemirno,
                            to_char(hardet.servissiparisid) as servissiparisid,
                            (select SSPX.BELGENO  from servissiparisler sspx where sspx.id= hardet.servissiparisid) as belgeno,
                            ss.malzemeid,
                            ss.kod,
                            ss.servisid
                        from servisstokhareketdetaylar hardet,
                                servisstoklar ss,
                                servisstokturler stur 
                        where
                            ss.servisstokturid=stur.id and
                            hardet.stokislemtipdeger=-1 and
                            NVL( to_char(HARDET.SERVISSIPARISID), HARDET.ISEMIRNO) is not null and  
                            SS.SERVISSTOKTURID in (6,7,8,9,10,11) and
                            hardet.servisstokid=ss.id AND 
                            ss.servisid {servisIdQuery}  
                    ) asd ,  (SELECT m1.id malzemeid,
                                                    m1.kod,
                                                    m1.gkod,
                                                    m2.kod orjinalkod,
                                                    m2.gkod orjinalgkod,
                                                    m1.orjinalmalzemeid
                                                FROM malzemeler m1, malzemeler m2
                                                WHERE m1.orjinalmalzemeid = M2.ID) orj  
                                
                            where 
                            asd.kod = orj.kod(+)
                    order by  asd.servisid
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}