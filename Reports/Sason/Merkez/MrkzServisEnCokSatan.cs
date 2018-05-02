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
    /// Merkez Servis En Çok Satan Raporu(onarım ve direk satış)
    /// </summary>
    public class MrkzServisEnCokSatan : Base.SasonMerkezReporter
    {
        public MrkzServisEnCokSatan()
        {
            Text = "Servis En Çok Satan Raporu";
            SubjectCode = "MrkzServisEnCokSatan";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));           
            Disabled = false;
        }
        public MrkzServisEnCokSatan(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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

#if DEBUG
             selectedServisId = ServisId;
              servisIdQuery = $" in( {selectedServisId} )";
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

            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@"   
                    SELECT asd.*,COUNT(asd.Kod) AS Miktar FROM ( 
                        SELECT Srv.Partnercode AS ServisKodu, 
                                Srv.Isortakad AS ServisAdi, 
                                Sstok.Kod AS Kod,
                                Sstok.Ad AS Ad,
                                --COUNT(Sstok.Kod) AS Miktar,
                                KURLAR_PKG.SERVISSTOKFIYATGETIR(Sshd.Servisstokid, 2,sysdate) AS EuroListeFiyat,                          
                                KURLAR_PKG.STOKFIYATINDGETIR(Sshd.Servisstokid, 2, 2, 1, 0) AS EuroIndFiyat,
                                NVL(to_char(Sshd.Servissiparisid),Sshd.Isemirno  ) Isemirno,  
                                to_char(SSH.TARIH,'DD/MM/YYYY') tarih
                            FROM Servisstokhareketdetaylar Sshd,
                                Servisstoklar Sstok,
                                Vt_Servisler Srv,
                                Servisstokhareketler ssh
                            WHERE Sshd.Stokislemtipdeger=-1
                                    AND Sshd.Servisstokid=Sstok.Id 
                                    AND Srv.Servisid=Sstok.Servisid 
                                    AND Srv.Dilkod='Turkish'                             
                                    AND Srv.Servisid  {servisIdQuery} 
                                    AND SSH.ID = SSHD.SERVISSTOKHAREKETID AND ssh.durumid = 1 
                                    AND SSH.TARIH between {dateQuery}    
                    ) asd
                    GROUP BY ServisKodu,ServisAdi,Kod,Ad,  Isemirno,EuroListeFiyat,EuroIndFiyat,tarih
                    ORDER BY ServisKodu, tarih desc, Miktar DESC  
                ")
              .GetDataTable(mr)
            .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}