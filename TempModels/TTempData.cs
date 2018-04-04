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
    [SmartTableAttribute("F_TABLE_NAME", "TTempData")]
    [DbTableType(typeof(Antibiotic.Tables.Table_TStructure))]
    public class TTempData : ItemRawModel
    {
        public TTempData()
        {
            this.SF_Guid = System.Guid.NewGuid().ToString("N");
            this.SF_TarihSaat = DateTime.Now.toLongDTSM();
        }

        public TTempData(string user, string project, int serviceId) : this()
        {
            this.SF_Key1 = user;
            this.SF_Key2 = project;
            this.SF_NumKey = serviceId;
        }

        [DbTargetField("F_GUID")] public string SF_Guid { get; set; }
        
        // tanju.nayir
        [DbTargetField("F_OWNER")] public string SF_Key1 { get; set; }

        // ssi34
        [DbTargetField("F_OWNER_KEY")] public string SF_Key2 { get; set; }

        //
        [DbTargetField("F_CODE")] public int SF_Key3 { get; set; }

        // 5
        [DbTargetField("F_NUMCODE")] public int SF_NumKey { get; set; }

        // 2017 06 03 22 52 59 999
        [DbTargetField("F_LONG_01")] public long SF_TarihSaat { get; set; }

        [DbTargetField("F_TEXT_01")] public string SF_Text1 { get; set; }
        [DbTargetField("F_TEXT_02")] public string SF_Text2 { get; set; }
        //[DbTargetField("F_TEXT_03")] public string SF_Text3 { get; set; }

        [DbTargetField("F_INT_01")] public int SF_Int1 { get; set; }
        [DbTargetField("F_INT_02")] public int SF_Int2 { get; set; }
        //[DbTargetField("F_INT_03")] public int SF_Int3 { get; set; }

        [DbTargetField("F_LONG_01")] public int SF_Long1 { get; set; }
        [DbTargetField("F_LONG_02")] public int SF_Long2 { get; set; }
        //[DbTargetField("F_LONG_03")] public int SF_Long3 { get; set; }

        [DbTargetField("F_NOTE_01")] public string SF_Note1 { get; set; }
        [DbTargetField("F_NOTE_02")] public string SF_Note2 { get; set; }

        [DbTargetField("F_BINARY_01")] public byte[] SF_Bin1 { get; set; }

        public static IOrderedQueryable<TPageLoad> Select { get { return R.Query<TPageLoad>(); } }

        //public static TPageLoad SelectTempData(string key1)
        //{

        //}

        //public static TPageLoad SelectTempData(string key1, string key2)
        //{

        //}

        //public static TPageLoad SelectTempData(string key1, string key2, string key3)
        //{
        //    return null;
        //}

        //public static TPageLoad SelectTempData(string key1, string key2, string key3, int numKey)
        //{
        //    DateTime dt = DateTime.Now;
        //    long start = dt.AddMinutes(-1).toLongDTSM();
        //    long finish = dt.AddMinutes(1).toLongDTSM();
        //    return Select.First(t => t.SF_User == user && t.SF_Project == project && t.SF_ServisId == serviceId && t.SF_TarihSaat.Between(start, finish));
        //}

        //public static TPageLoad SelectTempData(string key1, string key2, string key3, int numKey, DateTime start, DateTime finish)
        //{

        //}


        //public static void ClearTempDatas(string key1, string key2, string key3, int serviceId)
        //{
        //    Select.Where(t => t.SF_User == key1 && t.SF_Project == key2 && t.SF_ServisId == serviceId).ToList().Deletable(true).Update();
        //}
    }
}
