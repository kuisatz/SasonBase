using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Sason.Servis
{
    public class SrvsMusteriVelinimet : Base.SasonReporter
    {
        public SrvsMusteriVelinimet()
        {
            Text = "Müşteri Velinimetimizdir (Liste)";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_isemir_hizmetyerleri", Text = "Hizmet Yeri" }.CreateIsEmirHizmetYeri(true));
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

        public List<decimal> HizmetYeriIds
        {
            get { return GetParameter("param_isemir_hizmetyerleri").ReporterValue.cast<List<decimal>>(); }
            set { SetParameterReporterValue("param_isemir_hizmetyerleri", value); }
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
                case "param_isemir_hizmetyerleri":
                    HizmetYeriIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            string hizmetYeriIdQuery = "";
            if (HizmetYeriIds.isNotEmpty())
                hizmetYeriIdQuery = $" and HIZMETYERID in ({HizmetYeriIds.joinNumeric(",")}) ";

            List<object> reportDataSource = AppPool.EbaTestConnector.CreateQuery($@"
                select 
    
                    servis.SERVISID, ISEMIR.ID ISEMIRID, isortak.SERVISISORTAKID,  
                    trunc(isemir.kayittarih) TARIH,
                    servis.partnercode SERVISCODE, servis.isortakad SERVISADI, servis.varlikad SERVISVARLIKADI,
                    servisbilgi.ADRES SERVISADRES, servisbilgi.ULKE_AD SERVISADRES_ULKE, SERVISBILGI.IL_AD SERVISADRES_IL, SERVISBILGI.ILCE_AD SERVISADRES_ILCE, 
                    ISEMIR.ISEMIRNO ISEMIRNO,
                    OSUSER.FIRSTNAME USERFIRSTNAME, OSUSER.LASTNAME USERLASTNAME,
                    isortak.AD MUSTERI_AD, isortak.servisvarlikad MUSTERI_VARLIKAD, ISORTAK.VARLIKTIPAD MUSTERI_VARLIKTIPI, ISORTAK.VERGIDAIREAD MUSTERI_VERGIDAIRESI, ISORTAK.VERGINO MUSTERI_VERGINO, ISORTAK.VERGIDAIREILAD MUSTERI_VERGIDAIRESI_IL,
                    CASE when isortak.FILOBUYUKLUKID is null then 1 else 0 end MUSTERI_FILOBUYUKLUK,
                    --siotelfax.TELEFONNO MUSTERI_TELEFON,
                    isemir.MUSTERIAD MUSTERI_KISI_AD, isemir.MUSTERITELEFON MUSTERI_KISI_TELEFON,
                    kontak.AD KONTAK_AD, KONTAK.NO KONTAK_TELEFON, KONTAK.EPOSTA KONTAK_EPOSTA, KONTAK.SERVISISORTAKKONTAKTIPAD KONTAK_TIP, KONTAK.EPOSTAIZIN KONTAK_IZIN_EPOSTA, KONTAK.ARAMAIZIN KONTAK_IZIN_TELEFONARAMA, KONTAK.SMSIZIN KONTAK_IZIN_SMS,
                    aracbilgiler.saseno ARAC_SASENO, aracbilgiler.aractur ARAC_TUR, aracbilgiler.plaka ARAC_PLAKA

                from (select * from servisisemirler where trunc(kayittarih) between {{startDate}} and {{finishDate}} and servisid = {ServisId} {hizmetYeriIdQuery} ) isemir
                left join vt_servisler servis on servis.dilkod = 'Turkish' and servis.servisid = isemir.servisid
                --left join servisisemirler isemir on trunc(ISEMIR.KAYITTARIH) = tarihler.tarih and isemir.servisid = servis.servisid
                left join osusers osuser on osuser.id = isemir.kullaniciid
                left join sason.vw_isortakkontakbilgiler kontak on kontak.servisisortakid = isemir.servisisortakid
                left join vt_servisisortaklar isortak on isortak.dilkod = 'Turkish' and ISORTAK.servisisortakid = isemir.servisisortakid

                -- SERVIS BILGILERI (adres, telefon, fax)
                left join (
                           select 
                                se.id servisid, io.id isortakid, io.ad isortakad, adres.adres, ulke.ad ulke_ad, il.ad il_ad, ilce.ad ilce_ad, tel.no telefon, fax.no fax
                           from
                                servisler se,
                                isortaklar io,
                                isortakadresler ioadres,
                                adresler adres,
                                vw_ulkeler ulke,
                                iller il,
                                ilceler ilce,
                                isortaktelefonlar tel,
                                isortaktelefonlar fax
                           where
                                io.id(+) = se.isortakid
                                and ioadres.ISORTAKID(+) = se.isortakid
                                and ioadres.ISORTAKADRESTIPID(+) = 1
                                and adres.id(+) = ioadres.adresid

                                and ulke.dilkod(+) = 'Turkish'
                                and ulke.id(+) = adres.ulkeid
                
                                and IL.ID(+) = adres.ilid
                                and ilce.id(+) = adres.ilceid
                
                                and tel.isortakid(+)=io.id and tel.isortaktelefontipid(+)=1
                                and fax.isortakid(+)=io.id and fax.isortaktelefontipid(+)=2
                        ) servisbilgi on servisbilgi.SERVISID = servis.servisid
                /*
                left join (
                            select
                             io.id servisisortakid, tel.no telefonno, fax.no faxno
                            from
                                servisisortaklar io,
                                servisisortaktelefonlar tel,
                                servisisortaktelefonlar fax
                            where
                                tel.servisisortakid(+)=io.id and tel.servisisortaktelefontipid(+)=1
                                and fax.servisisortakid(+)=io.id and fax.servisisortaktelefontipid(+)=2
                        ) siotelfax on siotelfax.servisisortakid = isemir.servisisortakid
                */

                left join (
                    select
                        sarac.id servisaracid, sarac.saseno, aractur.kod aractur, sruhsat.plaka
                    from
                        servisaraclar sarac, araclar arac, aracturler aractur, servisvarlikruhsatlar sruhsat 
                    where
                        --esaarac.vin(+) = SARAC.SASENO
                        --and vm.esaaracid(+)=esaarac.id
                        arac.saseno(+)=sarac.saseno
                        and aractur.id(+)=arac.aracturid
                        and sruhsat.id(+)=sarac.servisvarlikruhsatid
                    ) aracbilgiler on aracbilgiler.servisaracid = isemir.servisaracid   

                --order by servis.servisid, ISEMIR.ID
            ")
            .Parameter("startDate", StartDate.startOfDay())
            .Parameter("finishDate", FinishDate.endOfDay())
            .GetDataTable()
            .ToModels();

            CloseCustomAppPool();
            return reportDataSource;
        }
    }
}