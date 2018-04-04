using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Database.Row;

namespace SasonBase.Sason.Models.TableModels
{
    [Serializable()]
    public class SERVISSTOKLAR : Tables.Table_SERVISSTOKLAR.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSTOKLAR>
        {
            Dictionary<Decimal, SERVISSTOKLAR> dict = new Dictionary<Decimal, SERVISSTOKLAR>();
            Dictionary<string, SERVISSTOKLAR> kodDict = new Dictionary<string, SERVISSTOKLAR>();

            public CONTAINER() { }
            public CONTAINER(IEnumerable<SERVISSTOKLAR> items) : base(items) { }


            #region Indexers
            public SERVISSTOKLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSTOKLAR this[string KOD]
            {
                get { return kodDict.find(KOD); }
            }
            #endregion

            #region Get / Gets
            public SERVISSTOKLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSTOKLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSTOKLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public SERVISSTOKLAR Get(string KOD)
            {
                return kodDict.find(KOD.unformattedCode());
            }

            //public List<SERVISSTOKLAR> Gets(params string[] KODs)
            //{
            //    return kodDict.findToList(KODs);
            //}

            //public List<SERVISSTOKLAR> Gets(IEnumerable<string> KODs)
            //{
            //    return kodDict.findToList(KODs);
            //}
            #endregion

            protected override void OnBeforeInsert(SERVISSTOKLAR item, ref bool cancel)
            {
                kodDict.set(item.KOD.unformattedCode(), item);
                if (!cancel)
                    dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSTOKLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSTOKLAR> Select
        {
            get { return R.Query<SERVISSTOKLAR>(); }
        }

        public static SERVISSTOKLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISSTOKLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISSTOKLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSTOKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSTOKLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSTOKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }


        public static SERVISSTOKLAR SelectItemFromKod(decimal servisId, string malzemeKod)
        {
            return Select.First(t => t.SERVISID == servisId && t.KOD == malzemeKod);
        }

        public static List<SERVISSTOKLAR> SelectItemsFromCodes(decimal servisId, IEnumerable<string> malzemeKods)
        {
            return Select.Where(t => t.SERVISID == servisId && t.KOD.In(malzemeKods)).ToList();
        }

        public static List<SERVISSTOKLAR> SelectItemsFromCodes(decimal servisId, params string[] malzemeKods)
        {
            return Select.Where(t => t.SERVISID == servisId && t.KOD.In(malzemeKods)).ToList();
        }
    }
}