using Antibiotic.Database.Field;
using Antibiotic.Database.Row;
using Antibiotic.Database.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Extensions;

namespace SasonBase.TempModels
{
    [SmartTableAttribute("F_TABLE_NAME", "TPageLoad")]
    [DbTableType(typeof(Antibiotic.Tables.Table_TStructure))]
    public class TPageLoad : ItemRawModel
    {
        public TPageLoad()
        {
            this.SF_Guid = System.Guid.NewGuid().ToString("N");
        }

        public TPageLoad(string user, string project, int serviceId) : this()
        {
            this.SF_User = user;
            this.SF_Project = project;
            this.SF_ServisId = serviceId;
            this.SF_TarihSaat = DateTime.Now.toLongDTSM();
        }

        [DbTargetField("F_GUID")] public string SF_Guid { get; set; }
        // tanju.nayir
        [DbTargetField("F_OWNER")] public string SF_User { get; set; }
        // (ssi34)
        [DbTargetField("F_OWNER_KEY")] public string SF_Project { get; set; } 
        [DbTargetField("F_NUMCODE")] public int SF_ServisId { get; set; }

        [DbTargetField("F_LONG_01")] public long SF_TarihSaat { get; set; }

        [DbTargetField("F_TEXT_01")] public string SF_Text1 { get; set; }
        [DbTargetField("F_NOTE_01")] public string SF_Note1 { get; set; }

        public static IOrderedQueryable<TPageLoad> Select { get { return R.Query<TPageLoad>(); } }

        public static TPageLoad SelectPageLoad(string user, string project, int serviceId)
        {
            DateTime dt = DateTime.Now;
            long start = dt.AddMinutes(-1).toLongDTSM();
            long finish = dt.AddMinutes(1).toLongDTSM();
            return Select.First(t => t.SF_User == user && t.SF_Project == project && t.SF_ServisId == serviceId && t.SF_TarihSaat.Between(start, finish));
        }

        public static void ClearPageLoad(string user, string project, int serviceId)
        {
            Select.Where(t => t.SF_User == user && t.SF_Project == project && t.SF_ServisId == serviceId).ToList().SetDeletable(true).Update();
        }
    }
}