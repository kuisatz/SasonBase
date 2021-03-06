﻿using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SasonBase.Reports.Sason.Servis
{
    /// <summary>
    /// Servis Servis En Çok Satan Raporu(onarım ve direk satış)
    /// </summary>
    public class SrvsServisEnCokSatan : Base.SasonReporter
    {
        public SrvsServisEnCokSatan()
        {
            Text = "Servis En Çok Satan Raporu";
            SubjectCode = "SrvsServisEnCokSatan";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            Disabled = false;
        }
        public SrvsServisEnCokSatan(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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

            StartDate = StartDate.startOfDay();
            FinishDate = FinishDate.endOfDay();
            dateQuery = "" + StartDate.ToString("dd/MM/yyyy") + "' AND '" + FinishDate.ToString("dd/MM/yyyy") + "";
            MethodReturn mr = new MethodReturn();

            List<object> queryResults = AppPool.EbaTestConnector.CreateQuery($@" 

                     SELECT Srv.Partnercode AS ServisKodu, 
                            Srv.Isortakad AS ServisAdi, 
                            Sstok.Kod AS Kod,
                            Sstok.Ad AS Ad,
                            COUNT(Sstok.Kod) AS Miktar,
                            KURLAR_PKG.SERVISSTOKFIYATGETIR(Sstok.id, 2,sysdate) AS EuroListeFiyat,
                            KURLAR_PKG.STOKFIYATINDGETIR(Sstok.id, 2, 2, 1, 0) AS EuroIndFiyat

                       FROM Servisstokhareketdetaylar Sshd,
                            Servisstoklar Sstok,
                            Vt_Servisler Srv

                      WHERE Sshd.Stokislemtipdeger=-1
                            AND Sshd.Servisstokid=Sstok.Id 
                            AND Srv.Servisid=Sstok.Servisid 
                            AND Srv.Dilkod='Turkish' 
                            AND (Sshd.Isemirno IS NOT NULL OR Sshd.Servissiparisid IS NOT NULL) 
                            AND Srv.Servisid  {servisIdQuery} 
                        GROUP BY Srv.Partnercode,Srv.Isortakad,Sstok.Kod,Sstok.Ad, Sshd.Servissiparisid, Sstok.id
                      ORDER BY Srv.Partnercode, COUNT(Sstok.Kod) DESC
 
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}