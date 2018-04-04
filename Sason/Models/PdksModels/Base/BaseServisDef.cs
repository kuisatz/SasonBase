using Antibiotic.Database.Field;
using Antibiotic.Database.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.PdksModels.Base
{
    
    public abstract class BaseServisDef : SasonBase.Sason.Tables.Table_TSERVISDEF.RawItem
    {
        /// <summary>
        /// ID
        /// </summary>
        [DbTargetField("ID")] public Decimal Id { get; private set; }
        /// <summary>
        /// FKEY1
        /// </summary>
        [DbTargetField("FKEY1")] public Decimal ServisId { get; set; }

        public BaseServisDef()
        {

        }

        public BaseServisDef(Decimal servisId)
        {
            this.ServisId = servisId;
        }
    }
}
