using Antibiotic.Extensions;
using SasonBase.Reports.Models;
using SasonBase.Sason.Models.PdksModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports.Teknisyen
{
    public class AktifTeknisyenDurumReporter : Base.TeknisyenReporter
    {
        public AktifTeknisyenDurumReporter()
        {
            Text           = "Teknisyen Son Durumları";
            SubjectCode    = "TEKNISYEN_PUANTAJ_02";
            ReportFileCode = "TeknisyenDurum";
        }

        public AktifTeknisyenDurumReporter(decimal servisId) : this()
        {
            base.ServisId = servisId;
        }

        private class TModel01
        {
            public decimal TEKNISYENID          {get;set;}
            public decimal SONHAREKETID         {get;set;}
            public decimal USTBILGIID           {get;set;}
            public decimal ISEMIRID             {get;set;}
            public decimal ISEMIRISLEMID        {get;set;}
            public decimal ISEMIRISLEMISCILIKID { get; set; }
        }

        public override object ExecuteReport(MethodReturn refMr = null)
        {
            List<ReportData> reportDataSource = new List<ReportData>();

            HareketNedenContainer       nedenContainer                                 = new HareketNedenContainer(R.Query<HareketNeden>(refMr).ToList());
            List<HareketNeden>          nedenler                                       = nedenContainer.ToList();
            ServisTeknisyenContainer    servisTeknisyenContainer                       = new ServisTeknisyenContainer(R.Query<ServisTeknisyen>(refMr).Where(t => t.SERVISID == ServisId).ToList());
            List<ServisGunMola>         gunMolalar                                     = ServisGunMola.SelectServisGunMolalar(ServisId, refMr);
            List<RptIsEmir>             isEmirler                                      = null;

            List<HareketUstBilgi> hareketUstBilgiler = null;

            TeknisyenHareketContainer<RptTeknisyenHareket> teknisyenHareketContainer  = null;

            List<TModel01> sonHareketler = AppPool.EbaTestConnector.CreateQuery(@"
                    select
                        stek.id servisteknisyenid,thrk.sonhareketid, UB.ID USTBILGIID, UB.ISEMIRID, UB.ISEMIRISLEMID, UB.ISEMIRISLEMISCILIKID
                    from (select id, teknisyenid from servisteknisyenler where servisid = {servisId}) stek
                    left join (
                        select
                            servisteknisyenid,
                            max(id) sonHareketId
                        from
                            tteknisyenhrk
                        group by servisteknisyenid
                    ) thrk on THRK.SERVISTEKNISYENID = stek.id
                    left join tteknisyenhrk hrk2 on hrk2.id = thrk.sonhareketid
                    left join thrkustbilgi ub on ub.id = HRK2.THRKUSTBILGIID
                ")
                .Parameter("servisId", ServisId)
                .GetDataTable(refMr).ToModels<TModel01>();
                //.Select(t => new {
                //        TEKNISYENID = t.ColumnValue<decimal>("SERVISTEKNISYENID"),
                //        SONHAREKETID = t.ColumnValue<decimal>("SONHAREKETID"),
                //        USTBILGIID = t.ColumnValue<decimal>("USTBILGIID"),
                //        ISEMIRID = t.ColumnValue<decimal>("ISEMIRID"),
                //        ISEMIRISLEMID = t.ColumnValue<decimal>("ISEMIRISLEMID"),
                //        ISEMIRISLEMISCILIKID = t.ColumnValue<decimal>("ISEMIRISLEMISCILIKID")
                //});

            if (sonHareketler.isNotEmpty())
            {
                teknisyenHareketContainer = new TeknisyenHareketContainer<RptTeknisyenHareket>(R.Query<RptTeknisyenHareket>(refMr).Where(h => h.ID.In(sonHareketler.select(sh => sh.SONHAREKETID))).ToList());
                isEmirler                 = R.Query<RptIsEmir>(refMr).Where(t => t.ID.In(sonHareketler.select(sh=> sh.ISEMIRID))).ToList();
                hareketUstBilgiler        = R.Query<HareketUstBilgi>(refMr).Where(t => t.ID.In(sonHareketler.select(sh=> sh.USTBILGIID))).ToList();
            }

            PuantajGunlugu pg = new PuantajGunlugu();
            servisTeknisyenContainer.forEach(st =>
            {
                teknisyenHareketContainer.GetTeknisyenHareketler(st.ID).forEach(hr =>
                {
                    HareketUstBilgi ustBilgi = hareketUstBilgiler.first(t => t.ID == hr.THRKUSTBILGIID);

                    ReportData reportData = new ReportData()
                    {
                        Teknisyen = st,
                        Hareket = hr,
                        IsEmir = isEmirler.first(t => t.ID == ustBilgi?.ISEMIRID),
                    };

                    reportData.IsEmirIslem = reportData.IsEmir?.Islemler.first(t => t.ID == ustBilgi?.ISEMIRISLEMID);
                    reportData.IsEmirIslemIscilik = reportData.IsEmirIslem?.Iscilikler.first(t => t.ID == ustBilgi?.ISEMIRISLEMISCILIKID);

                    hr.GirisNeden = nedenContainer[hr.GIRISNEDENID];
                    hr.CikisNeden = nedenContainer[hr.CIKISNEDENID];

                    hr.PSonuc = Puantaj.GetPuantajSonuclari(hr.MakeList(), pg, gunMolalar, nedenler);
                    hr.Calisma = hr.PSonuc.GetSonucSure(NedenFormati.NormalCalisma);

                    reportDataSource.add(reportData);
                });
            });

            CloseCustomAppPool();
            return reportDataSource;
        }

        public class ReportData
        {
            public ServisTeknisyen          Teknisyen { get; set; }
            public RptTeknisyenHareket      Hareket { get; set; }
            public RptIsEmir                IsEmir { get; set; }
            public RptIsEmirIslem           IsEmirIslem { get; set; }
            public RptIsEmirIslemIscilik    IsEmirIslemIscilik { get; set; }
        }

    }
}