using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ShortModels
{
    public class SERVISSTOKLAR_Short : SasonBase.Sason.Tables.Table_SERVISSTOKLAR.RawItem
    {
        public decimal ID { get; set; }
        public decimal BIRIMID { get; set; }
        public string KOD { get; set; }
        public decimal SERVISID { get; set; }
        public decimal? SERVISDEPOID { get; set; }
        public decimal? SERVISDEPORAFID { get; set; }


        public override string ToString()
        {
            return this.KOD;
        }


        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSTOKLAR_Short>
        {
            Dictionary<Decimal, SERVISSTOKLAR_Short> dict = new Dictionary<Decimal, SERVISSTOKLAR_Short>();
            Dictionary<string, SERVISSTOKLAR_Short> kodDict = new Dictionary<string, SERVISSTOKLAR_Short>();

            public CONTAINER() { }
            public CONTAINER(IEnumerable<SERVISSTOKLAR_Short> items) : base(items) { }


            #region Indexers
            public SERVISSTOKLAR_Short this[Decimal ID]
            {
                get { return dict.find(ID); }
            }
            #endregion

            #region Get / Gets
            public SERVISSTOKLAR_Short Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSTOKLAR_Short> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSTOKLAR_Short> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public SERVISSTOKLAR_Short Get(string KOD)
            {
                return kodDict.find(KOD.unformattedCode());
            }
            #endregion

            protected override void OnBeforeInsert(SERVISSTOKLAR_Short item, ref bool cancel)
            {
                kodDict.set(item.KOD.unformattedCode(), item);
                if (!cancel)
                    dict.set(item.ID, item, out cancel);
            }
        }

    }
}
