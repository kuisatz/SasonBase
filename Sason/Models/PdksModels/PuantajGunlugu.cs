using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Extensions;

namespace SasonBase.Sason.Models.PdksModels
{
    public class PuantajGunlugu
    {
        public PuantajGunlugu()
        {
            //NormalGirisSaatiStr = "08:30";
            //NormalCikisSaatiStr = "18:00";

            //Dagilim = new List<PuantajGunluguDagilim>();
            //Dagilim.Add(new PuantajGunluguDagilim() { BaslangicSaatiStr = "08:30", BitisSaatiStr = "12:00", NedenKodu = "NÇ" });
            //Dagilim.Add(new PuantajGunluguDagilim() { BaslangicSaatiStr = "12:00", BitisSaatiStr = "13:00", NedenKodu = "AD" });
            //Dagilim.Add(new PuantajGunluguDagilim() { BaslangicSaatiStr = "13:00", BitisSaatiStr = "18:00", NedenKodu = "NÇ" });

            MolalardanDagilimOlustur(null);
        }

        public PuantajGunlugu(ServisGunMola servisGunMola)
        {
            MolalardanDagilimOlustur(servisGunMola);
        }

        public void MolalardanDagilimOlustur(ServisGunMola servisGunMola)
        {
            if (servisGunMola != null)
            {
                this.NormalGirisSaati = servisGunMola.BaslangicSaati;
                this.NormalCikisSaati = servisGunMola.BitisSaati;
            }

            Dagilim = new List<PuantajGunluguDagilim>();

            servisGunMola?.Molalar.forEach(mola => Dagilim.add(new PuantajGunluguDagilim() { BaslangicSaati = mola.Baslangic, BitisSaati = mola.Bitis, NedenKodu = "AD" }));

            Dagilim = Dagilim.orderBy(t => t.BaslangicSaati).toList();

            List<PuantajGunluguDagilim> customDagilimlar = new List<PuantajGunluguDagilim>();

            int firstStart = 0;
            int lastFinish = 1440;

            int count = 0;
            Dagilim.forEach(dag =>
            {
                count++;

                int fark = 0;
                int intersectStart = 0;
                int intersectFinish = 0;

                if (Antibiotic.Helpers.IntegerHelpers.IsIntersect(firstStart, lastFinish, dag.BaslangicSaati, dag.BitisSaati, out fark, out intersectStart, out intersectFinish))
                {
                    PuantajGunluguDagilim dagItem = new PuantajGunluguDagilim(firstStart, intersectStart) { NedenKodu = "NÇ" };
                    if (fark.isInRange(30, 90))
                        dag.NedenKodu = "YM";

                    customDagilimlar.add(dagItem);
                }
                firstStart = dag.BitisSaati;

                if (count == Dagilim.Count)
                {
                    if (dag.BitisSaati < 1440)
                        customDagilimlar.add(new PuantajGunluguDagilim(firstStart, lastFinish) { NedenKodu = "NÇ" });
                }
            });

            if (Dagilim.Count == 0)
                customDagilimlar.add(new PuantajGunluguDagilim(firstStart, lastFinish) { NedenKodu = "NÇ" });

            Dagilim.addRange(customDagilimlar);
            Dagilim = Dagilim.orderBy(t => t.BaslangicSaati).toList();


            //NormalGirisSaati
        }



        public int NormalGirisSaati { get; set; }
        public int NormalCikisSaati { get; set; }

        public string NormalGirisSaatiStr
        {
            get { return NormalGirisSaati.toTimeString(); }
            set { NormalGirisSaati = value.toDbTimeInt(); }
        }

        public string NormalCikisSaatiStr
        {
            get { return NormalCikisSaati.toTimeString(); }
            set { NormalCikisSaati = value.toDbTimeInt(); }
        }

        public void InitNedenler(List<HareketNeden> nedenler)
        {
            Dagilim.forEach(dag =>
            {
                dag.Neden = nedenler.first(t => t.KOD == dag.NedenKodu);
            });
        }

        public List<PuantajGunluguDagilim> Dagilim { get; set; }
    }

    public class PuantajGunluguDagilim
    {
        public int BaslangicSaati { get; set; }
        public int BitisSaati { get; set; }
        public string NedenKodu { get; set; }

        public string BaslangicSaatiStr {
            get
            {
                return BaslangicSaati.toTimeString();
            }
            set
            {
                BaslangicSaati = value.toDbTimeInt();
            }
        }

        public string BitisSaatiStr
        {
            get
            {
                return BitisSaati.toTimeString();
            }
            set
            {
                BitisSaati = value.toDbTimeInt();
            }
        }

        public HareketNeden Neden { get; set; }


        public PuantajGunluguDagilim()
        {

        }

        public PuantajGunluguDagilim(int baslangic, int bitis)
        {
            this.BaslangicSaati = baslangic;
            this.BitisSaati = bitis;
        }

        public PuantajGunluguDagilim(int baslangic, int bitis, string nedenKodu) : this(baslangic, bitis)
        {
            this.NedenKodu = nedenKodu;
        }

        public override string ToString()
        {
            return $"Neden : {NedenKodu} [{BaslangicSaatiStr} - {BitisSaatiStr}]";
        }
    }
}