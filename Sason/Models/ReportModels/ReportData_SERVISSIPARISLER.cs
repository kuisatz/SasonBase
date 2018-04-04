using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class ReportData_SERVISSIPARISLER : SasonBase.Sason.Tables.Table_SERVISSIPARISLER.RawItem
    {
        internal decimal ID { get; set; }
        internal Decimal SERVISID { get; set; }
        public string BELGENO { get; set; }

        [ReadOnlyRelation]
        [RelationCondition("ID", "SERVISSIPARISID")]
        public List<ReportData_SERVISSIPARISMLZLER> Malzemeler { get; set; }
    }
}