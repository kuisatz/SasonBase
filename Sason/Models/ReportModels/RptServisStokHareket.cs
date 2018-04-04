using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptServisStokHareket01 : SasonBase.Sason.Tables.Table_SERVISSTOKHAREKETLER.RawItem
    {
        protected virtual Decimal ID { get; set; }
        //protected virtual Decimal SERVISSTOKISLEMID { get; set; }
        //protected virtual DateTime TARIH { get; set; }
        //protected virtual String BLGNO { get; set; }
        //protected virtual DateTime BLGTARIH { get; set; }
        //protected virtual Decimal PARABIRIMID { get; set; }
        //protected virtual String ACIKLAMA { get; set; }
        //protected virtual Decimal SERVISVARLIKID { get; set; }
        //protected virtual Decimal SERVISDEPOID { get; set; }
        //protected virtual Decimal SERVISDEPORAFID { get; set; }
        //protected virtual Decimal DURUMID { get; set; }
        //protected virtual Decimal SERVISID { get; set; }
        [DbTargetField("IRSALIYENO")] public String IrsaliyeNo { get; set; }
        //protected virtual String SERVISGARANTINO { get; set; }
        //protected virtual Decimal SERVISSIPARISID { get; set; }
        //protected virtual Decimal IRSALIYEONAY { get; set; }
        protected virtual Decimal FATURAID { get; set; }
    }
}