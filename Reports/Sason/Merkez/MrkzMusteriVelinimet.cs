using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Sason.Merkez
{
    public class MrkzMusteriVelinimet : Base.SasonMerkezReporter
    {
        public MrkzMusteriVelinimet()
        {
            Text = "Müşteri Velinimetimizdir (Liste)";
            SubjectCode = this.getType().Name;
            ReportFileCode = this.getType().Name;
            AddParameter(new ReporterParameter() { Name = "param_start_date", Text = "Başlangıç Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_finish_date", Text = "Bitiş Tarihi" }.CreateDate());
            AddParameter(new ReporterParameter() { Name = "param_servisler", Text = "Servisler" }.CreateServislerSelect(true));
            AddParameter(new ReporterParameter() { Name = "param_isemir_hizmetyerleri", Text = "Hizmet Yeri" }.CreateIsEmirHizmetYeri(true));
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
                case "param_servisler":
                    ServisIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
                case "param_isemir_hizmetyerleri":
                    HizmetYeriIds = value.toString().split(',').select(t => Convert.ToDecimal(t)).toList();
                    break;
            }
            return base.SetParameterIncomingValue(parameterName, value);
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            string servisIdQuery = "";
            decimal selectedServisId = ServisIds.first().toString("0").cto<decimal>();
            if (ServisIds.isNotEmpty())
                servisIdQuery = $" in ({ServisIds.joinNumeric(",")}) ";
            else
            {
                //    servisIdQuery = $" > 1 ";
                selectedServisId = ServisId;
                servisIdQuery = $" in( {selectedServisId} )";  
            }

            string hizmetYeriIdQuery = "";
            if (HizmetYeriIds.isNotEmpty())
                hizmetYeriIdQuery = $" and HIZMETYERID in ({HizmetYeriIds.joinNumeric(",")}) ";

            List<object> reportDataSource = AppPool.EbaTestConnector.CreateQuery($@"
                                SELECT DISTINCT
                                    servis.servisid, isemir.id isemirid, isortak.servisisortakid,  
                                    TRUNC(isemir.kayittarih) tarih,
                                    servis.partnercode serviscode, servis.isortakad servisadi, servis.varlikad servisvarlikadi,
                                    servisbilgi.adres servisadres, servisbilgi.ulke_ad servisadres_ulke, servisbilgi.il_ad servisadres_il, servisbilgi.ilce_ad servisadres_ilce, 
                                    isemir.isemirno isemirno,
                                    osuser.firstname userfirstname, osuser.lastname userlastname,
                                    isortak.vergino,                    
                                    isortak.ad musteri_ad, isortak.servisvarlikad musteri_varlikad, isortak.varliktipad musteri_varliktipi, isortak.vergidairead musteri_vergidairesi, isortak.vergino musteri_vergino, isortak.vergidaireilad musteri_vergidairesi_il,
                                    CASE WHEN isortak.filobuyuklukid IS NULL THEN 1 ELSE 0 END musteri_filobuyukluk,
                                --siotelfax.TELEFONNO MUSTERI_TELEFON,
                                    isemir.musteriad musteri_kisi_ad, isemir.musteritelefon musteri_kisi_telefon,
                                --KONTAK.EPOSTA KONTAK_EPOSTA, KONTAK.EPOSTAIZIN KONTAK_IZIN_EPOSTA, KONTAK.ARAMAIZIN KONTAK_IZIN_TELEFONARAMA, KONTAK.SMSIZIN KONTAK_IZIN_SMS,
                                --KONTAK.SERVISISORTAKKONTAKTIPAD KONTAK_TIP, 
                                --KONTAK.NO KONTAK_TELEFON, 
                                --kontak.AD KONTAK_AD,                
                                    kontakfirmasahibi.ad kontakfirmasahibi, 
                                    kontakfirmasahibi.no kontakfirmasahibi_tel,
                                    kontaksatisyetkilisi.ad kontaksatisyetkilisi, 
                                    kontaksatisyetkilisi.no kontaksatisyetkilisi_tel,
                                    kontakgenelmudur.ad kontakgenelmudur, 
                                    kontakgenelmudur.no kontakgenelmudur_tel,
                                    kontaksatissorumlusu.ad kontaksatissorumlusu, 
                                    kontaksatissorumlusu.no kontaksatissorumlusu_tel,
                                    kontakservismuduru.ad kontakservismuduru, 
                                    kontakservismuduru.no kontakservismuduru_tel,
                                    kontakfilo.ad kontakfiloyon, 
                                    kontakfilo.no kontakfiloyon_tel,  
                                    kontaksatinalma.ad  kontaksatinalma, 
                                    kontaksatinalma.no   kontaksatinalma_tel,
                                    kontaksatismuduru.ad kontaksatismuduru, 
                                    kontaksatismuduru.no kontaksatismuduru_tel,
                                    kontakgenelmuduryrd.ad kontakgenelmuduryrd, 
                                    kontakgenelmuduryrd.no kontakgenelmuduryrd_tel,
                                    kontakbolgemuduru.ad kontakbolgemuduru, 
                                    kontakbolgemuduru.no kontakbolgemuduru_tel,
                                    kontakbassofor.ad kontakbassofor, 
                                    kontakbassofor.no kontakbassofor_tel,  
                                    kontakdiger.ad  kontakdiger, 
                                    kontakdiger.no  kontakdiger_tel,                    
                    
                                    aracbilgiler.saseno arac_saseno, aracbilgiler.aractur arac_tur, aracbilgiler.plaka arac_plaka,
                                    (CASE
                                        WHEN aracbilgiler.manolmayan = 0
                                            THEN ''
                                        WHEN aracbilgiler.manolmayan = 1
                                            THEN 'MAN OLMAYAN'
                                    END) AS manolmayan,
                                    (SELECT 
                                        CASE bx.isemirtipid  
                                            WHEN 1 then 'Evet' 
                                            WHEN 5 then 'Evet' 
                                            ELSE 'Hayır' end    
                                        FROM servisisemirler ax                  
                                        LEFT JOIN servisisemirislemler bx ON bx.isemirtipid IN (1,5) AND bx.servisisemirid = ax.id  
                                        WHERE ax.isemirno = ISEMIR.ISEMIRNO AND ROWNUM <2 ) AS bakimmi   
                                        FROM (SELECT * FROM servisisemirler WHERE TRUNC(kayittarih)  BETWEEN {{startDate}} AND {{finishDate}} AND servisid {servisIdQuery} {hizmetYeriIdQuery} ) isemir
                                        LEFT JOIN vt_servisler servis ON servis.dilkod = 'Turkish' AND servis.servisid = isemir.servisid
                                        --left join servisisemirler isemir on trunc(ISEMIR.KAYITTARIH) = tarihler.tarih and isemir.servisid = servis.servisid
                                        LEFT JOIN osusers osuser ON osuser.id = isemir.kullaniciid
                        
                                        LEFT JOIN sason.vw_isortakkontakbilgiler kontakfirmasahibi ON kontakfirmasahibi.servisisortakid = isemir.servisisortakid AND  kontakfirmasahibi.servisisortakkontaktipid = 1
                                        LEFT JOIN sason.vw_isortakkontakbilgiler kontaksatisyetkilisi ON kontaksatisyetkilisi.servisisortakid = isemir.servisisortakid AND  kontaksatisyetkilisi.servisisortakkontaktipid = 2
                                        LEFT JOIN sason.vw_isortakkontakbilgiler kontakgenelmudur ON kontakgenelmudur.servisisortakid = isemir.servisisortakid AND  kontakgenelmudur.servisisortakkontaktipid = 3
                                        LEFT JOIN sason.vw_isortakkontakbilgiler kontaksatissorumlusu ON kontaksatissorumlusu.servisisortakid = isemir.servisisortakid AND  kontaksatissorumlusu.servisisortakkontaktipid = 4
                                        LEFT JOIN sason.vw_isortakkontakbilgiler kontakservismuduru ON kontakservismuduru.servisisortakid = isemir.servisisortakid AND  kontakservismuduru.servisisortakkontaktipid = 5
                                        LEFT JOIN sason.vw_isortakkontakbilgiler kontakfilo ON kontakfilo.servisisortakid = isemir.servisisortakid AND  kontakfilo.servisisortakkontaktipid = 6
                                        LEFT JOIN sason.vw_isortakkontakbilgiler kontaksatinalma ON kontaksatinalma.servisisortakid = isemir.servisisortakid AND  kontaksatinalma.servisisortakkontaktipid = 7
                                        LEFT JOIN sason.vw_isortakkontakbilgiler kontaksatismuduru ON kontaksatismuduru.servisisortakid = isemir.servisisortakid AND  kontaksatismuduru.servisisortakkontaktipid = 8
                                        LEFT JOIN sason.vw_isortakkontakbilgiler kontakgenelmuduryrd ON kontakgenelmuduryrd.servisisortakid = isemir.servisisortakid AND  kontakgenelmuduryrd.servisisortakkontaktipid = 9
                                        LEFT JOIN sason.vw_isortakkontakbilgiler kontakbolgemuduru ON kontakbolgemuduru.servisisortakid = isemir.servisisortakid AND  kontakbolgemuduru.servisisortakkontaktipid = 10
                                        LEFT JOIN sason.vw_isortakkontakbilgiler kontakbassofor ON kontakbassofor.servisisortakid = isemir.servisisortakid AND  kontakbassofor.servisisortakkontaktipid = 11
                                        LEFT JOIN sason.vw_isortakkontakbilgiler kontakdiger ON kontakdiger.servisisortakid = isemir.servisisortakid AND  kontakdiger.servisisortakkontaktipid = 12
                        
                                        LEFT JOIN vt_servisisortaklar isortak ON isortak.dilkod = 'Turkish' AND ISORTAK.servisisortakid = isemir.servisisortakid

                                        -- SERVIS BILGILERI (adres, telefon, fax)
                                        LEFT JOIN(
                                            SELECT se.id servisid, io.id isortakid, io.ad isortakad, 
                                                   adres.adres, ulke.ad ulke_ad, il.ad il_ad, ilce.ad ilce_ad, tel.no telefon, fax.no fax
                                            FROM servisler se,
                                                isortaklar io,
                                                isortakadresler ioadres,
                                                adresler adres,
                                                vw_ulkeler ulke,
                                                iller il,
                                                ilceler ilce,
                                                isortaktelefonlar tel,
                                                isortaktelefonlar fax
                                            WHERE io.id(+) = se.isortakid
                                                AND ioadres.ISORTAKID(+) = se.isortakid
                                                AND ioadres.ISORTAKADRESTIPID(+) = 1
                                                AND adres.id(+) = ioadres.adresid
                                                AND ulke.dilkod(+) = 'Turkish'
                                                AND ulke.id(+) = adres.ulkeid             
                                                AND il.id(+) = adres.ilid
                                                AND ilce.id(+) = adres.ilceid                
                                                AND tel.isortakid(+)=io.id AND tel.isortaktelefontipid(+)=1
                                                AND fax.isortakid(+)=io.id AND fax.isortaktelefontipid(+)=2
                                        ) servisbilgi ON servisbilgi.SERVISID = servis.servisid
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
                                        LEFT JOIN(
                                            SELECT sarac.id servisaracid, sarac.saseno, aractur.kod aractur, sruhsat.plaka, sarac.manolmayan manolmayan
                                            FROM servisaraclar sarac, 
                                                araclar arac, 
                                                aracturler aractur, 
                                                servisvarlikruhsatlar sruhsat 
                                            WHERE
                                                --esaarac.vin(+) = SARAC.SASENO
                                                --and vm.esaaracid(+)=esaarac.id
                                                arac.saseno(+)=sarac.saseno
                                                AND aractur.id(+)=arac.aracturid
                                                AND sruhsat.id(+)=sarac.servisvarlikruhsatid
                                        ) aracbilgiler on aracbilgiler.servisaracid = isemir.servisaracid   
                                        --WHERE kontak.servisisortakkontaktipad IN( 'BASSOFOR', 'FILOYONETICISI')  
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