﻿using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace SasonBase.Reports.Sason.Merkez
{
    /// <summary>
    /// Envanter Düzeltme Raporu
    /// </summary>
    public class MrkzEnvanterDuzeltme : Base.SasonMerkezReporter
    {
        public MrkzEnvanterDuzeltme()
        {
            Text = "Envanter Düzeltme Raporu";
            SubjectCode = "MrkzEnvanterDuzeltme";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true)); 
            Disabled = false;
        }
        public MrkzEnvanterDuzeltme(decimal servisId, DateTime startDate, DateTime finishDate) : this()
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
                    SRV.PARTNERCODE, 
                    SRV.ISORTAKAD,
                    se.kod ENVANTER_AYARLAMA_ACIKLAMA, 
                    SE.IPTALACIKLAMA, 
                    se.TARIH,
                    (case
                        when
                            SE.DURUMID=0 then 'İPTAL EDİLDİ'
                        when
                            SE.DURUMID=1 then 'BEKLİYOR'
                        else
                            'TAMAMLANDI'
                        end) as ENVANTER_DURUM,
                        vts.kod, 
                         CASE WHEN orj.orjinalgkod IS NULL THEN '' ELSE orj.orjinalgkod END orjinalkod,
                        vts.ad, 
                        sst.kod as stokturkod,       
                        SEM.MIKTAR,
                        SEM.STOKMIKTAR,
                        (sem.miktar-sem.stokmiktar) FARK,
                        sem.maciklama MALZEME_ACIKLAMA,
                        se.KULLANICIID,
                        kurlar_pkg.ORTALAMAMALIYET(vts.id) ortalamamaliyet
                    FROM servisenvantermalzemeler sem, servisenvanterler se, servisstoklar vts, vt_servisler srv, servisstokturler sst,  
                        (SELECT m1.id malzemeid,
                                m1.kod,
                                m1.gkod,
                                m2.kod orjinalkod,
                                m2.gkod orjinalgkod,
                                m1.orjinalmalzemeid
                         FROM malzemeler m1, malzemeler m2
                         WHERE m1.orjinalmalzemeid = M2.ID) orj  
                    WHERE
                        sem.servisenvanterid=se.id and
                        vts.id=sem.servisstokid and                        
                        SRV.SERVISID=se.servisid and
                        srv.dilkod='Turkish' and
                        sst.id=VTS.SERVISSTOKTURID AND
                        vts.kod = orj.kod(+) AND 
                        SRV.SERVISID {servisIdQuery} AND
                        se.TARIH between '{dateQuery}'
                ORDER BY se.id desc
                ")
              .GetDataTable(mr)
               .ToModels();
             
            CloseCustomAppPool();
            return queryResults;
        }

    }
}