using Antibiotic.Database.Field;
using Antibiotic.Database.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Extensions;
using Antibiotic.Database.Row;

namespace SasonBase.Sason.Models.PdksModels
{
    /*
            Id           = 1
            ServisId     = 102
            HaftaninGunu = 1 (Pazartesi)
     */

    [SmartTable("FTABLE", "PDKS_SERVIS_GUN_MOLALARI")]
    public partial class ServisGunMola : Base.BaseServisDef
    {
        [DbTargetField("FKEY2")] public DayOfWeek HaftaninGunu { get; set; }
        [DbTargetField("FTEXT1")] public string CalismaSaatleriString { get; set; }
        [DbTargetField("FTEXT2")] public string MolaSaatleriString { get; set; }
        [DbTargetField("FNOTE1")] public List<Mola> Molalar { get; set; } = new List<Mola>();

        public int BaslangicSaati { get; set; }
        public int BitisSaati { get; set; }

        public ServisGunMola()
        {
        }

        public ServisGunMola(decimal servisId) : base(servisId)
        {
        }

        protected override void Initialized(ItemRawModel ownerItem)
        {
            BaslangicSaati = CalismaSaatleriString.split('-').value(0).trim().toDbTimeInt();
            BitisSaati = CalismaSaatleriString.split('-').value(1).trim().toDbTimeInt();

            Molalar = new List<Mola>();
            MolaSaatleriString.split().forEach(bt =>
            {
                Mola mola = new Mola();
                mola.Baslangic = bt.split('-').value(0).trim().toDbTimeInt();
                mola.Bitis = bt.split('-').value(1).trim().toDbTimeInt();
                Molalar.add(mola);
            });
        }
    }

    public partial class ServisGunMola
    {
        public static List<ServisGunMola> SelectServisGunMolalar(Decimal servisId, MethodReturn mr = null)
        {
            return R.Query<ServisGunMola>(mr).Where(t => t.ServisId == servisId).ToList();
        }

        public static ServisGunMola SelectServisGunMola(Decimal servisId, DayOfWeek haftaninGunu, MethodReturn mr = null)
        {
            return R.Query<ServisGunMola>(mr).First(t => t.ServisId == servisId && t.HaftaninGunu == haftaninGunu);
        }
    }

    public class Mola
    {
        public int Baslangic { get; set; }
        public int Bitis { get; set; }

        public string BaslangicStr
        {
            get
            {
                return Baslangic.toTimeString();
            }
        }

        public string BitisStr
        {
            get
            {
                return Bitis.toTimeString();
            }
        }


        public Mola()
        {

        }

        public Mola(int baslangic, int bitis)
        {
            Baslangic = baslangic;
            Bitis = bitis;
        }
    }

    

    
}